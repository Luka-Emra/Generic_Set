using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using Set;

// Luka Emrashvili
// Red ID: 823 355 800

namespace Assignment4
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t-----Testing Default Constructor-----\n");
            Generic_Set<int> First_Set = new Generic_Set<int>();
            Console.WriteLine("\t\tIs it True or False that the First Set is Empty? It's : " + First_Set.any);
            First_Set.Addition(7);
            First_Set.Addition(2);
            First_Set.Addition(16);
            First_Set.Addition(12);

            Console.WriteLine("\t\tWhat about now? it's: " + First_Set.any);
            Console.Write("\t\tThese elements have been added to the First set : ");

            Console.Write("{ ");
            foreach (var x in First_Set)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");

            List<int> set = new List<int>();
            set.Add(20);
            set.Add(44);
            set.Add(12);
            set.Add(67); 
     
            Console.WriteLine("\n\n\t\t-----Testing Parameterized constructor-----\n");
            Generic_Set<int> mySet2 = new Generic_Set<int>(set);
            Console.WriteLine("\t\tIs it True or False that the Second Set is Empty ? It's : " + mySet2.any);
            Console.Write("\t\tThese elements are included in the Second set: ");

            Console.Write("{ ");
            foreach (var x in mySet2)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");


            Console.Write("\n\n\t\t-----Union: ");
            Generic_Set<int> U = First_Set + mySet2;

            Console.Write("{ ");
            foreach (var x in U)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");

            Console.WriteLine("\n\t\tCan we remove 44? : " + U.Removal(44));
            Console.WriteLine("\t\tCan we remove 88? : " + U.Removal(88));
            Console.Write("\n\t\tNew Set : ");


            Console.Write("{ ");
            foreach (var x in U)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");

            static bool Greater_Than_Fifteen(int x)
            {
                return (x > 15) ? true : false;
            }

            Console.Write("\n\n\t\tFiltered Set with numbers > 15 from the Union Set : ");
            Generic_Set<int> Fil1 = U.Filtering(Greater_Than_Fifteen);

            Console.Write("{ ");
            foreach (var x in Fil1)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");

            Console.Write("\n\n\t\tSorted Set : ");
            var sort = new Set.Sorted<int>(Fil1);

            Console.Write("{ ");
            foreach (var x in Fil1)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");

            Console.Write("\n\t\tAfter adding 24 : ");
            sort.Addition(24);

            Console.Write("{ ");
            foreach (var x in sort)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");

            static bool Fil2(int x)
            {
                return (x <= 15) ? true : false;
            }

            Console.Write("\n\n\t\tSecond Set with numbers less than or equal to 15 : ");
            Generic_Set<int> fil2 = U.Filtering(Fil2);

            Console.Write("{ ");
            foreach (var x in fil2)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}");

            Console.Write("\n\n\t\tSort the second set : ");
            var sort2 = new Set.Sorted<int>(fil2);

            Console.Write("{ ");
            foreach (var x in sort2)
            {
                Console.Write(x + ",  ");
            }
            Console.Write("}\n\n\n");
        }
    }
}
