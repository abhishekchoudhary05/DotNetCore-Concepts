namespace DotNetCore_Concepts.Questions.Array
{
    /// <summary>
    /// Provides methods to find the pivot index of an array.
    /// The pivot index is the index where the sum of all elements
    /// to the left equals the sum of all elements to the right.
    /// </summary>
    internal static class PivotIndex
    {
        /// <summary>
        /// Finds the pivot index of the given array using a brute-force O(n²) approach.
        /// For each index, the left and right sums are recalculated from scratch.
        /// </summary>
        /// <param name="arr">The input integer array.</param>
        /// <returns>
        /// The pivot index if one exists; otherwise, -1.
        /// For a single-element array, index 0 is always the pivot (both sides are empty, sum = 0).
        /// </returns>
        internal static int FindPivotIndex(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr);

            // A single element always has an empty left and right side (both sum to 0), so it is always a pivot.
            if (arr.Length == 1)
                return 0;

            // Iterate over every index as a candidate pivot
            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0, rightSum = 0;

                // Sum all elements to the left of index i
                for (int j = 0; j < i; j++)
                    leftSum = leftSum + arr[j];

                // Sum all elements to the right of index i
                for (int j = i + 1; j < arr.Length; j++)
                    rightSum = rightSum + arr[j];

                // If left and right sums are equal, i is the pivot index
                if (leftSum == rightSum)
                    return i;
            }

            // No pivot index found
            return -1;
        }

        /// <summary>
        /// Finds the pivot index of the given array using an optimized O(n) approach.
        /// Precomputes the total sum once, then uses a running left sum to derive
        /// the right sum at each index without an inner loop.
        /// </summary>
        /// <param name="arr">The input integer array.</param>
        /// <returns>
        /// The pivot index if one exists; otherwise, -1.
        /// </returns>
        internal static int FindPivotIndexOptimal(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr);

            // Compute the total sum of the array in a single pass
            int totalSum = 0;
            for (int i = 0; i < arr.Length; i++)
                totalSum += arr[i];

            int leftSum = 0;

            // Iterate through each index as a candidate pivot
            for (int i = 0; i < arr.Length; i++)
            {
                // Derive rightSum in O(1) using: rightSum = totalSum - leftSum - arr[i]
                int rightSum = totalSum - leftSum - arr[i];

                // If left and right sums are equal, i is the pivot index
                if (leftSum == rightSum)
                    return i;

                // Accumulate left sum as we move forward
                leftSum += arr[i];
            }

            // No pivot index found
            return -1;
        }
    }
}
