using DeadFishStudio.SandboxUtilities.Presenter.ConsoleResponsabilities;
using DeadFishStudio.SandboxUtilities.Presenter.FolderResponsabilities;
using DeadFishStudio.SandboxUtilities.Presenter.ProcessResponsabilities;
using Microsoft.Extensions.DependencyInjection;

namespace DeadFishStudio.SandboxUtilities.Presenter
{
    internal static class Program
    {
        private  static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConsoleUtilities, ConsoleUtilities>()
                .AddSingleton<IProcessUtilities, ProcessUtilities>()
                .AddSingleton<IFolderUtilities, FolderUtilities>()
                .BuildServiceProvider();

            var consoleUtilities = serviceProvider.GetService<IConsoleUtilities>();
            var processUtilities = serviceProvider.GetService<IProcessUtilities>();
            var folderUtilitiies = serviceProvider.GetService<IFolderUtilities>();

            consoleUtilities.ChangeConsoleTitle("Sandbox Update");

            consoleUtilities.Greetings();
            consoleUtilities.InsertLineSeparator("-------------------------------------------------------------");
            consoleUtilities.InsertLineSeparator("#############################################################");
            consoleUtilities.InsertLineSeparator("-------------------------------------------------------------");

            consoleUtilities.ShowDefaultMessage("Verificando repositório:");

            if (!folderUtilitiies.SearchFolder(@"C:\Users\gluca\Desktop\Modelagem"))
                folderUtilitiies.CreateFolder(@"C:\Users\gluca\Desktop\Modelagem");

            var git = processUtilities.SearchProcess("git.exe");
            if (git?.Length <= 0)
                processUtilities.StartProcess("git.exe"/*, @"git clone https://github.com/luca16s/MyPowershellScripts.git C:\Users\gluca\Desktop\Modelagem"*/);

        }
    }
}
