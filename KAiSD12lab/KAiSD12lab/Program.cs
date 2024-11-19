using System;
using System.Collections.Generic;
using System.Diagnostics;
class prog 
{
    public class MyQueue : IComparable<MyQueue> 
    {
        int Application_number { get; set; }
        int Priority { get; set; }
        int Step_number { get; set; }
        public MyQueue(int application_number, int priority, int step_number)
        {
            Application_number = application_number;
            Priority = priority;
            Step_number = step_number;
        }
        public int CompareTo(MyQueue obj) => Priority.CompareTo(obj.Priority);
        public static void Main(string[] args) 
        {

            string path = @"..\..\..\log.txt";
            MyPriorityQueue<MyQueue> queue = new MyPriorityQueue<MyQueue>();
            Console.Write("Введите количество заявок = ");
            int n = Convert.ToInt32(Console.ReadLine());
            StreamWriter sw = new StreamWriter(path);
            int count = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < n; i++) 
            {
                Random random = new Random();
                int num_of_applications = random.Next(1, 11);
                for (int j = 0; j < num_of_applications; j++) 
                {
                    int priority = random.Next(1, 6);
                    MyQueue app = new MyQueue(j,priority,i);
                    queue.Add(app);
                    sw.WriteLine("ADD: НомерЗаявки: " + app.Application_number + " Приоритет: " + app.Priority + " НомерШага: " + app.Step_number);
                    count++;
                }
            }
            for (int i = 0; i < count; i++)
            {
                MyQueue temp = queue.Peek();
                TimeSpan elapsedTime = stopwatch.Elapsed;
                sw.WriteLine("REMOVE: НомерЗаявки: " + temp.Application_number + " Приоритет: " + temp.Priority + " НомерШага: " + temp.Step_number + " решена за " + elapsedTime.TotalSeconds + " секунд");
                queue.Remove(queue.Peek());
            }
            stopwatch.Stop();
            sw.Close();
;       }
    }
}