using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    internal class AddCollection<T> : IAddable<T>
    {
        private IList<T> collection;

        public AddCollection()
        {
            this.collection = new List<T>();
        }

        public int Add(T item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
