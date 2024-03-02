using System.Net;

public class Task243
{

    public static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        string[] urls = { "http://mail.ru", "https://google.com", "https://ya.ru" };
        Task<string> t = DownloadAllAsync(client, urls);
        Console.WriteLine("Скачано: {0}", await t);
    }
    static async Task<string> DownloadAllAsync(HttpClient client,
     IEnumerable<string> urls)
    {
        // Определить действие, выполняемое для каждого URL.
        var downloads = urls.Select(url => client.GetStringAsync(url));
        // Обратите внимание: задачи еще не запущены,
        // потому что последовательность не была обработана.
        // Запустить загрузку для всех URL одновременно.
        Task<string>[] downloadTasks = downloads.ToArray();
        // Все задачи запущены.
        // Асинхронно ожидать завершения всех загрузок.
        string[] htmlPages = await Task.WhenAll(downloadTasks);
        return string.Concat(htmlPages);
    }
}