using DynamicArray;
using System;
using System.ComponentModel;

namespace PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable
    {
        public int heapSize { get; private set; } = 0;
        private int heapCapicty = 0;
        private DynamicArray<T> heap = new DynamicArray<T>(1);
        private Dictionary<T, DynamicArray<int>> map = new Dictionary<T, DynamicArray<int>>();

        public PriorityQueue() { }
        public PriorityQueue(int size) {
            heap = new DynamicArray<T>(size);
            heapSize = size;
        }
        public PriorityQueue(T[] elems) {
            foreach (T elem in elems)
            {
                add(elem);
            }
        }

        public void add(T ele)
        {
            if(heapSize < heapCapicty)
            {
                heap[heapSize] = ele;
            }
            else
            {
                heap.push(ele);
                heapCapicty++;
            }
            mapAdd(ele, heapSize);
            swim(heapSize);
            heapSize++;
        }
        public Boolean isEmpty()
        {
            return heapSize == 0;
        }
        public void clear(){
            heap = heap.filter((T _ ,int _) => {
                return false;
            });
            heapSize = 0;
            map.Clear();
        }
        public T peek()
        {
            if (isEmpty()) throw new Exception("PQ Is Empty");
            return heap.peek();

        }
        public T poll()
        {
            return removeAt(0);
        }
        public Boolean isMinHeap(int parent = 0)
        {
            if (parent >= heapSize) return true;
            
            int left = parent  * 2 + 1;
            int right = parent * 2 + 2;

            if (left < heapSize && less(left, parent)) return false;
            if (right < heapSize && less(right, parent)) return false;
                
            return isMinHeap(left) && isMinHeap(right);

        }
        public Boolean contains(T key)
        {
            return map.ContainsKey(key);
        }
        public string stringify()
        {
            return heap.stringify();
        }
        public T[] toArray()
        {
            T[] heapArray = new T[heapSize];
            heap.forEach((T el, int index) => {
                heapArray[index] =  el;
            });
            return heapArray;
        }
        private Boolean less(int i,int j ) {
            T node1 = heap[i];
            T node2 = heap[j];
            return node1.CompareTo(node2) <= 0;
        }
        private void swim(int k) {
            int parent = (k - 1) / 2;

            while (k > 0 && less(k, parent)) {
                swap(parent, k);
                k = parent;
                parent = (k - 1) / 2;
            }
        }
        private void sink(int parent)
        {
            if (parent >= heapSize) return;
            
            int leftChild = parent * 2 + 1;
            int rightChild = parent * 2 + 2;
            int lessChild = leftChild;

            if (rightChild < heapSize && less(rightChild, lessChild))
                lessChild = rightChild;


            if (lessChild < heapSize && less(lessChild, parent))
            {
                swap(lessChild, parent);
                sink(lessChild);
            }
        }
        private void swap(int i, int j)
        {
            T node1 = heap[i];
            T node2 = heap[j];
            heap[i] = node2;
            heap[j] = node1;
            mapSwap(node1, node2, i, j);
        }
        public Boolean remove(T elem) {
            if (!contains(elem)) return false;
            removeAt(map[elem][0]);
            return true;
        }
        private T removeAt(int i)
        {
            if (isEmpty()) return default(T);
            heapSize--;

            T removedNode = heap[i];

            mapRemove(heap[heapSize], heapSize);
            swap(i, heapSize);
            heap.pop();

            if (i == heapSize) return removedNode;
            T elem = heap[i];
            sink(i);
            if (heap[i].Equals(elem)) swim(i);
            return removedNode;
        }
        private void mapAdd(T value, int index)
        {
            try
            {
                DynamicArray<int> set = map[value];
                set.push(index);
                map[value] = set;
            }
            catch (KeyNotFoundException)
            {
                map.Add(value, new DynamicArray<int>(new int[1] { index }));
            }
        }
        private void mapRemove(T value, int index) {
            try
            {
                DynamicArray<int> removed = map[value];
                if (removed.length == 1) map.Remove(value);
                else
                {
                    removed.filter((int ele, int _) => {
                        if (ele == index) return false;
                        else return true;
                    });
                }
            }
            catch (KeyNotFoundException)
            {
                //throw new Exception("Keys Not Exist");
            }
        }
        private void mapSwap(T val1, T val2, int index1, int index2) {
            try
            {
                DynamicArray<int> set1 = map[val1];
                DynamicArray<int> set2 = map[val2];
                set2 = set2.map((int el,int _) => {
                    if (el == index2) return index1;
                    else return el;
                });
                set1 = set1.map((int el, int _) =>
                {
                    if (el == index1) return index2;
                    else return el;
                });
                map[val1] = set1;
                map[val2] = set2;
            }
            catch (KeyNotFoundException)
            {
                //throw new Exception("Keys Not Exist");
            }
        }
    }
}
