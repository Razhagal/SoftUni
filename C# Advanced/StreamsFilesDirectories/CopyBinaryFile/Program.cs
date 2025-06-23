using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream readStream = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writeStream = new FileStream("../../../copied.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = readStream.Read(buffer, 0, buffer.Length);
                    while (readBytes > 0)
                    {
                        writeStream.Write(buffer, 0, readBytes);
                        readBytes = readStream.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}