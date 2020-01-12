using System.IO;

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

        public bool FolderHasItems(string path, string searchPattern = null) => Directory.GetFiles(path, searchPattern).Length > 0;

        public bool SearchFolder(string path) => Directory.Exists(path);
    }
}
