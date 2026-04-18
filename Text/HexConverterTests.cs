using Utils;

namespace Text;

public class HexConverterTests
{
    [Fact]
    public void ToHexString_ShouldSupportUpperLowerAndSeparator()
    {
        var bytes = new byte[] { 0x0A, 0x1B, 0xFF };

        var upper = HexConverter.ToHexString(bytes);
        var lower = HexConverter.ToHexString(bytes, upperCase: false, separator: "-");

        Assert.Equal("0A 1B FF", upper);
        Assert.Equal("0a-1b-ff", lower);
    }

    [Fact]
    public void ToByteArray_ShouldParseHexWithSpacesAndSeparators()
    {
        var bytes = HexConverter.ToByteArray("0A 1B-FF:10");

        Assert.Equal(new byte[] { 0x0A, 0x1B, 0xFF, 0x10 }, bytes);
    }

    [Fact]
    public void ToByteArray_WhenInvalidCharacter_ShouldThrowFormatException()
    {
        Assert.Throws<FormatException>(() => HexConverter.ToByteArray("0G"));
    }

    [Fact]
    public void ToByteArray_WhenOddLength_ShouldThrowFormatException()
    {
        Assert.Throws<FormatException>(() => HexConverter.ToByteArray("ABC"));
    }

    [Fact]
    public void TryToByteArray_WhenInvalid_ShouldReturnFalseAndEmptyBytes()
    {
        var result = HexConverter.TryToByteArray("ZZ", out var bytes);

        Assert.False(result);
        Assert.Empty(bytes);
    }

    [Fact]
    public void ByteArrayAndHexString_ShouldRoundTrip()
    {
        var original = new byte[] { 0x11, 0x22, 0x33, 0xAA };

        var hex = HexConverter.ToHexString(original);
        var parsed = HexConverter.ToByteArray(hex);

        Assert.Equal(original, parsed);
    }
}
