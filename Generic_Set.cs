using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

// Luka Emrashvili
// Red ID: 823 355 800

namespace Set
{
    public delegate bool F<T>(T elt);       // declare delegate

    public class Generic_Set<T> : IEnumerable<T>
    {
        protected List<T> Collection;

        public bool any
        {
            get
            {
                return !Collection.Any();
            }
        }

        public int x
        {
            get
            {
                return Collection.Count();
            }
        }

        public Generic_Set()
        {
            Collection = new List<T>();
        }

        public Generic_Set(IEnumerable<T> elements)
        {
            Collection = new List<T>();

            foreach (var el in elements)
            {
                if (!Collection.Contains(el))  // check if the element is in the set
                {
                    Collection.Add(el);
                }
            }
        }

        public static Generic_Set<T> operator +(Generic_Set<T> left_side, Generic_Set<T> right_side)    // creating operator
        {
            Generic_Set<T> U = new Generic_Set<T>(left_side);

            foreach (var x in right_side)
            {
                if (!U.Containing(x))
                {
                    U.Collection.Add(x);
                }
            }

            return U;
        }

        public virtual bool Addition(T i)    // Addition method
        {
            if (!Collection.Contains(i))
            {
                Collection.Add(i);
                return true;
            }

            return false;
        }

        public virtual bool Removal(T i)            // Removal method
        {
            if (Collection.Contains(i))
            {
                Collection.Remove(i);
                return true;
            }

            return false;
        }

        public bool Containing(T i) => Collection.Contains(i);      // checking method

        public Generic_Set<T> Filtering(F<T> fil_func)             // Filtering Method
        {
            Generic_Set<T> fil_set = new Generic_Set<T>();

            foreach (var x in Collection)
            {
                if (fil_func(x))
                {
                    fil_set.Collection.Add(x);
                }
            }

            return fil_set;
        }

        public IEnumerator<T> GetEnumerator()      // implement IEnumerable
        {
            foreach (var x in Collection)
            {
                yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Sorted<T> : Generic_Set<T>        // sorted class, subclass of Generic_Set()
           where T : IComparable<T>
    {
        public Sorted(IEnumerable<T> element)
                : base(element)
        {
            Collection.Sort();
        }

        public override bool Addition(T i)
        {
            if (!Collection.Contains(i))
            {
                foreach (var x in Collection)
                {
                    if (i.CompareTo(x) < 0)
                    {
                        Collection.Insert(Collection.IndexOf(x), i);
                        return true;
                    }
                }
            }

            return false;
        }
        public override bool Removal(T i)     // overriden method
        {
            return base.Removal(i);
        }

        public static Sorted<T> operator +(Sorted<T> left_hand, Sorted<T> right_hand)
        {
            Sorted<T> U = new Sorted<T>(left_hand);
            foreach (var x in right_hand)
            {
                if (!left_hand.Containing(x))
                {
                    U.Addition(x);
                }
            }
            return U;
        }

    }
}
