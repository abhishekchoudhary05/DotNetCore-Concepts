namespace InterviewPrepration.Questions;

/// <summary>Contains an example of traversing a two-dimensional array into a flat sequence.</summary>
internal static class MultiToSingleQuestion
{
    /// <summary>Copies values column by column (the first dimension varies fastest) and writes them.</summary>
    internal static void MultiToSingle(int[,] array)
    {
        int index = 0;
        int width = array.GetLength(0);
        int height = array.GetLength(1);
        int[] single = new int[width * height];

        // Visit each coordinate once and use index as the next flat-array position.
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                single[index] = array[x, y];
                Console.Write(single[index] + " ");
                index++;
            }
        }
    }
}
