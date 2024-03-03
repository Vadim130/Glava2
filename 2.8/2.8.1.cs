public class Task281
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
        try
        {
            await ThrowExceptionAsync();
        }
        catch (Exception InvalidOperationException)
        {
            Console.WriteLine(InvalidOperationException.Message);
        }
    }
}