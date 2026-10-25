namespace DotNetCore_Concepts.Questions.Array
{
    internal static class MoveZeros
    {
        internal static int[] MoveZerosTtEnd(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr, "Input array is null");

            // [0,1,0,3,12]
            int nonZeroIndex = 1;
            int i = 0;
            while (i < arr.Length && nonZeroIndex < arr.Length)
            {
                if (arr[i] != 0)
                {
                    i++;
                    nonZeroIndex++;
                }
                else if (arr[i] == 0 && arr[nonZeroIndex] != 0)
                {
                    int temp = arr[i];
                    arr[i] = arr[nonZeroIndex];
                    arr[nonZeroIndex] = temp;
                    i++;
                    nonZeroIndex++;
                }
                else if (arr[nonZeroIndex] == 0)
                {
                    nonZeroIndex++;
                }
            }

            return arr;
        }
    }
}
