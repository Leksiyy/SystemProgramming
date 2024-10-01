namespace homework5;

public static class WebDownloader
{
    public static async Task<List<string>> DownloadUrlsAsync(List<string> urls, CancellationToken token)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            List<Task<string>> tasks = new List<Task<string>>();

            foreach (var url in urls)
            {
                tasks.Add(DownloadUrlAsync(httpClient, url, token));
            }

            var contents = await Task.WhenAll(tasks);

            return [..contents];
        }
    }

    public static async Task<string> DownloadUrlAsync(HttpClient httpClient, string url, CancellationToken token)
    {
        try
        {
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Начинаем загрузку: {url}");
            var response = await httpClient.GetAsync(url, token);

            string content = await response.Content.ReadAsStringAsync(token);

            Console.WriteLine($"Загрузка завершена для {url}, длина содержимого: {content.Length}");

            return content;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"Загрузка отменена для {url}");
            return string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке {url}: {ex.Message}");
            return string.Empty;
        }
    }
}