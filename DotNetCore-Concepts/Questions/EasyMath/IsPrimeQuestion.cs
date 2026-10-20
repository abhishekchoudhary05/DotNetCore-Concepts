namespace DotNetCore_Concepts.Questions.EasyMath;

/// <summary>Contains a primality-checking example.</summary>
internal static class IsPrimeQuestion
{
    /// <summary>Writes whether the supplied integer is prime.</summary>
    internal static void IsPrime(int number)
    {
        if (number <= 1)
        {
            Console.WriteLine("Number is less then equal to One.");
            return;
        }

        int squareRoot = (int)Math.Floor(Math.Sqrt(number));
        // Any composite number has a factor no greater than its square root.
        for (int i = 2; i <= squareRoot; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine($"{number} is not prime");
                return;
            }
        }

        Console.WriteLine($"{number} is prime number");
    }
}
