using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sorts;

namespace genmas
{
    public class Genmas
    {

        public static int[] RandomMass(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            return array;
        }

        public static int[] RandomSubmass(int length)
        {
            Random random = new Random();
            int mod = random.Next(1, length);
            int newLength = random.Next(2, length) % mod;
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

        public static int[] SortedAndSwaped(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++) array[i] = i;

            Random random = new Random();
            int countOfSwap = random.Next(0, length / 10);
            for (int i = 0; i < countOfSwap; i++)
            {
                int firstIndex = random.Next(0, array.Length - 1);
                int secondIndex = random.Next(0, array.Length - 1);
                Sorts.Swap(ref array[firstIndex], ref array[secondIndex]);
            }
            return array;
        }

        public static int[] SortedSwapedAndRepeated(int length)
        {
            int[] array = SortedAndSwaped(length);
            Random random = new Random();
            int indexOfRepeat = random.Next(0, length - 1);
            int countOfRepeat = random.Next(0, length / 10);

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