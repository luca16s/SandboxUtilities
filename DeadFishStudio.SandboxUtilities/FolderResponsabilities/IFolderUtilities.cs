namespace DeadFishStudio.SandboxUtilities.Presenter.FolderResponsabilities
{
    public interface IFolderUtilities
    {
        bool CreateFolder(string path);
        void DeleteFolder(string path);
        bool SearchFolder(string path);
        bool FolderHasItems(string path, string searchPattern = null);
    }
}
