
namespace DynamicArray
{
    public class DynamicArray<T>
    {
        public int length { get; private set; } = 0;
        private int capicty;
        private T[] array;
        public DynamicArray()
        {
            this.capicty = 1;
            this.array = new T[1];
        }

        public DynamicArray(int size)
        {
            if (size == 0) size = 1;
            this.capicty = size;
            this.array = new T[size];
        }
        public DynamicArray(T[] items)
        {
            int size = items.Length;
            if (items.Length == 0) size = 1;
            size *= 2;
            this.capicty = size;
            this.array = new T[size];
            foreach (T item in items)
            {
                this.push(item);
            }
        }
        public T this[int index]
        {
            get
            {
                return indexOf(index);
            }
            set
            {
                updateAt(index, value);
            }

        }
        public T push(T element)
        {
            if (length >= capicty)
            {
                capicty *= 2;
                T[] newArray = new T[capicty];

                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
                array[length] = element;
                length++;
            }
            else
            {
                array[length] = element;
                length++;
            }
            return element;
        }
        public T pop()
        {
            T removeEl = array[length - 1];
            T[] newArray = new T[capicty];
            for (int i = 0; i < length - 1; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
            length--;
            return removeEl;
        }
        public T peek()
        {
            return array[0];
        }
        public T shift(T element)
        {

            if (length >= capicty) capicty *= 2;
            T[] newArray = new T[capicty];
            newArray[0] = element;
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i + 1] = array[i];
            }
            array = newArray;
            length++;
            return element;
        }
        public T remove(T removedElement)
        {
            T[] newArray = new T[capicty];
            int j = 0;
            for (int i = 0; i < length; i++, j++)
            {
                T el = array[i];
                if (el != null && el.Equals(removedElement))
                {
                    j--;
                    continue;

                }
                newArray[j] = array[i];

            }
            array = newArray;
            length--;
            return removedElement;
        }
        public T removeAt(int index)
        {
            T removedElement = array[index];
            remove(array[index]);
            return removedElement;
        }
        public Boolean contains(T element)
        {
            Boolean contain = false;
            for (int i = 0; i < length; i++)
            {
                T el = array[i];
                if (el != null && el.Equals(element))
                {
                    contain = true;
                    break;
                }

            }
            return contain;
        }
        public string stringify()
        {
            return stringify(array, length);
        }
        public T find(Func<T, int, Boolean> callback) {
            T foundedItem = default(T);
            for (int i = 0; i < length; i++)
            {
                if (callback(array[i], i))
                {
                    foundedItem = array[i];
                }
            }
            return foundedItem;
        }
        public DynamicArray<T> filter(Func<T, int, Boolean> callback)
        {
            DynamicArray<T> newList = new DynamicArray<T>(capicty);
            for (int i = 0; i < length; i++)
            {
                if (callback(array[i], i))
                {
                    newList.push(array[i]);
                }
            }
            return newList;
        }

        public DynamicArray<T> map(Func<T, int, T> callback)
        {
            DynamicArray<T> newList = new DynamicArray<T>(capicty);
            for (int i = 0; i < length; i++)
            {
                if (callback(array[i], i) == null) continue;
                newList.push(callback(array[i], i));
            }
            return newList;
        }
        public void forEach(Action<T, int> callback)
        {
            for (int i = 0; i < length; i++)
            {
                callback(array[i], i);
            }
        }
        private string stringify(T[] data, int legnth)
        {
            string stringified = "[";
            for (int i = 0; i < legnth; i++)
            {
                stringified += "\"" + data[i] + "\"";
                if (i != legnth - 1) stringified += ", ";
                else stringified += "]";
            }
            if (legnth == 0) stringified = "[]";
            return stringified;
        }
        private T indexOf(int index)
        {
            if (index > length - 1) throw new IndexOutOfRangeException();
            return array[index];
        }
        private void updateAt(int index, T value)
        {
            if (index > length - 1) throw new IndexOutOfRangeException();
            array[index] = value;
        }
    }

}
