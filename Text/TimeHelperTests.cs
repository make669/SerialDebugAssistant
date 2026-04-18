using System.Text.RegularExpressions;
using Utils;

namespace Text;

public class TimeHelperTests
{
    [Fact]
    public void Format_ShouldUseDefaultFormatWhenFormatIsNull()
    {
        var dateTime = new DateTime(2024, 1, 2, 3, 4, 5, 678);

        var formatted = TimeHelper.Format(dateTime);

        Assert.Equal("2024-01-02 03:04:05.678", formatted);
    }

    [Fact]
    public void UnixTimestamp_ShouldRoundTripInUtcMode()
    {
        var utcDateTime = new DateTime(2024, 1, 2, 3, 4, 5, 678, DateTimeKind.Utc);

        var unixMilliseconds = TimeHelper.ToUnixTimeMilliseconds(utcDateTime);
        var restored = TimeHelper.FromUnixTimeMilliseconds(unixMilliseconds, toLocalTime: false);

        Assert.Equal(utcDateTime, restored);
    }

    [Fact]
    public void FormatDuration_ShouldReturnExpectedText()
    {
        var duration = new TimeSpan(1, 2, 3) + TimeSpan.FromMilliseconds(456);

        var text = TimeHelper.FormatDuration(duration);

        Assert.Equal("01:02:03.456", text);
    }

    [Fact]
    public void FormatNow_ShouldMatchDefaultPattern()
    {
        var formatted = TimeHelper.FormatNow();

        Assert.Matches(new Regex("^\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}:\\d{2}\\.\\d{3}$"), formatted);
    }
}
