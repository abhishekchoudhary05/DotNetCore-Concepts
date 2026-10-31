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
            string input = "Mr John Smith";
            string result = input.Replace(" ", "%20");
            Console.WriteLine(result);
        }
    }
}

