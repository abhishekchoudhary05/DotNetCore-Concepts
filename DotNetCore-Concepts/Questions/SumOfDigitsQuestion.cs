namespace InterviewPrepration.Questions;

internal static class SumOfDigitsQuestion
{
    internal static void SumOfDigits(int number)
    {
        if (number <= 0)
            Console.WriteLine("Number is less than 1.");

        int sum = 0;
        while (number != 0)
        {
            sum = sum + (number % 10);
            number = number / 10;
        }

        Console.WriteLine($"Sum of all digit of number is {sum}");
    }
}
