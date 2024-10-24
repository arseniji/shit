
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml.Linq;


class ReversePolishNotation
{
    public static int Weight(string opertator)
    {
        switch (opertator)
        {
            case "+":
                return 2;
            case "-":
                return 2;
            case "*":
            case "/":
            case "div":
                return 3;
            case "^":
                return 4;
            case "sqrt":
            case "ln":
            case "cos":
            case "sin":
            case "tg":
            case "ctg":
            case "abs":
            case "log":
            case "min":
            case "max":
            case "mod":
            case "exp":
            case "trunc":
                return 5;
            case "%":
                return 6;
            default: return 0;
        }
    }
    public static string GetNum(string line, ref int pos)
    {
        string num = "";
        for (; pos < line.Length; pos++)
        {
            if (Char.IsDigit(line[pos]) || line[pos] == ',') num += line[pos];
            else { pos--; break; }
        }
        return num;
    }
    public static string GetText(string line, ref int pos)
    {
        string text = "";
        for (; pos < line.Length; pos++)
        {
            if (Char.IsLetter(line[pos]) || line[pos] == '/') text += line[pos];
            else { pos--; break; }
        }
        return text;
    }
    public static string GetPostfix(string infix)
    {
        string postfix = "";
        var stack = new MyStack<string>();
        for (int i = 0; i < infix.Length; i++)
        {
            if (Char.IsDigit(infix[i])) postfix += GetNum(infix, ref i)+ " ";
            else if (Char.IsLetter(infix[i]))
            {
                string operation = "";
                operation += GetText(infix, ref i);
                if (Weight(operation) != 0)
                {

                    while (!stack.Empty() && (Weight(stack.Peek()) >= Weight(operation)))
                    {
                        postfix += stack.Peek()+ " ";
                        stack.Pop();
                    }
                    stack.Push(operation);
                }
            }
            else if (Weight(Convert.ToString(infix[i])) != 0)
            {
                while (!stack.Empty() && (Weight(stack.Peek()) >= Weight(Convert.ToString(infix[i]))))
                {
                    postfix += stack.Peek() + " ";
                    stack.Pop();
                }

                stack.Push(Convert.ToString(infix[i]));
            }
            else if (infix[i] == '(' && i + 1 != infix.Length && infix[i + 1] == '-')
            {
                if (Char.IsDigit(infix[i + 2]))
                {
                    i += 2;
                    string temp = GetNum(infix, ref i);
                    postfix += Convert.ToString('~') + temp + " ";
                    i += 1;
                }
            }
            else if (infix[i] == '(') stack.Push(Convert.ToString(infix[i]));
            else if (infix[i] == ')')
            {
                while (stack.Peek() != "(")
                {
                    postfix += stack.Peek() + " ";
                    stack.Pop();
                }
                stack.Pop();
            }
        }
        while (!stack.Empty())
        {
            postfix += stack.Peek() + " ";
            stack.Pop();
        }
        return postfix;
    }
    private static double Do(string op, params double[] x) => op switch
    {
        "+" => x[0] + x[1],
        "-" => x[0] - x[1],
        "*" => x[0] * x[1],
        "/" => x[0] / x[1],
        "^" => Math.Pow(x[0], x[1]),
        "div" => Math.Floor(x[0] / x[1]),
        "exp" => Math.Exp(x[0]),
        "sqrt" => Math.Sqrt(x[0]),
        "abs" => Math.Abs(x[0]),
        "ln" => Math.Log(x[0]),
        "log" => Math.Log10(x[0]),
        "sin" => Math.Sin(x[0]),
        "cos" => Math.Cos(x[0]),
        "tg" => Math.Tan(x[0]),
        "ctg" => 1 / Math.Tan(x[0]),
        "max" => x[0] > x[1] ? x[0] : x[1],
        "min" => x[0] < x[1] ? x[0] : x[1],
        "trunc" => Math.Truncate(x[0]),
        "mod" => (int)x[0] % (int)x[1],
        _ => 0
    };
     public static double Calc(string postFix)
    {
        string name = "";
        Stack<double> component = new Stack<double>();
        for (int i = 0; i < postFix.Length; i++)
        {
            name = "";
            if (Char.IsDigit(postFix[i]))
            {
                string number = GetNum(postFix, ref i);
                component.Push(Convert.ToDouble(number));
            }
            else if (Char.IsLetter(postFix[i]))
            {
                name += GetText(postFix, ref i);
            }
            else if ((i + 1 < postFix.Length || i + 2 < postFix.Length) && postFix[i] == '~')
            {
                if (Char.IsDigit(postFix[i + 1]))
                {
                    i += 1;
                    string number;
                    number = GetNum(postFix, ref i);
                    double x = Convert.ToDouble(number);
                    component.Push(-x);
                    i += 1;
                }
            }
            else if (Weight(Convert.ToString(postFix[i])) != 0)
            {
                double y = component.Peek();
                component.Pop();
                double x = component.Peek();
                component.Pop();
                component.Push(Do(Convert.ToString(postFix[i]), x, y));
            }
            if (Weight(name) != 0 && name == "div")
            {
                double y = component.Peek();
                component.Pop();
                double x = component.Peek();
                component.Pop();
                component.Push(Do(name, x, y));
            }

            if (Weight(name) != 0)
            {

                if (Weight(name) == 5 && (name != "mod" || name != "min" || name != "max"))
                {
                    double y = component.Peek();
                    component.Pop();
                    component.Push(Do(Convert.ToString(name), y));
                }
                else if (Weight(name) == 5 && (name == "mod" || name == "min" || name == "max"))
                {
                    double y = component.Peek();
                    component.Pop();
                    double x = component.Peek();
                    component.Pop();
                    component.Push(Do(Convert.ToString(name), x, y));
                }
            }
        }
        return component.Peek();
    }
    static void Main(string[] args)
    {

        string line = Console.ReadLine();
        string postfix = GetPostfix(line);
        Console.WriteLine(postfix);
        double res = Calc(postfix);
        Console.WriteLine(res);
    }
}

