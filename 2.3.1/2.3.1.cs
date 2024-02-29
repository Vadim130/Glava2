
public class Task231
{
    static async Task MyMethodAsync(IProgress<double> progress = null)
    {
        bool done = false;
        double percentComplete = 0;
        while (!done)
        {
            await Task.Delay(200);
            percentComplete += 10;
            if (percentComplete >= 100)
                done = true;
            progress?.Report(percentComplete);
        }
    }
    static async Task CallMyMethodAsync()
    {
        var progress = new Progress<double>();
        progress.ProgressChanged += (sender, args) =>
        {
            Console.WriteLine("Прогресс: {0}%", args);
        };
        await MyMethodAsync(progress);
        Console.WriteLine("Все готово!");
    }
    public static async Task Main(string[] args)
    {
        await CallMyMethodAsync();
    }
}