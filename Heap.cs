    public class Heap
    {
        public int[] A;
        public int heapSize; // mostly will give the index of last element in heap
                             //constructor
        public Heap(int[] array)
        {
            A = array;
            heapSize = array.Length - 1;
        }
        //returns left child's index
        public int ChildL(int parent)
        {
            return parent * 2 + 1;
        }
        //returns right child's index
        public int ChildR(int parent)
        {
            return (parent * 2 + 2);
        }
        //swaps two index values in an array
        public void Swap(int i, int j)
        {
            if (i <= heapSize && j <= heapSize && i != j)
            {
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }
        }

        public void MaxHeapify(int i)
        {
            int l = ChildL(i);
            int r = ChildR(i);
            int largest = i;

            if (l <= heapSize && A[l] > A[i])
                largest = l;

            if (r <= heapSize && A[r] > A[largest])
                largest = r;

            if (largest <= heapSize && largest != i)
            {
                Swap(largest, i);
                MaxHeapify(largest);
            }
        }

        public void BuildHeap()
        {
            for (int i = (A.Length / 2); i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        public int[] HeapSort()
        {
            BuildHeap();
            for (int i = heapSize; i > 0; i--)
            {
                Swap(i, 0);
                heapSize--;
                MaxHeapify(0);
            }

            return A;
        }
    }
