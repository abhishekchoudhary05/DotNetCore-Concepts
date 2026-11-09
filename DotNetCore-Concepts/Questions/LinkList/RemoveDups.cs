using DotNetCore_Concepts.Models;

namespace DotNetCore_Concepts.Questions.LinkList
{
    internal static class RemoveDups
    {
        /// <summary>
        /// Removes duplicates from an unsorted singly linked list using a hash set buffer.
        /// Preserves the original relative order of elements.
        /// </summary>
        /// <param name="head">The head node of the singly linked list.</param>
        /// <returns>The head node of the linked list with duplicates removed.</returns>
        /// <remarks>
        /// Time Complexity: O(N) — single pass through the list.
        /// Space Complexity: O(N) — auxiliary hash set to store seen values.
        /// </remarks>
        internal static Node? RemoveDupsFromUnsortedArray(Node? head)
        {
            if (head == null)
                return head;

            // Hash set to track values already encountered
            HashSet<int> ints = new HashSet<int>();
            Node? current = head;
            Node? previous = null;

            while (current != null)
            {
                // HashSet.Add returns false if the element already exists in the set
                if (!ints.Add(current.Data))
                {                    
                    // Duplicate found: bypass/unlink the current node from the chain
                    previous?.next = current.next;
                }
                else
                {
                    // First time seeing this value: advance previous to keep this node
                    previous = current;
                }

                // Advance to the next node in the list
                current = current.next;
            }

            return head;
        }

        /// <summary>
        /// Removes duplicates from an unsorted singly linked list without using a temporary buffer.
        /// Uses the runner technique (two pointers) to inspect subsequent nodes in-place.
        /// </summary>
        /// <param name="head">The head node of the singly linked list.</param>
        /// <returns>The head node of the linked list with duplicates removed.</returns>
        /// <remarks>
        /// Time Complexity: O(N^2) — nested traversal comparing each node with all subsequent nodes.
        /// Space Complexity: O(1) — no extra memory allocated; modifies pointers in-place.
        /// </remarks>
        internal static Node? RemoveDupsWithoutBuffer(Node? head)
        {
            if (head == null)
                return head;

            // Outer pointer: iterates through each unique node in the list
            Node? current = head;
            while (current != null)
            {
                // Runner pointer: starts at current and checks all subsequent nodes
                Node runner = current;

                // Inspect runner.next so runner stays at the predecessor of the node being checked
                while (runner.next != null)
                {
                    if (runner.next.Data == current.Data)
                    {
                        // Duplicate found: unlink runner.next by pointing to runner.next.next.
                        // Do not advance runner here, so the new runner.next is validated on the next iteration.
                        runner.next = runner.next.next;
                    }
                    else
                    {
                        // Distinct value: advance runner forward
                        runner = runner.next;
                    }
                }

                // Advance current to inspect the next node
                current = current.next;
            }

            return head;
        }
    }
}
