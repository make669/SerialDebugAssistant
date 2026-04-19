using System;
using Models.Enums;

namespace Models
{
    /// <summary>
    /// 内部使用的串口消息表示，用于在应用内部传递或显示单条消息。
    /// </summary>
    internal class SerialMessage
    {
        /// <summary>
        /// 消息时间戳，消息创建或接收时间，默认当前时间。
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// 消息方向（接收或发送）默认为串口接收到的。
        /// </summary>
        public MessageDirection Direction { get; set; } = MessageDirection.Receive;

        /// <summary>
        /// 数据展示模式（文本或十六进制），默认文本。
        /// </summary>
        public DataDisplayMode DisplayMode { get; set; } = DataDisplayMode.Text;

        /// <summary>
        /// 原始字节数据，默认为空列表。
        /// </summary>
        public byte[] RawData { get; set; } = Array.Empty<byte>();

        /// <summary>
        /// 文本表示（根据 DisplayMode 或解码器生成，默认为空。
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// 使用的串口名称（例如 COM1），如果适用则填充。
        /// </summary>
        public string? PortName { get; set; }

        /// <summary>
        /// 使用的校验类型，默认不用校验。
        /// </summary>
        public ChecksumType ChecksumType { get; set; } = ChecksumType.None;

        /// <summary>
        /// 计算出的校验值（如果有）。
        /// </summary>
        public string? Checksum { get; set; }
    }
}
