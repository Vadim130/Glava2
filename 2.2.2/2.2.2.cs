IMyAsyncInterface myAs = new MySynchronousImplementation();
await myAs.DoSomethingAsync();

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