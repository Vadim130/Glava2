public class Task25
{

    public static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        Task<int> t = FirstRespondingUrlAsync(client, "http://mail.ru", "https://ya.ru");
        Console.WriteLine("Длина данных: {0}", await t);

    }
    // Возвращает длину данных первого ответившего URL-адреса.
    static async Task<int> FirstRespondingUrlAsync(HttpClient client,
     string urlA, string urlB)
    {
        // Запустить обе загрузки параллельно.
        Task<byte[]> downloadTaskA = client.GetByteArrayAsync(urlA);
        Task<byte[]> downloadTaskB = client.GetByteArrayAsync(urlB);
        // Ожидать завершения любой из этих задач.
        Task<byte[]> completedTask =
        await Task.WhenAny(downloadTaskA, downloadTaskB);
        // Вернуть длину данных, загруженных по этому URL-адресу.
        byte[] data = await completedTask;
        return data.Length;
    }
}