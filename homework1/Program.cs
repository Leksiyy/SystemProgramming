using System.Diagnostics;

namespace homework1;

class Program
{
    static void Main()
    {
        Process process = new Process();
        
        process.StartInfo.FileName = "/usr/bin/env";
        process.StartInfo.Arguments = "bash";
        process.Start();
        
        process.WaitForExit();
        Console.WriteLine("Process ended");
        
        // на маке процессы уходят в фон и process.WaitForExit срабатывает сразу после запуска
        // программы, поэтому вызвал утилиту
    }
}