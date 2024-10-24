public class MyStack<T> : MyVector<T>
{
    MyVector<T> stack;
    int top;
    public MyStack() { top = -1;stack = new MyVector<T>(1);}
    public void Push(T e) { stack.add(e); top++; }
    public void Pop() { stack.removeInd(top--);top--; }
    public T Peek() { if (top == -1) throw new Exception("NO ELEMENTES"); else return stack.get(top); }
    public bool Empty() { if (top == -1) return true; return false;  }
    public int Search(T e) { if (stack.indexOf(e) == -1) return -1; return top - stack.indexOf(e) + 1; }
}
class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(52);
        stack.Push(1337);
        stack.Push(1488);
        Console.WriteLine(stack.Peek());
        stack.Pop();
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Search(52));
    }
}