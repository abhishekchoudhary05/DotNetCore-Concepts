namespace InterviewPrepration.Questions;

/// <summary>Contains a routine for removing repeated characters from a string.</summary>
internal static class RemoveDuplicateCharactersQuestion
{
    /// <summary>Writes each character's first occurrence, retaining the original order.</summary>
    internal static void RemoveDuplicateCharacters(string? str)
    {
        ArgumentNullException.ThrowIfNull(str, "Input string is null");

        // "Welcome to CSharp Corner."
        string result = string.Empty;
        // Append only unseen characters; Contains keeps the first occurrence and its position.
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
