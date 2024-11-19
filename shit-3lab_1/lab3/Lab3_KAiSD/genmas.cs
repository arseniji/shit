using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sorts;

namespace genmas
{
    public static class Generate
    {
        public static int[] GenerateArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
                array[i] = random.Next(0, 1000);
            return array;
        }
        public static int[] GenerateSubArrays(int size)
        {
            Random random = new Random();
            int module = random.Next(0, size);
            int newSize = random.Next(2, size) % module;
            if (newSize < 2) newSize = 2;
            int[] array = new int[size];
            int countArray = 0, i = 0;
            while (i < size)
            {
                int baseElement = 0;
                int exp = random.Next(0, 1000);
                countArray++;
                while (i < size && i < countArray * newSize)
                {
                    baseElement++;
                    array[i] = baseElement * exp;
                    i++;
                }
            }
            return array;
        }
        public static int[] GenerateBySwap(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++) array[i] = i;
            Random random = new Random();
            int countSwaps = random.Next(0, size / 3);
            for (int i = 0; i < countSwaps; i++)
            {
                int first = random.Next(0, array.Length - 1);
                int second = random.Next(0, array.Length - 1);
                int temp = array[first];
                array[first] = array[second];
                array[second] = temp;
            }
            return array;
        }
        public static int[] GenerateSwapAndRepeat(int size)
        {
            int[] array = GenerateBySwap(size);
            Random random = new Random();
            int repeatIndex = random.Next(0, array.Length - 1);
            int repeatCount = random.Next(0, array.Length / 3);
            while (repeatCount > 0)
            {
                int randomIndex = random.Next(0, array.Length - 1);
                if (array[randomIndex] != array[repeatIndex])
                {
                    array[randomIndex] = array[repeatIndex];
                    repeatCount--;
                }
            }
            return array;
        }
    }
}