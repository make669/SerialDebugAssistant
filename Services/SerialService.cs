using System.IO.Ports;
using System.IO.Ports;
using Models;
using Models.Enums;
using Services.Interfaces;
using Utils;

namespace Services
{
    /// <summary>
    /// 串口服务实现，负责连接管理、收发数据与资源释放。
    /// </summary>
    public class SerialService : ISerialService
    {
        private readonly object _syncRoot = new();
        private readonly IChecksumService _checksumService;
        private SerialPort? _serialPort;
        private SerialPortConfig? _config;
        private bool _disposed;

        /// <summary>
        /// 初始化串口服务。
        /// </summary>
        /// <param name="checksumService">校验服务，空则使用默认实现。</param>
        public SerialService(IChecksumService? checksumService = null)
        {
            _checksumService = checksumService ?? new ChecksumService();
        }

        /// <summary>
        /// 当前串口是否已打开。
        /// </summary>
        public bool IsOpen => _serialPort?.IsOpen == true;

        /// <summary>
        /// 接收数据事件。
        /// </summary>
        public event EventHandler<LogEntry>? DataReceived;

        /// <summary>
        /// 发送数据事件。
        /// </summary>
        public event EventHandler<LogEntry>? DataSent;

        /// <summary>
        /// 按配置打开串口。
        /// </summary>
        public OperationResult Open(SerialPortConfig config)
        {
            ThrowIfDisposed();

            if (config is null)
            {
                return Fail("串口配置不能为空。");
            }

            var validationMessage = ValidateConfig(config);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                return Fail(validationMessage);
            }

            try
            {
                lock (_syncRoot)
                {
                    if (IsOpen)
                    {
                        return Success("串口已打开。", _serialPort?.PortName);
                    }

                    var existingPorts = SerialPort.GetPortNames();
                    if (!existingPorts.Contains(config.PortName, StringComparer.OrdinalIgnoreCase))
                    {
                        return Fail($"串口不存在: {config.PortName}");
                    }

                    var serialPort = new SerialPort(config.PortName, config.BaudRate, config.Parity, config.DataBits, config.StopBits)
                    {
                        Handshake = config.Handshake,
                        ReadTimeout = config.ReadTimeout,
                        WriteTimeout = config.WriteTimeout,
                        DtrEnable = config.DtrEnable,
                        RtsEnable = config.RtsEnable
                    };

                    serialPort.DataReceived += OnDataReceived;
                    serialPort.Open();

                    _serialPort = serialPort;
                    _config = config;

                    return Success("串口打开成功。", config.PortName);
                }
            }
            catch (Exception ex)
            {
                return Fail("串口打开失败。", ex);
            }
        }

        /// <summary>
        /// 关闭并释放当前串口实例。
        /// </summary>
        public OperationResult Close()
        {
            if (_disposed)
            {
                return Success("串口已释放。", null);
            }

            try
            {
                lock (_syncRoot)
                {
                    if (_serialPort is null)
                    {
                        return Success("串口已关闭。", null);
                    }

                    _serialPort.DataReceived -= OnDataReceived;
                    if (_serialPort.IsOpen)
                    {
                        _serialPort.Close();
                    }

                    _serialPort.Dispose();
                    _serialPort = null;
                    _config = null;

                    return Success("串口关闭成功。", null);
                }
            }
            catch (Exception ex)
            {
                return Fail("串口关闭失败。", ex);
            }
        }

        /// <summary>
        /// 发送字节数据，可按需附加校验值。
        /// </summary>
        public OperationResult SendBytes(byte[]? data, ChecksumType checksumType = ChecksumType.None, bool appendChecksum = false)
        {
            ThrowIfDisposed();

            if (data is null || data.Length == 0)
            {
                return Fail("发送数据不能为空。");
            }

            if (!IsOpen || _serialPort is null)
            {
                return Fail("串口未打开。");
            }

            try
            {
                var payload = data.ToArray();
                if (appendChecksum && checksumType != ChecksumType.None)
                {
                    var checksum = _checksumService.ComputeChecksumBytes(payload, checksumType);
                    payload = payload.Concat(checksum).ToArray();
                }

                lock (_syncRoot)
                {
                    _serialPort.Write(payload, 0, payload.Length);
                }

                var message = BuildMessage(payload, MessageDirection.Send, DataDisplayMode.Hex, _config?.EncodingName);
                DataSent?.Invoke(this, message);

                return Success("发送成功。", payload);
            }
            catch (Exception ex)
            {
                return Fail("发送失败。", ex);
            }
        }

