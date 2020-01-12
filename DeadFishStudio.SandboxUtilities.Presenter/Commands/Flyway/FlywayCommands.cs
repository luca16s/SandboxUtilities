namespace DeadFishStudio.SandboxUtilities.Commands.Flyway
{
    public class FlywayCommands : IFlywayCommands
    {
        public string FlywayClean => @".\flyway clean";

        public string FlywayMigrate => @".\flyway migrate";
    }
}
