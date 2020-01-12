namespace DeadFishStudio.SandboxUtilities.Presenter.ConsoleResponsabilities
{
    public interface IConsoleUtilities
    {
        void ChangeConsoleTitle(string title);
        void ClearConsole();
        void InsertLineSeparator(string separator);
        void ShowMessage(string message);
        void Greetings();
        string ReadUserInput(string message);
    }
}
