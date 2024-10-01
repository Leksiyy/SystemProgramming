namespace homework6;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = "../../../example.txt";

        try
        {
            string content = await ReadFileAsync(filePath);

            int characterCount = content.Length;

            Console.WriteLine($"Количество символов в файле: {characterCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static async Task<string> ReadFileAsync(string filePath)
    {
        return await File.ReadAllTextAsync(filePath);
    }
}