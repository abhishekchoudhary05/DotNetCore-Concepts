using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts
{
    /// <summary>Application entry point for the console examples.</summary>
    internal class Program
    {
        /// <summary>Runs the selected missing-number example.</summary>
        static void Main(string[] args)
        {
            int[] arr = [2, 1, 4, 0, 5, 6];
            Console.WriteLine("Missing number is : " + MissingNumber.FindNumber(arr));
        }
    }
}
