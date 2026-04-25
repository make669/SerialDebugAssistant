using System.ComponentModel;
using System.IO.Ports;
using Models;
using Properties;
using Services;
using Services.Interfaces;
using Utils;

namespace SerialDebugAssistant
{
    public partial class MainForm : Form
    {
        private readonly ISerialService _serialService;
        private readonly ILogService _logService;
        private readonly IConfigService _configService;
        private readonly BindingList<LogGridItem> _uiLogs = new();

        private AppSettings _currentSettings = AppSettings.CreateDefault();
        private long _rxBytes;
        private long _txBytes;
        private int _errorCount;

        public MainForm()
        {
            InitializeComponent();

            _serialService = new SerialService();
            _logService = new LogService();
            _configService = new ConfigService();

            _serialService.DataReceived += serialService_DataReceived;
            _serialService.DataSent += serialService_DataSent;

            InitializeViewData();
            _ = LoadConfigAsync();
        }

        private void InitializeViewData()
        {
            cmbBaudRate.Items.AddRange(new object[] { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" });
            cmbDataBits.Items.AddRange(new object[] { "5", "6", "7", "8" });
            cmbParity.Items.AddRange(Enum.GetNames<Parity>());
            cmbStopBits.Items.AddRange(Enum.GetNames<StopBits>().Where(n => n != nameof(StopBits.None)).ToArray());
            cmbHandshake.Items.AddRange(Enum.GetNames<Handshake>());
            cmbEncoding.Items.AddRange(new object[] { "UTF-8", "GBK", "GB2312", "ASCII", "Unicode" });

            dgvRealtimeLog.AutoGenerateColumns = true;
            dgvRealtimeLog.DataSource = _uiLogs;
            dgvLogCenter.AutoGenerateColumns = true;
            dgvLogCenter.DataSource = _uiLogs;

            ShowPanel(ucRealtimePanel);
            RefreshPorts();
            UpdateStatus("界面初始化完成。");
        }

        private async Task LoadConfigAsync()
        {
            var result = _configService.LoadOrCreateDefault();
            if (!result.IsSuccess || result.Data is not AppSettings settings)
            {
                IncreaseError(result.Message);
                return;
            }

            _currentSettings = settings;
            ApplySettingsToControls(settings);
            UpdateStatus("配置加载完成。");
            await Task.CompletedTask;
        }

        private void ApplySettingsToControls(AppSettings settings)
        {
            var config = settings.DefaultSerialPortConfig;

            SelectComboValue(cmbPortName, config.PortName);
            SelectComboValue(cmbBaudRate, config.BaudRate.ToString());
            SelectComboValue(cmbParity, config.Parity.ToString());
            SelectComboValue(cmbDataBits, config.DataBits.ToString());
            SelectComboValue(cmbStopBits, config.StopBits.ToString());
            SelectComboValue(cmbHandshake, config.Handshake.ToString());
            SelectComboValue(cmbEncoding, config.EncodingName);

            tsslLogPath.Text = settings.LogFilePath;
            tsslEncoding.Text = settings.DefaultEncodingName;
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (_serialService.IsOpen)
            {
                var closeResult = _serialService.Close();
                if (!closeResult.IsSuccess)
                {
                    IncreaseError(closeResult.Message);
                    return;
                }

                UpdateConnectionState(false);
                UpdateStatus("串口已关闭。");
                return;
            }

            var openResult = _serialService.Open(BuildSerialConfigFromControls());
            if (!openResult.IsSuccess)
            {
                IncreaseError(openResult.Message);
                return;
            }

            UpdateConnectionState(true);
            UpdateStatus("串口已打开。");
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            var result = _configService.LoadOrCreateDefault();
            if (!result.IsSuccess || result.Data is not AppSettings settings)
            {
                IncreaseError(result.Message);
                return;
            }

            _currentSettings = settings;
            ApplySettingsToControls(settings);
            UpdateStatus("配置已加载。");
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            _currentSettings.DefaultSerialPortConfig = BuildSerialConfigFromControls();
            _currentSettings.DefaultEncodingName = cmbEncoding.Text;

            var result = _configService.Save(_currentSettings);
            if (!result.IsSuccess)
            {
                IncreaseError(result.Message);
                return;
            }

            UpdateStatus("配置保存成功。");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSend.Text))
            {
                IncreaseError("发送内容不能为空。");
                return;
            }

            OperationResult result;
            if (chkSendHex.Checked)
            {
                if (!HexConverter.TryToByteArray(txtSend.Text, out var bytes))
                {
                    IncreaseError("HEX 内容格式错误。");
                    return;
                }

                result = _serialService.SendBytes(bytes);
            }
            else
            {
                result = _serialService.SendText(txtSend.Text, cmbEncoding.Text);
            }

            if (!result.IsSuccess)
            {
                IncreaseError(result.Message);
                return;
            }

            UpdateStatus("发送成功。");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            _uiLogs.Clear();
            UpdateStatus("日志显示已清空（不影响文件）。");
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "Log Files|*.log|Text Files|*.txt|All Files|*.*",
                FileName = $"serial_{DateTime.Now:yyyyMMdd_HHmmss}.log"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                var sourcePath = _currentSettings.LogFilePath;
                var content = FileHelper.ReadAllText(sourcePath);
                FileHelper.WriteAllText(dialog.FileName, content);
                UpdateStatus($"日志已导出: {dialog.FileName}");
            }
            catch (Exception ex)
            {
                IncreaseError($"导出日志失败: {ex.Message}");
            }
        }

