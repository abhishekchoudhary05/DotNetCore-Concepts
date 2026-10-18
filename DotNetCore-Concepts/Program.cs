using DotNetCore_Concepts.Questions.HashMap;

namespace DotNetCore_Concepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = [2, 7, 11, 15];
            int[] result = TwoSum.FindElements(arr, 9);
            Console.WriteLine("Result is");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
