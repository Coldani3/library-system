using System.Collections.Generic;

namespace library_system
{
    public interface IFileType
    {
        List<Book> Read(string fileURL);
        void Write(string url, List<Book> books);
    }
}