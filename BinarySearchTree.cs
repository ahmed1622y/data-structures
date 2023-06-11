

using System.Drawing;

namespace data_structers
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public Node root = null;
        public int size { get; private set; } = 0;   
        public BinarySearchTree() {}
        public BinarySearchTree(T[] ele) {
            foreach (T item in ele)
            {
                add(item);
            }
        }
        public class Node
        {
            public Node left = null;
            public Node right = null;
            public T value;
            public Node(Node left, Node right, T value)
            {
                this.left = left;
                this.right = right;
                this.value = value;
            }
        }
        public Boolean isEmpty() {
            return size == 0;
        }
        public Boolean add(T value)
        {
            if (contains(value)) return false;
            else
            {
                add(root, value);
                size++;
                return true;
            }
        }
        public Boolean contains(T value)
        {
            return contains(root,value) != null;
        }
        public int height()
        {
            return height(root);
        }
        public Boolean remove(T value)
        {
            if (!contains(value)) return false;
            else
            {
                remove(root, value);
                size--;
                return true;
            }
        }
        private Node remove(Node parent, T value)
        {
            Node CurrentParent = parent;
            while (true)
            {
                int compare = value.CompareTo(parent.value);
                if(compare < 0)
                {
                    CurrentParent = parent;
                    parent = parent.left;
                }
                else if(compare > 0) {
                    CurrentParent = parent;
                    parent = parent.right;
                }
                else
                {
                    if(parent.left != null && parent.right != null)
                    {
                        Node successor = digLeft(parent.right);
                        parent.value = successor.value;
                        parent.right = successor.right;
                        return successor;
                    }
                    else if(parent.left != null)
                    {
                        Node successor = parent.left;
                        CurrentParent.left = successor;
                        return successor;
                    }
                    else
                    {
                        Node successor = parent.right;
                        CurrentParent.right = successor;
                        return successor;
                    }
                }
            }
        }
        private Node add(Node parent, T value)
        {
            if (isEmpty())
            {
                root = new(null, null, value);
            }
            else
            {
                Node currentRoot = parent;
                while (true)
                {
                    int compare = value.CompareTo(currentRoot.value);
                    if (compare < 0)
                    {
                        if (currentRoot.left == null)
                        {
                            currentRoot.left = new(null, null, value);
                            break;
                        }
                        else
                        {
                            currentRoot = currentRoot.left;
                        }
                    }
                    else
                    {
                        if (currentRoot.right == null)
                        {
                            currentRoot.right = new(null, null, value);
                            break;
                        }
                        else
                        {
                            currentRoot = currentRoot.right;
                        }
                    }
                }
            }
            return new(null, null, value);
        }
        private Node contains(Node parent, T elem) {
            if (isEmpty()) return null;
            Node currentRoot = parent;
            while (true)
            {
                int compare = elem.CompareTo(currentRoot.value);
                if (compare == 0)
                {
                    return currentRoot;
                }
                else if(compare < 0)
                {
                    if(currentRoot.left == null)
                    {
                        return null;
                    }
                    else
                    {
                        currentRoot = currentRoot.left;
                    }
                }
                else
                {
                    if (currentRoot.right == null)
                    {
                        return null;
                    }
                    else
                    {
                        currentRoot = currentRoot.right;
                    }
                }
            }
        }
        private int height(Node node)
        {
            return 1;
        }
        private Node digLeft(Node node)
        {
            Node currentNode = node;
            while (true)
            {
                if (currentNode.left == null)
                {
                    break;
                }
                else
                {
                    currentNode = currentNode.left;
                }
            }
            return currentNode;
        }
        private Node digRight(Node node)
        {
            Node currentNode = node;
            while (true)
            {
                if (currentNode.right == null)
                {
                    break;
                }
                else
                {
                    currentNode = currentNode.right;
                }
            }
            return currentNode;
        }

    }
}
