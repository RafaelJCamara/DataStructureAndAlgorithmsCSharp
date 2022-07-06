using System;
namespace DSA.Trees.BinarySearchTree
{
    public class BST
    {
        public TreeNode Root { get; set; }

        /*
            Time complexity: O(log(n))
         */
        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode
                {
                    Value = value
                };
                return;
            }
            Insert(Root, value);
        }

        private void Insert(TreeNode root, int value)
        {
            if (Root.Value == value) throw new InvalidOperationException("Can't have duplicated values.");
            if (value < root.Value && root.Left == null)
            {
                root.Left = new TreeNode
                {
                    Value = value
                };
                return;
            }
            else if (value > root.Value && root.Right == null)
            {
                root.Right = new TreeNode
                {
                    Value = value
                };
                return;
            }
            if (value < root.Value) Insert(root.Left, value);
            else Insert(root.Right, value);
        }

    }
}