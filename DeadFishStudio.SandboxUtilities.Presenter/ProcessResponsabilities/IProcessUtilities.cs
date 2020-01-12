using System.Diagnostics;

namespace DeadFishStudio.SandboxUtilities.Presenter.ProcessResponsabilities
{
    public interface IProcessUtilities
    {
        int StartProcess(string processName, string args = null);
        Process[] SearchProcess(string processName);
        void StopProcess(Process[] processes);
    }
}
