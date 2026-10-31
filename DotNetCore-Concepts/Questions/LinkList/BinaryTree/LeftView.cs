using DotNetCore_Concepts.Models;

namespace DotNetCore_Concepts.Questions.LinkList.BinaryTree
{
    internal static class LeftView
    {
        internal static List<int> PrintLeftView(TreeNode? root)
        {
            if (root == null)
                return [];

            List<int> result = new List<int>();
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);

            while (nodes.Count != 0)
            {
                result.Add(nodes.Peek().data);

                int size = nodes.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode temp = nodes.Dequeue();

                    if (temp.left != null)
                        nodes.Enqueue(temp.left);

                    if (temp.right != null)
                        nodes.Enqueue(temp.right);
                }
            }

            return result;
        }
    }
}
