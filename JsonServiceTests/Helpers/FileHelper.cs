using System.IO;
using NUnit.Framework;

namespace JsonServiceTests.Helpers
{
    public static class FileHelper
    {
        private static DirectoryInfo TestBaseDirectory => new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        private static DirectoryInfo TestDirectory => TestBaseDirectory?.Parent?.Parent ?? TestBaseDirectory;
        private static string FileDirectory => Path.Combine(TestDirectory.FullName, "test-files");

        public static FileStream GetFileStream(string filename)
        {
            return File.OpenRead(Path.Combine(FileDirectory, filename));
        }
    }
}