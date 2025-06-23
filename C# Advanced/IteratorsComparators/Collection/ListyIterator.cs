using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currentIndex;

        public ListyIterator(params T[] collection)
        {
            currentIndex = 0;
            this.collection = new List<T>(collection);
        }

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
            }
            else
            {
                return false;
            }

            return currentIndex < this.collection.Count;
        }

        public void Print()
        {
            if (currentIndex >= this.collection.Count || this.collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.collection[currentIndex]);
            }
        }

        public bool HasNext()
        {
            return currentIndex + 1 < this.collection.Count;
        }

        public void PrintAll()
        {
            int index = 0;
            foreach (var item in this.collection)
            {
                Console.Write(item + " ");
                index++;
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}