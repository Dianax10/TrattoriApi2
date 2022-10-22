using System.Text.Json;
using TrattoriApi.Models;

namespace TrattoriApi.Helper
{
    public class FileHelper
    {
        public List<Trattore> ReadAndDeserialize(string path)
        {
            string json = File.ReadAllText(path);

            if (json == string.Empty)
            {
                return new List<Trattore>();
            }
            else
            {
                List<Trattore> trattori = JsonSerializer.Deserialize<List<Trattore>>(json);
                return trattori;
            }
        }

        public void WriteAndSerialize(string path, List<Trattore> trattori)
        {
            string json = JsonSerializer.Serialize(trattori);
            File.WriteAllText(path, json);
        }

    }
}
