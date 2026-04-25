using System.Text;
using Utils;

namespace Text;

public class EncodingHelperTests
{
    [Fact]
    public void Utf8_ShouldEncodeAndDecodeCorrectly()
    {
        const string text = "串口调试助手";

        var bytes = EncodingHelper.GetBytes(text, "UTF-8");
        var decoded = EncodingHelper.GetString(bytes, "UTF-8");

        Assert.Equal(text, decoded);
    }

    [Fact]
    public void Ascii_ShouldEncodeAndDecodeCorrectlyForAsciiText()
    {
        const string text = "ABC123";

        var bytes = EncodingHelper.GetBytes(text, "ASCII");
        var decoded = EncodingHelper.GetString(bytes, "ASCII");

        Assert.Equal(text, decoded);
    }

    [Fact]
    public void Gbk_ShouldEncodeAndDecodeCorrectly()
    {
        const string text = "中文GBK测试";

        var bytes = EncodingHelper.GetBytes(text, "GBK");
        var decoded = EncodingHelper.GetString(bytes, "GBK");

        Assert.Equal(text, decoded);
    }

    [Fact]
    public void GetEncodingOrDefault_WhenNameInvalid_ShouldReturnFallback()
    {
        var fallback = Encoding.ASCII;

        var encoding = EncodingHelper.GetEncodingOrDefault("NOT_A_REAL_ENCODING", fallback);

        Assert.Equal(fallback.WebName, encoding.WebName);
    }

    [Fact]
    public void IsSupportedEncoding_ShouldReturnExpectedResult()
    {
        Assert.True(EncodingHelper.IsSupportedEncoding("UTF-8"));
        Assert.False(EncodingHelper.IsSupportedEncoding("NOT_A_REAL_ENCODING"));
    }

    [Fact]
    public void GetString_WhenBytesInvalidForUtf8_ShouldNotThrow()
    {
        var invalidBytes = new byte[] { 0xFF, 0xFF };

        var exception = Record.Exception(() => EncodingHelper.GetString(invalidBytes, "UTF-8"));

        Assert.Null(exception);
    }
}
