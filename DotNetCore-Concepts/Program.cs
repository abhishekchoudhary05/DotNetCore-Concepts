using DotNetCore_Concepts.Questions.Array;
using DotNetCore_Concepts.Concepts;

namespace DotNetCore_Concepts
{
    /// <summary>Application entry point for the console examples.</summary>
    internal class Program
    {
        /// <summary>Runs the selected missing-number example.</summary>
        static void Main(string[] args)
        {
            // int[] arr = [2, 1, 4, 0, 5, 6];
            // Console.WriteLine("Missing number is : " + MissingNumber.FindNumber(arr));

            // MultiThreading multiThreading = new MultiThreading();
            // multiThreading.RunDemo();

            int[] arr = [0, 9, 0, -3, 0, 1];
            int[] result = MoveZeros.MoveZerosTtEnd(arr);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}

