public class Task2111
{
    public static async Task Main(string[] args)
    {
        Task t = ConsumingMethodAsync();
        await t;
    }
    static ValueTask<int> MethodAsync()
    {
        return new ValueTask<int>(13);
    }
    static async Task ConsumingMethodAsync()
    {
        int value = await MethodAsync();
        Console.WriteLine(value);
    }
}