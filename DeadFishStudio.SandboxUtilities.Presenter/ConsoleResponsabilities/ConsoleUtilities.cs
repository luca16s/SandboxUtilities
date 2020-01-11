using System;
using System.Diagnostics;

namespace DeadFishStudio.SandboxUtilities.Presenter.ConsoleResponsabilities
{
    public class ConsoleUtilities : IConsoleUtilities
    {
        public void ChangeConsoleTitle(string title) => Console.Title = title;

        public void ClearConsole() => Console.Clear();

        public void InsertLineSeparator(string separator) => Console.WriteLine(separator);

        public void ShowDefaultMessage(string message) => Console.WriteLine(message);

        public void ShowErrorMessage(string message)
        {
            ShowDefaultMessage(message);
            Console.Beep();
        }

        public void  Greetings()
        {
            var date = DateTime.Now;

            if (date.Hour < 12)
            {
                Console.WriteLine("Bom Dia!");
            }
            else if (date.Hour > 18)
            {
                Console.WriteLine("Boa Noite!");
            }
            else
            {
                Console.WriteLine("Boa Noite!");
            }

            Console.WriteLine($"{date.DayOfWeek}, {date.Date.ToShortDateString()}.");
        }
    }
}
