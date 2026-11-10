using DotNetCore_Concepts.Models;

namespace DotNetCore_Concepts.Questions.LinkList
{
    /// <summary>
    /// CTCI 2.6 — Palindrome:
    /// Check whether a singly linked list is a palindrome.
    ///
    /// A palindrome reads the same forwards and backwards.
    /// Example:
    ///   1 -> 2 -> 3 -> 2 -> 1  =>  true  (palindrome)
    ///   1 -> 2 -> 3 -> 4 -> 5  =>  false (not a palindrome)
    /// </summary>
    internal static class PalindromeList
    {
        /// <summary>
        /// Checks if the linked list is a palindrome by copying values into a List
        /// and comparing from both ends inward using two pointers.
        ///
        /// Algorithm:
        ///   1. Traverse the linked list and copy all values into a List&lt;int&gt;.
        ///   2. Use two pointers (first at index 0, last at end) to compare values
        ///      moving inward. Return false on the first mismatch.
        ///
        /// Time Complexity:  O(n) — one pass to copy, one pass to compare.
        /// Space Complexity: O(n) — stores all node values in a list.
        /// </summary>
        /// <param name="head">Head node of the linked list.</param>
        /// <returns>True if the list is a palindrome; false if null or not a palindrome.</returns>
        internal static bool IsListPalindrome(Node head)
        {
            if (head == null)
                return false;

            // Copy all node values into a list for random access
            List<int> list = new List<int>();
            Node? current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.next;
            }

            // Compare values from both ends moving inward
            int first = 0, last = list.Count - 1;
            while (first < last)
            {
                if (list[first] != list[last])
                    return false;
                first++;
                last--;
            }

            return true;
        }

        /// <summary>
        /// Checks if the linked list is a palindrome using the reverse-second-half
        /// technique with slow/fast pointers — no extra collection needed.
        ///
        /// Algorithm:
        ///   1. Use slow/fast pointers to find the middle of the list.
        ///      - slow advances 1 step, fast advances 2 steps.
        ///      - When fast reaches the end, slow is at the midpoint.
        ///   2. Reverse the second half of the list in place.
        ///   3. Compare the first half (from head) with the reversed second half.
        ///      Return false on the first mismatch.
        ///
        /// Note: This modifies the original list (the second half is reversed).
        ///       To preserve the list, re-reverse the second half after comparison.
        ///
        /// Time Complexity:  O(n) — three half-list passes (find mid, reverse, compare).
        /// Space Complexity: O(1) — only pointer variables, no extra data structures.
        /// </summary>
        /// <param name="head">Head node of the linked list.</param>
        /// <returns>True if the list is a palindrome; false if null or not a palindrome.</returns>
        internal static bool IsListPalindromeOptimized(Node head)
        {
            if (head == null)
                return false;

            // Step 1: Find the middle using slow/fast pointers
            Node? slow = head;
            Node? fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow?.next;
                fast = fast.next.next;
            }

            // Step 2: Reverse the second half of the list
            Node? prev = null;
            Node? curr = slow;
            while (curr != null)
            {
                Node? nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }

            // Step 3: Compare the first half with the reversed second half
            Node? left = head;
            Node? right = prev; // prev is the head of the reversed second half
            while (right != null)
            {
                if (left?.Data != right.Data)
                    return false;
                left = left?.next;
                right = right.next;
            }

            return true;
        }
    }
}
