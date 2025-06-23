using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");
            double sum = 0;
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(files[i]);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;
            File.WriteAllText("../../../Output.txt", sum.ToString());
        }
    }
}