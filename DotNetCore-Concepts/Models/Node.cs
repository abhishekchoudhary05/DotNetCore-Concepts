namespace DotNetCore_Concepts.Models;

internal class Node
{
    public int Data { get; set; }
    public Node? next;

    public Node(int data)
    {
        this.Data = data;
        this.next = null;
    }
}
