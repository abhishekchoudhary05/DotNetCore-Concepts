namespace DotNetCore_Concepts.Questions.Array
{
    /// <summary>Finds array elements greater than every element to their right.</summary>
    internal static class FindLeaders
    {
        /// <summary>Returns leader values in their original left-to-right order.</summary>
        internal static int[] FindLeadersInArray(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr, "Input array is null");

            if (arr.Length == 0)
                return [];

            List<int> results = new List<int>();
            int leader = arr[^1];

            results.Add(leader);
            // Scanning right to left keeps the greatest value seen so far as the leader threshold.
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > leader)
                {
                    results.Add(arr[i]);
                    leader = arr[i];
                }
            }

            results.Reverse();
            return [.. results];
        }
    }
}