        /// <summary>
        /// 发送文本数据。
        /// </summary>
        public OperationResult SendText(string? text, string? encodingName = null, ChecksumType checksumType = ChecksumType.None, bool appendChecksum = false)
        {
            ThrowIfDisposed();

            if (string.IsNullOrEmpty(text))
            {
                return Fail("发送文本不能为空。");
            }

            var finalEncoding = string.IsNullOrWhiteSpace(encodingName) ? _config?.EncodingName : encodingName;
            var bytes = EncodingHelper.GetBytes(text, finalEncoding);
            return SendBytes(bytes, checksumType, appendChecksum);
        }

        /// <summary>
        /// 构建统一日志消息对象。
        /// </summary>
        public LogEntry BuildMessage(byte[]? rawData, MessageDirection direction, DataDisplayMode displayMode, string? encodingName = null)
        {
            var payload = rawData ?? Array.Empty<byte>();
            var text = displayMode == DataDisplayMode.Hex
                ? HexConverter.ToHexString(payload)
                : EncodingHelper.GetString(payload, encodingName);

            return new LogEntry
            {
                Timestamp = DateTime.Now,
                Direction = direction,
                DisplayMode = displayMode,
                RawData = payload,
                Message = text
            };
        }

        /// <summary>
        /// 释放串口资源。
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Close();
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 串口底层接收事件处理。
        /// </summary>
        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = _serialPort;
            if (serialPort is null || !serialPort.IsOpen)
            {
                return;
            }

            try
            {
                var count = serialPort.BytesToRead;
                if (count <= 0)
                {
                    return;
                }

                var buffer = new byte[count];
                var read = serialPort.Read(buffer, 0, count);
                if (read <= 0)
                {
                    return;
                }

                if (read < count)
                {
                    Array.Resize(ref buffer, read);
                }

                var message = BuildMessage(buffer, MessageDirection.Receive, DataDisplayMode.Text, _config?.EncodingName);
                DataReceived?.Invoke(this, message);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 校验串口配置是否合法。
        /// </summary>
        /// <returns>合法返回 <see langword="null"/>，否则返回错误消息。</returns>
        private static string? ValidateConfig(SerialPortConfig config)
        {
            if (!ValidationHelper.IsValidPortName(config.PortName))
            {
                return "串口名称无效。";
            }

            if (!ValidationHelper.IsValidBaudRate(config.BaudRate))
            {
                return "波特率无效。";
            }

            if (!ValidationHelper.IsValidDataBits(config.DataBits))
            {
                return "数据位无效。";
            }

            if (!ValidationHelper.IsValidParity((int)config.Parity))
            {
                return "校验位无效。";
            }

            if (!ValidationHelper.IsValidStopBits((int)config.StopBits))
            {
                return "停止位无效。";
            }

            if (!ValidationHelper.IsValidHandshake((int)config.Handshake))
            {
                return "握手协议无效。";
            }

            if (!ValidationHelper.IsValidTimeout(config.ReadTimeout) || !ValidationHelper.IsValidTimeout(config.WriteTimeout))
            {
                return "超时时间无效。";
            }

            if (!ValidationHelper.IsValidEncodingName(config.EncodingName))
            {
                return "编码名称无效。";
            }

            return null;
        }

        /// <summary>
        /// 构造成功结果对象。
        /// </summary>
        private static OperationResult Success(string message, object? data)
        {
            return new OperationResult
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 构造失败结果对象。
        /// </summary>
        private static OperationResult Fail(string message, Exception? ex = null)
        {
            return new OperationResult
            {
                IsSuccess = false,
                Message = message,
                Exception = ex
            };
        }

        /// <summary>
        /// 若对象已释放则抛出异常。
        /// </summary>
        private void ThrowIfDisposed()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
        }
    }
}
