using System;
using System.Collections.Generic;


namespace UserManagementSystem
{
    public class UserQueue<T> : Container<T>
    {

        // count property for the UserQueue
        public int Count { get; set; }

        public UserQueue() { }


        //    making the queue ienumerable to be able to loop over the values 
        public UserQueue(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }



        // creating the dequeue method
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var value = Begin.Next.Value;

            Begin.Next = Begin.Next.Next;
            Begin.Next.Prev = Begin;
            Count--;

            return value;
        }

        // creating the enqueue method
        public void Enqueue(T value)
        {
            var item = new Node<T>()
            {
                Prev = End.Prev,
                Next = End,
                Value = value
            };

            End.Prev.Next = item;
            End.Prev = item;
            Count++;
        }


    }
}
