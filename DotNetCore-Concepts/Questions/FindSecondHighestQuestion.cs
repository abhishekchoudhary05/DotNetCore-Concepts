namespace InterviewPrepration.Questions;

internal static class FindSecondHighestQuestion
{
    internal static int FindSecondHighest(int[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        int? highest = null;
        int? secondHighest = null;

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
