using Iterator;
namespace MyQueue
{
    public class MyQueue<T> : Iterator<T>
    {
        public MyQueue() { }
        public MyQueue(T[] items) : base(items)
        {
        }
        public MyQueue(T element)
        {
            enQueue(element);
        }
        public T peek()
        {
            if (isEmpty()) throw new Exception("Queue is Empty");
            return list.peekFirst();
        }
        public T enQueue(T element)
        {
            size++;
            return list.push(element);
        }
        public T deQueue()
        {
            if (isEmpty()) throw new Exception("Queue is Empty");
            return list.popFirst();
        }
    }

}
