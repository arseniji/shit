using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sorts
{
    public class Sorts<T> where T : IComparable<T>
    {
        private static readonly Comparer<T> comparator = Comparer<T>.Default;
        public static void Swap(ref T e1, ref T e2)
        {
            T temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public class TreeNode<T> where T : IComparable<T>
        {
            public T value { get; set; }
            public TreeNode(T key)
            {
                value = key;
            }
            public TreeNode<T> right { get; set; }
            public TreeNode<T> left { get; set; }

            public void InsertNode(TreeNode<T> root)
            {
                if (root.value.CompareTo(value) < 0)
                {
                    if (left == null) left = root;
                    else left.InsertNode(root);
                }
                else
                {
                    if (right == null) right = root;
                    else right.InsertNode(root);
                }
            }

            public T[] TransformToArray(List<T> elements = null)
            {
                if (elements == null) elements = new List<T>();
                if (left != null) left.TransformToArray(elements);
                elements.Add(value);
                if (right != null) right.TransformToArray(elements);
                return elements.ToArray();
            }

        }

        private static void Heapify(T[] array, int size, int index)
        {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;
            if (leftChild < size && comparator.Compare(array[leftChild], array[largestIndex]) > 0) largestIndex = leftChild;
            if (rightChild < size && comparator.Compare(array[rightChild], array[largestIndex]) > 0) largestIndex = rightChild;
            if (largestIndex != index)
            {
                Swap(ref array[index], ref array[largestIndex]);
                Heapify(array, size, largestIndex);
            }
        }

        private static int Separation(T[] array, int start, int stop)
        {
            int left = start;
            T support = array[left];
            int index = 0;
            if ((start + 1).CompareTo(stop) >= 0)
                return left;
            for (int i = start + 1; i < stop; i++)
            {
                if (array[i].CompareTo(support) < 0)
                {
                    T temp = array[i];
                    array[i] = array[left];
                    array[left] = temp;
                    left++;
                }
                if (array[i].CompareTo(support) == 0)
                    index = i;
                else if (array[left].CompareTo(support) == 0)
                    index = left;
            }
            array[index] = array[left];
            array[left] = support;
            return left;
        }
        private static void SecondPart(T[] helpArray, int left, int right)
        {
            if (left < right)
            {
                int dot = Separation(helpArray, left, right);
                SecondPart(helpArray, left, dot);
                SecondPart(helpArray, dot + 1, right);
            }
        }
        private static void MergeSubarrays(T[] array, int left, int mid, int right, bool swap)
        {
            int countNums1 = mid - left + 1;
            int countNums2 = right - mid;
            T[] leftArray = new T[countNums1];
            T[] rightArray = new T[countNums2];
            for (int i = 0; i < countNums1; i++)
                leftArray[i] = array[left + i];
            for (int i = 0; i < countNums2; i++)
                rightArray[i] = array[mid + i + 1];
            int j = 0, z = 0;
            while (j < countNums1 && z < countNums2)
            {
                if ((!swap && leftArray[j].CompareTo(rightArray[z]) < 0) || (swap && leftArray[j].CompareTo(rightArray[z]) > 0))
                {
                    array[left] = leftArray[j];
                    j++;
                }
                else
                {
                    array[left] = rightArray[z];
                    z++;
                }
                left++;
            }
            while (j < countNums1)
            {
                array[left] = leftArray[j];
                j++;
                left++;
            }
            while (z < countNums2)
            {
                array[left] = rightArray[z];
                z++;
                left++;
            }
        }
        private static void Merge(T[] helpArray, int left, int right, bool swap = false)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                Merge(helpArray, left, mid, swap);
                Merge(helpArray, mid + 1, right, swap);
                MergeSubarrays(helpArray, left, mid, right, swap);
            }
        }
        private static void BitonicSequenceSort(T[] array, int low, int count, bool upward)
        {
            if (count > 1)
            {
                int k = count / 2;
                for (int i = low; i < low + k; i++)
                    if (upward ? array[i].CompareTo(array[i + k]) > 0 : array[i].CompareTo(array[i + k]) < 0)
                    {
                        T temp = array[i];
                        array[i] = array[i + k];
                        array[i + k] = temp;
                    }
                BitonicSequenceSort(array, low, k, upward);
                BitonicSequenceSort(array, low + k, k, upward);
            }
        }
        private static void BitonicSequenceCreate(T[] array, int low, int count, bool upward)
        {
            if (count > 1)
            {
                int k = count / 2;
                BitonicSequenceCreate(array, low, k, true);
                BitonicSequenceCreate(array, low + k, k, false);
                BitonicSequenceSort(array, low, count, upward);
            }
        }



        public static T[] BubbleSort(T [] array)
        {
            int i, j, n = array.Length;
            bool swaped;
            for (i = 0; i < n - 1; i++)
            {
                swaped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swaped = true;
                    }
                }
                if (!swaped)
                {
                    break;
                }
            }
            return array;
        }
        public static T[] ShakerSort(T[] array)
        {
            int i, j, n = array.Length;
            bool swaped;
            for (i = 0; i < n / 2; i++)
            {
                swaped = false;
                for (j = i; j < n - i - 1; j++)
                {
                    if (comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swaped = true;
                    }
                }

                for (j = n - 2 - i; j > i; j--)
                {
                    if (comparator.Compare(array[j - 1], array[j]) > 0)
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swaped = true;
                    }
                }
                if (!swaped)
                {
                    break;
                }
            }
            return array;
        }

        static int GetNextStep(int s)
        {
            s = s * 1000 / 1247;
            return s > 1 ? s : 1;
        }

        public static T[] CombSort(T[] array)
        {
            int i, n = array.Length;
            int currentStep = n - 1;
            while (currentStep > 1)
            {
                for (i = 0; i + currentStep < n; i++)
                {
                    if (comparator.Compare(array[i], array[i + currentStep]) > 0)
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }
                currentStep = GetNextStep(currentStep);
            }
            BubbleSort(array);
            return array;
        }
        public static T[] InsertionSort(T[] array)
        {
            int i, j, n = array.Length;
            T key;
            for (i = 1; i < n; i++)
            {
                key = array[i];
                j = i;
                while ((j > 1) && (comparator.Compare(array[j - 1], key) > 0))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }

            return array;
        }

        public static T[] ShellSort(T[] array)
        {
            int i, j, n = array.Length;
            var d = n / 2;
            while (d >= 1)
            {
                for (i = d; i < array.Length; i++)
                {
                    j = i;
                    while ((j >= d) && (comparator.Compare(array[j - d], array[j]) > 0))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }

        public static T[] TreeSort(T[] array, bool swap = false)
        {
            TreeNode<T> root = new TreeNode<T>(array[0]);
            for (int i = 1; i < array.Length; i++) root.InsertNode(new TreeNode<T>(array[i]));
            T[] supportArray = root.TransformToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (swap)
                {
                    array[i] = supportArray[array.Length - 1 - i];
                    continue;
                }
                array[i] = supportArray[i];
            }
            return array;
        }
        public static T[] GnomeSort(T[] array)
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < array.Length)
            {
                if (comparator.Compare(array[index-1], array[index]) < 0 )
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(ref array[index - 1], ref array[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }
            return array;
        }
        public static T[] SelectionSort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                T extremum = array[i];
                int indexOfExtremum = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparator.Compare(array[j], extremum) < 0)
                    {
                        indexOfExtremum = j;
                        extremum = array[j];
                    }
                }

                array[indexOfExtremum] = array[i];
                array[i] = extremum;
            }
            return array;
        }
        public static T[] HeapSort(T[] array, bool swap = false)
        {
            int countNums = array.Length;
            for (int i = countNums / 2 - 1; i >= 0; i--)
                Heapify(array, countNums, i);
            for (int i = countNums - 1; i >= 0; i--)
            {
                Swap(ref array[0], ref array[i]);
                Heapify(array, i, 0);
            }
            if (swap)
            {
                for (int i = 0; i < countNums / 2; i++)
                {
                    Swap(ref array[i], ref array[countNums - i - 1]);
                }
            }
            return array;
        }
        public static T[] HeapSort(T[] array) => HeapSort(array, false);
        public static T[] QuickSort(T[] array)
        {
            SecondPart(array, 0, array.Length);
            return array;
        }
        public static T[] MergeSort(T[] array, bool swap = false)
        {
            Merge(array, 0, array.Length - 1, swap);
            return array;
        }
        public static T[] MergeSort(T[] array) => MergeSort(array, false);
        public static T[] BitonicSort(T[] array, bool swap = false)
        {
            BitonicSequenceCreate(array, 0, array.Length, !swap);
            return array;
        }
        public static T[] BitonicSort(T[] array) => BitonicSort(array, false);
    }
}

