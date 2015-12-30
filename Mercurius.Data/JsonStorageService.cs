using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Mercurius.Data
{
    public class JsonStorageService<T>
    {
        private readonly string _jsonFilePath;

        public JsonStorageService()
        {
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dataPath = appPath ?? @"C:\";

            var jsonFileName = typeof (T).Name + ".json";

            _jsonFilePath = Path.Combine(dataPath, jsonFileName);
        }

        public IList<T> ReadAll()
        {
            if (!File.Exists(_jsonFilePath))
            {
                return new List<T>();
            }

            var jsonContent = File.ReadAllText(_jsonFilePath);
            return JsonConvert.DeserializeObject<IList<T>>(jsonContent);
        }

        public void AddItem(T item)
        {
            var allItems = ReadAll();
            allItems.Add(item);

            Save(allItems);
        }

        private void Save(IList<T> allItems)
        {
            var jsonContet = JsonConvert.SerializeObject(allItems);

            File.WriteAllText(_jsonFilePath, jsonContet);
        }
    }
}