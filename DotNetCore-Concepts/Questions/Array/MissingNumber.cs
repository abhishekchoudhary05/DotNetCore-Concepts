namespace DotNetCore_Concepts.Questions.Array
{
    internal static class MissingNumber
    {
        internal static int FindNumber(int[] arr)
        {
            // [2, 1, 4, 0, 5, 6]
            ArgumentNullException.ThrowIfNull(arr, "input array is null.");

            int[] tempraoryArray = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < tempraoryArray.Length)
                    tempraoryArray[arr[i]] = 1;
            }

            for (int i = 0; i < tempraoryArray.Length; i++)
            {
                if (tempraoryArray[i] == 0)
                    return i;
            }

            return -1;
        }
    }
}
