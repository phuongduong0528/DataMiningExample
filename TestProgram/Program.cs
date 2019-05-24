using SequentialPatternMining;
using SequentialPatternMining.GSP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //    List<SortedSet<string>>[] dataSet = new List<SortedSet<string>>[]
            //    {
            //        new List<SortedSet<string>>()
            //        {
            //            new SortedSet<string>(){"A"},
            //            new SortedSet<string>(){"B"},
            //            new SortedSet<string>(){"F","G"},
            //            new SortedSet<string>(){"C"},
            //            new SortedSet<string>(){"D"}
            //        },
            //        new List<SortedSet<string>>()
            //        {
            //            new SortedSet<string>(){"B"},
            //            new SortedSet<string>(){"G"},
            //            new SortedSet<string>(){"D"}
            //        },
            //        new List<SortedSet<string>>()
            //        {
            //            new SortedSet<string>(){"B"},
            //            new SortedSet<string>(){"F"},
            //            new SortedSet<string>(){"G"},
            //            new SortedSet<string>(){"A","B"}
            //        },
            //        new List<SortedSet<string>>()
            //        {
            //            new SortedSet<string>(){"F"},
            //            new SortedSet<string>(){"A","B"},
            //            new SortedSet<string>(){"C"},
            //            new SortedSet<string>(){"D"}
            //        },
            //        new List<SortedSet<string>>()
            //        {
            //            new SortedSet<string>(){"A"},
            //            new SortedSet<string>(){"B","C"},
            //            new SortedSet<string>(){"G"},
            //            new SortedSet<string>(){"F"},
            //            new SortedSet<string>(){"D","E"}
            //        }
            //    };

            List<SortedSet<string>>[] dataSet = new List<SortedSet<string>>[]
        {
                new List<SortedSet<string>>()
                {
                    new SortedSet<string>(){"30"},
                    new SortedSet<string>(){"90"}
                },
                new List<SortedSet<string>>()
                {
                    new SortedSet<string>(){"10", "20"},
                    new SortedSet<string>(){"30"},
                    new SortedSet<string>(){"40", "60","70"}
                },
                new List<SortedSet<string>>()
                {
                    new SortedSet<string>(){"30", "50", "70"}

                },
                new List<SortedSet<string>>()
                {
                    new SortedSet<string>(){"30"},
                    new SortedSet<string>(){"40","70"},
                    new SortedSet<string>(){"90"}
                },
                new List<SortedSet<string>>()
                {
                    new SortedSet<string>(){"90"}
                }
        };

            SortedSet<string>[] dataset1 =
                {

                new SortedSet<string> { "A","B","C","D"},
                new SortedSet<string> { "B","C","D","E" },
                new SortedSet<string> { "A","B","E" }
            };
            GSP al = new GSP(2);
            Sequence[] x = al.Learn(dataSet);
            foreach (var i in x)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("\nDone...\nPress any key to exit....");
            Console.ReadKey();
            //Apriori apr = new Apriori(2, 0);
            //var a = apr.Learn(dataset1.ToArray());
            //foreach(var i in a)
            //{
            //    Console.WriteLine(i.ToString());
            //}
            //Console.ReadKey();
        }
    }
}
