using System.Collections;
using System.Drawing;
using Prog.Interfaces;

namespace Prog.Components.Core
{
    public class CustomStack<T> : ICustomStack<T>
    {
        public Node<T>? Top { get; private set; }
        private int size = 0;
        public int Size => size;
        public bool IsEmpty => Top == null;

        public void Push(T element)
        {
            Node<T> node = new(element, Top);
            Top = node;
            size++;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new Exception("Stack Underflow");
            }
        
            T temp = Top.Element;
            Top = Top.Next;
            size--;

            return temp;
        }

        public T PopAtIndex(int index)
        {
            if (IsEmpty)
            {
                throw new Exception("Stack Underflow");
            }

            int n = size;

            if (index > n - 1)
            {
                throw new Exception("Index out of range");
            } else
            {
                n = index - 1;
            }
            
            if (index == 0)
            {
                Pop();
            }

            Node<T> previousNode = Top;
            Node<T> currentNode = Top.Next;
            for (int i = 0; i < n; i++)
            {
                Node<T> temp = currentNode.Next;
                previousNode = currentNode;
                currentNode = temp;
            }

            previousNode.Next = currentNode.Next;
            size--;

            return currentNode.Element;
        }

        public void PushAtIndex(T element, int index)
        {
            int n = size;

            if (index > n - 1)
            {
                throw new Exception("Index out of range");
            } else
            {
                n = index - 1;
            }
            
            if (index == 0)
            {
                Push(element);
            }

            Node<T>? previousNode = Top;
            Node<T>? currentNode = Top.Next;
            for (int i = 0; i < n; i++)
            {
                Node<T> temp = currentNode.Next;
                previousNode = currentNode;
                currentNode = temp;
            }

            previousNode.Next = new(element, currentNode);
            size++;
        }

        public T PeekAtIndex(int index)
        {
            if (IsEmpty)
            {
                throw new Exception("Stack is empty");
            }

            int n = size;

            if (index > n - 1)
            {
                throw new Exception("Index out of range");
            } else
            {
                n = index;
            }

            Node<T> currentNode = Top;
            for (int i = 0; i < n; i++)
            {
                Node<T> temp = currentNode.Next;
                currentNode = temp;
            }

            return currentNode.Element;
        }

    }

    public class Node<T>
        {
            public T Element { get; set; }
            public Node<T>? Next { get; set; }

            public Node(T element, Node<T>? next)
            {
                Element = element;
                Next = next;
            }
        }
}