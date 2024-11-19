namespace KAiSD
{
    class MyArrayList<T>
    {
        private T[] ElementData;
        int ElementCount { get; set; }
        public MyArrayList()
        {
            ElementCount = 0;
            ElementData = new T[0];
        }
        public MyArrayList(T[] array)
        {
            ElementCount = array.Length;
            ElementData = new T[array.Length];
            for (int i = 0; i < array.Length; i++) ElementData[i] = array[i];
        }
        public MyArrayList(int capacity)
        {
            ElementCount = 0;
            ElementData = new T[capacity];
        }
        public void Add(T e)
        {
            if (ElementCount >= ElementData.Length)
            {
                var new_array = new T[(int)(ElementCount * 1.5)+1];
                for (int i = 0; i < ElementCount; i++) new_array[i] = ElementData[i];
                new_array[ElementCount] = e;
                ElementData = new_array;
                ElementCount = ElementCount + 1;
            }
            else
            {
                ElementData[ElementCount++] = e;
            }
        }

        public void Add(int index, T e)
        {
            var new_array = new T[ElementCount + 1];
            for (int i = 0; i < index; i++) new_array[i] = ElementData[i];
            new_array[index] = e;
            for (int i = index + 1; i < ElementCount + 1; i++) new_array[i] = ElementData[i - 1];
            ElementData = new_array;
            ElementCount = ElementCount + 1;
        }
        public void AddAll(T[] a)
        {
            var new_array = new T[ElementCount + a.Length];
            for (int i = 0; i < ElementCount; i++) new_array[i] = ElementData[i];
            for (int i = ElementCount; i < a.Length; i++) new_array[i] = a[i - ElementCount];
            ElementData = new_array;
            ElementCount = ElementCount + a.Length;
        }
        public void AddAll(int index, T[] a)
        {
            var new_array = new T[ElementCount + a.Length] ;
            for (int i = 0; i < index; i++) new_array[i] = ElementData[i];
            for (int i = index; i < a.Length; i++) new_array[i] = a[i];
            for (int i = index + 1; i < ElementCount + a.Length; i++) new_array[i] = a[i - ElementCount];
            ElementData = new_array;
            ElementCount = ElementCount + a.Length;
        }
        public void Clear()
        {
            var new_array = new T[0];
            ElementCount = 0;
            ElementData = new_array;
        }
        public bool Contains(T o)
        {
            foreach (var obj in ElementData)
            {
                if (obj.Equals(o)) { return true; }
            }
            return false;
        }
        public bool ContainsAll(T[] a)
        {
            foreach (var obj in a)
            {
                bool flag = false;
                for (int i = 0; i < ElementCount; i++)
                {
                    if (obj.Equals(ElementData[i])) { flag = true; break; }
                }
                if (flag == false) return false;
            }
            return true;
        }
        public bool IsEmpty()
        {
            if (ElementCount == 0) return true;
            else return false;
        }
        public void RemoveAll(T[] a)
        {
            foreach (var obj in a)
            {
                for (int i = 0; i < ElementCount; i++)
                {
                    if (obj.Equals(ElementData[i]))
                    {
                        for (int j = i; j < ElementCount - 1; j++)
                        {
                            ElementData[j] = ElementData[j + 1];
                        }
                        ElementCount--;
                    }
                }
            }
            var new_array = new T[ElementCount];
            for (int i = 0; i < ElementCount; i++) { new_array[i] = ElementData[i]; }
            ElementData = new_array;
        }
        public void RetainAll(T[] a)
        {
            for (int i = 0; i < ElementCount; i++)
            {
                bool flag_1 = false;
                foreach (var obj in a)
                {
                    if (obj.Equals(ElementData[i])) { flag_1 = true; break; }
                }
                if (flag_1 == false)
                {
                    for (int j = i; j < ElementCount - 1; j++)
                    {
                        ElementData[j] = ElementData[j + 1];
                    }
                    ElementCount--;
                    i = 0;

                }
            }
            var new_array = new T[ElementCount];
            for (int i = 0; i < ElementCount; i++) { new_array[i] = ElementData[i]; }
            ElementData = new_array;
        }
        public int Size()
        {
            return ElementCount;
        }
        public T[] ToArray()
        {
            var new_array = new T[ElementCount];
            for (int i = 0; i < ElementCount; i++) new_array[i] = ElementData[i];
            return new_array;
        }
        public T[] ToArray(T[] a)
        {
            if (a == null) a = new T[ElementCount];
            a = a.ToArray();
            return a;
        }
        public T Get(int index)
        {
            return ElementData[index];
        }
        public int IndexOf(object o)
        {
            for (int i = 0; i < ElementCount; i++)
            {
                if (ElementData[i].Equals(o)) return i;
            }
            return -1;
        }
        public int LastIndexOf(object o)
        {
            int temp = -1;
            for (int i = 0; i < ElementCount; i++)
            {
                if (ElementData[i].Equals(o)) temp = i;
            }
            return temp;
        }
        public T Remove(int index)
        {
            for (int i = 0; i < ElementCount; i++)
            {
                if (ElementData[index].Equals(ElementData[i]))
                {
                    for (int j = i; j < ElementCount - 1; j++)
                    {
                        ElementData[j] = ElementData[j + 1];
                    }
                    ElementCount--;
                }
            }
            var new_array = new T[ElementCount];
            for (int i = 0; i < ElementCount; i++) { new_array[i] = ElementData[i]; }
            ElementData= new_array;
            return ElementData[index];
        }
        public void Remove(object o)
        {
            for (int i = 0; i < ElementCount; i++)
            {
                if (o.Equals(ElementData[i]))
                {
                    for (int j = i; j < ElementCount - 1; j++)
                    {
                        ElementData[j] = ElementData[j + 1];
                    }
                    ElementCount--;
                }
            }
            var new_array = new T[ElementCount];
            for (int i = 0; i < ElementCount; i++) { new_array[i] = ElementData[i]; }
            ElementData = new_array;
        }
        public void Set(int index, T e)
        {
            ElementData[index] = e;
        }
        public T[] SubList(int fromIndex, int toIndex)
        {
            int count = toIndex - fromIndex + 1;
            var new_array = new T[count];
            for (int i = fromIndex; i <= toIndex; i++) new_array[i - fromIndex] = ElementData[i];
            return new_array;
        }
        public T this[int index]
        {
            get { return ElementData[index]; }
            set { ElementData[index] = value; }
        }
        public int Length
        {
            get { return ElementData.Length; }
        }
    }
}