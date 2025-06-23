using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;

        private T[] elementsArr;

        public int Count { get; private set; }

        public CustomStack()
        {
            this.elementsArr = new T[DefaultCapacity];
            this.Count = 0;
        }

        private void Resize()
        {
            T[] tempArr = new T[this.elementsArr.Length * 2];
            for (int i = 0; i < this.elementsArr.Length; i++)
            {
                tempArr[i] = this.elementsArr[i];
            }

            this.elementsArr = tempArr;
        }

        public void Push(T element)
        {
            if (this.elementsArr.Length == this.Count)
            {
                Resize();
            }

            this.elementsArr[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T elementToReturn = this.elementsArr[Count - 1];
            this.elementsArr[Count - 1] = default(T);
            this.Count--;

            return elementToReturn;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elementsArr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}