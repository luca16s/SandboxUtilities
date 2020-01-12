using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace DeadFishStudio.SandboxUtilities.PowerShellResponsabilities
{
    public class PowerShellUtilities : IPowerShellUtilities
    {
        public List<string> CallPowerShellCommandLine(string name, params string[] args)
        {
            using var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            using var powerShell = PowerShell.Create();
            powerShell.Runspace = runspace;

            foreach (var arg in args)
            {
                powerShell.AddScript($"{name} {arg}");
            }

            powerShell.Invoke();

            return ReturnListOfErrors(powerShell.Streams.Error);
        }

        private static List<string> ReturnListOfErrors(PSDataCollection<ErrorRecord> dataCollections)
        {
            var consoleOutput = new List<string>();
            foreach (var item in dataCollections)
            {
                consoleOutput.Add(item.Exception.Message);
            }

            return consoleOutput;
        }
    }
}
