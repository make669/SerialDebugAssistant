using System;
using System.Text;

namespace Utils
{
    /// <summary>
    /// 文件操作工具。
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 判断路径是否存在（文件或目录）。
        /// </summary>
        public static bool Exists(string? path)
        {
            return !string.IsNullOrWhiteSpace(path) && (File.Exists(path) || Directory.Exists(path));
        }

        /// <summary>
        /// 确保目录存在，不存在则创建。
        /// </summary>
        public static void EnsureDirectoryExists(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new ArgumentException("目录路径不能为空。", nameof(directoryPath));
            }

            Directory.CreateDirectory(directoryPath);
        }

        /// <summary>
        /// 读取文本文件，若文件不存在返回空字符串。
        /// </summary>
        public static string ReadAllText(string filePath, Encoding? encoding = null)
        {
            if (!File.Exists(filePath))
            {
                return string.Empty;
            }

            return File.ReadAllText(filePath, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        /// 读取二进制文件，若文件不存在返回空字节数组。
        /// </summary>
        public static byte[] ReadAllBytes(string filePath)
        {
            return File.Exists(filePath) ? File.ReadAllBytes(filePath) : Array.Empty<byte>();
        }

        /// <summary>
        /// 写入文本到文件（覆盖写入）。
        /// </summary>
        public static void WriteAllText(string filePath, string? content, Encoding? encoding = null)
        {
            EnsureFileDirectory(filePath);
            File.WriteAllText(filePath, content ?? string.Empty, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        /// 追加文本到文件。
        /// </summary>
        public static void AppendAllText(string filePath, string? content, Encoding? encoding = null)
        {
            EnsureFileDirectory(filePath);
            File.AppendAllText(filePath, content ?? string.Empty, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        /// 写入字节数组到文件（覆盖写入）。
        /// </summary>
        public static void WriteAllBytes(string filePath, byte[]? bytes)
        {
            EnsureFileDirectory(filePath);
            File.WriteAllBytes(filePath, bytes ?? Array.Empty<byte>());
        }

        /// <summary>
        /// 组合路径。
        /// </summary>
        public static string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        private static void EnsureFileDirectory(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("文件路径不能为空。", nameof(filePath));
            }

            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
