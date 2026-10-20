namespace InterviewPrepration.Concepts;

/// <summary>Demonstrates static, default, parameterized, and private constructors.</summary>
internal class Constructor
{
    internal static string message = string.Empty;

    /// <summary>Creates an instance using the parameterless constructor.</summary>
    internal Constructor()
    {
        Console.WriteLine("This is default constructor");
    }

    /// <summary>Creates an instance using a string parameter.</summary>
    internal Constructor(string input)
    {
        Console.WriteLine("This is parameterized constructor.");
    }

    // The runtime calls the static constructor once before the type is first used.
    static Constructor()
    {
        message = "Static Constructor.";
        Console.WriteLine($"This is {message}");
    }

    /// <summary>Shows that a private constructor restricts construction to this type.</summary>
    private Constructor(int number)
    {
        Console.WriteLine("This is private constructor");
    }

    static void ShowMessage()
    {
        Console.WriteLine("This is ShowMessage method. It is static method");
    }
}
