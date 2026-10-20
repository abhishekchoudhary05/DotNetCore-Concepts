namespace DotNetCore_Concepts.Questions.Array
{
    /// <summary>Finds a missing value from the expected zero-based range.</summary>
    internal static class MissingNumber
    {
        /// <summary>Returns the first absent value in the range from zero to array length minus one.</summary>
        internal static int FindNumber(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr, "input array is null.");

            int[] tempraoryArray = new int[arr.Length];

            // Mark in-range values as present; the marker array lets the next pass find the first gap.
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
