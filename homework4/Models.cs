namespace homework4;

public class Bank
{
    private object locker = new object();
    public int Balance { get; set; }

    public Bank(int balance)
    {
        Balance = balance;
    }

    public void Withdraw(int amount)
    {
        Monitor.Enter(locker);
        try
        {
            if (Balance - amount < 0) return;
            Console.WriteLine(Thread.CurrentThread.Name + " is do withdraw");
            Balance -= amount;
        }
        finally
        {
            Monitor.Exit(locker);
        }
    }
}