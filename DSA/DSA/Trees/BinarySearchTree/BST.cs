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
            var newNode = new TreeNode { Value = value };
            if (value < root.Value)
            {
                if (root.Left == null) root.Left = newNode;
                else Insert(root.Left, value);
            }
            else if (value > root.Value )
            {
                if (root.Right == null) root.Right = newNode;
                else Insert(root.Right, value);
            }
        }

        /*
            Time complexity: O(log(n))
        */
        public bool Find(int value)
        {
            return Root == null ? false : Find(Root, value);
        }

        private bool Find(TreeNode root, int value)
        {
            if (root == null) return false;
            if (root.Value == value) return true;
            return root.Value > value ? Find(root.Left, value) : Find(root.Left, value);
        }

    }
}