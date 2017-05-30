// ReSharper disable ConvertToAutoProperty

using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public class BinaryTree
    {
        private BinaryTreeNode _rootNode;

        private BinaryTreeNode _superRootNode;

        public BinaryTreeNode RootNode
        {
            get => _rootNode;
            set => _rootNode = value;
        }

        public BinaryTree()
        {
            _rootNode = null;
        }

        public BinaryTree(int key, string value = null)
        {
            _rootNode = new BinaryTreeNode(key, value);
        }

        public int Count => RootNode.Count;

        public void PreOrderTreeTraversal(Action<BinaryTreeNode, BinaryTreeNode> action)
        {
            RootNode.PreOrderTreeTraversal(null, action);
        }

        public void InOrderTreeTraversal(Action<BinaryTreeNode, BinaryTreeNode> action)
        {
            RootNode.InOrderTreeTraversal(null, action);
        }

        public void PostOrderTreeTraversal(Action<BinaryTreeNode, BinaryTreeNode> action)
        {
            RootNode.PostOrderTreeTraversal(null, action);
        }

        public string FindOrAdd(int key, string value = null)
        {
            if (IsEmpty())
            {
                RootNode = new BinaryTreeNode(key, value);
                return value;
            }
            return RootNode.FindOrAdd(key, value);
        }

        public bool IsEmpty()
        {
            return RootNode == null;
        }

        public void Delete(int key)
        {
            if (!IsEmpty())
                RootNode = RootNode.Delete(key);

        }
    }
}