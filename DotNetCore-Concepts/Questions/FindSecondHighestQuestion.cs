namespace InterviewPrepration.Questions;

/// <summary>Finds the second-largest distinct integer in an array.</summary>
internal static class FindSecondHighestQuestion
{
    /// <summary>Tracks the two largest distinct values in one pass.</summary>
    internal static int FindSecondHighest(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        int? highest = null;
        int? secondHighest = null;

        // When a new maximum appears, the previous maximum becomes the second maximum.
        foreach (int item in array)
        {
            if (highest is null || item > highest)
            {
                secondHighest = highest;
                highest = item;
            }
            else if (item < highest &&
                     (secondHighest is null || item > secondHighest))
            {
                secondHighest = item;
            }
        }

        if (secondHighest is null)
            throw new ArgumentException(
                "Second highest distinct value is not available.");

        return secondHighest.Value;
    }
}
