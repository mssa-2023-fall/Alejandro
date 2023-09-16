using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public class BinaryTree
    {
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
