using Utils;

namespace Text;

public class ValidationHelperTests
{
    [Theory]
    [InlineData("COM1", true)]
    [InlineData("com12", true)]
    [InlineData("COM", false)]
    [InlineData("USB1", false)]
    public void IsValidPortName_ShouldReturnExpected(string portName, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidPortName(portName));
    }

    [Theory]
    [InlineData(9600, true)]
    [InlineData(0, false)]
    [InlineData(-1, false)]
    public void IsValidBaudRate_ShouldReturnExpected(int baudRate, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidBaudRate(baudRate));
    }

    [Theory]
    [InlineData(5, true)]
    [InlineData(8, true)]
    [InlineData(9, false)]
    public void IsValidDataBits_ShouldReturnExpected(int dataBits, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidDataBits(dataBits));
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(4, true)]
    [InlineData(5, false)]
    public void IsValidParity_Int_ShouldReturnExpected(int parity, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidParity(parity));
    }

    [Theory]
    [InlineData("None", true)]
    [InlineData("Even", true)]
    [InlineData("4", true)]
    [InlineData("6", false)]
    public void IsValidParity_String_ShouldReturnExpected(string value, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidParity(value));
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    public void IsValidStopBits_Int_ShouldReturnExpected(int stopBits, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidStopBits(stopBits));
    }

    [Theory]
    [InlineData("One", true)]
    [InlineData("OnePointFive", true)]
    [InlineData("1.5", true)]
    [InlineData("8", false)]
    public void IsValidStopBits_String_ShouldReturnExpected(string value, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidStopBits(value));
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(3, true)]
    [InlineData(5, false)]
    public void IsValidHandshake_Int_ShouldReturnExpected(int handshake, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidHandshake(handshake));
    }

    [Theory]
    [InlineData("None", true)]
    [InlineData("XOnXOff", true)]
    [InlineData("Request To Send", true)]
    [InlineData("Unknown", false)]
    public void IsValidHandshake_String_ShouldReturnExpected(string value, bool expected)
    {
        Assert.Equal(expected, ValidationHelper.IsValidHandshake(value));
    }

    [Fact]
    public void IsValidEncodingName_ShouldReturnExpected()
    {
        Assert.True(ValidationHelper.IsValidEncodingName("UTF-8"));
        Assert.False(ValidationHelper.IsValidEncodingName("BAD_ENCODING"));
    }

    [Fact]
    public void IsValidHexString_ShouldValidateHex()
    {
        Assert.True(ValidationHelper.IsValidHexString("AA BB 01"));
        Assert.False(ValidationHelper.IsValidHexString("ZZ"));
        Assert.False(ValidationHelper.IsValidHexString("", allowEmpty: false));
    }
}
