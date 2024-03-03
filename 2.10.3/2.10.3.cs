public class Task2103
{
    public static async Task Main(string[] args)
    {
        ValueTask t = DisposeAsync();
        await t;
        Console.WriteLine(t.IsCompleted);
    }
    static private Func<Task> _disposeLogic;
    static public ValueTask DisposeAsync()
    {
        if (_disposeLogic == null)
            return default;
        // Примечание: этот простой пример не является потокобезопасным;
        // если сразу несколько потоков вызовут DisposeAsync,
        // логика может быть выполнена более одного раза.
         Func<Task> logic = _disposeLogic;
        _disposeLogic = null;
        return new ValueTask(logic());
    }
}