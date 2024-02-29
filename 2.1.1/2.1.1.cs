public class Task211
{ 
    static async Task<T> DelayResult<T>(T result, TimeSpan delay)
    {
        await Task.Delay(delay);
        return result;
    }
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Задача 2.1.1");
        Task<int> t = DelayResult<int>(10, TimeSpan.FromSeconds(3));
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(100);
            Console.Write(i);
        }
        Console.WriteLine();
        int v = await t;
        Console.WriteLine("Value={0}", v);
    }
}