using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    internal class MyList<T> : Interfaces.IAddable<T>, IRemovable<T>, IUsed
    {
        private IList<T> collection;

        public MyList()
        {
            this.collection = new List<T>();
        }

        public int Used { get { return this.collection.Count; } }

        public int Add(T item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T removedItem = this.collection[0];
            this.collection.RemoveAt(0);

            return removedItem;
        }
    }
}
