using Models;

namespace Properties
{
    /// <summary>
    /// 应用默认设置。
    /// </summary>
    public sealed class AppSettings
    {
        /// <summary>
        /// 默认串口配置。
        /// </summary>
        public SerialPortConfig DefaultSerialPortConfig { get; set; } = new()
        {
            BaudRate = AppConstants.DefaultBaudRate,
            Parity = AppConstants.DefaultParity,
            DataBits = AppConstants.DefaultDataBits,
            StopBits = AppConstants.DefaultStopBits,
            Handshake = AppConstants.DefaultHandshake,
            ReadTimeout = AppConstants.DefaultReadTimeoutMs,
            WriteTimeout = AppConstants.DefaultWriteTimeoutMs,
            EncodingName = AppConstants.DefaultEncodingName
        };

        /// <summary>
        /// 默认日志目录。
        /// </summary>
        public string LogDirectoryPath { get; set; } = AppConstants.DefaultLogDirectoryPath;

        /// <summary>
        /// 默认日志文件路径。
        /// </summary>
        public string LogFilePath { get; set; } = AppConstants.DefaultLogFilePath;

        /// <summary>
        /// 默认编码名称。
        /// </summary>
        public string DefaultEncodingName { get; set; } = AppConstants.DefaultEncodingName;

        /// <summary>
        /// 默认刷新间隔，单位毫秒。
        /// </summary>
        public int RefreshIntervalMs { get; set; } = AppConstants.DefaultRefreshIntervalMs;

        /// <summary>
        /// 创建一份新的默认设置副本。
        /// </summary>
        public static AppSettings CreateDefault() => new();
    }
}
