namespace DotNetCore_Concepts.Questions.Array
{
    /// <summary>
    /// MaximumSubarray class solves the maximum subarray sum problem.
    /// 
    /// Problem: Given an array of integers, find the contiguous subarray which has the largest sum.
    /// A subarray can be a single element or multiple consecutive elements.
    /// 
    /// Examples:
    /// - [5, -4, -1, -3, 7, -1, 2] → Maximum subarray is [7] with sum = 7
    /// - [-2, 1, -3, 4, -1, 2, 1, -5, 4] → Maximum subarray is [4, -1, 2, 1] with sum = 6
    /// - [-5, -3, -8] → Maximum subarray is [-3] with sum = -3
    /// - [3] → Maximum subarray is [3] with sum = 3
    /// 
    /// Algorithm Approach:
    /// Brute Force - Nested Loop:
    /// 1. For each starting position i, consider all subarrays starting at i
    /// 2. Track the running sum by extending to position j
    /// 3. Keep track of the maximum sum encountered
    /// 4. This ensures we check ALL possible contiguous subarrays
    /// 
    /// Why this works:
    /// - Outer loop: tries each position as a starting point
    /// - Inner loop: extends the subarray by adding next elements one by one
    /// - We capture single elements when tempSum = arr[i]
    /// - We capture multi-element subarrays by accumulating in tempSum
    /// 
    /// Time Complexity: O(n²) where n is the array length
    /// Space Complexity: O(1) - only using constant extra space
    /// 
    /// Alternative: Kadane's Algorithm achieves O(n) with a single pass
    /// </summary>
    internal static class MaximumSubAarray
    {
        /// <summary>
        /// Finds the maximum sum of any contiguous subarray using brute force approach.
        /// 
        /// Algorithm Steps:
        /// 1. Validate input (check for null)
        /// 2. Handle empty array edge case
        /// 3. For each starting position, calculate sums of all subarrays from that position
        /// 4. Track and return the maximum sum found
        /// 
        /// Key Points:
        /// - Single elements are treated as subarrays of length 1
        /// - Handles both positive, negative, and mixed arrays
        /// - Returns the largest sum (even if all numbers are negative)
        /// </summary>
        /// <param name="arr">Input array of integers (can contain positive, negative values, or both)</param>
        /// <returns>The maximum sum of any contiguous subarray</returns>
        /// <exception cref="ArgumentNullException">Thrown if input array is null</exception>
        internal static int FindMaximumSumFromSubarray(int[] arr)
        {
            // Validate input - throw if array is null
            ArgumentNullException.ThrowIfNull(arr);

            // Handle empty array edge case
            if (arr.Length == 0)
                return 0;

            // Initialize with minimum value to ensure any sum is larger
            int maximumSum = int.MinValue;

            // Outer loop: try each position as a starting point of a subarray
            // Loop goes to Length - 1 because the last element is handled separately
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // Initialize tempSum with the current element (single element subarray)
                int tempSum = arr[i];

                // Update maximum with current single element
                // This captures all single-element subarrays
                maximumSum = int.Max(tempSum, maximumSum);

                // Inner loop: extend the subarray by adding elements one by one
                // Start from i+1 and go to the end of the array
                for (int j = i + 1; j < arr.Length; j++)
                {
                    // Add the next element to the running sum
                    tempSum = tempSum + arr[j];

                    // Update maximum sum if current subarray sum is larger
                    maximumSum = int.Max(tempSum, maximumSum);
                }
            }

            // Handle the last element separately
            // The outer loop doesn't start with arr.Length - 1, so check it explicitly
            // This ensures the last single element is considered if it's the maximum
            if (arr[arr.Length - 1] > maximumSum)
                return arr[arr.Length - 1];

            return maximumSum;
        }

        /// <summary>
        /// Finds the maximum sum of any contiguous subarray using Kadane's Algorithm.
        /// This is an OPTIMIZED version with O(n) time complexity.
        /// 
        /// Kadane's Algorithm:
        /// 1. Maintain the maximum sum ending at current position (maxEndingHere)
        /// 2. At each element, decide: extend current subarray or start new one?
        ///    - If maxEndingHere is negative, start fresh (don't extend)
        ///    - If maxEndingHere is positive, extend by adding current element
        /// 3. Track the global maximum seen so far
        /// 
        /// Key Insight:
        /// - A subarray is only worth extending if its sum is positive
        /// - If sum becomes negative, better to start fresh from next element
        /// - This single pass guarantees optimal solution
        /// 
        /// Example: [5, -4, -1, -3, 7, -1, 2]
        /// Position 0 (5):   maxEnding=5,  maxGlobal=5
        /// Position 1 (-4):  maxEnding=max(-4,1)=1, maxGlobal=5
        /// Position 2 (-1):  maxEnding=max(-1,0)=0, maxGlobal=5
        /// Position 3 (-3):  maxEnding=max(-3,-3)=-3, maxGlobal=5
        /// Position 4 (7):   maxEnding=max(7,4)=7, maxGlobal=7
        /// Position 5 (-1):  maxEnding=max(-1,6)=6, maxGlobal=7
        /// Position 6 (2):   maxEnding=max(2,8)=8, maxGlobal=8
        /// Result: 8 (subarray [7, -1, 2])
        /// 
        /// Time Complexity: O(n) - single pass through array
        /// Space Complexity: O(1) - only constant extra space
        /// </summary>
        /// <param name="arr">Input array of integers</param>
        /// <returns>The maximum sum of any contiguous subarray</returns>
        /// <exception cref="ArgumentNullException">Thrown if input array is null</exception>
        internal static int FindMaximumSumFromSubarrayOptimized(int[] arr)
        {
            // Validate input
            ArgumentNullException.ThrowIfNull(arr);

            // Handle empty array
            if (arr.Length == 0)
                return 0;

            // maxEndingHere: maximum sum of subarray ending at current position
            // Initialize with first element
            int maxEndingHere = arr[0];

            // maxSoFar: global maximum sum found so far
            // Initialize with first element
            int maxSoFar = arr[0];

            // Single pass through array starting from second element
            for (int i = 1; i < arr.Length; i++)
            {
                // Decision point: extend current subarray or start fresh?
                // maxEndingHere + arr[i]: extend the subarray
                // arr[i]: start a new subarray
                // Choose whichever gives larger sum
                maxEndingHere = int.Max(arr[i], maxEndingHere + arr[i]);

                // Update global maximum if current ending sum is larger
                maxSoFar = int.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }
    }
}
