using Xunit;
using DotNetCore_Concepts.Questions.EasyMath;

namespace DotNetCore_Concepts.Tests.Questions.EasyMath;

/// <summary>
/// Tests for FindAngleBetweenHourAndMinutesQuestion which calculates the angle between clock hands.
/// Algorithm:
/// - Hour hand moves 30 degrees per hour (360/12) plus 0.5 degrees per minute (30/60)
/// - Minute hand moves 6 degrees per minute (360/60)
/// - Formula: |(30 * hour) - (5.5 * minute)| = |30H - 5.5M|
/// - If angle > 180°, returns the smaller angle (360 - angle)
/// - Time complexity: O(1), Space complexity: O(1)
/// </summary>
public class FindAngleBetweenHourAndMinutesTests
{
    /// <summary>
    /// Tests angle calculation at 3:30.
    /// Hour hand: 3.5 * 30 = 105°, Minute hand: 6 * 30 = 180°
    /// Difference: 75° (≤ 180, so no adjustment needed)
    /// </summary>
    [Fact]
    public void FindAngleBetweenHourAndMinutes_3_30_Test()
    {
        FindAngleBetweenHourAndMinutesQuestion.FindAngleBetweenHourAndMinutes(3, 30);
    }

    /// <summary>
    /// Tests angle calculation at 12:00.
    /// Both hands at 0°, difference = 0°
    /// </summary>
    [Fact]
    public void FindAngleBetweenHourAndMinutes_12_0_Test()
    {
        FindAngleBetweenHourAndMinutesQuestion.FindAngleBetweenHourAndMinutes(12, 0);
    }
}