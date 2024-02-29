
interface IMyAsyncInterface
{
    Task<int> GetValueAsync();
}
class MySynchronousImplementation : IMyAsyncInterface
{
    public Task<int> GetValueAsync()
    {
        return Task.FromResult(13);
    }
}

public class Task221
{
    public static async Task Main(string[] args)
    {
        IMyAsyncInterface myAsyncInterface = new MySynchronousImplementation();
        Console.Write("{0}", await myAsyncInterface.GetValueAsync());
    }
}