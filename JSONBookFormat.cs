using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace library_system
{
    public class JSONBookFormat : IFileType
    {
        public List<Book> Read(string url)
        {
            if (File.Exists(url))
            {
                string existingData;
                using (StreamReader reader = new StreamReader(url, Encoding.Default))
                {
                    existingData = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<List<Book>>(existingData);
            }
            else
            {
                return new List<Book>() {};
            }
        }

        public void Write(string url, List<Book> books)
        {
            using (StreamWriter file = File.CreateText(@"library.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, books);
            }            
        }
    }
}