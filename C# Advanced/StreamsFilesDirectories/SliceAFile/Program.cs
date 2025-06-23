using System;
using System.Collections.Generic;
using System.IO;

namespace SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "../../../sliceMe.txt";
            List<string> destinationFiles = new List<string>() { "Part-1.txt", "Part-2.txt", "Part-3.txt", "Part-4.txt", };
            int parts = destinationFiles.Count;

            using (FileStream readStream = new FileStream(sourceFile, FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)readStream.Length / parts);

                Console.WriteLine(readStream.Length + " " + pieceSize);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    using (FileStream writeStream = new FileStream($"../../../{destinationFiles[i]}", FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = readStream.Read(buffer, 0, buffer.Length);
                        while (readBytes > 0)
                        {
                            currentPieceSize += buffer.Length;
                            writeStream.Write(buffer, 0, readBytes);

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }

                            readBytes = readStream.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}