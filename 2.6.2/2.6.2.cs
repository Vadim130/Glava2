using System.Diagnostics;
public class Task262
{
    public static async Task Main(string[] args)
    {
        Task t = ProcessTasksAsync();
        await t;
    }

    static async Task<int> DelayAndReturnAsync(int value)
    {
        await Task.Delay(TimeSpan.FromSeconds(value));
        return value;
    }
    static async Task AwaitAndProcessAsync(Task<int> task)
    {
        int result = await task;
        Trace.WriteLine(result);
    }
    // Этот метод теперь выводит "1", "2" и "3".
    static async Task ProcessTasksAsync()
    {
        // Создать последовательность задач.
        Task<int> taskA = DelayAndReturnAsync(2);
        Task<int> taskB = DelayAndReturnAsync(3);
        Task<int> taskC = DelayAndReturnAsync(1);
        Task<int>[] tasks = new[] { taskA, taskB, taskC };
        IEnumerable<Task> taskQuery =
        from t in tasks select AwaitAndProcessAsync(t);
        Task[] processingTasks = taskQuery.ToArray();
        // Ожидать завершения всей обработки
        await Task.WhenAll(processingTasks);
    }
}