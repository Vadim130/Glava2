using System.Windows.Input;

sealed class MyAsyncCommand : ICommand
{
    async void ICommand.Execute(object parameter)
    {
        await Execute(parameter);
    }
    public async Task Execute(object parameter)
    {
        // Здесь размещается асинхронная реализация команды.
    }

    // Другие составляющие (CanExecute и т. д.)
}

public class Task291
{    public static async Task Main(string[] args)
    {

    }
}