
using Iterator;
namespace MyStack
{
   public class MyStack<T> : Iterator<T>
    {
        public MyStack() { }
        public MyStack(T[] items) : base(items)
        {
        }
        public MyStack(T item)
        {
            push(item);
        }
        public T peek()
        {
            if (isEmpty()) throw new Exception("Stack is Empty");
            return list.peekLast();
        }
        public T push(T item)
        {
            size++;
            return list.push(item);
        }
        public T pop()
        {
            if (isEmpty()) throw new Exception("Stack is Empty");
            size--;
            return list.pop();
        }
    }
}
