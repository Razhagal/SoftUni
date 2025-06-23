using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            this.Count = 0;
        }

        public void AddFirst(T element)
        {
            Node<T> newHead = new Node<T>(element);
            if (this.Count == 0)
            {
                this.head = newHead;
                this.tail = newHead;
            }
            else
            {
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            Node<T> newTail = new Node<T>(element);
            if (this.Count == 0)
            {
                this.head = newTail;
                this.tail = newTail;
            }
            else
            {
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T elementToReturn = this.head.Value;
            this.head = this.head.Next;
            if (this.head != null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return elementToReturn;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T elementToReturn = this.tail.Value;
            this.tail = this.tail.Previous;
            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return elementToReturn;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int index = 0;
            Node<T> currentNode = this.head;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.Next;
                index++;
            }

            return array;
        }

        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Previous { get; set; }
            public Node<T> Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }

        }
    }
}
