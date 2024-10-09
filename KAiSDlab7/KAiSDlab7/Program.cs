
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
class lab7
{
    private static string pathToData = @"..\..\..\input.txt";
    private static string pathToOut = @"..\..\..\output.txt";
    static StreamReader sr = new StreamReader(pathToData);
    static StreamWriter sw = new StreamWriter(pathToOut);
    public static bool SUMM(string line)
    {
        if (line.Length > 0)
        {
            int num = Convert.ToInt32(line);
            if (num > 255) return false;
            else if (num >= 0) return true;
        }
        return false;
    }
    static bool ip(string line)
    {
        int dots = 0;
        if (line[0] == '.') return false;
        for (int i = 0; i < line.Length; i++)
        {
            if (!(line[i] == '.' || char.IsDigit(line[i]))) return false;
            if (line[i] == '.') dots++;
        }
        if (dots != 3) return false;
        else
        {
            string num = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i])) num += line[i];
                else if (line[i] == '.')
                {
                    if (SUMM(num)) num = "";
                    else return false;
                }
            }
            num = "";
            dots = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '.') dots++;
                if (dots == 3 && char.IsDigit(line[i]))
                {
                    num += line[i];
                }
            }
            if (!SUMM(num)) return false;
        }
        return true;
    }
    static MyVector<string> showIPs(MyVector<string> vector)
    {
        var new_vector = new MyVector<string>();
        for (int i = 0; i < vector.size(); i++)
        {
            string line = vector[i];
            if (ip(line)) new_vector.add(line);
        }
        return new_vector;
    }
    static MyVector<string> readIPs()
    {
        string line = sr.ReadToEnd();
        var vector = new MyVector<string>(line.Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries));
        return vector;
    }
    public static void Main(string[] args)
    {
        var vector = readIPs();
        for (int i = 0; i < vector.size(); i++) Console.WriteLine($"{i + 1}) {vector[i]}");

       var new_vector = showIPs(vector);
        for (int i = 0; i < new_vector.size(); i++) Console.WriteLine($"{i + 1}) {new_vector[i]}");

        for (int i = 0; i < new_vector.size(); i++)
        {
            sw.WriteLine(new_vector[i]);
        }
    }
}