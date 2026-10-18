namespace InterviewPrepration.Questions;

internal static class IsPrimeQuestion
{
    internal static void IsPrime(int number)
    {
        if (number <= 1)
        {
            Console.WriteLine("Number is less then equal to One.");
            return;
        }

        int squareRoot = (int)Math.Floor(Math.Sqrt(number));
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
