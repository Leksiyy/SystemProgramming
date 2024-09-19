namespace SystemProgramming;

class Program
{
    static void Main(string[] args)
    {
        ParameterizedThreadStart threadStart = new ParameterizedThreadStart(Method2);
        Thread thread = new Thread(Method1);
        Thread thread2 = new Thread(Method2);
        Console.ReadLine();
    }

    static void Method1()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(i + "\n");
        }
    }

    static void Method2(object o)
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine("\t\t\t" + o + "\n");
        }
    }
}