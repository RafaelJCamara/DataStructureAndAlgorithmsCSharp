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
            return root.Value > value ? Find(root.Left, value) : Find(root.Right, value);
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
        }

        private void PreOrderTraversal(TreeNode root)
        {
            if (root == null) return;
            Console.WriteLine(root.Value);
            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
        }

        private void InOrderTraversal(TreeNode root)
        {
            if (root == null) return;
            InOrderTraversal(root.Left);
            Console.WriteLine(root.Value);
            InOrderTraversal(root.Right);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
        }

        private void PostOrderTraversal(TreeNode root)
        {
            if (root == null) return;
            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.WriteLine(root.Value);
        }

        public void LevelOrderTraversal()
        {
            for(int i = 0; i <= Height();i++)
            {
                var nodes = GetNodesAtDistanceFromRoot(i);
                foreach(var value in nodes)
                {
                    Console.WriteLine($"Level {i}: {value}");
                }
            }
        }

        public int Height()
        {
            if (Root == null) throw new InvalidOperationException("There are no nodes!");
            return Height(Root);
        }

        private int Height(TreeNode root)
        {
            if (root==null || root.Left == null && root.Right == null) return 0;
            return 1 + Math.Max(Height(root.Left), Height(root.Right));
        }

        public List<int> GetNodesAtDistanceFromRoot(int distance)
        {
            if (distance < 0) throw new ArgumentException("Please insert distance from 0 onwards!");
            if(Root==null) throw new InvalidOperationException("There are no nodes!");
            var nodeList = new List<int>();
            GetNodesAtDistanceFromRoot(Root, distance, nodeList);
            return nodeList;
        }

        private void GetNodesAtDistanceFromRoot(TreeNode root, int distance, List<int> currentNodes)
        {
            if (root == null) return;
            if (distance == 0)
            {
                currentNodes.Add(root.Value);
                return;
            }
            GetNodesAtDistanceFromRoot(root.Left, distance -1, currentNodes);
            GetNodesAtDistanceFromRoot(root.Right, distance - 1, currentNodes);
        }

        public int CountLeaves()
        {
            return CountLeaves(Root);
        }

        public int CountLeaves(TreeNode root)
        {
            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return 1;
            return CountLeaves(root.Left) + CountLeaves(root.Right);
        }

        public int Size()
        {
            return Size(Root);
        }

        public int Size(TreeNode root)
        {
            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return 1;
            return 1 + Size(root.Left) + Size(root.Right);
        }

        public int Max()
        {
            if (Root == null) throw new InvalidOperationException("Root is null!");
            return Max(Root.Right);
        }

        public int Max(TreeNode root)
        {
            if (root.Right==null) return root.Value;
            return Max(Root.Right);
        }

    }
}