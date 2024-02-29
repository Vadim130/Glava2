public class Task241
{
    public static async Task Task1()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
    public static async Task Task2()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
    }

    public static async Task Main(string[] args)
    {
        Task task1 = Task1();
        Task task2 = Task2();
        Task task3 = Task.Delay(TimeSpan.FromSeconds(1));
        await Task.WhenAll(task1, task2, task3);
    }
}