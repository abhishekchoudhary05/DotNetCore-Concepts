namespace DotNetCore_Concepts.Questions.Array
{
    internal static class FindLeaders
    {
        internal static int[] FindLeadersInArray(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr, "Input array is null");

            if (arr.Length == 0)
                return [];

            List<int> results = new List<int>();
            int leader = arr[^1];

            results.Add(leader);
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
