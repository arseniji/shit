using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2_shian
{
    internal class Program
    {
        public class Complex
        {
            private double re;
            private double im;
            public void Make(double x, double y)
            {
                re = x;
                im = y;
            }
            public Complex Sum(Complex other)
            {
                Complex ans = new Complex();
                ans.re = this.re + other.re;
                ans.im = this.im + other.im;
                return ans;
            }
            public Complex Sub(Complex other)
            {
                Complex ans = new Complex();
                ans.re = this.re - other.re;
                ans.re = this.im - other.im;
                return ans;
            }
            public Complex Mult(Complex other)
            {

                Complex ans = new Complex();
                ans.re = this.re * other.re - this.im * other.im;
                ans.im = this.im * other.re + this.re * other.im;
                return ans;
            }
            public Complex Div(Complex other)
            {
                Complex ans = new Complex();
                ans.re = (this.re * other.re + this.im * other.im) / (other.re * other.re + other.im * other.im);
                ans.im = (this.im * other.re - this.re * other.im) / (other.re * other.re + other.im * other.im);
                return ans;
            }
            public double AbsoluteVal()
            {
                return Math.Sqrt(this.re * this.re + this.im * this.im);
            }
            public double Argument()
            {
                if (this.re > 0) return Math.Atan(this.im / this.re);
                if (this.re < 0 && this.im >= 0) return Math.PI + Math.Atan(this.im / this.re);
                if (this.re < 0 && this.im < 0) return -Math.PI + Math.Atan(this.im / this.re);
                if (this.re == 0 && this.im > 0) return Math.PI / 2;
                if (this.re == 0 && this.im < 0) return -Math.PI / 2;
                return 0;
            }
            public double Real()
            {
                return this.re;
            }
            public double Imaginary()
            {
                return this.im;
            }
            public Complex Print()
            {
                if (this.im >= 0) Console.WriteLine($"{this.re} + {this.im}i");
                if (this.im < 0) Console.WriteLine($"{this.re} - {this.im * -1}i");
                return null;
            }
        }

        static void Main(string[] args)
        {
            double re, im;
            string line;
            char action;
            bool flag = false;
            Complex firstNum = new Complex();
            firstNum.Make(0, 0);
            Complex secondNum = new Complex();
            secondNum.Make(0, 0);
            Complex thirdNum = new Complex();
            thirdNum.Make(0, 0);
            while (true)
            {
                Console.WriteLine("All operations: ");
                Console.WriteLine("0. Create complex numbers");
                Console.WriteLine("1. Summation");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Module");
                Console.WriteLine("6. Argument");
                Console.WriteLine("7. Return real");
                Console.WriteLine("8. Return imaginary");
                Console.WriteLine("9. Print complex number");
                Console.WriteLine("Press q or Q to exit");
                Console.WriteLine("\nSelect operation");
                line = Console.ReadLine();
                if (line != null && line.Length == 1 ) {
                    action = Convert.ToChar(line);
                    if (action == 'Q' || action == 'q') break;
                    if (action > '9' || action < '0') { Console.WriteLine("Error"); }
                }
                else
                {
                    Console.WriteLine("Error");
                    break;
                }

                switch (action)
                {
                    case '0':
                        Console.Write("Enter real part of the first number: ");
                        line = Console.ReadLine();
                        re = Convert.ToDouble(line);
                        Console.Write("Enter imaginary part of the first number: ");
                        line = Console.ReadLine();
                        im = Convert.ToDouble(line);
                        firstNum.Make(re, im);
                        Console.Write($"\nFirst complex number is ");
                        firstNum.Print();
                        Console.WriteLine();
                        Console.Write("Enter real part of the second number: ");
                        line = Console.ReadLine();
                        re = Convert.ToDouble(line);
                        Console.Write("Enter imaginary part of the second number: ");
                        line = Console.ReadLine();
                        im = Convert.ToDouble(line);
                        secondNum.Make(re, im);
                        Console.Write($"\nSecond complex number is ");
                        secondNum.Print();
                        Console.WriteLine();
                        flag = true;
                        break;
                    case '1':
                        if (flag == true)
                        {
                            thirdNum = firstNum.Sum(secondNum);
                            Console.WriteLine($"Answer is ");
                            thirdNum.Print();
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '2':
                        if (flag == true)
                        {
                            thirdNum = firstNum.Sub(secondNum);
                            Console.WriteLine($"Answer is ");
                            thirdNum.Print();
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '3':
                        if (flag == true)
                        {
                            thirdNum = firstNum.Mult(secondNum);
                            Console.WriteLine($"Answer is ");
                            thirdNum.Print();
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '4':
                        if (flag == true)
                        {
                            thirdNum = firstNum.Div(secondNum);
                            Console.WriteLine($"Answer is ");
                            thirdNum.Print();
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '5':
                        if (flag == true)
                        {
                            Console.WriteLine("Select num:");
                            Console.WriteLine("1. First number");
                            Console.WriteLine("2. Second number");
                            action = Convert.ToChar(Console.ReadLine());
                            if (action == 'Q' || action == 'q') break;
                            if (action > '2' || action < '1') { Console.WriteLine("Error"); }
                            switch (action)
                            {
                                case '1':
                                    Console.WriteLine($"Module of first number is {firstNum.AbsoluteVal()}");
                                    break;
                                case '2':
                                    Console.WriteLine($"Module of second number is {secondNum.AbsoluteVal()}");
                                    break;
                                default:
                                    Console.WriteLine("invalid action");
                                    break;
                            }
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '6':
                        if (flag == true)
                        {
                            Console.WriteLine("Select num:");
                            Console.WriteLine("1. First number");
                            Console.WriteLine("2. Second number");
                            action = Convert.ToChar(Console.ReadLine());
                            if (action == 'Q' || action == 'q') break;
                            if (action > '2' || action < '1') { Console.WriteLine("Error"); }
                            switch (action)
                            {
                                case '1':
                                    Console.WriteLine($"Argument of first number is {firstNum.Argument()}");
                                    break;
                                case '2':
                                    Console.WriteLine($"Argument of second number is {secondNum.Argument()}");
                                    break;
                                default:
                                    Console.WriteLine("invalid action");
                                    break;
                            }
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '7':
                        if (flag == true)
                        {
                            Console.WriteLine("Select num:");
                            Console.WriteLine("1. First number");
                            Console.WriteLine("2. Second number");
                            action = Convert.ToChar(Console.ReadLine());
                            if (action == 'Q' || action == 'q') break;
                            if (action > '2' || action < '1') { Console.WriteLine("Error"); }
                            switch (action)
                            {
                                case '1':
                                    Console.WriteLine($"Real part of first number is {firstNum.Real()}");
                                    break;
                                case '2':
                                    Console.WriteLine($"Real part of second number is {secondNum.Real()}");
                                    break;
                                default:
                                    Console.WriteLine("invalid action");
                                    break;
                            }
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '8':
                        if (flag == true)
                        {
                            Console.WriteLine("Select num:");
                            Console.WriteLine("1. First number");
                            Console.WriteLine("2. Second number");
                            action = Convert.ToChar(Console.ReadLine());
                            if (action == 'Q' || action == 'q') break;
                            if (action > '2' || action < '1') { Console.WriteLine("Error"); }
                            switch (action)
                            {
                                case '1':
                                    Console.WriteLine($"Imaginary part of first number is {firstNum.Imaginary()}");
                                    break;
                                case '2':
                                    Console.WriteLine($"Imaginary part of second number is {secondNum.Imaginary()}");
                                    break;
                                default:
                                    Console.WriteLine("invalid action");
                                    break;
                            }
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    case '9':
                        if (flag == true)
                        {
                            Console.WriteLine("Select num:");
                            Console.WriteLine("1. First number");
                            Console.WriteLine("2. Second number");
                            action = Convert.ToChar(Console.ReadLine());
                            if (action == 'Q' || action == 'q') break;
                            if (action > '2' || action < '1') { Console.WriteLine("Error"); }
                            switch (action)
                            {
                                case '1':
                                    Console.WriteLine($"First number is ");
                                    firstNum.Print();
                                    break;
                                case '2':
                                    Console.WriteLine($"Second number is ");
                                    secondNum.Print();
                                    break;
                                default:
                                    Console.WriteLine("invalid action");
                                    break;
                            }
                        }
                        else { Console.WriteLine("No numbers"); }
                        break;
                    default:
                        Console.WriteLine("invalid action");
                        break;

                }
                
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
