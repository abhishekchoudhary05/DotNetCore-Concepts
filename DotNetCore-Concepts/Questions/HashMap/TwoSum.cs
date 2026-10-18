namespace DotNetCore_Concepts.Questions.HashMap;

internal static class TwoSum
{
    internal static int[] FindElements(int[] arr, int target)
    {
        ArgumentNullException.ThrowIfNull(arr);

        Dictionary<int, int> pairs = new Dictionary<int, int>();
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
