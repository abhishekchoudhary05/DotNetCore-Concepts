namespace DotNetCore_Concepts.Questions.HashMap;

/// <summary>Finds a pair of array entries that add to a target value.</summary>
internal static class TwoSum
{
    /// <summary>Returns the indices of the first discovered pair, or [0, 0] if none exists.</summary>
    internal static int[] FindElements(int[] arr, int target)
    {
        ArgumentNullException.ThrowIfNull(arr);

        Dictionary<int, int> pairs = new Dictionary<int, int>();
        // Store prior values so each new value can be checked against its needed complement in O(1) average time.
        for (int i = 0; i < arr.Length; i++)
        {
            int complement = target - arr[i];
            if (pairs.ContainsKey(complement))
            {
                return [pairs[complement], i];
            }
            else
            {
                // store value -> index
                pairs[arr[i]] = i;
            }
        }
        return [0, 0];
    }
}
