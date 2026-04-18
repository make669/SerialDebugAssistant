using System;
using Models;
using Models.Enums;
using Properties;
using Services.Interfaces;
using Utils;

namespace Services
{
    public class LogService : ILogService
    {
        private readonly SemaphoreSlim _writeLock = new(1, 1);
        private readonly string _defaultFilePath;
        private readonly string _defaultEncodingName;

        public LogService(string? defaultFilePath = null, string? defaultEncodingName = null)
        {
            _defaultFilePath = string.IsNullOrWhiteSpace(defaultFilePath) ? AppConstants.DefaultLogFilePath : defaultFilePath;
            _defaultEncodingName = string.IsNullOrWhiteSpace(defaultEncodingName) ? AppConstants.DefaultEncodingName : defaultEncodingName;
        }

        public OperationResult Append(LogEntry entry, string? filePath = null, string? encodingName = null)
        {
            return AppendAsync(entry, filePath, encodingName).GetAwaiter().GetResult();
        }

        public async Task<OperationResult> AppendAsync(LogEntry entry, string? filePath = null, string? encodingName = null, CancellationToken cancellationToken = default)
        {
            if (entry is null)
            {
                return Fail("日志条目不能为空。");
            }

            var targetPath = ResolveFilePath(filePath);
            var encoding = EncodingHelper.GetEncodingOrDefault(encodingName ?? _defaultEncodingName);
            var line = Format(entry) + Environment.NewLine;

            try
            {
                await _writeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
                FileHelper.AppendAllText(targetPath, line, encoding);

                return new OperationResult
                {
                    IsSuccess = true,
                    Message = "日志写入成功。",
                    Data = targetPath
                };
            }
            catch (Exception ex)
            {
                return Fail("日志写入失败。", ex);
            }
            finally
            {
                if (_writeLock.CurrentCount == 0)
                {
                    _writeLock.Release();
                }
            }
        }

        public string Format(LogEntry entry)
        {
            var timestamp = TimeHelper.Format(entry.Timestamp);
            var content = ResolveContent(entry);
            return $"[{timestamp}] [{entry.Direction}] [{entry.DisplayMode}] {content}";
        }

        private static string ResolveContent(LogEntry entry)
        {
            if (!string.IsNullOrWhiteSpace(entry.Message))
            {
                return entry.Message;
            }

            if (entry.RawData is { Length: > 0 })
            {
                return entry.DisplayMode == DataDisplayMode.Hex
                    ? HexConverter.ToHexString(entry.RawData)
                    : EncodingHelper.GetString(entry.RawData);
            }

            return string.Empty;
        }

        private string ResolveFilePath(string? filePath)
        {
            return string.IsNullOrWhiteSpace(filePath) ? _defaultFilePath : filePath;
        }

        private static OperationResult Fail(string message, Exception? ex = null)
        {
            return new OperationResult
            {
                IsSuccess = false,
                Message = message,
                Exception = ex
            };
        }
    }
}
