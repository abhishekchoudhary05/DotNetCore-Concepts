namespace InterviewPrepration.Questions;

/// <summary>Contains an in-place left rotation for arrays.</summary>
internal static class LeftCirculationQuestion
{
    /// <summary>Moves the first value to the end and shifts every other value one place left.</summary>
    internal static void LeftCirculation<T>(T[] arr)
    {
        ArgumentNullException.ThrowIfNull(arr, "Input array is null");

        if (arr.Length == 1)
            return;

        T firstValue = arr[0];
        // Save the value that will be overwritten, shift the remaining elements, then restore it at the end.
        for (int i = 0; i < arr.Length - 1; i++)
            arr[i] = arr[i + 1];

        arr[arr.Length - 1] = firstValue;

        foreach (var item in arr)
            Console.WriteLine(item);
    }
}
