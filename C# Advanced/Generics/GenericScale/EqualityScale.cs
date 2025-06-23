using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T firstElement;
        private T secondElement;

        public EqualityScale(T first, T second)
        {
            this.firstElement = first;
            this.secondElement = second;
        }

        public bool AreEqual()
        {
            return this.firstElement.Equals(this.secondElement);
        }
    }
}