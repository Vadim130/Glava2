
interface IMyAsyncInterface
{
    Task DoSomethingAsync();
}
class MySynchronousImplementation : IMyAsyncInterface
{
    public Task DoSomethingAsync()
    {
        return Task.CompletedTask;
    }
}

public class Task222
{
    public static async Task Main(string[] args)
    {
        IMyAsyncInterface myAs = new MySynchronousImplementation();
        await myAs.DoSomethingAsync();
    }
}