using System.Diagnostics;
using Nito.AsyncEx;
public class Task264
{

    public static async Task Main(string[] args)
    {
        Task t = UseOrderByCompletionAsync();
        await t;
    }
    static async Task<int> DelayAndReturnAsync(int value)
    {
        await Task.Delay(TimeSpan.FromSeconds(value));
        return value;
    }
    // Этот метод теперь выводит "1", "2" и "3".
    static async Task UseOrderByCompletionAsync()
    {
        // Создать последовательность задач.
        Task<int> taskA = DelayAndReturnAsync(2);
        Task<int> taskB = DelayAndReturnAsync(3);
        Task<int> taskC = DelayAndReturnAsync(1);
        Task<int>[] tasks = new[] { taskA, taskB, taskC };
        // Ожидать каждой задачи по мере выполнения.
        foreach (Task<int> task in tasks.OrderByCompletion())
        {
            int result = await task;
            Trace.WriteLine(result);
        }
    }
}