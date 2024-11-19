using System;
using System.ComponentModel;
using System.Xml.Linq;
using KAiSD;
class MyPriorityQueue<T> where T : IComparable<T>
{
    private MyArrayList<T> queue;
    int size { get; set; }
    private readonly Comparer<T> comparator = Comparer<T>.Default;
    public MyPriorityQueue()
    {
        queue = new MyArrayList<T>(11);
        size = 0;
    }
    public MyPriorityQueue(T[] a)
    {
        queue = new MyArrayList<T>(a.Length);
        size = a.Length;
        for (int i = 0; i < size; i++) queue.Add(a[i]);
        RefreshHeap();
    }
    public MyPriorityQueue(int capacity)
    {
        queue = new MyArrayList<T>(capacity);
        size = 0;
    }
    public MyPriorityQueue(int capacity, Comparer<T> comparator2)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException();
        queue = new MyArrayList<T>(capacity);
        size = 0;
        comparator = comparator2;
    }
    public MyPriorityQueue(MyPriorityQueue<T> c)
    {
        T[] new_queue = new T[c.size];
        for (int i = 0; i < c.size; i++) new_queue[i] = c.queue[i];
        queue = new MyArrayList<T>(c.size);
        size = c.size;
        for (int i = 0; i < c.size; i++)
            queue.Add(new_queue[i]);
        RefreshHeap();
    }
    public void Add(T e)
    {
        queue.Add(e);
        size++;
        RefreshHeap();
    }
    public void AddAll(T[] a)
    {
        queue.AddAll(a);
        size += a.Length;
        RefreshHeap();
    }
    public void Clear() { queue.Clear(); size = 0; }
    public bool Contains(T o) => queue.Contains(o);
    public bool ContainsAll(T[] a) => queue.ContainsAll(a);
    public bool IsEmpty() => queue.IsEmpty();
    public void Remove(object o) { queue.Remove(o); size--; RefreshHeap(); }
    public void RemoveAll(T[] a) { queue.RemoveAll(a); size = queue.Size(); RefreshHeap(); }
    public void RetainAll(T[] a) { queue.RetainAll(a); size = queue.Size(); RefreshHeap(); }
    public int Size() => queue.Size();
    public T[] ToArray() => queue.ToArray();
    public T[] ToArray(T[] a) => queue.ToArray(a);
    public T Element() => queue[0];
    public T Peek() { if (IsEmpty()) return default(T); else return queue[0]; }
    public bool Offer(T e) { Add(e); if (queue.Contains(e)) return true; return false; }
    public T Poll() { T temp = queue[0]; queue.Remove(queue[0]); RefreshHeap(); return temp; }
    public void RefreshHeap()
    {
        for (int i = size / 2; i >= 0; i--) HeapifyDown(i);
    }
    private void HeapifyDown(int index)
    {
        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largestIndex = index;
            if (leftChildIndex < size && comparator.Compare(queue[leftChildIndex], queue[largestIndex]) > 0) largestIndex = leftChildIndex;
            if (rightChildIndex < size && comparator.Compare(queue[rightChildIndex], queue[largestIndex]) > 0) largestIndex = rightChildIndex;
            if (largestIndex == index) break;
            T temp = queue[index];
            queue[index] = queue[largestIndex];
            queue[largestIndex] = temp;
            index = largestIndex;
        }
    }
    public T this[int index]
    {
        get { return queue[index]; }
        set { queue[index] = value; }
    }
}
