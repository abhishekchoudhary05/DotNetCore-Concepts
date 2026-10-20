namespace DotNetCore_Concepts.Questions.EasyMath;

/// <summary>Contains a decimal digit-summing example.</summary>
internal static class SumOfDigitsQuestion
{
    /// <summary>Writes the sum of a number's decimal digits.</summary>
    internal static void SumOfDigits(int number)
    {
        if (number <= 0)
            Console.WriteLine("Number is less than 1.");

        int sum = 0;
        // The remainder extracts the last digit; integer division removes it for the next iteration.
        while (number != 0)
        {
            sum = sum + (number % 10);
            number = number / 10;
        }

        Console.WriteLine($"Sum of all digit of number is {sum}");
    }
}
