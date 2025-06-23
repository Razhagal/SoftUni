using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePaths = Directory.GetFiles("../../../TestDirectory");
            Dictionary<string, Dictionary<string, long>> filesData = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < filePaths.Length; i++)
            {
                FileInfo info = new FileInfo(filePaths[i]);

                if (!filesData.ContainsKey(info.Extension))
                {
                    filesData.Add(info.Extension, new Dictionary<string, long>());
                }

                filesData[info.Extension].Add(info.Name, info.Length);
            }

            filesData = filesData.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var fileData in filesData)
            {
                filesData[fileData.Key] = filesData[fileData.Key].OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            using (StreamWriter writer = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\report.txt"))
            {
                foreach (var extension in filesData)
                {
                    writer.WriteLine(extension.Key);
                    foreach (var file in extension.Value)
                    {
                        double fileSizeKB = file.Value / (double)1024;
                        writer.WriteLine($"--{file.Key} - {fileSizeKB:f3}kb");
                    }
                }
            }
        }
    }
}