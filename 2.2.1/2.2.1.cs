IMyAsyncInterface myAsyncInterface = new MySynchronousImplementation();
Console.Write("{0}", await myAsyncInterface.GetValueAsync());
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
