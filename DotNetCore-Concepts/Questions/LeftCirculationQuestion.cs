namespace InterviewPrepration.Questions;

internal static class LeftCirculationQuestion
{
    internal static void LeftCirculation<T>(T[] arr)
    {
        ArgumentNullException.ThrowIfNull(arr, "Input array is null");

        if (arr.Length == 1)
            return;

        T firstValue = arr[0];
        for (int i = 0; i < arr.Length - 1; i++)
            arr[i] = arr[i + 1];

        arr[arr.Length - 1] = firstValue;

        foreach (var item in arr)
            Console.WriteLine(item);
    }
}
