using CollectionHierarchy.Interfaces;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IAddable<string> addCollection = new AddCollection<string>();
            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            Dictionary<int, List<int>> allCollectionsAddIndexes = new Dictionary<int, List<int>>();
            allCollectionsAddIndexes[0] = new List<int>();
            allCollectionsAddIndexes[1] = new List<int>();
            allCollectionsAddIndexes[2] = new List<int>();

            string[] inputStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputStrings.Length; i++)
            {
                allCollectionsAddIndexes[0].Add(addCollection.Add(inputStrings[i]));
                allCollectionsAddIndexes[1].Add(addRemoveCollection.Add(inputStrings[i]));
                allCollectionsAddIndexes[2].Add(myList.Add(inputStrings[i]));
            }

            foreach (var indexesCollection in allCollectionsAddIndexes)
            {
                Console.WriteLine(string.Join(' ', indexesCollection.Value));
            }

            Dictionary<int, List<string>> allCollectionsRemovedItems = new Dictionary<int, List<string>>();
            allCollectionsRemovedItems[0] = new List<string>();
            allCollectionsRemovedItems[1] = new List<string>();
            int removesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < removesCount; i++)
            {
                allCollectionsRemovedItems[0].Add(addRemoveCollection.Remove());
                allCollectionsRemovedItems[1].Add(myList.Remove());
            }

            foreach (var removedItems in allCollectionsRemovedItems)
            {
                Console.WriteLine(string.Join(' ', removedItems.Value));
            }
        }
    }
}
