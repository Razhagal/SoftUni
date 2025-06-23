using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();
                if (command.Equals("Play"))
                {
                    songsQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    int songIndex = command.IndexOf(" ") + 1;
                    string songName = command.Substring(command.IndexOf(" ") + 1, (command.Length - songIndex));
                    if (!songsQueue.Contains(songName))
                    {
                        songsQueue.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine(songName + " is already contained!");
                    }
                }
                else if (command.Equals("Show"))
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
