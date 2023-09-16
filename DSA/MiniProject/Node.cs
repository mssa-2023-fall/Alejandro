using System.Security.Cryptography;

namespace MiniProject
{
    public class TreeNode
    {
        public TreeNode? Parent;
        public TreeNode? LeftChild;
        public TreeNode? RightChild;
        public bool IsLeaf => RightChild == null && LeftChild == null;
        public bool IsRoot => Parent == null;
        public TreeNode(int value)
        {
            Value = value;
        }


        public TreeNode(int _value, TreeNode _parent, int _level)
        {
            this.Parent = _parent;
            Level = _level;
            Value = _value;
        }
        public int Value { get; }
        public int Level { get; set; }


        public TreeNode createBST(int[] array)
        {
            Array.Sort(array);
            return BalanceTree(array, 0, array.Length - 1);
        }

        public TreeNode BalanceTree(int[] array, int start, int end)
        {

            if (array == null || array.Length == 0 || start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode root = new TreeNode(array[mid]);

            root.LeftChild = (BalanceTree(array, start, mid - 1));
            root.RightChild = (BalanceTree(array, mid + 1, end));

            return root;
        }

    }
}