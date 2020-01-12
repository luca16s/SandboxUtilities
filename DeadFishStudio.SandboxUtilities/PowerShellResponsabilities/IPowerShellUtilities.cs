using System.Collections.Generic;

namespace DeadFishStudio.SandboxUtilities.PowerShellResponsabilities
{
    public interface IPowerShellUtilities
    {
        List<string> CallPowerShellCommandLine(params string[] scripts);
    }
}
