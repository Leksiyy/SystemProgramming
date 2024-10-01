namespace homework7;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://jsonplaceholder.typicode.com/users/1";

        using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        
        try
        {
            string userData = await GetUserDataAsync(url, cts.Token);
            Console.WriteLine("Запрос был удачно завершен.");
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine("Запрос был отменен. Сервер не ответил вовремя.");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Ошибка при загрузке данных: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка: {e.Message}");
        }
    }

    static async Task<string> GetUserDataAsync(string url, CancellationToken ct)
    {
        Random rnd = new Random(); // для непредвиденной задержки сервера

        using HttpClient client = new HttpClient();
        
        await Task.Delay(rnd.Next(5000, 15000), ct);
            
        HttpResponseMessage response = await client.GetAsync(url, ct);
            
        response.EnsureSuccessStatusCode();
            
        return await response.Content.ReadAsStringAsync(ct);
    }
}