using System.IO;

namespace Infrastructure.Helpers
{
    public static class FileHelper
    {
        public static FileInfo GetFileInfo(string path, string filename)
        {
            var filePath = Path.Combine(path, filename);

            if (!File.Exists(filePath))
                return null;

            return new FileInfo(filePath);
        }

        public static DirectoryInfo GetDirectoryInfo(string path, bool create = false)
        {
            var dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                if (!create)
                    return null;

                dirInfo.Create();
            }

            return dirInfo;
        }

        public static FileInfo[] GetFiles(string directory, string searchPattern = "*")
        {
            var dirInfo = GetDirectoryInfo(directory);

            if (dirInfo == null)
                return new FileInfo[0];

            return dirInfo.GetFiles(searchPattern);
        }

        public static FileStream OpenFile(string path, string filename, FileAccess access = FileAccess.Read)
        {
            var fileInfo = GetFileInfo(path, filename);
            return fileInfo?.Open(FileMode.Open, access);
        }
    }
}