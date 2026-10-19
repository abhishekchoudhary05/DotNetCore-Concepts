using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = [2, 1, 4, 0, 5, 6];
            Console.WriteLine("Missing number is : " + MissingNumber.FindNumber(arr));
        }
    }
}