        private async void serialService_DataReceived(object? sender, LogEntry entry)
        {
            await HandleLogEntryAsync(entry, true);
        }

        private async void serialService_DataSent(object? sender, LogEntry entry)
        {
            await HandleLogEntryAsync(entry, false);
        }

        private async Task HandleLogEntryAsync(LogEntry entry, bool isReceived)
        {
            await _logService.AppendAsync(entry, _currentSettings.LogFilePath, _currentSettings.DefaultEncodingName);

            if (isReceived)
            {
                Interlocked.Add(ref _rxBytes, entry.RawData.Length);
            }
            else
            {
                Interlocked.Add(ref _txBytes, entry.RawData.Length);
            }

            if (InvokeRequired)
            {
                BeginInvoke(() => AppendUiLog(entry));
                return;
            }

            AppendUiLog(entry);
        }

        private void AppendUiLog(LogEntry entry)
        {
            _uiLogs.Add(new LogGridItem
            {
                Timestamp = entry.Timestamp,
                Direction = entry.Direction.ToString(),
                DisplayMode = entry.DisplayMode.ToString(),
                Message = entry.Message,
                Length = entry.RawData.Length
            });

            UpdateCounterLabels();
        }

        private void btnNavRealtime_Click(object sender, EventArgs e)
        {
            ShowPanel(ucRealtimePanel);
        }

        private void btnNavConfig_Click(object sender, EventArgs e)
        {
            ShowPanel(ucConfigPanel);
        }

        private void btnNavLogCenter_Click(object sender, EventArgs e)
        {
            ShowPanel(ucLogCenterPanel);
        }

        private void btnNavTools_Click(object sender, EventArgs e)
        {
            ShowPanel(ucToolsPanel);
        }

        private void ShowPanel(Control target)
        {
            ucRealtimePanel.Visible = false;
            ucConfigPanel.Visible = false;
            ucLogCenterPanel.Visible = false;
            ucToolsPanel.Visible = false;
            target.Visible = true;
            target.BringToFront();
        }

        private void RefreshPorts()
        {
            var ports = SerialPort.GetPortNames().OrderBy(x => x).ToArray();
            cmbPortName.Items.Clear();
            cmbPortName.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                cmbPortName.SelectedIndex = 0;
            }

            UpdateStatus($"已刷新串口，共 {ports.Length} 个。");
        }

        private SerialPortConfig BuildSerialConfigFromControls()
        {
            return new SerialPortConfig
            {
                PortName = cmbPortName.Text,
                BaudRate = ParseInt(cmbBaudRate.Text, AppConstants.DefaultBaudRate),
                Parity = Enum.TryParse<Parity>(cmbParity.Text, out var parity) ? parity : AppConstants.DefaultParity,
                DataBits = ParseInt(cmbDataBits.Text, AppConstants.DefaultDataBits),
                StopBits = Enum.TryParse<StopBits>(cmbStopBits.Text, out var stopBits) ? stopBits : AppConstants.DefaultStopBits,
                Handshake = Enum.TryParse<Handshake>(cmbHandshake.Text, out var handshake) ? handshake : AppConstants.DefaultHandshake,
                ReadTimeout = AppConstants.DefaultReadTimeoutMs,
                WriteTimeout = AppConstants.DefaultWriteTimeoutMs,
                DtrEnable = AppConstants.DefaultDtrEnable,
                RtsEnable = AppConstants.DefaultRtsEnable,
                EncodingName = string.IsNullOrWhiteSpace(cmbEncoding.Text) ? AppConstants.DefaultEncodingName : cmbEncoding.Text
            };
        }

        private static int ParseInt(string value, int fallback)
        {
            return int.TryParse(value, out var number) ? number : fallback;
        }

        private static void SelectComboValue(ComboBox comboBox, string value)
        {
            if (comboBox.Items.Contains(value))
            {
                comboBox.SelectedItem = value;
                return;
            }

            comboBox.Text = value;
        }

        private void UpdateConnectionState(bool isOpen)
        {
            lblConnectionState.Text = isOpen ? "状态: 已连接" : "状态: 未连接";
            lblConnectionState.ForeColor = isOpen ? Color.DarkGreen : Color.DarkRed;
            btnOpenClose.Text = isOpen ? "关闭串口" : "打开串口";
        }

        private void UpdateCounterLabels()
        {
            lblRxBytes.Text = $"接收: {_rxBytes} 字节";
            lblTxBytes.Text = $"发送: {_txBytes} 字节";
            lblErrorCount.Text = $"错误: {_errorCount} 次";
        }

        private void IncreaseError(string message)
        {
            Interlocked.Increment(ref _errorCount);
            if (InvokeRequired)
            {
                BeginInvoke(() =>
                {
                    UpdateCounterLabels();
                    UpdateStatus(message);
                });
                return;
            }

            UpdateCounterLabels();
            UpdateStatus(message);
        }

        private void UpdateStatus(string message)
        {
            tsslStatus.Text = message;
            tsslLogPath.Text = _currentSettings.LogFilePath;
            tsslEncoding.Text = cmbEncoding.Text;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serialService.DataReceived -= serialService_DataReceived;
            _serialService.DataSent -= serialService_DataSent;
            _serialService.Dispose();
        }

        private sealed class LogGridItem
        {
            public DateTime Timestamp { get; set; }
            public string Direction { get; set; } = string.Empty;
            public string DisplayMode { get; set; } = string.Empty;
            public string Message { get; set; } = string.Empty;
            public int Length { get; set; }
        }
    }
}
