using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    internal class AddRemoveCollection<T> : Interfaces.IAddable<T>, IRemovable<T>
    {
        private IList<T> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<T>();
        }

        public int Add(T item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T removedItem = this.collection[this.collection.Count - 1];
            this.collection.RemoveAt(this.collection.Count - 1);

            return removedItem;
        }
    }
}
