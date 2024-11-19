using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sorts;
using genmas;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3_KAiSD
{
    public partial class Form1 : Form
    {
        int flag = 0;
            
        public Form1()
        {
            InitializeComponent();

            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Размер массива (количество элементов), шт";
            pane.YAxis.Title.Text = "Время выполнения, мс";
            pane.Title.Text = "Зависимость времени выполнения от размера массивов";
        }
        public void SetPath()
        {
            pathToArray = @"..\..\array.txt";
            pathToTime = @"..\..\time.txt";
        }
        string pathToArray;
        string pathToTime;
        int selectedGroupIndex = -1;
        int selectedArrayTypeIndex = -1;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedArrayTypeIndex = masivos.SelectedIndex;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGroupIndex = algos.SelectedIndex;
        }

        private void SpeedOfSorting(Func<int, int[]> Generate, int size, params Func<int[], int[]>[] SortMethods)
        {
            SetPath();
            double[] speedSum = new double[SortMethods.Length];
            for (int i = 0; i < 20; i++)
            {
                int[] array = Generate(size);
                try
                {
                    StreamWriter sw = File.AppendText(pathToArray);
                    sw.WriteLine("Unsorted array: " + (i + 1).ToString());
                    foreach (int item in array) sw.Write(item.ToString() + " ");
                    sw.Write("\n");

                    int[] sortedArray = null;
                    int index = 0;
                    foreach (Func<int[], int[]> Method in SortMethods)
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        sortedArray = Method(array);
                        timer.Stop();
                        speedSum[index] += timer.ElapsedMilliseconds;
                        index++;
                    }

                    sw.WriteLine("Sorted array: " + (i + 1).ToString());
                    foreach (int item in sortedArray) sw.Write(item.ToString() + " ");
                    sw.Write("\n");
                    sw.Close();


                }
                catch (Exception ex) { Console.WriteLine(ex); };
            }

            try
            {
                StreamWriter sw = File.AppendText(pathToTime);
                for (int i = 0; i < speedSum.Length; i++)
                {
                    if (i == 0)
                    {
                        sw.Write(((double)(speedSum[i] / 20)).ToString());
                        continue;
                    }
                    sw.Write(" " + ((double)(speedSum[i] / 20)).ToString());
                }
                sw.WriteLine();
                sw.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); };
        }
        int chek = 0;


        private void button2_Click(object sender, EventArgs e)
        {

            switch (algos.SelectedIndex)
            {
                case 0:
                    chek = 1;
                    switch (masivos.SelectedIndex)
                    {
                        case 0:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateArray, length, Sorts<int>.BubbleSort, Sorts<int>.InsertionSort, Sorts<int>.SelectionSort, Sorts<int>.ShakerSort, Sorts<int> .GnomeSort);
                            break;
                        case 1:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateSubArrays, length, Sorts<int>.BubbleSort, Sorts<int>.InsertionSort, Sorts<int>.SelectionSort, Sorts<int>.ShakerSort, Sorts<int>.GnomeSort);
                            break;
                        case 2:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateBySwap, length, Sorts<int>.BubbleSort, Sorts<int>.InsertionSort, Sorts<int>.SelectionSort, Sorts<int>.ShakerSort, Sorts<int>.GnomeSort);
                            break;
                        case 3:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateSwapAndRepeat, length, Sorts<int>.BubbleSort, Sorts<int>.InsertionSort, Sorts<int>.SelectionSort, Sorts<int>.ShakerSort, Sorts<int>.GnomeSort);
                            break;
                    }
                    break;
                case 1:
                    chek = 2;
                    switch (masivos.SelectedIndex)
                    {
                        case 0:
                            for (int length = 10; length <= 100000; length *= 10)
                                SpeedOfSorting(Generate.GenerateArray, length, Sorts<int>.ShellSort, Sorts<int>.BitonicSort);
                            break;
                        case 1:
                            for (int length = 10; length <= 100000; length *= 10)
                                SpeedOfSorting(Generate.GenerateSubArrays, length, Sorts<int>.ShellSort, Sorts<int>.BitonicSort);
                            break;
                        case 2:
                            for (int length = 10; length <= 100000; length *= 10)
                                SpeedOfSorting(Generate.GenerateBySwap, length, Sorts<int>.ShellSort, Sorts<int>.BitonicSort);
                            break;
                        case 3:
                            for (int length = 10; length <= 100000; length *= 10)
                                SpeedOfSorting(Generate.GenerateSwapAndRepeat, length, Sorts<int>.ShellSort, Sorts<int>.BitonicSort);
                            break;
                    }
                    break;
                case 2:
                    chek = 3;
                    switch (masivos.SelectedIndex)
                    {
                        case 0:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateArray, length, Sorts<int>.CombSort, Sorts<int>.HeapSort, Sorts<int>.QuickSort, Sorts<int>.MergeSort);
                            break;
                        case 1:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateSubArrays, length, Sorts<int>.CombSort, Sorts<int>.HeapSort, Sorts<int>.QuickSort, Sorts<int>.MergeSort);
                            break;
                        case 2:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateBySwap, length, Sorts<int>.CombSort, Sorts<int>.HeapSort, Sorts<int>.QuickSort, Sorts<int>.MergeSort);
                            break;
                        case 3:
                            for (int length = 10; length <= 10000; length *= 10)
                                SpeedOfSorting(Generate.GenerateSwapAndRepeat, length, Sorts<int>.CombSort, Sorts<int>.HeapSort, Sorts<int>.QuickSort, Sorts<int>.MergeSort);
                            break;
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<List<double>> list = new List<List<double>>();
            SetPath();
            try
            {
                StreamReader sr = new StreamReader(pathToTime);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] lineArray = line.Split(' ');
                    List<double> times = new List<double>();
                    foreach (string s in lineArray)
                    {
                        times.Add(Convert.ToDouble(s));
                    }
                    list.Add(times);

                    line = sr.ReadLine();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };

            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Размер массива";
            pane.YAxis.Title.Text = "Время выполнения, мс";
            pane.Title.Text = "Зависимость времени выполнения от размера массива";
            for (int i = 0; i < list[0].Count(); i++)
            {
                PointPairList pointList = new PointPairList();
                int x = 10;

                for (int j = 0; j < list.Count(); j++)
                {
                    pointList.Add(x, list[j][i]);
                    x *= 10;
                }

                switch (chek)
                {
                    case 1:
                        switch (i)
                        {
                            case 0:
                                pane.AddCurve("Сортировка пузырьком", pointList, Color.Blue, SymbolType.Default);
                                break;
                            case 1:
                                pane.AddCurve("Сортировка вставками", pointList, Color.Red, SymbolType.Default);
                                break;
                            case 2:
                                pane.AddCurve("Сортировка выбором", pointList, Color.Orchid, SymbolType.Default);
                                break;
                            case 3:
                                pane.AddCurve("Шейкерная сортировка", pointList, Color.Yellow, SymbolType.Default);
                                break;
                            case 4:
                                pane.AddCurve("Гномья сортировка", pointList, Color.Purple, SymbolType.Default);
                                break;
                        }
                        break;
                    case 2:
                        switch (i)
                        {
                            case 0:
                                pane.AddCurve("Битонная сортировка", pointList, Color.Red, SymbolType.Default);
                                break;
                            case 1:
                                pane.AddCurve("Сортировка Шелла", pointList, Color.Yellow, SymbolType.Default);
                                break;
                        }
                        break;
                    case 3:
                        switch (i)
                        {
                            case 0:
                                pane.AddCurve("Сортировка расчёской", pointList, Color.Green, SymbolType.Default);
                                break;
                            case 1:
                                pane.AddCurve("Пирамидальная сортировка", pointList, Color.Red, SymbolType.Default);
                                break;
                            case 2:
                                pane.AddCurve("Быстрая сортировка", pointList, Color.Blue, SymbolType.Default);
                                break;
                            case 3:
                                pane.AddCurve("Сортировка слиянием", pointList, Color.Yellow, SymbolType.Default);
                                break;
                        }
                        break;
                }
            }


            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

    }

}
