namespace DotNetCore_Concepts.Questions.Array
{
    internal static class RotateAraay
    {
        // time complexity - O(n*k)
        internal static int[] RotateArrayByKTimes(int[] arr, int k)
        {
            ArgumentNullException.ThrowIfNull(arr);

            if (arr.Length == 0 || arr.Length == 1 || k == 0)
                return arr;
            if (k > arr.Length)
                k = k % arr.Length;

            while (k > 0)
            {
                int temp = arr[arr.Length - 1];

                for (int i = arr.Length - 1; i > 0; i--)
                    arr[i] = arr[i - 1];

                arr[0] = temp;
                k--;
            }

            return arr;
        }

        // time complexity - O(n) using reversal algorithm
        // space complexity - O(1)
        internal static int[] RotateArrayByKTimesOptimized(int[] arr, int k)
        {
            ArgumentNullException.ThrowIfNull(arr);

            if (arr.Length == 0 || arr.Length == 1 || k == 0)
                return arr;

            k = k % arr.Length;

            // Step 1: Reverse entire array
            Reverse(arr, 0, arr.Length - 1);

            // Step 2: Reverse first k elements
            Reverse(arr, 0, k - 1);

            // Step 3: Reverse remaining elements
            Reverse(arr, k, arr.Length - 1);

            return arr;
        }

        private static void Reverse(int[] arr, int start, int end)
        {
            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }
    }
}
