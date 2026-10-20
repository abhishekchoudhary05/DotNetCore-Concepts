namespace InterviewPrepration.Questions;

/// <summary>Counts how many times each character appears in a string.</summary>
internal static class OccurrenceOfCharactersQuestion
{
    /// <summary>Writes one count for each distinct character in the input.</summary>
    internal static void OccuranceOfCharacters(string? str)
    {
        ArgumentNullException.ThrowIfNull(str, "Input string is null");

        // "Welcome to CSharp Corner."
        Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

        // Build the frequency table in one pass, creating a count on first sight.
        for (int i = 0; i < str.Length; i++)
        {
            if (keyValuePairs.ContainsKey(str[i]))
                keyValuePairs[str[i]]++;
            else
                keyValuePairs.Add(str[i], 1);
        }

        foreach (var item in keyValuePairs)
            Console.WriteLine($"Character : {item.Key} count : {item.Value}");
    }
}
