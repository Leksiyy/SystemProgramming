namespace homework3;

class Program
{
    static async Task Main(string[] args)
    {
        Ant ant1 = new Ant(0, 0, 2, "soldat");
        Ant ant2 = new Ant(5, 5, 2, "soldat");


        World.Instance.AddEntity(ant1);
        World.Instance.AddEntity(ant2);

        var task1 = Task.Run(() => ant1.Move());
        var task2 = Task.Run(() => ant2.Move());

        await Task.WhenAll(task1, task2);
    }
}