using System.Diagnostics;

public class Task261
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
    // В текущей версии метод выводит "2", "3" и "1".
    // При этом метод должен выводить "1", "2" и "3".
    static async Task ProcessTasksAsync()
    {
        // Создать последовательность задач.
        Task<int> taskA = DelayAndReturnAsync(2);
        Task<int> taskB = DelayAndReturnAsync(3);
        Task<int> taskC = DelayAndReturnAsync(1);
        Task<int>[] tasks = new[] { taskA, taskB, taskC };
        // Ожидать каждую задачу по порядку.
        foreach (Task<int> task in tasks)
        {
            var result = await task;
            Trace.WriteLine(result);
        }
    }
}