namespace DeadFishStudio.SandboxUtilities.Commands.Flyway
{
    public interface IFlywayCommands
    {
        string  FlywayClean { get; }
        string FlywayMigrate { get; }
    }
}
