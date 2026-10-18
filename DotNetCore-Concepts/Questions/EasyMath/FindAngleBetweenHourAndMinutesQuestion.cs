namespace DotNetCore_Concepts.Questions.EasyMath;

internal static class FindAngleBetweenHourAndMinutesQuestion
{
    internal static void FindAngleBetweenHourAndMinutes(int hour, int minute)
    {
        double diff = Math.Abs((30 * hour) - (5.5 * minute));
        if (diff > 180)
            Console.WriteLine($"Angle is : {360 - diff}");
        else
            Console.WriteLine($"Angle is : {diff}");
    }
}
