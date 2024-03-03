public class Task2101
{

    public static async Task Main(string[] args)
    {
        ValueTask<int> t = MethodAsync();
        int result = await t;
        Console.WriteLine(result);
    }
    static public async ValueTask<int> MethodAsync()
    {
        await Task.Delay(100); // Асинхронная работа.
        return 13;
    }
}