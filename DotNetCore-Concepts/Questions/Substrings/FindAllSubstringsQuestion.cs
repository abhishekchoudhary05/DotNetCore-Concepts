namespace DotNetCore_Concepts.Questions.Substrings;

internal static class FindAllSubstringsQuestion
{
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
