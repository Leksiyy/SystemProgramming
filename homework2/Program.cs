namespace homework2;

class Program
{
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(Room1);
        Thread thread2 = new Thread(Room2);
        
        thread1.Start();
        thread2.Start();
    }

    static void Room1()
    {
        for (int i = 0; i < 20; i++)
        {
            Random rnd = new Random();
            Console.WriteLine("Now room1 has {0} degrees", (15.0 + rnd.NextDouble() * (30.0 - 15.0)).ToString("F1"));
            Thread.Sleep(1000);
        }
    }
    
    static void Room2()
    {
        for (int i = 0; i < 25; i++)
        {
            Random rnd = new Random();
            Console.WriteLine("\t\t\tNow room2 has {0} degrees", (15.0 + rnd.NextDouble() * (30.0 - 15.0)).ToString("F1"));
            Thread.Sleep(800);
        }
    }
}