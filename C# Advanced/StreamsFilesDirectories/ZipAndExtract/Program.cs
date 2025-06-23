using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ZipArchive archive = ZipFile.Open("../../../archive.zip", ZipArchiveMode.Update))
            {
                string filePath = Path.GetFullPath("../../../copyMe.png");
                FileInfo fileInfo = new FileInfo(filePath);

                archive.CreateEntryFromFile(filePath, fileInfo.Name);
            }

            ZipFile.ExtractToDirectory("../../../archive.zip", "../../../archive");
        }
    }
}