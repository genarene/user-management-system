using System.Collections;
using System.Collections.Generic;

namespace UserManagementSystem
{

    // the container class that holds the queue node values 
    // provides an enumerator to the queue to be able to loop over it
    public abstract class Container<T> : IEnumerable<T>
    {
        internal Node<T> Begin { get; }
        internal Node<T> End { get; }


        // constructor to instantiate the node values
        protected Container()
        {
            Begin = new Node<T>();
            End = new Node<T>();

            Begin.Next = End;
            End.Prev = Begin;
        }

        // creating the enumerator method
        public virtual IEnumerator<T> GetEnumerator()
        {
            var current = Begin.Next;

            while (current != End)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}