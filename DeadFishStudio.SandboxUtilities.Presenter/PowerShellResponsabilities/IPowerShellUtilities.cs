using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace DeadFishStudio.SandboxUtilities.PowerShellResponsabilities
{
    public interface IPowerShellUtilities
    {
        List<string> CallPowerShellCommandLine(string name, params string[] args);
    }
}
