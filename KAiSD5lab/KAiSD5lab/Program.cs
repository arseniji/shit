
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

class lab5 
{
    private static string pathToData = @"..\..\..\input.txt";
    static StreamReader sr = new StreamReader(pathToData);
    static MyArrayList<string> readTags() 
    {
        bool openFlag = false;
        bool closeFlag = false;
        bool slashFlag = false;
        var array = new MyArrayList<string>();
        string tag = "";
        string? line = sr.ReadLine();
        while (line != null)
        {
            closeFlag = false;
            tag = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '<' && line[i + 1] != null)
                {
                    if (line[i + 1] == '/') { slashFlag = true; openFlag = true;}
                    else if ((char.IsLetter(line[i + 1])) && !char.IsDigit(line[i + 1])) { slashFlag = false; openFlag = true; }
                    else
                    {
                        do
                        {
                            if (i >= line.Length - 1) break;
                            i++;
                        } while (line[i + 1] != '<');
                        tag = "";
                    }
                    if (i == line.Length) break;
                }
                if (slashFlag == false && line[i] == '/') { openFlag = false; tag = ""; }
                if (slashFlag == true && line[i] == '/') { slashFlag = false; }
                if (line[i] == '/' && char.IsDigit(line[i + 1])) openFlag = false;
                if (line[i] == '>' && openFlag == true) { openFlag = false; tag += line[i]; closeFlag = true; }
                if (openFlag && (line[i] == '<' || line[i] == '/'  || char.IsLetter(line[i]) || char.IsDigit(line[i]))) tag += line[i];
                if (closeFlag == true) {array.add(tag); tag = ""; closeFlag = false;}
            }
            line = sr.ReadLine();
        }
        return array;
    }
    static MyArrayList<string> dellDub(MyArrayList<string> array)
    {
        var containsAll = new MyArrayList<string>();
        var containsUnique = new MyArrayList<string>();
        string line;
        for (int i = 0; i < array.size(); i++)
        {
            line = array[i].ToLower().Replace("/",string.Empty);
            containsAll.add(line);
        }
        for (int i = 0; i < array.size(); i++)
        {
            for (int j = i + 1; j < array.size(); j++)
            {
                if (containsAll[i] == containsAll[j]) array.set(j,"");    
            }
        }
        for (int i = 0; i < array.size(); i++)
        {
            if (array[i] == "") continue;
            containsUnique.add(array[i]);
        }

        return containsUnique;
    }
    public static void Main(string[] args)
    {
        var mas = new MyArrayList<string>();
        var sas = new MyArrayList<string>();
        mas = readTags();
        sas = dellDub(mas);
        for (int i = 0; i < sas.size(); i++) Console.WriteLine($"{i + 1}) {sas[i]}");
    }
}