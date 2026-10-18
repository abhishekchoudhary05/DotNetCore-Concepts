namespace InterviewPrepration.Concepts;

internal class Constructor
{
    internal static string message = string.Empty;

    internal Constructor()
    {
        Console.WriteLine("This is default constructor");
    }

    internal Constructor(string input)
    {
        Console.WriteLine("This is parameterized constructor.");
    }

    static Constructor()
    {
        message = "Static Constructor.";
        Console.WriteLine($"This is {message}");
    }

    private Constructor(int number)
    {
        Console.WriteLine("This is private constructor");
    }

    static void ShowMessage()
    {
        Console.WriteLine("This is ShowMessage method. It is static method");
    }
}
