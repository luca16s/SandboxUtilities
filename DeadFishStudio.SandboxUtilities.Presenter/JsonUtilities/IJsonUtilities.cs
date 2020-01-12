namespace DeadFishStudio.SandboxUtilities.JsonUtilities
{
    public interface IJsonUtilities<T> where T : class
    {
        public T ReadFile(string fileName);
        public void CreateFile(T data, string fileName);
    }
}
