using DotNetCore_Concepts.Models;

namespace DotNetCore_Concepts.Questions.LinkList
{
    internal static class IntersectionOfTwoLinkedList
    {
        // time complexicity : O(n + m)
        internal static Node? FindIntersection(Node start1, Node start2)
        {
            ArgumentNullException.ThrowIfNull(start1);
            ArgumentNullException.ThrowIfNull(start2);

            int length1 = 0, length2 = 0;
            Node? temp = start1;
            while (temp != null)
            {
                length1++;
                temp = temp.next;
            }

            temp = start2;
            while (temp != null)
            {
                length2++;
                temp = temp.next;
            }

            Node? curr1 = start1;
            Node? curr2 = start2;

            if (length1 > length2)
            {
                int diff = length1 - length2;
                while (diff > 0 && curr1 != null)
                {
                    curr1 = curr1?.next;
                    diff--;
                }
            }
            else
            {
                int diff = length2 - length1;
                while (diff > 0 && curr2 != null)
                {
                    curr2 = curr2?.next;
                    diff--;
                }
            }

            while (curr1 != null && curr2 != null)
            {
                if (curr1 == curr2)
                    return curr1;

                curr1 = curr1.next;
                curr2 = curr2.next;
            }

            return null;
        }
    }
}
