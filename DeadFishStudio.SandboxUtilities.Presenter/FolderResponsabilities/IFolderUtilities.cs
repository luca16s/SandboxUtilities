using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadFishStudio.SandboxUtilities.Presenter.FolderResponsabilities
{
    public interface IFolderUtilities
    {
        bool CreateFolder(string path);
        void DeleteFolder(string path);
        bool SearchFolder(string path);
    }
}
