namespace DotNetCore_Concepts.Questions.Array
{
    internal static class MaximumProfit
    {
        internal static int FindMaximumProfit(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr, "Input array is null");

            int minimum = int.MaxValue;
            int maximum = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > maximum)
                {
                    maximum = arr[i];
                }
                if (arr[i] < minimum)
                {
                    minimum = arr[i];
                }
            }


            return maximum - minimum;
        }
    }
}
