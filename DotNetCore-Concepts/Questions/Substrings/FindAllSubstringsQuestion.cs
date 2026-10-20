namespace DotNetCore_Concepts.Questions.Substrings;

/// <summary>Writes every contiguous substring of an input string.</summary>
internal static class FindAllSubstringsQuestion
{
    /// <summary>Enumerates substrings by increasing length, then by starting position.</summary>
    internal static void FindAllSubstrings(string? str)
    {
        ArgumentNullException.ThrowIfNull(str, "Input string is null");

        for (int i = 1; i <= str.Length; i++)
        {
            for (int j = 0; j <= str.Length - i; j++)
            {
                Console.WriteLine(str.Substring(j, i));
            }
        }
    }
}
