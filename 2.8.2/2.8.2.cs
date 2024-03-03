public class Task282
{

    public static async Task Main(string[] args)
    {
        Task t = TestAsync();
        await t;
    }
    static async Task ThrowExceptionAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        throw new InvalidOperationException("Test");
    }
    static async Task TestAsync()
    {
        // Исключение выдается методом и помещается в задачу.
        Task task = ThrowExceptionAsync();
        try
        {
            // Здесь исключение будет выдано повторно.
            await task;
        }
        catch (Exception InvalidOperationException)
        {
            Console.WriteLine(InvalidOperationException.Message);
        }
    }
}