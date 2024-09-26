namespace SystemProgramming;
 
class Program
{
    static void Main(string[] args)
    {
        Task task = Task.Factory.StartNew(() =>
        {
            var list = CalculatePrimes(1000);
            foreach (var a in list)
            {
                Console.WriteLine(a);
            }
        });
        
        task.Wait();
        Console.WriteLine("Main end");
    }
 
    static List<int> CalculatePrimes(int limit)
    {
        List<int> primes = new List<int>();

        for (int num = 2; num <= limit; num++) // начинаю с 2 потому что 1 не являеься простым числом
        {
            bool isPrime = true;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primes.Add(num);
            }
        }

        return primes;
    }
}