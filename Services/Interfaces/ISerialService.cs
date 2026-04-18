using System;
using Models;
using Models.Enums;

namespace Services.Interfaces
{
    public interface ISerialService : IDisposable
    {
        bool IsOpen { get; }

        event EventHandler<LogEntry>? DataReceived;

        event EventHandler<LogEntry>? DataSent;

        OperationResult Open(SerialPortConfig config);

        OperationResult Close();

        OperationResult SendBytes(byte[]? data, ChecksumType checksumType = ChecksumType.None, bool appendChecksum = false);

        OperationResult SendText(string? text, string? encodingName = null, ChecksumType checksumType = ChecksumType.None, bool appendChecksum = false);

        LogEntry BuildMessage(byte[]? rawData, MessageDirection direction, DataDisplayMode displayMode, string? encodingName = null);
    }
}
