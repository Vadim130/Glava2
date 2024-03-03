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
        Task<int> task1 = MethodAsync().AsTask();
        Task<int> task2 = MethodAsync().AsTask();
        int[] results = await Task.WhenAll(task1, task2);
        Console.WriteLine(results[0]);
        Console.WriteLine(results[1]);
    }
}