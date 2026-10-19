using Xunit;
using DotNetCore_Concepts.Questions.EasyMath;

namespace DotNetCore_Concepts.Tests.Questions.EasyMath;

public class FindAngleBetweenHourAndMinutesTests
{
    [Fact]
    public void FindAngleBetweenHourAndMinutes_3_30_Test()
    {
        // 3:30 - hour hand at 3.5 * 30 = 105°, minute hand at 6 * 30 = 180°
        // Difference: 75°, which is <= 180
        FindAngleBetweenHourAndMinutesQuestion.FindAngleBetweenHourAndMinutes(3, 30);
    }

    [Fact]
    public void FindAngleBetweenHourAndMinutes_12_0_Test()
    {
        // 12:00 - both hands at 0°, difference = 0°
        FindAngleBetweenHourAndMinutesQuestion.FindAngleBetweenHourAndMinutes(12, 0);
    }
}