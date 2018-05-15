using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_List
{
    class Program
    {
        static void Main(string[] args)
        {   //Testing out the Generic List
            GenericList<string> list = new GenericList<string>();
            list.Add("Hi ");
            list.Add("Samson ");
            list.Add("Whats up.");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
            }

            Console.ReadKey();
        }

        class GenericList<T>
        {
            private T[] array;
            private int length;
            private int usedPlaces = 0;
            public GenericList(): this(0)
            {

            }

            public GenericList(int length)
            {
                array = new T[length];
                this.length = length;
            }

            public T this[int index]
            {
                get { return array[index]; }
            }

            public int Count
            {   //Calculates the total number of active objects in the array
                get
                {
                    return length;
                }
            }

            public void Add(T item)
            {
                Resize();   //Resize array before including item
                array[usedPlaces] = item;
                usedPlaces++;
            }

            public void RemoveAt(int index)
            {
                if (index < length - 1)
                {
                    for (int i = index; i < length - 1; i++)
                    {
                        array[i] = array[i + 1];        //Move all the items left side into the index being removed
                    }
                    array[length - 1] = default(T);
                }
                else
                {
                    array[length - 1] = default(T);
                }
                usedPlaces--;
            }

            public void InsertAt(T item, int index)
            {
                if (index >= length || index < 0)
                {
                    throw new IndexOutOfRangeException("The index you are trying to access is out of range.");
                }
                Resize();
                for (int i = length - 1; i > index; i--)
                {   //Move items in the array to the right side from the given index.
                    array[i] = array[i - 1];
                }
                array[index] = item;
                usedPlaces++;
            }

            public void Clear()
            {
                for (int i = 0; i < length; i++)
                {
                    array[i] = default(T);      //Set every element of the array to null = default(T)
                }
                length = 0;
                usedPlaces = 0;
            }
            public void Resize()
            {
                T[] temp = array;
                length++;
                array = new T[length];
                temp.CopyTo(array, 0);
            }
            public int Search(T item)
            {
                for (int i = 0; i < length; i++)
                {
                    if ( ReferenceEquals(array[i], item))
                    {
                        return i;
                    }
                }
                return -1;
            }
            public override string ToString()
            {
                return base.ToString();
            }
        }
    }
}
