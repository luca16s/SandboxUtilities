namespace DeadFishStudio.SandboxUtilities.Commands.Directory
{
    public class DirectoryCommands : IDirectoryCommands
    {
        public string Path { get; set; }

        public DirectoryCommands()
        {

        }

        public DirectoryCommands(string path)
        {
            Path = path;
        }

        public string ChangeDirectory => $"cd {Path}";
    }
}
