// ReSharper disable ConvertToAutoProperty
// ReSharper disable ConvertToAutoPropertyWhenPossible

using System;

namespace WindowsFormsApplication1
{
    public class BinaryTreeNode
    {
        private int _key;
        private string _value;
        private BinaryTreeNode _left;
        private BinaryTreeNode _right;
        private byte _bp;

        public BinaryTreeNode(int key, string value = null) : this(key, value, null, null)
        { }

        public BinaryTreeNode(int key, string value, BinaryTreeNode left, BinaryTreeNode right)
        {
            _key = key;
            _value = value;
            _left = left;
            _right = right;
            _bp = 0;
        }

        public int Key
        {
            get => _key;
            set => _key = value;
        }

        public string Value
        {
            get => _value;
            set => _value = value;
        }

        public BinaryTreeNode Left
        {
            get => _left;
            set => _left = value;
        }

        public BinaryTreeNode Right
        {
            get => _right;
            set => _right = value;
        }

        public bool IsLeafNode => _right == null && _left == null;

        public int Count => 1 + (_left?.Count ?? 0) + (_right?.Count ?? 0);

        public void PreOrderTreeTraversal(BinaryTreeNode parent, Action<BinaryTreeNode, BinaryTreeNode> action)
        {
            action(parent, this);
            _left?.PreOrderTreeTraversal(this, action);
            _right?.PreOrderTreeTraversal(this, action);
        }

        public void InOrderTreeTraversal(BinaryTreeNode parent, Action<BinaryTreeNode, BinaryTreeNode> action)
        {
            _left?.InOrderTreeTraversal(this, action);
            action(parent, this);
            _right?.InOrderTreeTraversal(this, action);
        }

        public void PostOrderTreeTraversal(BinaryTreeNode parent, Action<BinaryTreeNode, BinaryTreeNode> action)
        {
            _left?.PostOrderTreeTraversal(this, action);
            _right?.PostOrderTreeTraversal(this, action);
            action(parent, this);
        }

        public override string ToString()
        {
            return _key.ToString();
        }

        public string FindOrAdd(int key, string value = null)
        {
            if (key == Key)
                return Value;
            if (key < Key)
            {
                if (Left != null)
                    return Left.FindOrAdd(key, value);
                Left = new BinaryTreeNode(key, value);
            }
            else
            {
                if (Right != null)
                    return Right.FindOrAdd(key, value);
                Right = new BinaryTreeNode(key, value); 
            }
            return value;
        }

        public BinaryTreeNode Delete(int key)
        {
            if (key < Key)
                Left = Left?.Delete(key);
            else if (key > Key)
                Right = Right?.Delete(key);
            else if (Left != null && Right != null)
            {
                var rightMin = Right.Minimun();
                Key = rightMin.Key;
                Value = rightMin.Value;
                Right = Right.Delete(Key);
            }
            else if (Left != null)
                return Left;
            else
                return Right;
            return this;
        }

        public BinaryTreeNode Minimun()
        {
            if (Left == null)
                return this;
            return Left.Minimun();
        }

        public BinaryTreeNode Maximum()
        {
            if (Right == null)
                return this;
            return Right.Maximum();
        }

    }
}