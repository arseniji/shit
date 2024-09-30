class KAiSD
{
    class MyArrayList<T>
    {
        private T[] _array;
        private int length;
        public MyArrayList()
        {
            this.length = 0;
            _array = new T[length];
        }

        public MyArrayList(T[] array)
        {
            this.length = array.Length;
            _array = new T[length];
            for (int i = 0; i < array.Length; i++) _array[i] = array[i];
        }
        public MyArrayList(int capacity)
        {
            this.length = capacity;
            _array = new T[length];
        }

        public void add(T e)
        {
            var new_array = new T[length + 1];
            for (int i = 0; i < length; i++) new_array[i] = _array[i];
            new_array[length] = e;
            _array = new_array;
            length = length + 1;
        }
        public void add(int index, T e)
        {
            var new_array = new T[length + 1];
            for (int i = 0; i < index; i++) new_array[i] = _array[i];
            new_array[index] = e;
            for (int i = index + 1; i < length + 1; i++) new_array[i] = _array[i - 1];
            _array = new_array;
            length = length + 1;
        }
        public void addAll(T[] a)
        {
            var new_array = new T[length + a.Length];
            for (int i = 0; i < length; i++) new_array[i] = _array[i];
            for (int i = length; i < a.Length; i++) new_array[i] = a[i - length];
            _array = new_array;
            length = length + a.Length;
        }
        public void addAll(int index, T[] a)
        {
            var new_array = new T[length + a.Length];
            for (int i = 0; i < index; i++) new_array[i] = _array[i];
            for (int i = index; i < a.Length; i++) new_array[i] = a[i];
            for (int i = index + 1; i < length + a.Length; i++) new_array[i] = a[i - length];
            _array = new_array;
            length = length + a.Length;
        }
        public void clear()
        {
            var new_array = new T[0];
            length = 0;
            _array = new_array;
        }
        public bool contains(object o)
        {
            foreach (var obj in _array)
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
                for (int i = 0; i < _array.Length; i++)
                {
                    if (obj.Equals(_array[i])) { flag = true; break; }
                }
                if (flag == false) return false;
            }
            return true;
        }
        public bool isEmpty()
        {
            if (length == 0) return true;
            else return false;
        }
        public void removeAll(T[] a)
        {
            foreach (var obj in a)
            {
                for (int i = 0; i < length; i++)
                {
                    if (obj.Equals(_array[i]))
                    {
                        for (int j = i; j < length - 1; j++)
                        {
                            _array[j] = _array[j + 1];
                        }
                        length--;
                    }
                }
            }
            var new_array = new T[length];
            for (int i = 0; i < length; i++) { new_array[i] = _array[i]; }
            _array = new_array;
        }
        public void retainAll(T[] a)
        {
            for (int i = 0; i < length; i++)
            {
                bool flag_1 = false;
                foreach (var obj in a)
                {
                    if (obj.Equals(_array[i])) { flag_1 = true; break; }
                }
                if (flag_1 == false)
                {
                    for (int j = i; j < length - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    length--;
                    i = 0;

                }
            }
            var new_array = new T[length];
            for (int i = 0; i < length; i++) { new_array[i] = _array[i]; }
            _array = new_array;
        }
        public int size()
        {
            return length;
        }
        public T[] toArray()
        {
            var new_array = new T[length];
            for (int i = 0; i < length; i++) new_array[i] = _array[i];
            return new_array;
        }
        public T[] toArray(T[] a)
        {
            if (a == null) a = new T[length];
            a = a.ToArray();
            return a;
        }
        public T get(int index)
        {
            return _array[index];
        }
        public int indexOf(object o)
        {
            for (int i = 0; i < length; i++)
            {
                if (_array[i].Equals(o)) return i;
            }
            return -1;
        }
        public int lastIndexOf(object o)
        {
            int temp = -1;
            for (int i = 0; i < length; i++)
            {
                if (_array[i].Equals(o)) temp = i;
            }
            return temp;
        }
        public T remove(int index)
        {
            for (int i = 0; i < length; i++)
            {
                if (_array[index].Equals(_array[i]))
                {
                    for (int j = i; j < length - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    length--;
                }
            }
            var new_array = new T[length];
            for (int i = 0; i < length; i++) { new_array[i] = _array[i]; }
            _array = new_array;
            return _array[index];
        }
        public void set(int index, T e) 
        {
            _array[index] = e;
        }
        public T[] subList(int fromIndex, int toIndex) 
        {
            int count = toIndex - fromIndex + 1;
            var new_array = new T[count];
            for (int i = fromIndex; i <= toIndex; i++) new_array[i-fromIndex] = _array[i];
            return new_array;
        }
        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

    }
    public static void Main(string[] args)
    {
        int[] a = { 1, 2, 3, 4, 3 };
        int[] c = { };
        var mas = new MyArrayList<int>(c);
        mas.addAll(a);
        for (int i = 0; i < mas.size(); i++)
        {
            Console.WriteLine(mas[i]);
        }
    }
}