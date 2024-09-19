using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {   
        static bool symmetric(int[,]a,int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i, j] != a[j, i]) return false;
                }
            }
            return true;
        }
        static double mult(int[,] a, int n,int[] b)
        {
            int s = 0;
            int[]c = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i] += b[j] * a[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                s += c[i] * b[i];
            }
            return Math.Sqrt(s);
        }
        static void Main(string[] args)
        {
            string path = @"D:/test.txt";
            string line;
            int[,] matrix = null;
            int[] vector = null;
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                int dimension = Convert.ToInt32(line);
                Console.WriteLine($"Dimension = {dimension}");

                matrix = new int[dimension, dimension];
                vector = new int[dimension];

                for (int i = 0; i < dimension; i++)
                {
                    line = sr.ReadLine();
                    var numbers = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                    for (int j = 0; j < dimension; j++)
                    {
                        matrix[i, j] = numbers[j];
                    }
                }
                Console.WriteLine($"Matrix: ");
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        Console.Write(matrix[i, j]);
                        Console.Write('\t');
                    }
                    Console.WriteLine();
                }

                line = sr.ReadLine();
                var numeros = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < dimension; j++)
                {
                    vector[j] = numeros[j];
                }
                Console.Write("Vector: ");
                for (int i = 0; i < dimension; i++)
                {
                    Console.Write(vector[i]);
                    Console.Write('\t');

                }
                sr.Close();
                Console.WriteLine();
                bool flag = symmetric(matrix, dimension);
                if (flag == false)
                {
                    Console.WriteLine("Not symmetric");
                }
                else
                {
                    Console.Write("Lenght of vector: ");
                    double result = mult(matrix, dimension, vector);
                    Console.WriteLine(result);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.Read();
        }
    }
}
