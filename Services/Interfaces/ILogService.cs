using System;
using Models;

namespace Services.Interfaces
{
    public interface ILogService
    {
        OperationResult Append(LogEntry entry, string? filePath = null, string? encodingName = null);

        Task<OperationResult> AppendAsync(LogEntry entry, string? filePath = null, string? encodingName = null, CancellationToken cancellationToken = default);

        string Format(LogEntry entry);
    }
}
