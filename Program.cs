using PriorityQueue;
using data_structers;
namespace DataStructures

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[6] { 10, 12, 8, 6, 15, 9 };
            BinarySearchTree<int> binarySearch = new(data);
            binarySearch.remove(8);
        }
    }


}