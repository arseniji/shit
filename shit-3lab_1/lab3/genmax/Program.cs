using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace genmax
{
    public static class Gen
    {
        public static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public static int[] Random(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            return array;
        }
        public static int[] RandomSub(int length)
        {
            Random random = new Random();
            int modul = random.Next(0, length);
            int newLength = random.Next(2, length) % modul;
            if (newLength < 2) newLength = 2;
            int[] array = new int[length];
            int countOfArray = 0;

            int i = 0;
            while (i < length)
            {
                int exp = random.Next(0, 1000);
                int elementBase = 0;
                countOfArray++;

                while (i < length && i < newLength * countOfArray)
                {
                    elementBase++;
                    array[i] = elementBase * exp;
                    i++;
                }
            }

            return array;
        }

        public static int[] RandomSwap(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++) array[i] = i;
            Random random = new Random();
            int swaps = random.Next(0, length / 10);
            for (int i = 0; i < swaps; i++)
            {
                int firstNum = random.Next(0, length);
                int secondNum = random.Next(0, length);
                Swap(ref array[firstNum], ref array[secondNum]);
            }
            return array;
        }

        public static int[] RandomSwapRepeat(int length)
        {
            int[] array = RandomSwap(length);
            Random random = new Random();
            int indexOfRepeat = random.Next(0, length - 1);
            int countOfRepeat = random.Next(0, length / 3);

            while (countOfRepeat > 0)
            {
                int randomIndex = random.Next(0, array.Length - 1);
                if (array[randomIndex] != array[indexOfRepeat])
                {
                    array[randomIndex] = array[indexOfRepeat];
                    countOfRepeat--;
                }

            }
            return array;
        }
    }
}
