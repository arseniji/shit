public class MyVector<T>
{
    private T[] elementData;
    private int elementCount;
    private int capacityIncrement;

    public MyVector(int initalCapacity, int capacityIncremente)
    {
        elementData = new T[initalCapacity];
        capacityIncrement = capacityIncremente;
        elementCount = 0;
    }
    public MyVector(int initalCapacity)
    {
        elementData = new T[initalCapacity];
        capacityIncrement = 0;
        elementCount = 0;
    }

    public MyVector()
    {
        elementData = new T[10];
        capacityIncrement = 0;
        elementCount = 0;
    }
    public MyVector(T[] a)
    {
        elementCount = a.Length;
        elementData = new T[elementCount];
        for (int i = 0; i < a.Length; i++) elementData[i] = a[i];
        capacityIncrement = 0;
    }
    public void add(T e)
    {
        if (elementCount == elementData.Length)
        {

            if (capacityIncrement != 0)
            {
                var new_vector = new T[elementData.Length + capacityIncrement];
                for (int i = 0; i < elementCount; i++) new_vector[i] = elementData[i];
                elementData = new_vector;
            }
            else
            {
                var new_vector = new T[(int)((elementData.Length + 1) * 2)];
                Array.Copy(elementData, new_vector, elementData.Length);
                elementData = new_vector;

            }
        }
        elementData[elementCount++] = e;
    }
    public void addAll(T[] a)
    {
        for (int i = 0; i < a.Length; i++) add(a[i]);
    }
    public void clear()
    {
        var new_vector = new T[0];
        elementCount = 0;
        elementData = new_vector;
    }
    public bool contains(object o)
    {
        foreach (var obj in elementData)
        {
            if (obj.Equals(o)) { return true; }
        }
        return false;
    }
    public bool containsAll(T[] a)
    {
        foreach (var obj in a)
        {
            bool flag = false;
            for (int i = 0; i < elementCount; i++)
            {
                if (obj.Equals(elementData[i])) { flag = true; break; }
            }
            if (flag == false) return false;
        }
        return true;
    }
    public bool isEmpty()
    {
        if (elementCount == 0) return true;
        else return false;
    }
    public void remove(T e)
    {
        if (contains(e))
            for (int i = 0; i < elementCount; i++)
            {
                if (e.Equals(elementData[i]))
                {
                    for (int j = i; j < elementCount - 1; j++)
                    {
                        elementData[j] = elementData[j + 1];
                    }
                    elementCount--;
                }
            }
        else Console.WriteLine($"No element {e}");
        var new_vector = new T[elementData.Length];
        Array.Copy(elementData, new_vector, elementCount);
        elementData = new_vector;
    }
    public void removeAll(T[] a)
    {
        foreach (var obj in a)
        {
            for (int i = 0; i < elementCount; i++)
            {
                if (obj.Equals(elementData[i]))
                {
                    for (int j = i; j < elementCount - 1; j++)
                    {
                        elementData[j] = elementData[j + 1];
                    }
                    elementCount--;
                }
            }
        }
        var new_vector = new T[elementData.Length];
        Array.Copy(elementData, new_vector, elementCount);
        elementData = new_vector;
    }
    public void retainAll(T[] a)
    {
        for (int i = 0; i < elementCount; i++)
        {
            bool flag_1 = false;
            foreach (var obj in a)
            {
                if (obj.Equals(elementData[i])) { flag_1 = true; break; }
            }
            if (flag_1 == false)
            {
                for (int j = i; j < elementCount - 1; j++)
                {
                    elementData[j] = elementData[j + 1];
                }
                elementCount--;
                i = 0;
            }
        }
        var new_vector = new T[elementData.Length];
        Array.Copy(elementData, new_vector, elementCount);
        elementData = new_vector;
    }
    public int size()
    {
        return elementCount;
    }
    public T[] toArray()
    {
        var new_vector = new T[elementData.Length];
        Array.Copy(elementData, new_vector, elementCount);
        return new_vector;
    }
    public T[] toArray(T[] a)
    {
        if (a == null) a = new T[elementData.Length];
        a = a.ToArray();
        return a;
    }
    public void add(int index, T e)
    {
        if (elementCount == elementData.Length)
        {
            if (capacityIncrement != 0)
            {
                var new_vector = new T[elementData.Length + capacityIncrement];
                for (int i = 0; i < index; i++) new_vector[i] = elementData[i];
                new_vector[index] = e;
                for (int i = index + 1; i < elementCount + 1; i++) new_vector[i] = elementData[i - 1];
                elementData = new_vector;
                elementCount++;
            }
            else
            {
                var new_vector = new T[(int)(elementData.Length * 2)];
                for (int i = 0; i < index; i++) new_vector[i] = elementData[i];
                new_vector[index] = e;
                for (int i = index + 1; i < elementCount + 1; i++) new_vector[i] = elementData[i - 1];
                elementData = new_vector;
                elementCount++;
            }
        }
        else elementData[elementCount++] = e;

    }

    public void addAll(int index, T[] a)
    {
        if (elementCount >= elementData.Length)
        {
            if (capacityIncrement != 0)
            {
                var new_vector = new T[elementData.Length + capacityIncrement];
                for (int i = 0; i < index; i++) new_vector[i] = elementData[i];
                for (int i = index; i < a.Length; i++) new_vector[i] = a[i];
                for (int i = index + 1; i < elementCount + a.Length; i++) new_vector[i] = a[i - elementCount];
                elementData = new_vector;
                elementCount = elementCount + a.Length;
            }
            else
            {
                var new_vector = new T[(int)(elementData.Length * 2)];
                for (int i = 0; i < index; i++) new_vector[i] = elementData[i];
                for (int i = index; i < a.Length; i++) new_vector[i] = a[i];
                for (int i = index + 1; i < elementCount + a.Length; i++) new_vector[i] = a[i - elementCount];
                elementData = new_vector;
                elementCount = elementCount + a.Length;
            }
        }
    }
    public T get(int index)
    {
        return elementData[index];
    }
    public int indexOf(object o)
    {
        for (int i = 0; i < elementCount; i++)
        {
            if (elementData[i].Equals(o)) return i;
        }
        return -1;
    }
    public int lastIndexOf(object o)
    {
        int temp = -1;
        for (int i = 0; i < elementCount; i++)
        {
            if (elementData[i].Equals(o)) temp = i;
        }
        return temp;
    }
    public T removeInd(int index)
    {
        for (int i = 0; i < elementCount; i++)
        {
            if (elementData[index].Equals(elementData[i]))
            {
                for (int j = i; j < elementCount - 1; j++)
                {
                    elementData[j] = elementData[j + 1];
                }
                elementCount--;
            }
        }
        var new_vector = new T[elementData.Length];
        for (int i = 0; i < elementCount; i++) { new_vector[i] = elementData[i]; }
        elementData = new_vector;
        return elementData[index];
    }
    public void set(int index, T e)
    {
        elementData[index] = e;
    }
    public T[] subList(int fromIndex, int toIndex)
    {
        int count = toIndex - fromIndex + 1;
        var new_vector = new T[count];
        for (int i = fromIndex; i <= toIndex; i++) new_vector[i - fromIndex] = elementData[i];
        return new_vector;
    }
    public T this[int index]
    {
        get { return elementData[index]; }
        set { elementData[index] = value; }
    }
    public T firstElement
    {
        get { return elementData[0]; }
        set { elementData[0] = value; }

    }
    public T lastElement
    {
        get { return elementData[elementCount - 1]; }
        set { elementData[elementCount - 1] = value; }
    }
    public void removeElementAt(int pos)
    {

        for (int i = 0; i < elementCount; i++)
        {
            if (elementData[pos].Equals(elementData[i]))
            {
                for (int j = i; j < elementCount - 1; j++)
                {
                    elementData[j] = elementData[j + 1];
                }
                elementCount--;
            }
        }
        var new_vector = new T[elementData.Length];
        for (int i = 0; i < elementCount; i++) { new_vector[i] = elementData[i]; }
        elementData = new_vector;
    }
    public void removeRange(int begin, int end)
    {
        for (int i = 0; i < elementCount; i++)
        {
            if (i >= begin && i <= end)
            {
                for (int j = i; j < elementCount - 1; j++)
                {
                    elementData[j] = elementData[j + 1];
                }
                elementCount--;
            }
        }
        var new_vector = new T[elementData.Length];
        Array.Copy(elementData, new_vector, elementCount);
        elementData = new_vector;
    }
}
