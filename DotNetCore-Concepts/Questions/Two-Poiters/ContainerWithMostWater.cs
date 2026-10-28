namespace DotNetCore_Concepts.Questions.Array
{
    internal static class ContainerWithMostWater
    {
        internal static long FindMaximum(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr);

            if (arr.Length < 2)
            {
                return 0;
            }

            int left = 0, right = arr.Length - 1;
            long maximumWater = 0;
            while (left < right)
            {
                long maximum = (long)(right - left) * int.Min(arr[left], arr[right]);
                if (maximum > maximumWater)
                {
                    maximumWater = maximum;
                }
                if (arr[left] < arr[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maximumWater;
        }
    }
}
