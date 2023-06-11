
namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node head, tail;
        public int size { get; private set; } = 0;
        public DoublyLinkedList() { }
        public DoublyLinkedList(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                this.push(items[i]);
            }
        }
        private class Node
        {
            public T data;
            public Node next, prev;
            public Node(T data, Node next, Node prev)
            {
                this.data = data;
                this.next = next;
                this.prev = prev;
            }
        }
        public Boolean isEmpty()
        {
            return size == 0;
        }
        public T peekFirst()
        {
            if (isEmpty()) throw new Exception("List is Empty");
            return head.data;
        }
        public T peekLast()
        {
            if (isEmpty()) throw new Exception("List is Empty");
            return tail.data;
        }
        public T push(T item)
        {
            return addLast(item);
        }
        public T shift(T item)
        {
            return addFirst(item);
        }
        public T pop()
        {
            if (isEmpty()) throw new Exception("List is Empty");
            T removed = tail.data;
            tail = tail.prev;
            size--;
            if (isEmpty()) head = null;
            else tail.next = null;
            return removed;
        }
        public T popFirst()
        {
            if (isEmpty()) throw new Exception("List is Empty");
            T removed = head.data;
            head = head.next;
            size--;
            if (isEmpty()) tail = null;
            else head.prev = null;
            return removed;
        }
        public T removeAt(int index)
        {
            if (index < 0 || index >= size) throw new ArgumentException("out of size");
            Node trav;
            if (index < size / 2)
            {
                trav = head;
                for (int i = 0; i != index; i++)
                {
                    trav = trav.next;
                }
            }
            else
            {

                trav = tail;
                for (int i = size - 1; i != index; i--)
                {
                    trav = trav.prev;
                }
            }
            return remove(trav);
        }
        public Boolean remove(T data)
        {
            Boolean removed = false;
            Node trav = head;
            if (isEmpty()) return removed;
            for (trav = head; trav != null; trav = trav.next)
            {
                if (trav.data.Equals(data))
                {
                    remove(trav);
                    removed = true;
                }
            }
            return removed;
        }
        public int indexOf(T data)
        {
            Node trav;
            int index = -1;
            for (trav = head; trav != null; trav = trav.next)
            {
                index++;
                if (trav.data.Equals(data)) return index;
            }
            return -1;
        }
        public Boolean contains(T data)
        {
            return indexOf(data) != -1;
        }
        public void clear()
        {
            Node trav = head;
            while (trav != null)
            {
                Node next = trav.next;
                trav = null;
                trav = next;
                size--;
            }
        }
        public string stringify()
        {
            string stringified = "{";
            Node trav = this.head;
            int i = 1;

            while (trav != null)
            {
                Node next = trav.next;
                stringified += "\"" + trav.data + "\"";
                if (i != size) stringified += ", ";
                else stringified += "}";
                trav = next;
                i++;
            }

            if (size == 0) stringified = "{}";
            return stringified;
        }
        public void forEach(Action<T, int> callback)
        {
            int i = 0;
            for (Node trav = head; trav != null; trav = trav.next, i++)
            {
                callback(trav.data, i);
            }
        }
        private T remove(Node node)
        {
            if (node.next == null) return pop();
            if (node.prev == null) return popFirst();

            node.next.prev = node.prev;
            node.prev.next = node.next;

            T removed = node.data;

            node = null;
            size--;

            return removed;
        }
        private T addLast(T item)
        {
            if (isEmpty())
            {
                head = tail = new Node(item, null, null);
            }
            else
            {
                tail.next = new Node(item, null, tail);
                tail = tail.next;
            }
            size++;
            return item;
        }
        private T addFirst(T item)
        {
            if (isEmpty())
            {
                head = tail = new Node(item, null, null);
            }
            else
            {
                head.prev = new Node(item, head, null);
                head = head.prev;
            }
            size++;
            return item;
        }

    }
}
