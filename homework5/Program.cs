namespace homework5;

class Program
{
    static async Task Main(string[] args)
    {
        List<string> urls = new List<string>
        {
            "https://leetcode.com/problemset/",
            "https://www.codewars.com",
            "https://ru.wikipedia.org/wiki/Заглавная_страница",
            "https://monkeytype.com"
        };

        List<string> result = new List<string>();
        
        using (CancellationTokenSource cts = new CancellationTokenSource())
        {
            cts.CancelAfter(TimeSpan.FromSeconds(10)); // ограничение на выполнение

            Console.WriteLine("Нажмите любую клавишу для отмены...");
            Task cancelTask = Task.Run(() =>
            {
                Console.ReadKey();
                cts.Cancel();
            });

            try
            {
                result = await WebDownloader.DownloadUrlsAsync(urls, cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция была отменена.");
            }
            finally
            {
                cts.Cancel();
            }
        }
    }
}