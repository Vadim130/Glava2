public class Task2102
{
    static bool CanBehaveSynchronously = false;
    public static async Task Main(string[] args)
    {
        CanBehaveSynchronously = true;
        ValueTask<int> t = MethodAsync();
        
        int result = await t;
        Console.WriteLine(result);
    }
    static public ValueTask<int> MethodAsync()
    {
        if (CanBehaveSynchronously)
            return new ValueTask<int>(13);
        return new ValueTask<int>(SlowMethodAsync());
    }
    static private Task<int> SlowMethodAsync()
    {
        Task.Delay(100);
        return Task.FromResult(26);
    }
}