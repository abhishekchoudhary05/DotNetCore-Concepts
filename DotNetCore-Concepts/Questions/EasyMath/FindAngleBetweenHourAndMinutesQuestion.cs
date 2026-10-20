namespace DotNetCore_Concepts.Questions.EasyMath;

/// <summary>Calculates the smaller angle between clock hands.</summary>
internal static class FindAngleBetweenHourAndMinutesQuestion
{
    /// <summary>Writes the smaller angle in degrees for the given hour and minute.</summary>
    internal static void FindAngleBetweenHourAndMinutes(int hour, int minute)
    {
        // The minute hand moves 6 degrees per minute; the hour hand moves 30 degrees per hour plus half a degree per minute.
        double diff = Math.Abs((30 * hour) - (5.5 * minute));
        if (diff > 180)
            Console.WriteLine($"Angle is : {360 - diff}");
        else
            Console.WriteLine($"Angle is : {diff}");
    }
}
