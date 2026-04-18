using System.Text.Json;
using Models;
using Properties;
using Services.Interfaces;
using Utils;

namespace Services
{
    public class ConfigService : IConfigService
    {
        private const string DefaultConfigFileName = "appsettings.json";
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public OperationResult Save(AppSettings settings, string? filePath = null)
        {
            if (settings is null)
            {
                return Fail("配置对象不能为空。");
            }

            try
            {
                var targetPath = ResolveFilePath(filePath);
                var json = JsonSerializer.Serialize(settings, JsonOptions);
                FileHelper.WriteAllText(targetPath, json);

                return new OperationResult
                {
                    IsSuccess = true,
                    Message = "配置保存成功。",
                    Data = targetPath
                };
            }
            catch (Exception ex)
            {
                return Fail("保存配置失败。", ex);
            }
        }

        public OperationResult Load(string? filePath = null)
        {
            try
            {
                var targetPath = ResolveFilePath(filePath);
                if (!File.Exists(targetPath))
                {
                    return Fail("配置文件不存在。", data: targetPath);
                }

                var json = FileHelper.ReadAllText(targetPath);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                if (settings is null)
                {
                    return Fail("配置文件内容为空或格式无效。", data: targetPath);
                }

                return new OperationResult
                {
                    IsSuccess = true,
                    Message = "配置读取成功。",
                    Data = settings
                };
            }
            catch (Exception ex)
            {
                return Fail("读取配置失败。", ex);
            }
        }

        public OperationResult LoadOrCreateDefault(string? filePath = null)
        {
            var loadResult = Load(filePath);
            if (loadResult.IsSuccess)
            {
                return loadResult;
            }

            var settings = AppSettings.CreateDefault();
            var saveResult = Save(settings, filePath);
            if (!saveResult.IsSuccess)
            {
                return saveResult;
            }

            return new OperationResult
            {
                IsSuccess = true,
                Message = "已生成默认配置。",
                Data = settings
            };
        }

        private static string ResolveFilePath(string? filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                return filePath;
            }

            return Path.Combine(AppContext.BaseDirectory, DefaultConfigFileName);
        }

        private static OperationResult Fail(string message, Exception? ex = null, object? data = null)
        {
            return new OperationResult
            {
                IsSuccess = false,
                Message = message,
                Exception = ex,
                Data = data
            };
        }
    }
}
