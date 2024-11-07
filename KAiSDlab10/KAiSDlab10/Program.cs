using System.Collections.Generic;
using System.Runtime.InteropServices;

class MyMaxHeap<T> where T: IComparable 
{
    private T[] ElementData;
    private int ElementCount;
    public MyMaxHeap(T[] a)
    {
        ElementData = new T[a.Length];
        ElementCount = 0;
        makeHeap(a);
    }
    public void add(T value)
    {
        if (ElementData.Length <= ElementCount)
        {
            var newheap = new T[ElementData.Length * 2];
            for (int j = 0; j < ElementCount; j++) newheap[j] = ElementData[j];
            newheap[ElementCount++] = value;
            ElementData = newheap;
        }
        else 
        {
            var newheap = new T[ElementData.Length];
            for (int j = 0; j < ElementCount; j++) newheap[j] = ElementData[j];
            newheap[ElementCount++] = value;
            ElementData = newheap;
        }
        int i = ElementCount - 1;
        int parent = (i - 1) / 2;
        while (i > 0 && (ElementData[i].CompareTo(ElementData[parent]) > 0))
        {
            T temp = ElementData[i];
            ElementData[i] = ElementData[parent];
            ElementData[parent] = temp;
            i = parent;
            parent = (i - 1) / 2;
        }
        for (i = ElementCount / 2; i >= 0; i--) heapify(i);
    }
    private void heapify(int i)
    {
        int leftChild,rightChild,largestChild;
        for (; ; )
        {
            leftChild = 2 * i + 1;
            rightChild = 2 * i + 2;
            largestChild = i;
            if (leftChild < ElementCount &&(ElementData[leftChild].CompareTo(ElementData[largestChild]) > 0)) largestChild = leftChild;
            if (rightChild < ElementCount && (ElementData[rightChild].CompareTo(ElementData[largestChild]) > 0)) largestChild = rightChild;
            if (largestChild == i) break;
            T temp = ElementData[i];
            ElementData[i] = ElementData[largestChild];
            ElementData[largestChild] = temp;
            i = largestChild;
        }
    }
    private void makeHeap(T[] a)
    {
        foreach (T obj in a) add(obj);

    }
    public T returnMax() 
    {
        return ElementData[0];
    }
    public T getMax()
    {
        T result = ElementData[0];
        var newheap = new T[ElementCount-1];
        newheap[0] = ElementData[ElementCount - 1];
        for (int i = 1; i < ElementCount - 1; i++) newheap[i] = ElementData[i];
        ElementData = newheap;
        ElementCount--;
        heapify(0);
        return result;
    }
    public void print() 
    {
        for (int i = 0; i < ElementCount; i ++) Console.WriteLine($"{i+1}) { ElementData[i]}");
        Console.WriteLine();
    }
    public void keyIncrease(int index, T value) 
    {
        ElementData[index] = value;
        for (int i = ElementCount / 2; i >= 0; i--) heapify(i);
    }
    public void MergeHeap(MyMaxHeap<T> newheap) 
    {
        var newMaxHeap = new T[ElementCount + newheap.ElementCount];
        for (int i = 0; i < ElementCount; i++) newMaxHeap[i] = ElementData[i];
        for (int i = 0; i < newheap.ElementCount; i++) newMaxHeap[i+ElementCount] = newheap.ElementData[i];
        ElementData = newMaxHeap;
        ElementCount = ElementCount + newheap.ElementCount;
        for (int i = ElementCount / 2; i >= 0; i--) heapify(i);
    }
}
class program {
    public static void Main(string[] args)
    {
        int[]a = {1,6,15,20,3,17,11,5,7,9,8};
        int[] b = { 2, 7, 16, 21, 4, 18, 12, 6, 8, 10, 9 };
        var heap1 = new MyMaxHeap<int>(a);
        var heap2 = new MyMaxHeap<int>(b);
        heap1.print();
        heap2.print();
        heap1.MergeHeap(heap2);
        heap1.print();
    }
}
