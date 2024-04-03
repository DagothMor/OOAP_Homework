using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAP_Homework
{
    using System;

    public class CustomLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node head;
        private Node tail;
        private Node current;
        private int count;

        public void Head()
        {
            current = head;
        }

        public void Tail()
        {
            current = tail;
        }

        public void Right()
        {
            if (current != null) current = current.Next;
        }

        public T Get()
        {
            if (current == null) throw new InvalidOperationException("Current is null.");
            return current.Value;
        }

        public void PutRight(T value)
        {
            if (current == null) throw new InvalidOperationException("List is empty.");

            Node newNode = new Node(value);
            newNode.Previous = current;
            newNode.Next = current.Next;

            if (current.Next != null) current.Next.Previous = newNode;
            current.Next = newNode;

            if (current == tail) tail = newNode;

            count++;
        }

        public void PutLeft(T value)
        {
            if (current == null) throw new InvalidOperationException("List is empty.");

            Node newNode = new Node(value);
            newNode.Next = current;
            newNode.Previous = current.Previous;

            if (current.Previous != null) current.Previous.Next = newNode;
            current.Previous = newNode;

            if (current == head) head = newNode;

            count++;
        }

        public void Remove()
        {
            if (current == null) throw new InvalidOperationException("List is empty or current is null.");

            if (current.Previous != null) current.Previous.Next = current.Next;
            if (current.Next != null) current.Next.Previous = current.Previous;

            if (current == head) head = current.Next;
            if (current == tail) tail = current.Previous;

            current = (current.Next != null) ? current.Next : current.Previous;

            count--;
        }

        public void Clear()
        {
            head = tail = current = null;
            count = 0;
        }

        public int Size()
        {
            return count;
        }

        public void AddToEmpty(T value)
        {
            if (head != null) throw new InvalidOperationException("List is not empty.");
            Node newNode = new Node(value);
            head = tail = current = newNode;
            count = 1;
        }

        public void AddTail(T value)
        {
            Node newNode = new Node(value);
            if (tail != null)
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            else
            {
                head = tail = newNode;
            }
            count++;
        }

        public void Replace(T value)
        {
            if (current == null) throw new InvalidOperationException("Current is null.");
            current.Value = value;
        }

        public void Find(T value)
        {
            Node node = current;
            while (node != null && !node.Value.Equals(value))
            {
                node = node.Next;
            }
            current = node;
        }

        public void RemoveAll(T value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    if (node == current) Remove();
                    else
                    {
                        if (node.Previous != null) node.Previous.Next = node.Next;
                        if (node.Next != null) node.Next.Previous = node.Previous;
                        if (node == head) head = node.Next;
                        if (node == tail) tail = node.Previous;
                        count--;
                    }
                }
                node = node.Next;
            }
        }

        public bool IsHead()
        {
            return current == head;
        }

        public bool IsTail()
        {
            return current == tail;
        }

        public bool IsValue()
        {
            return current != null;
        }
    }

}
