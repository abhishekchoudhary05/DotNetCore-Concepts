namespace InterviewPrepration.Questions;

internal static class MultiToSingleQuestion
{
    internal static void MultiToSingle(int[,] array)
    {
        int index = 0;
        int width = array.GetLength(0);
        int height = array.GetLength(1);
        int[] single = new int[width * height];

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
