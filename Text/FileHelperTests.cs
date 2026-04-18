using System.Text;
using Utils;

namespace Text;

public class FileHelperTests
{
    [Fact]
    public void WriteAndReadText_ShouldWorkAndCreateDirectory()
    {
        var root = CreateTempDirectory();
        try
        {
            var filePath = Path.Combine(root, "sub", "log.txt");

            FileHelper.WriteAllText(filePath, "hello", Encoding.UTF8);
            var content = FileHelper.ReadAllText(filePath, Encoding.UTF8);

            Assert.Equal("hello", content);
            Assert.True(FileHelper.Exists(filePath));
            Assert.True(FileHelper.Exists(Path.GetDirectoryName(filePath)));
        }
        finally
        {
            SafeDeleteDirectory(root);
        }
    }

    [Fact]
    public void AppendAllText_ShouldAppendContent()
    {
        var root = CreateTempDirectory();
        try
        {
            var filePath = Path.Combine(root, "append.txt");

            FileHelper.WriteAllText(filePath, "A");
            FileHelper.AppendAllText(filePath, "B");

            Assert.Equal("AB", FileHelper.ReadAllText(filePath));
        }
        finally
        {
            SafeDeleteDirectory(root);
        }
    }

    [Fact]
    public void Read_WhenFileNotExists_ShouldReturnEmpty()
    {
        var root = CreateTempDirectory();
        try
        {
            var filePath = Path.Combine(root, "missing.txt");

            Assert.Equal(string.Empty, FileHelper.ReadAllText(filePath));
            Assert.Empty(FileHelper.ReadAllBytes(filePath));
        }
        finally
        {
            SafeDeleteDirectory(root);
        }
    }

    [Fact]
    public void WriteAndReadBytes_ShouldWork()
    {
        var root = CreateTempDirectory();
        try
        {
            var filePath = Path.Combine(root, "data.bin");
            var bytes = new byte[] { 1, 2, 3, 255 };

            FileHelper.WriteAllBytes(filePath, bytes);
            var read = FileHelper.ReadAllBytes(filePath);

            Assert.Equal(bytes, read);
        }
        finally
        {
            SafeDeleteDirectory(root);
        }
    }

    [Fact]
    public void EnsureDirectoryExists_WhenPathEmpty_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => FileHelper.EnsureDirectoryExists(string.Empty));
    }

    [Fact]
    public void WriteAllText_WhenFileIsReadOnly_ShouldThrow()
    {
        var root = CreateTempDirectory();
        var filePath = Path.Combine(root, "readonly.txt");

        try
        {
            FileHelper.WriteAllText(filePath, "origin");
            File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.ReadOnly);

            Assert.ThrowsAny<Exception>(() => FileHelper.WriteAllText(filePath, "new"));
        }
        finally
        {
            if (File.Exists(filePath))
            {
                var attributes = File.GetAttributes(filePath);
                if (attributes.HasFlag(FileAttributes.ReadOnly))
                {
                    File.SetAttributes(filePath, attributes & ~FileAttributes.ReadOnly);
                }
            }

            SafeDeleteDirectory(root);
        }
    }

    private static string CreateTempDirectory()
    {
        var path = Path.Combine(Path.GetTempPath(), "SerialDebugAssistantTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(path);
        return path;
    }

    private static void SafeDeleteDirectory(string path)
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
    }
}
