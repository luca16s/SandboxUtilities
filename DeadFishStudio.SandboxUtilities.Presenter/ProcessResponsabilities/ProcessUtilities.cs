using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadFishStudio.SandboxUtilities.Presenter.ProcessResponsabilities
{
    public class ProcessUtilities : IProcessUtilities
    {
        public Process[] SearchProcess(string processName)
        {
            return Process.GetProcessesByName(processName);
        }

        public int StartProcess(string processName, string args = null)
        {
            var processStartInfo = new ProcessStartInfo(processName, args);

            using var process = Process.Start(processStartInfo);

            process.WaitForExit();
            return process.ExitCode;
        }

        public void StopProcess(Process[] processes)
        {
            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }
    }
}
