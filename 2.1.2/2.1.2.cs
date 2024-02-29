public class Task212
{ 
    static async Task<string> DownloadStringWithRetries(HttpClient client, string uri)
    {
        // Повторить попытку через 1 секунду, потом через 2 и через 4 секунды.
        TimeSpan nextDelay = TimeSpan.FromSeconds(1);
        for (int i = 0; i != 3; ++i)
        {
            try
            {
                return await client.GetStringAsync(uri);
            }
            catch
            {
            }
            await Task.Delay(nextDelay);
            nextDelay = nextDelay + nextDelay;
        }
        // Попробовать в последний раз и разрешить распространение ошибки.
        return await client.GetStringAsync(uri);
    }
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Задача 2.1.2");
        HttpClient c = new HttpClient();
        string uri = "http://www.mail.ru";
        Task<string> t = DownloadStringWithRetries(c, uri);
        Console.WriteLine("Downloading {0}...", uri);
        try
        {
            string s = await t;
            Console.WriteLine("Got message:{0}", s);
        }
        catch (System.Net.Http.HttpRequestException x)
        {
            Console.WriteLine("Exception occured, details: {0}", x.ToString());
        }
    }
}