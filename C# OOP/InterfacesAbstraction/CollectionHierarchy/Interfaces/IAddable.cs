using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interfaces
{
    internal interface IAddable<T>
    {
        int Add(T item);
    }
}
