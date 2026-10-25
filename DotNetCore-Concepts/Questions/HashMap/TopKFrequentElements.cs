namespace DotNetCore_Concepts.Questions.HashMap
{
    /// <summary>
    /// Finds the top k most frequent elements in an array.
    /// If two elements have the same frequency, the larger number is given higher priority.
    /// </summary>
    internal static class TopKFrequentElements
    {
        /// <summary>
        /// Returns the top k most frequent elements in descending order of frequency,
        /// breaking ties by selecting the larger number.
        /// </summary>
        /// <param name="arr">Input array of integers.</param>
        /// <param name="k">The number of top frequent elements to return.</param>
        /// <returns>Array containing the top k frequent elements.</returns>
        internal static int[] FindElements(int[] arr, int k)
        {
            ArgumentNullException.ThrowIfNull(arr, "Input array is null");

            if (k <= 0 || arr.Length == 0)
            {
                return [];
            }

            Dictionary<int, int> frequencies = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                frequencies[arr[i]] = frequencies.GetValueOrDefault(arr[i], 0) + 1;
            }

            // Min-heap tracking the top k elements.
            // Priority is (Frequency, Value) so that lower frequency, and on ties smaller value,
            // has lower priority and is evicted first when queue size exceeds k.
            PriorityQueue<int, (int Frequency, int Value)> priorityQueue = new PriorityQueue<int, (int Frequency, int Value)>();
            foreach (var item in frequencies)
            {
                priorityQueue.Enqueue(item.Key, (item.Value, item.Key));
                if (priorityQueue.Count > k)
                {
                    priorityQueue.Dequeue();
                }
            }

            int count = Math.Min(k, priorityQueue.Count);
            int[] result = new int[count];
            for (int i = count - 1; i >= 0; i--)
            {
                result[i] = priorityQueue.Dequeue();
            }

            return result;
        }
    }
}
