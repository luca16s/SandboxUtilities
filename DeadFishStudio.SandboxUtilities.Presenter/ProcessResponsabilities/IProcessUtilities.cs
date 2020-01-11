using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadFishStudio.SandboxUtilities.Presenter.ProcessResponsabilities
{
    public interface IProcessUtilities
    {
        int StartProcess(string processName, string args = null);
        Process[] SearchProcess(string processName);
        void StopProcess(Process[] processes);
    }
}
