using System.Text.Json;
using System.Resources;
namespace cs_mvc_sprint.Utils
{
    public class JsonReader
    {
        public const string CONNECTION_STRING = "";

        public static string ReadFile(string filePath)
        {
            string path = $"{filePath}.json";
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
        public static void WriteFile<T>(string FileName, List<T> data)
        {
            string path = $"{FileName}.json";
            using (StreamWriter sr = new StreamWriter(path))
            {
                sr.WriteLine(JsonSerializer.Serialize(data));
            }
        }
    }
}
