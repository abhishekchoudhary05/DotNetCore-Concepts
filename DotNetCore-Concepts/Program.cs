using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;

namespace DotNetCore_Concepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(1);
            head.next = new Node(3);
            head.next.next = new Node(4);

            head.next.next.next = head.next;

            if (FindCycles.DetectCycles(head))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
}
