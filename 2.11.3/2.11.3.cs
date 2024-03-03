public class Task2113
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
        Task<int> task = MethodAsync().AsTask();
        await Task.Delay(2);

        int value = await task;
        int anotherValue = await task;

        Console.WriteLine(value);
        Console.WriteLine(anotherValue);
    }
}