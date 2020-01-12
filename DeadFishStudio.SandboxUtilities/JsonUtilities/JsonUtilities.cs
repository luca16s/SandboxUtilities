using System.IO;
using Newtonsoft.Json;

namespace DeadFishStudio.SandboxUtilities.JsonUtilities
{
    public class JsonUtilities<T> : IJsonUtilities<T> where T : class
    {
        public void CreateFile(T data, string fileName)
        {
            using var file = File.CreateText($@"{Directory.GetCurrentDirectory()}\{fileName}.json");
            var json = new JsonSerializer();
            json.Serialize(file, data);
        }

        public T ReadFile(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText($@"{Directory.GetCurrentDirectory()}\{fileName}.json"));
        }
    }
}
