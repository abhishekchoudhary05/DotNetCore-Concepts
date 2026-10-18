namespace InterviewPrepration.Questions;

internal static class OccurrenceOfCharactersQuestion
{
    internal static void OccuranceOfCharacters(string? str)
    {
        ArgumentNullException.ThrowIfNull(str, "Input string is null");

        // "Welcome to CSharp Corner."
        Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

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
