using System.Collections.Generic;
using System;



namespace UserManagementSystem
{
    // generic node 
    class Node<T>
    {
        // public Node(T item)

        // {
        //     this.Item = item;
        //     this.Next = null;
        // }

        // public T Item { get; set; }

        // public Node<T> Next { get; set; }

        internal Node<T> Prev;
        internal Node<T> Next;

        internal T Value;

        internal void Clear()
        {
            Prev = null;
            Next = null;
            Value = default;
        }


    }
}