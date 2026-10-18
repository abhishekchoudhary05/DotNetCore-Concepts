namespace InterviewPrepration.Questions;

internal static class RemoveDuplicateCharactersQuestion
{
    internal static void RemoveDuplicateCharacters(string? str)
    {
        ArgumentNullException.ThrowIfNull(str, "Input string is null");

        // "Welcome to CSharp Corner."
        string result = string.Empty;
        for (int i = 0; i < str.Length; i++)
        {
            if (!result.Contains(str[i]))
            {
                result = result + str[i];
            }
        }
        Console.WriteLine($"Result : {result}");
    }
}
