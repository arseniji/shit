using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorts
{
    public static class Sorts
    {



        static int IndexOfMin(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }
        public static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public class TreeNode
        {
            public TreeNode(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public void Insert(TreeNode node)
            {
                if (node.Data < Data)
                {
                    if (Left == null)
                    {
                        Left = node;
                    }
                    else
                    {
                        Left.Insert(node);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = node;
                    }
                    else
                    {
                        Right.Insert(node);
                    }
                }
            }
            public int[] Transform(List<int> elements = null)
            {
                if (elements == null)
                {
                    elements = new List<int>();
                }
                if (Left != null)
                {
                    Left.Transform(elements);
                }
                elements.Add(Data);

                if (Right != null)
                {
                    Right.Transform(elements);
                }
                return elements.ToArray();
            }
        }
        private static void Heapify(int[] array, int size, int index)
        {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
                Heapify(array, size, largestIndex);
            }
        }
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        private static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        private static int GetMaxVal(int[] array, int size)
        {
            var maxVal = array[0];
            for (int i = 1; i < size; i++)
                if (array[i] > maxVal)
                    maxVal = array[i];
            return maxVal;
        }
        private static void CountingSort(int[] array, int size, int exponent)
        {
            var outputArr = new int[size];
            var occurences = new int[10];
            for (int i = 0; i < 10; i++)
                occurences[i] = 0;
            for (int i = 0; i < size; i++)
                occurences[(array[i] / exponent) % 10]++;
            for (int i = 1; i < 10; i++)
                occurences[i] += occurences[i - 1];
            for (int i = size - 1; i >= 0; i--)
            {
                outputArr[occurences[(array[i] / exponent) % 10] - 1] = array[i];
                occurences[(array[i] / exponent) % 10]--;
            }
            for (int i = 0; i < size; i++)
                array[i] = outputArr[i];
        }
 



        public static int[] BubbleSort(int[] array)
        {
            int i, j, n = array.Length;
            bool swaped;
            for (i = 0; i < n - 1; i++)
            {
                swaped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
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
        public static int[] ShakerSort(int[] array)
        {
            int i, j, n = array.Length;
            bool swaped;
            for (i = 0; i < n / 2; i++)
            {
                swaped = false;
                for (j = i; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swaped = true;
                    }
                }

                for (j = n - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
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

        public static int[] CombSort(int[] array)
        {
            int i, n = array.Length;
            int currentStep = n - 1;
            while (currentStep > 1)
            {
                for (i = 0; i + currentStep < n; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }
                currentStep = GetNextStep(currentStep);
            }
            BubbleSort(array);
            return array;
        }
        public static int[] InsertionSort(int[] array)
        {
            int i, j, key, n = array.Length;
            for (i = 1; i < n; i++)
            {
                key = array[i];
                j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }

            return array;
        }

        public static int[] ShellSort(int[] array)
        {
            int i, j, n = array.Length;
            var d = n / 2;
            while (d >= 1)
            {
                for (i = d; i < array.Length; i++)
                {
                    j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }

        public static int[] TreeSort(int[] array)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }
            return treeNode.Transform();
        }
        public static int[] GnomeSort(int[] array)
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < array.Length)
            {
                if (array[index - 1] < array[index])
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
        public static int[] SelectionSort(int[] array, int currentIndex = 0)
        {
            if (currentIndex == array.Length)
                return array;

            var index = IndexOfMin(array, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref array[index], ref array[currentIndex]);
            }

            return SelectionSort(array, currentIndex + 1);
        }
        public static int[] HeapSort(int[] array)
        {
            int size = array.Length;
            if (size <= 1)
                return array;
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(array, size, i);
            }
            for (int i = size - 1; i >= 0; i--)
            {
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;
                Heapify(array, i, 0);
            }
            return array;
        }
        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        private static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        public static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        public static int[] CountingSort(int[] array)
        {
            var min = array[0];
            var max = array[0];
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }
                else if (element < min)
                {
                    min = element;
                }
            }

            var correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            var count = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] + correctionFactor]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i - correctionFactor;
                    index++;
                }
            }

            return array;
        }
        static void BitonicMerge(int[] array, int start, int count, bool dir)
        {

            if (count > 1)
            {
                int k = count / 2;
                for (int i = start; i < start + k; i++)
                {
                    bool flag = false;
                    if (array[i] > array[i + k]) flag = true;
                    if (dir == flag)
                    {
                        int temp = array[i];
                        array[i] = array[i + k];
                        array[i + k] = temp;
                    }
                }
                BitonicMerge(array, start, k, dir);
                BitonicMerge(array, start + k, k, dir);

            }
        }
        static void BitonicSortPart(int[] array, int start, int count, bool dir)
        {
            if (count > 1)
            {
                int k = count / 2;
                BitonicSortPart(array, start, k, true);
                BitonicSortPart(array, start + k, k, false);
                BitonicMerge(array, start, count, dir);
            }
        }
        public static int[] BitonicSort(int[] array, bool isReverse = false)
        {

            double length = array.Length;
            int powOfTwo = 0;
            while (length > 1)
            {
                length /= 2;
                powOfTwo++;
            }
            if (length != 1) powOfTwo++;

            int[] bitonicArray = new int[(int)Math.Pow(2, powOfTwo)];
            for (int i = 0; i < bitonicArray.Length; i++)
            {
                if (i < array.Length)
                {
                    bitonicArray[i] = array[i];
                    continue;
                }
                bitonicArray[i] = -1;
            }

            BitonicSortPart(bitonicArray, 0, bitonicArray.Length, !isReverse);

            for (int i = 0; i < bitonicArray.Length; i++)
            {
                if (isReverse && bitonicArray[i] != -1) array[i] = bitonicArray[i];
                if (!isReverse && bitonicArray[bitonicArray.Length - 1 - i] != -1) array[array.Length - 1 - i] = bitonicArray[bitonicArray.Length - 1 - i];
            }

            return array;
        }
    }
}

