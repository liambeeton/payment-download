using System.IO;

namespace Payment.Core.FileSystem
{
    public interface IDirectoryHandler
    {
        DirectoryInfo Create(string path);
    }
}