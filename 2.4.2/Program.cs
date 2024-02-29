public class Task242
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Начинаем тесты...");
        Task<int> task1 = Task.FromResult(3);
        Task<int> task2 = Task.FromResult(5);
        Task<int> task3 = Task.FromResult(7);
        int[] results = await Task.WhenAll(task1, task2, task3);
        foreach (var i in results)
            Console.WriteLine(i);
    }
}