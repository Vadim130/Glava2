public class Task2112
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
        ValueTask<int> valueTask = MethodAsync();
        await Task.Delay(2);
        int value = await valueTask;
        Console.WriteLine(value);
    }
}