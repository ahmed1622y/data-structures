
namespace data_structers
{
    public class UnionFind
    {
        public int size { get; private set; } = 0;
        public int numComponents { get; private set; } = 0;

        private int[] componentsSize;

        private int[] ids;

        public UnionFind(int size)
        {
            this.size = numComponents = size;

            ids = new int[size];
            componentsSize = new int[size];

            for (int i = 0; i < size; i++)
            {
                ids[i] = i;
                componentsSize[i] = 1;
            }
        }
        public int find(int p)
        {
            int parent = p;
            while (ids[parent] != parent) parent = ids[parent];

            while (p != parent)
            {
                int next = ids[p];
                ids[p] = parent;
                p = next;
            }

            return parent;
        }
        public Boolean connected(int p, int q)
        {
            return find(p) == find(q);
        }
        public int componentSize(int p)
        {
            return componentsSize[find(p)];
        }
        public int components()
        {
            return numComponents;
        }
        public void unify(int p, int q)
        {
            int pRoot = ids[p];
            int qRoot = ids[q];

            if (componentSize(pRoot) > componentSize(qRoot))
            {
                ids[pRoot] = qRoot;
                componentsSize[pRoot] += componentsSize[qRoot];
            }
            else
            {
                ids[qRoot] = pRoot;
            }
            numComponents--;
        }
    }
}