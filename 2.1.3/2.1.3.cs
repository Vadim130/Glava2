public class Task213
{ 
    static async Task<string> DownloadStringWithTimeout(HttpClient client, string uri)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        Task<string> downloadTask = client.GetStringAsync(uri);
        Task timeoutTask = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);
        Task completedTask = await Task.WhenAny(downloadTask, timeoutTask);
        if (completedTask == timeoutTask)
            return null;
        return await downloadTask;
    }
    public static async Task Main(string[] args)
    {
        HttpClient clnt = new HttpClient();
        Task<string> dnlTask = DownloadStringWithTimeout(clnt, "http://www.mail.ru");
        try
        {
            string str = await dnlTask;
            if (str == null)
                Console.WriteLine("Тайм аут");
            else
                Console.WriteLine("Получил строку:\n{0}", str);
        }
        catch (System.Net.Http.HttpRequestException ex)
        {
            Console.WriteLine("Ошибка: {0}", ex.Message);
        }
    }
}
