using DotNetCore_Concepts.Questions.Array;
using DotNetCore_Concepts.Concepts;
using DotNetCore_Concepts.Questions.HashMap;

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

            int[] arr = [1, 4, 1, 2, 1, 3, 2, 4];
            int[] result = TopKFrequentElements.FindElements(arr, 2);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}

