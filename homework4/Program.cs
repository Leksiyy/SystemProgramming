using System.Runtime.InteropServices.ComTypes;

namespace homework4;

class Program
{
    static void Main(string[] args)
    {
        object obj = new object();
        Bank bank = new Bank(250);
        
        Thread thread1 = new Thread(() => bank.Withdraw(250));
        Thread thread2 = new Thread(() => bank.Withdraw(250));
        
        thread1.Start();
        thread2.Start();
        
        thread1.Name = "Thread 1";
        thread2.Name = "Thread 2";
        
        thread1.Join();
        thread2.Join();
        
        Console.WriteLine(bank.Balance);
    }
}