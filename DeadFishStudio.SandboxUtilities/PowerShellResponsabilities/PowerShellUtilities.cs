using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace DeadFishStudio.SandboxUtilities.PowerShellResponsabilities
{
    public class PowerShellUtilities : IPowerShellUtilities
    {
        public List<string> CallPowerShellCommandLine(params string[] scripts)
        {
            using var powerShell = PowerShell.Create();
            using var runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            powerShell.Runspace = runspace;

            powerShell.Streams.Warning.Clear();
            powerShell.Streams.Error.Clear();

            foreach (var script in scripts)
            {
                powerShell.AddScript(script);
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
