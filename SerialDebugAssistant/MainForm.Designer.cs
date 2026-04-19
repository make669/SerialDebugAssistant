namespace SerialDebugAssistant
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTopBar = new Panel();
            lblErrorCount = new Label();
            lblTxBytes = new Label();
            lblRxBytes = new Label();
            lblConnectionState = new Label();
            btnSaveConfig = new Button();
            btnLoadConfig = new Button();
            btnOpenClose = new Button();
            btnRefreshPorts = new Button();
            cmbEncoding = new ComboBox();
            cmbHandshake = new ComboBox();
            cmbStopBits = new ComboBox();
            cmbDataBits = new ComboBox();
            cmbParity = new ComboBox();
            cmbBaudRate = new ComboBox();
            cmbPortName = new ComboBox();
            lblEncoding = new Label();
            lblHandshake = new Label();
            lblStopBits = new Label();
            lblDataBits = new Label();
            lblParity = new Label();
            lblBaudRate = new Label();
            lblPortName = new Label();
            pnlLeftNav = new Panel();
            btnNavTools = new Button();
            btnNavLogCenter = new Button();
            btnNavConfig = new Button();
            btnNavRealtime = new Button();
            pnlMainHost = new Panel();
            ucToolsPanel = new Panel();
            lblToolsPlaceholder = new Label();
            ucLogCenterPanel = new Panel();
            dgvLogCenter = new DataGridView();
            btnExportLog = new Button();
            btnClearLog = new Button();
            ucConfigPanel = new Panel();
            lblConfigPlaceholder = new Label();
            ucRealtimePanel = new Panel();
            dgvRealtimeLog = new DataGridView();
            btnSend = new Button();
            chkSendHex = new CheckBox();
            txtSend = new TextBox();
            lblSendContent = new Label();
            statusStripMain = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            tsslLogPath = new ToolStripStatusLabel();
            tsslEncoding = new ToolStripStatusLabel();
            pnlTopBar.SuspendLayout();
            pnlLeftNav.SuspendLayout();
            pnlMainHost.SuspendLayout();
            ucToolsPanel.SuspendLayout();
            ucLogCenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogCenter).BeginInit();
            ucConfigPanel.SuspendLayout();
            ucRealtimePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRealtimeLog).BeginInit();
            statusStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BorderStyle = BorderStyle.FixedSingle;
            pnlTopBar.Controls.Add(lblErrorCount);
            pnlTopBar.Controls.Add(lblTxBytes);
            pnlTopBar.Controls.Add(lblRxBytes);
            pnlTopBar.Controls.Add(lblConnectionState);
            pnlTopBar.Controls.Add(btnSaveConfig);
            pnlTopBar.Controls.Add(btnLoadConfig);
            pnlTopBar.Controls.Add(btnOpenClose);
            pnlTopBar.Controls.Add(btnRefreshPorts);
            pnlTopBar.Controls.Add(cmbEncoding);
            pnlTopBar.Controls.Add(cmbHandshake);
            pnlTopBar.Controls.Add(cmbStopBits);
            pnlTopBar.Controls.Add(cmbDataBits);
            pnlTopBar.Controls.Add(cmbParity);
            pnlTopBar.Controls.Add(cmbBaudRate);
            pnlTopBar.Controls.Add(cmbPortName);
            pnlTopBar.Controls.Add(lblEncoding);
            pnlTopBar.Controls.Add(lblHandshake);
            pnlTopBar.Controls.Add(lblStopBits);
            pnlTopBar.Controls.Add(lblDataBits);
            pnlTopBar.Controls.Add(lblParity);
            pnlTopBar.Controls.Add(lblBaudRate);
            pnlTopBar.Controls.Add(lblPortName);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Margin = new Padding(4, 4, 4, 4);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1029, 117);
            pnlTopBar.TabIndex = 0;
            // 
            // lblErrorCount
            // 
            lblErrorCount.AutoSize = true;
            lblErrorCount.Location = new Point(840, 81);
            lblErrorCount.Margin = new Padding(4, 0, 4, 0);
            lblErrorCount.Name = "lblErrorCount";
            lblErrorCount.Size = new Size(75, 20);
            lblErrorCount.TabIndex = 21;
            lblErrorCount.Text = "错误: 0 次";
            // 
            // lblTxBytes
            // 
            lblTxBytes.AutoSize = true;
            lblTxBytes.Location = new Point(694, 81);
            lblTxBytes.Margin = new Padding(4, 0, 4, 0);
            lblTxBytes.Name = "lblTxBytes";
            lblTxBytes.Size = new Size(90, 20);
            lblTxBytes.TabIndex = 20;
            lblTxBytes.Text = "发送: 0 字节";
            // 
            // lblRxBytes
            // 
            lblRxBytes.AutoSize = true;
            lblRxBytes.Location = new Point(549, 81);
            lblRxBytes.Margin = new Padding(4, 0, 4, 0);
            lblRxBytes.Name = "lblRxBytes";
            lblRxBytes.Size = new Size(90, 20);
            lblRxBytes.TabIndex = 19;
            lblRxBytes.Text = "接收: 0 字节";
            // 
            // lblConnectionState
            // 
            lblConnectionState.AutoSize = true;
            lblConnectionState.ForeColor = Color.DarkRed;
            lblConnectionState.Location = new Point(437, 81);
            lblConnectionState.Margin = new Padding(4, 0, 4, 0);
            lblConnectionState.Name = "lblConnectionState";
            lblConnectionState.Size = new Size(92, 20);
            lblConnectionState.TabIndex = 18;
            lblConnectionState.Text = "状态: 未连接";
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.Location = new Point(332, 76);
            btnSaveConfig.Margin = new Padding(4, 4, 4, 4);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new Size(96, 29);
            btnSaveConfig.TabIndex = 17;
            btnSaveConfig.Text = "保存配置";
            btnSaveConfig.UseVisualStyleBackColor = true;
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // btnLoadConfig
            // 
            btnLoadConfig.Location = new Point(228, 76);
            btnLoadConfig.Margin = new Padding(4, 4, 4, 4);
            btnLoadConfig.Name = "btnLoadConfig";
            btnLoadConfig.Size = new Size(96, 29);
            btnLoadConfig.TabIndex = 16;
            btnLoadConfig.Text = "加载配置";
            btnLoadConfig.UseVisualStyleBackColor = true;
            btnLoadConfig.Click += btnLoadConfig_Click;
            // 
            // btnOpenClose
            // 
            btnOpenClose.Location = new Point(123, 76);
            btnOpenClose.Margin = new Padding(4, 4, 4, 4);
            btnOpenClose.Name = "btnOpenClose";
            btnOpenClose.Size = new Size(96, 29);
            btnOpenClose.TabIndex = 15;
            btnOpenClose.Text = "打开串口";
            btnOpenClose.UseVisualStyleBackColor = true;
            btnOpenClose.Click += btnOpenClose_Click;
            // 
            // btnRefreshPorts
            // 
            btnRefreshPorts.Location = new Point(19, 76);
            btnRefreshPorts.Margin = new Padding(4, 4, 4, 4);
            btnRefreshPorts.Name = "btnRefreshPorts";
            btnRefreshPorts.Size = new Size(96, 29);
            btnRefreshPorts.TabIndex = 14;
            btnRefreshPorts.Text = "刷新串口";
            btnRefreshPorts.UseVisualStyleBackColor = true;
            btnRefreshPorts.Click += btnRefreshPorts_Click;
            // 
            // cmbEncoding
            // 
            cmbEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEncoding.FormattingEnabled = true;
            cmbEncoding.Location = new Point(842, 34);
            cmbEncoding.Margin = new Padding(4, 4, 4, 4);
            cmbEncoding.Name = "cmbEncoding";
            cmbEncoding.Size = new Size(166, 28);
            cmbEncoding.TabIndex = 13;
            // 
            // cmbHandshake
            // 
            cmbHandshake.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHandshake.FormattingEnabled = true;
            cmbHandshake.Location = new Point(705, 34);
            cmbHandshake.Margin = new Padding(4, 4, 4, 4);
            cmbHandshake.Name = "cmbHandshake";
            cmbHandshake.Size = new Size(129, 28);
            cmbHandshake.TabIndex = 12;
            // 
            // cmbStopBits
            // 
            cmbStopBits.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStopBits.FormattingEnabled = true;
            cmbStopBits.Location = new Point(577, 34);
            cmbStopBits.Margin = new Padding(4, 4, 4, 4);
            cmbStopBits.Name = "cmbStopBits";
            cmbStopBits.Size = new Size(118, 28);
            cmbStopBits.TabIndex = 11;
            // 
            // cmbDataBits
            // 
            cmbDataBits.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDataBits.FormattingEnabled = true;
            cmbDataBits.Location = new Point(464, 34);
            cmbDataBits.Margin = new Padding(4, 4, 4, 4);
            cmbDataBits.Name = "cmbDataBits";
            cmbDataBits.Size = new Size(104, 28);
            cmbDataBits.TabIndex = 10;
            // 
            // cmbParity
            // 
            cmbParity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParity.FormattingEnabled = true;
            cmbParity.Location = new Point(351, 34);
            cmbParity.Margin = new Padding(4, 4, 4, 4);
            cmbParity.Name = "cmbParity";
            cmbParity.Size = new Size(104, 28);
            cmbParity.TabIndex = 9;
            // 
            // cmbBaudRate
            // 
            cmbBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBaudRate.FormattingEnabled = true;
            cmbBaudRate.Location = new Point(185, 34);
            cmbBaudRate.Margin = new Padding(4, 4, 4, 4);
            cmbBaudRate.Name = "cmbBaudRate";
            cmbBaudRate.Size = new Size(157, 28);
            cmbBaudRate.TabIndex = 8;
            // 
            // cmbPortName
            // 
            cmbPortName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPortName.FormattingEnabled = true;
            cmbPortName.Location = new Point(19, 34);
            cmbPortName.Margin = new Padding(4, 4, 4, 4);
            cmbPortName.Name = "cmbPortName";
            cmbPortName.Size = new Size(157, 28);
            cmbPortName.TabIndex = 7;
            // 
            // lblEncoding
            // 
            lblEncoding.AutoSize = true;
            lblEncoding.Location = new Point(842, 11);
            lblEncoding.Margin = new Padding(4, 0, 4, 0);
            lblEncoding.Name = "lblEncoding";
            lblEncoding.Size = new Size(69, 20);
            lblEncoding.TabIndex = 6;
            lblEncoding.Text = "编码格式";
            // 
            // lblHandshake
            // 
            lblHandshake.AutoSize = true;
            lblHandshake.Location = new Point(705, 11);
            lblHandshake.Margin = new Padding(4, 0, 4, 0);
            lblHandshake.Name = "lblHandshake";
            lblHandshake.Size = new Size(69, 20);
            lblHandshake.TabIndex = 5;
            lblHandshake.Text = "握手协议";
            // 
            // lblStopBits
            // 
            lblStopBits.AutoSize = true;
            lblStopBits.Location = new Point(577, 11);
            lblStopBits.Margin = new Padding(4, 0, 4, 0);
            lblStopBits.Name = "lblStopBits";
            lblStopBits.Size = new Size(54, 20);
            lblStopBits.TabIndex = 4;
            lblStopBits.Text = "停止位";
            // 
            // lblDataBits
            // 
            lblDataBits.AutoSize = true;
            lblDataBits.Location = new Point(464, 11);
            lblDataBits.Margin = new Padding(4, 0, 4, 0);
            lblDataBits.Name = "lblDataBits";
            lblDataBits.Size = new Size(54, 20);
            lblDataBits.TabIndex = 3;
            lblDataBits.Text = "数据位";
            // 
            // lblParity
            // 
            lblParity.AutoSize = true;
            lblParity.Location = new Point(351, 11);
            lblParity.Margin = new Padding(4, 0, 4, 0);
            lblParity.Name = "lblParity";
            lblParity.Size = new Size(54, 20);
            lblParity.TabIndex = 2;
            lblParity.Text = "校验位";
            // 
            // lblBaudRate
            // 
            lblBaudRate.AutoSize = true;
            lblBaudRate.Location = new Point(185, 11);
            lblBaudRate.Margin = new Padding(4, 0, 4, 0);
            lblBaudRate.Name = "lblBaudRate";
            lblBaudRate.Size = new Size(54, 20);
            lblBaudRate.TabIndex = 1;
            lblBaudRate.Text = "波特率";
            // 
            // lblPortName
            // 
            lblPortName.AutoSize = true;
            lblPortName.Location = new Point(19, 11);
            lblPortName.Margin = new Padding(4, 0, 4, 0);
            lblPortName.Name = "lblPortName";
            lblPortName.Size = new Size(54, 20);
            lblPortName.TabIndex = 0;
            lblPortName.Text = "串口号";
            // 
            // pnlLeftNav
            // 
            pnlLeftNav.BorderStyle = BorderStyle.FixedSingle;
            pnlLeftNav.Controls.Add(btnNavTools);
            pnlLeftNav.Controls.Add(btnNavLogCenter);
            pnlLeftNav.Controls.Add(btnNavConfig);
            pnlLeftNav.Controls.Add(btnNavRealtime);
            pnlLeftNav.Dock = DockStyle.Left;
            pnlLeftNav.Location = new Point(0, 117);
            pnlLeftNav.Margin = new Padding(4, 4, 4, 4);
            pnlLeftNav.Name = "pnlLeftNav";
            pnlLeftNav.Size = new Size(154, 445);
            pnlLeftNav.TabIndex = 1;
            // 
            // btnNavTools
            // 
            btnNavTools.Dock = DockStyle.Top;
            btnNavTools.Location = new Point(0, 120);
            btnNavTools.Margin = new Padding(4, 4, 4, 4);
            btnNavTools.Name = "btnNavTools";
            btnNavTools.Size = new Size(152, 40);
            btnNavTools.TabIndex = 3;
            btnNavTools.Text = "工具箱(预留)";
            btnNavTools.UseVisualStyleBackColor = true;
            btnNavTools.Click += btnNavTools_Click;
            // 
            // btnNavLogCenter
            // 
            btnNavLogCenter.Dock = DockStyle.Top;
            btnNavLogCenter.Location = new Point(0, 80);
            btnNavLogCenter.Margin = new Padding(4, 4, 4, 4);
            btnNavLogCenter.Name = "btnNavLogCenter";
            btnNavLogCenter.Size = new Size(152, 40);
            btnNavLogCenter.TabIndex = 2;
            btnNavLogCenter.Text = "日志中心";
            btnNavLogCenter.UseVisualStyleBackColor = true;
            btnNavLogCenter.Click += btnNavLogCenter_Click;
            // 
            // btnNavConfig
            // 
            btnNavConfig.Dock = DockStyle.Top;
            btnNavConfig.Location = new Point(0, 40);
            btnNavConfig.Margin = new Padding(4, 4, 4, 4);
            btnNavConfig.Name = "btnNavConfig";
            btnNavConfig.Size = new Size(152, 40);
            btnNavConfig.TabIndex = 1;
            btnNavConfig.Text = "配置中心";
            btnNavConfig.UseVisualStyleBackColor = true;
            btnNavConfig.Click += btnNavConfig_Click;
            // 
            // btnNavRealtime
            // 
            btnNavRealtime.Dock = DockStyle.Top;
            btnNavRealtime.Location = new Point(0, 0);
            btnNavRealtime.Margin = new Padding(4, 4, 4, 4);
            btnNavRealtime.Name = "btnNavRealtime";
            btnNavRealtime.Size = new Size(152, 40);
            btnNavRealtime.TabIndex = 0;
            btnNavRealtime.Text = "实时收发";
            btnNavRealtime.UseVisualStyleBackColor = true;
            btnNavRealtime.Click += btnNavRealtime_Click;
            // 
            // pnlMainHost
            // 
            pnlMainHost.BorderStyle = BorderStyle.FixedSingle;
            pnlMainHost.Controls.Add(ucToolsPanel);
            pnlMainHost.Controls.Add(ucLogCenterPanel);
            pnlMainHost.Controls.Add(ucConfigPanel);
            pnlMainHost.Controls.Add(ucRealtimePanel);
            pnlMainHost.Dock = DockStyle.Fill;
            pnlMainHost.Location = new Point(154, 117);
            pnlMainHost.Margin = new Padding(4, 4, 4, 4);
            pnlMainHost.Name = "pnlMainHost";
            pnlMainHost.Size = new Size(875, 445);
            pnlMainHost.TabIndex = 2;
            // 
            // ucToolsPanel
            // 
            ucToolsPanel.Controls.Add(lblToolsPlaceholder);
            ucToolsPanel.Dock = DockStyle.Fill;
            ucToolsPanel.Location = new Point(0, 0);
            ucToolsPanel.Margin = new Padding(4, 4, 4, 4);
            ucToolsPanel.Name = "ucToolsPanel";
            ucToolsPanel.Size = new Size(873, 443);
            ucToolsPanel.TabIndex = 3;
            ucToolsPanel.Visible = false;
            // 
            // lblToolsPlaceholder
            // 
            lblToolsPlaceholder.AutoSize = true;
            lblToolsPlaceholder.Location = new Point(36, 31);
            lblToolsPlaceholder.Margin = new Padding(4, 0, 4, 0);
            lblToolsPlaceholder.Name = "lblToolsPlaceholder";
            lblToolsPlaceholder.Size = new Size(144, 20);
            lblToolsPlaceholder.TabIndex = 0;
            lblToolsPlaceholder.Text = "工具箱模块（预留）";
            // 
            // ucLogCenterPanel
            // 
            ucLogCenterPanel.Controls.Add(dgvLogCenter);
            ucLogCenterPanel.Controls.Add(btnExportLog);
            ucLogCenterPanel.Controls.Add(btnClearLog);
            ucLogCenterPanel.Dock = DockStyle.Fill;
            ucLogCenterPanel.Location = new Point(0, 0);
            ucLogCenterPanel.Margin = new Padding(4, 4, 4, 4);
            ucLogCenterPanel.Name = "ucLogCenterPanel";
            ucLogCenterPanel.Size = new Size(873, 443);
            ucLogCenterPanel.TabIndex = 2;
            ucLogCenterPanel.Visible = false;
            // 
            // dgvLogCenter
            // 
            dgvLogCenter.AllowUserToAddRows = false;
            dgvLogCenter.AllowUserToDeleteRows = false;
            dgvLogCenter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogCenter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogCenter.Dock = DockStyle.Bottom;
            dgvLogCenter.Location = new Point(0, 54);
            dgvLogCenter.Margin = new Padding(4, 4, 4, 4);
            dgvLogCenter.Name = "dgvLogCenter";
            dgvLogCenter.ReadOnly = true;
            dgvLogCenter.RowHeadersWidth = 51;
            dgvLogCenter.RowTemplate.Height = 25;
            dgvLogCenter.Size = new Size(873, 389);
            dgvLogCenter.TabIndex = 2;
            // 
            // btnExportLog
            // 
            btnExportLog.Location = new Point(156, 14);
            btnExportLog.Margin = new Padding(4, 4, 4, 4);
            btnExportLog.Name = "btnExportLog";
            btnExportLog.Size = new Size(130, 32);
            btnExportLog.TabIndex = 1;
            btnExportLog.Text = "导出日志";
            btnExportLog.UseVisualStyleBackColor = true;
            btnExportLog.Click += btnExportLog_Click;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(18, 14);
            btnClearLog.Margin = new Padding(4, 4, 4, 4);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(130, 32);
            btnClearLog.TabIndex = 0;
            btnClearLog.Text = "清空显示";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // ucConfigPanel
            // 
            ucConfigPanel.Controls.Add(lblConfigPlaceholder);
            ucConfigPanel.Dock = DockStyle.Fill;
            ucConfigPanel.Location = new Point(0, 0);
            ucConfigPanel.Margin = new Padding(4, 4, 4, 4);
            ucConfigPanel.Name = "ucConfigPanel";
            ucConfigPanel.Size = new Size(873, 443);
            ucConfigPanel.TabIndex = 1;
            ucConfigPanel.Visible = false;
            // 
            // lblConfigPlaceholder
            // 
            lblConfigPlaceholder.AutoSize = true;
            lblConfigPlaceholder.Location = new Point(36, 31);
            lblConfigPlaceholder.Margin = new Padding(4, 0, 4, 0);
            lblConfigPlaceholder.Name = "lblConfigPlaceholder";
            lblConfigPlaceholder.Size = new Size(159, 20);
            lblConfigPlaceholder.TabIndex = 0;
            lblConfigPlaceholder.Text = "配置中心模块（预留）";
            // 
            // ucRealtimePanel
            // 
            ucRealtimePanel.Controls.Add(dgvRealtimeLog);
            ucRealtimePanel.Controls.Add(btnSend);
            ucRealtimePanel.Controls.Add(chkSendHex);
            ucRealtimePanel.Controls.Add(txtSend);
            ucRealtimePanel.Controls.Add(lblSendContent);
            ucRealtimePanel.Dock = DockStyle.Fill;
            ucRealtimePanel.Location = new Point(0, 0);
            ucRealtimePanel.Margin = new Padding(4, 4, 4, 4);
            ucRealtimePanel.Name = "ucRealtimePanel";
            ucRealtimePanel.Size = new Size(873, 443);
            ucRealtimePanel.TabIndex = 0;
            // 
            // dgvRealtimeLog
            // 
            dgvRealtimeLog.AllowUserToAddRows = false;
            dgvRealtimeLog.AllowUserToDeleteRows = false;
            dgvRealtimeLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRealtimeLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRealtimeLog.Dock = DockStyle.Bottom;
            dgvRealtimeLog.Location = new Point(0, 54);
            dgvRealtimeLog.Margin = new Padding(4, 4, 4, 4);
            dgvRealtimeLog.Name = "dgvRealtimeLog";
            dgvRealtimeLog.ReadOnly = true;
            dgvRealtimeLog.RowHeadersWidth = 51;
            dgvRealtimeLog.RowTemplate.Height = 25;
            dgvRealtimeLog.Size = new Size(873, 389);
            dgvRealtimeLog.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(756, 13);
            btnSend.Margin = new Padding(4, 4, 4, 4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(96, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "发送";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // chkSendHex
            // 
            chkSendHex.AutoSize = true;
            chkSendHex.Location = new Point(656, 15);
            chkSendHex.Margin = new Padding(4, 4, 4, 4);
            chkSendHex.Name = "chkSendHex";
            chkSendHex.Size = new Size(91, 24);
            chkSendHex.TabIndex = 2;
            chkSendHex.Text = "HEX发送";
            chkSendHex.UseVisualStyleBackColor = true;
            // 
            // txtSend
            // 
            txtSend.Location = new Point(108, 14);
            txtSend.Margin = new Padding(4, 4, 4, 4);
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(539, 27);
            txtSend.TabIndex = 1;
            // 
            // lblSendContent
            // 
            lblSendContent.AutoSize = true;
            lblSendContent.Location = new Point(18, 18);
            lblSendContent.Margin = new Padding(4, 0, 4, 0);
            lblSendContent.Name = "lblSendContent";
            lblSendContent.Size = new Size(69, 20);
            lblSendContent.TabIndex = 0;
            lblSendContent.Text = "发送内容";
            // 
            // statusStripMain
            // 
            statusStripMain.ImageScalingSize = new Size(20, 20);
            statusStripMain.Items.AddRange(new ToolStripItem[] { tsslStatus, tsslLogPath, tsslEncoding });
            statusStripMain.Location = new Point(0, 562);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Padding = new Padding(1, 0, 18, 0);
            statusStripMain.Size = new Size(1029, 26);
            statusStripMain.TabIndex = 3;
            statusStripMain.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(39, 20);
            tsslStatus.Text = "就绪";
            // 
            // tsslLogPath
            // 
            tsslLogPath.Name = "tsslLogPath";
            tsslLogPath.Size = new Size(69, 20);
            tsslLogPath.Text = "日志路径";
            // 
            // tsslEncoding
            // 
            tsslEncoding.Name = "tsslEncoding";
            tsslEncoding.Size = new Size(37, 20);
            tsslEncoding.Text = "UTF";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 588);
            Controls.Add(pnlMainHost);
            Controls.Add(pnlLeftNav);
            Controls.Add(statusStripMain);
            Controls.Add(pnlTopBar);
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimumSize = new Size(1044, 626);
            Name = "MainForm";
            Text = "SerialDebugAssistant";
            FormClosing += MainForm_FormClosing;
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            pnlLeftNav.ResumeLayout(false);
            pnlMainHost.ResumeLayout(false);
            ucToolsPanel.ResumeLayout(false);
            ucToolsPanel.PerformLayout();
            ucLogCenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLogCenter).EndInit();
            ucConfigPanel.ResumeLayout(false);
            ucConfigPanel.PerformLayout();
            ucRealtimePanel.ResumeLayout(false);
            ucRealtimePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRealtimeLog).EndInit();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTopBar;
        private Panel pnlLeftNav;
        private Panel pnlMainHost;
        private StatusStrip statusStripMain;
        private ComboBox cmbPortName;
        private ComboBox cmbBaudRate;
        private ComboBox cmbParity;
        private ComboBox cmbDataBits;
        private ComboBox cmbStopBits;
        private ComboBox cmbHandshake;
        private ComboBox cmbEncoding;
        private Button btnRefreshPorts;
        private Button btnOpenClose;
        private Button btnLoadConfig;
        private Button btnSaveConfig;
        private Label lblConnectionState;
        private Label lblRxBytes;
        private Label lblTxBytes;
        private Label lblErrorCount;
        private Button btnNavRealtime;
        private Button btnNavConfig;
        private Button btnNavLogCenter;
        private Button btnNavTools;
        private Panel ucRealtimePanel;
        private Panel ucConfigPanel;
        private Panel ucLogCenterPanel;
        private Panel ucToolsPanel;
        private ToolStripStatusLabel tsslStatus;
        private ToolStripStatusLabel tsslLogPath;
        private ToolStripStatusLabel tsslEncoding;
        private Label lblPortName;
        private Label lblBaudRate;
        private Label lblParity;
        private Label lblDataBits;
        private Label lblStopBits;
        private Label lblHandshake;
        private Label lblEncoding;
        private TextBox txtSend;
        private CheckBox chkSendHex;
        private Button btnSend;
        private DataGridView dgvRealtimeLog;
        private Label lblSendContent;
        private Label lblConfigPlaceholder;
        private Label lblToolsPlaceholder;
        private Button btnClearLog;
        private Button btnExportLog;
        private DataGridView dgvLogCenter;
    }
}
