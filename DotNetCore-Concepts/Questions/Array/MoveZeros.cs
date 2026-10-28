namespace DotNetCore_Concepts.Questions.Array;

internal static class MoveZeros
{
    internal static int[] MoveZerosToEnd(int[] arr)
    {
        ArgumentNullException.ThrowIfNull(arr);

        int insertPos = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                if (i != insertPos)
                {
                    int temp = arr[insertPos];
                    arr[insertPos] = arr[i];
                    arr[i] = temp;
                }
                insertPos++;
            }
        }

        return arr;
    }
}