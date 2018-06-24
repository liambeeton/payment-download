using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Payment.Core.FileSystem
{
    public class DirectoryHandler : IDirectoryHandler
    {
        public DirectoryInfo Create(string path, string identity)
        {
            var fileSystemAccessRule = new FileSystemAccessRule(
                identity ?? WindowsIdentity.GetCurrent().Name, 
                FileSystemRights.FullControl, 
                AccessControlType.Allow);

            var directorySecurity = new DirectorySecurity();
            directorySecurity.AddAccessRule(fileSystemAccessRule);

            return Directory.CreateDirectory(path, directorySecurity);
        }
    }
}
