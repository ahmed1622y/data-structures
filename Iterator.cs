

using DoublyLinkedList;
namespace Iterator
{
    public class Iterator<T>
    {
        public int size { get; protected set; } = 0;
        protected DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public Iterator()
        { }
        public Iterator(T[] items)
        {
            foreach (T item in items)
            {
                list.push(item);
                size++;
            }
        }
        public Boolean isEmpty()
        {
            return this.size == 0;
        }
        public void forEach(Action<T, int> callback)
        {
            list.forEach(callback);
        }
        public string stringify()
        {
            return list.stringify();
        }
    }

}
