namespace DotNetCore_Concepts.Models;

/// <summary>Represents one integer node in a singly linked structure.</summary>
internal class Node
{
    public int Data { get; set; }
    public Node? next;

    /// <summary>Creates a node containing the supplied value with no successor.</summary>
    public Node(int data)
    {
        this.Data = data;
        this.next = null;
    }
}
