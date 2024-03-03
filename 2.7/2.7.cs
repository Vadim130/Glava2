using System.Diagnostics;

public class Task27
{

    public static async Task Main(string[] args)
    {
        Task t1 = ResumeOnContextAsync();
        Task t2 = ResumeWithoutContextAsync();

        await t1;
        await t2;
    }
    static async Task ResumeOnContextAsync()
    {
        int value = 13;

        await Task.Delay(TimeSpan.FromSeconds(1));
        // Этот метод возобновляется в том же контексте.        

        value *= 2;
        await Task.Delay(TimeSpan.FromSeconds(1));

        Trace.WriteLine(value);
    }
    static async Task ResumeWithoutContextAsync()
    {
        int value = 13;

        await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
        // Этот метод теряет свой контекст при возобновлении.

        value *= 2;
        await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

        Trace.WriteLine(value);
    }
}