using System.IO;

namespace FileSafeExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] fileData = File.ReadAllBytes(@"C:\Users\sercan.solmaz\Desktop\test\original.png");
            FileType fileType = fileData.GetFileType();
        }
    }
}