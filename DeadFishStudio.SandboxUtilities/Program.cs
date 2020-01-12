using System.IO;
using DeadFishStudio.SandboxUtilities.Commands.Directory;
using DeadFishStudio.SandboxUtilities.Commands.Flyway;
using DeadFishStudio.SandboxUtilities.Commands.Git;
using DeadFishStudio.SandboxUtilities.Messages;
using DeadFishStudio.SandboxUtilities.PowerShellResponsabilities;
using DeadFishStudio.SandboxUtilities.Presenter.ConsoleResponsabilities;
using DeadFishStudio.SandboxUtilities.Presenter.FolderResponsabilities;
using DeadFishStudio.SandboxUtilities.Presenter.ProcessResponsabilities;
using DeadFishStudio.SandboxUtilities.JsonUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace DeadFishStudio.SandboxUtilities.Presenter
{
    internal static class Program
    {
        private static void Main()
        {
            var jsonConfigurationProvider = new ServiceCollection()
                .AddSingleton<IJsonUtilities<Configuration>, JsonUtilities<Configuration>>()
                .BuildServiceProvider();
            var jsonConfigurationUtilities = jsonConfigurationProvider.GetService<IJsonUtilities<Configuration>>();

            var folderProvider = new ServiceCollection()
                .AddSingleton<IFolderUtilities, FolderUtilities>()
                .BuildServiceProvider();
            var folderUtilities = folderProvider.GetService<IFolderUtilities>();

            var consoleProviders = new ServiceCollection()
                .AddSingleton<IConsoleUtilities, ConsoleUtilities>()
                .BuildServiceProvider();
            var consoleUtilities = consoleProviders.GetService<IConsoleUtilities>();

            if (!folderUtilities.FolderHasItems(Directory.GetCurrentDirectory(), "Configuration.json"))
            {
                var config = new Configuration
                {
                    BranchName = consoleUtilities.ReadUserInput(SystemDefaultMessages.BranchNameMessage),
                    DatabaseProcess = consoleUtilities.ReadUserInput(SystemDefaultMessages.DataBaseProcessMessage),
                    DirectoryPath = consoleUtilities.ReadUserInput(SystemDefaultMessages.DirectoryPathMessage),
                    RepositoryUrl = consoleUtilities.ReadUserInput(SystemDefaultMessages.RepositoryUrlMessage),
                    SearchPattern = consoleUtilities.ReadUserInput(SystemDefaultMessages.SearchPatternMessage),
                };

                jsonConfigurationUtilities.CreateFile(config, nameof(Configuration));
            }
            var configuration = jsonConfigurationUtilities.ReadFile(nameof(Configuration));

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IProcessUtilities, ProcessUtilities>()
                .AddSingleton<IPowerShellUtilities, PowerShellUtilities>()
                .AddSingleton<IFlywayCommands, FlywayCommands>()
                .AddSingleton<IGitCommands, GitCommands>(_ => new GitCommands(configuration.BranchName, configuration.RepositoryUrl))
                .AddSingleton<IDirectoryCommands, DirectoryCommands>(_ => new DirectoryCommands(configuration.DirectoryPath))
                .BuildServiceProvider();

            var processUtilities = serviceProvider.GetService<IProcessUtilities>();
            var powerShellUtilities = serviceProvider.GetService<IPowerShellUtilities>();
            var gitCommands = serviceProvider.GetService<IGitCommands>();
            var flywayCommands = serviceProvider.GetService<IFlywayCommands>();
            var directoryCommands = serviceProvider.GetService<IDirectoryCommands>();

            consoleUtilities.ChangeConsoleTitle(SystemDefaultMessages.SandboxUpdate);
            consoleUtilities.Greetings();
            consoleUtilities.InsertLineSeparator(SystemDefaultMessages.LineSeparator);

            consoleUtilities.ShowMessage(SystemDefaultMessages.VerifyingRepository);

            if (!folderUtilities.SearchFolder(directoryCommands.ChangeDirectory))
                folderUtilities.CreateFolder(directoryCommands.ChangeDirectory);

            if (!folderUtilities.FolderHasItems(directoryCommands.ChangeDirectory, configuration.SearchPattern))
            {
                foreach (var message in powerShellUtilities.CallPowerShellCommandLine(directoryCommands.ChangeDirectory, gitCommands.GitClone))
                {
                    consoleUtilities.ShowMessage(message);
                }
            }

            foreach (var message in powerShellUtilities.CallPowerShellCommandLine(directoryCommands.ChangeDirectory, gitCommands.GitPull))
                consoleUtilities.ShowMessage(message);

            consoleUtilities.InsertLineSeparator(SystemDefaultMessages.LineSeparator);

            var sqlDevelop = processUtilities.SearchProcess(configuration.DatabaseProcess);
            if (sqlDevelop.Length > 0)
                processUtilities.StopProcess(sqlDevelop);

            consoleUtilities.InsertLineSeparator(SystemDefaultMessages.LineSeparator);
            consoleUtilities.ShowMessage(SystemDefaultMessages.CleanSandbox);

            foreach (var message in powerShellUtilities.CallPowerShellCommandLine(directoryCommands.ChangeDirectory, flywayCommands.FlywayClean))
            {
                consoleUtilities.ShowMessage(message);
            }

            consoleUtilities.InsertLineSeparator(SystemDefaultMessages.LineSeparator);
            consoleUtilities.ShowMessage(SystemDefaultMessages.MigratingSandbox);

            foreach (var message in powerShellUtilities.CallPowerShellCommandLine(directoryCommands.ChangeDirectory, flywayCommands.FlywayMigrate))
            {
                consoleUtilities.ShowMessage(message);
            }
        }
    }
}
