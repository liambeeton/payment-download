using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Payment.Core.FileSystem
{
    public class DirectoryHandler : IDirectoryHandler
    {
        public DirectoryInfo Create(string path)
        {
            var securityIdentifier = new SecurityIdentifier(WellKnownSidType.CreatorOwnerSid, null);
            var fileSystemAccessRule = new FileSystemAccessRule(securityIdentifier, FileSystemRights.FullControl, AccessControlType.Allow);
            var directorySecurity = new DirectorySecurity();

            directorySecurity.AddAccessRule(fileSystemAccessRule);

            return Directory.CreateDirectory(path, directorySecurity);
        }
    }
}
