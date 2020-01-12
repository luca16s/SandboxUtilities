namespace DeadFishStudio.SandboxUtilities.Commands.Git
{
    public interface IGitCommands
    {
        string GitPull { get; }
        string GitClone { get; }
    }
}
