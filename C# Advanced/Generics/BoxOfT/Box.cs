using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> elements;

        public Box()
        {
            elements = new Stack<T>();
        }

        public int Count { get { return this.elements.Count; } }

        public void Add(T element)
        {
            this.elements.Push(element);
        }

        public T Remove()
        {
            return this.elements.Pop();
        }
    }
}
