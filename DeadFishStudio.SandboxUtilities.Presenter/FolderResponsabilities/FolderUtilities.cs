using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadFishStudio.SandboxUtilities.Presenter.FolderResponsabilities
{
    public class FolderUtilities : IFolderUtilities
    {
        public bool CreateFolder(string path) => Directory.CreateDirectory(path).Exists;

        public void DeleteFolder(string path)
        {
            if (!SearchFolder(path))
                return;

            Directory.Delete(path);
        }

        public bool SearchFolder(string path) => Directory.Exists(path);
    }
}
