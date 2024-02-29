
interface IMyAsyncInterface
{
    Task DoSomethingAsync();
}
class MySynchronousImplementation : IMyAsyncInterface
{
    private void DoSomethingSynchronously()
    {
        throw new Exception("Тестовое исключение");
    }
    public Task DoSomethingAsync()
    {
        try
        {
            DoSomethingSynchronously();
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }
}

public class Task224
{
    public static async Task Main(string[] args)
    {
        IMyAsyncInterface myAsyncInterface = new MySynchronousImplementation();
        try
        {
            await myAsyncInterface.DoSomethingAsync();
            Console.WriteLine("Задача завершилась успешно");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Получено исключение: {0}", ex.Message);
        }
    }
}