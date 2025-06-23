using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] createdArr = Enumerable.Repeat(item, length).ToArray();
            return createdArr;
        }
    }
}