using DotNetCore_Concepts.Models;

namespace DotNetCore_Concepts.Questions.LinkList
{
    internal static class FindCycles
    {
        internal static bool DetectCycles(Node start)
        {
            ArgumentNullException.ThrowIfNull(start, "starting node is null");

            Node? slow = start;
            Node? fast = start;

            // Use Floyd's Tortoise and Hare algorithm safely by
            // checking fast and fast.next before advancing.
            while (fast != null && fast.next != null)
            {
                slow = slow!.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }

            return false;
        }
    }
}
