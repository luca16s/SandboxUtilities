namespace DeadFishStudio.SandboxUtilities.Commands.Git
{
    public class GitCommands : IGitCommands
    {
        public string BranchName { get; set; }
        public string RepositoryUrl { get; set; }

        public GitCommands()
        {

        }

        public GitCommands(string branchName, string repositoryUrl)
        {
            BranchName = branchName;
            RepositoryUrl = repositoryUrl;
        }

        public string GitPull => "git pull";
        public string GitClone => $"git clone --single-branch --branch {BranchName} {RepositoryUrl}";
    }
}
