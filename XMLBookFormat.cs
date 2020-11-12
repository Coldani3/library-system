using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace library_system
{
    public class XMLBookFormat : IFileType
    {
        public List<Book> Read(string url)
        {
            if (File.Exists(url))
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                using (var reader = new StreamReader(url))
                {
                    try
                    {
                        return (List<Book>)serializer.Deserialize(reader);
                    }
                    catch
                    {
                        Console.WriteLine($"Could not load file {url}");
                        return new List<Book>() {};
                    } // Could not be deserialized to this type.
                }
            }
            else
            {
                return new List<Book>() {};
            }
        }

        public void Write(string url, List<Book> books)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            
            using (var writer = new StreamWriter(url))
            {
                serializer.Serialize(writer, books);
            }   
        }
    }
}