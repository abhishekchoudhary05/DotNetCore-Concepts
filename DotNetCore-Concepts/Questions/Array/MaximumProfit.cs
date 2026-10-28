namespace DotNetCore_Concepts.Questions.Array
{
    internal static class MaximumProfit
    {
        internal static long FindMaximumProfit(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr, "Input array is null");

            if (arr.Length < 2)
            {
                return 0;
            }

            int minimumPrice = arr[0];
            long maximumProfit = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                long profit = (long)arr[i] - minimumPrice;
                if (profit > maximumProfit)
                {
                    maximumProfit = profit;
                }

                if (arr[i] < minimumPrice)
                {
                    minimumPrice = arr[i];
                }
            }

            return maximumProfit;
        }
    }
}
