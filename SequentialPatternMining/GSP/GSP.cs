using Accord.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPatternMining.GSP
{
    public class GSP
    {
        internal class FrequentItem
        {
            public List<SortedSet<string>> seq;
            public int count;
        }
        private int supportMin;
        private List<FrequentItem> frequent;
        private List<List<SortedSet<string>>> tempIList;
        public GSP(int support)
        {
            this.supportMin = support;
            frequent = new List<FrequentItem>();
        }

        List<List<SortedSet<string>>> Init(List<SortedSet<string>>[] dataSet)
        {
            SortedSet<string> t1 = new SortedSet<string>();
            List<List<SortedSet<string>>> t2 = new List<List<SortedSet<string>>>();
            foreach (var i in dataSet)
                foreach (var j in i)
                    foreach (var k in j)
                    {
                        t1.Add(k);
                    }
            foreach (var i in t1)
                t2.Add(new List<SortedSet<string>>() { new SortedSet<string>() { i } });
            return t2;
        }

        public Sequence[] Learn(List<SortedSet<string>>[] dataSet)
        {
            frequent.Clear();
            List<List<SortedSet<string>>> individualItemList = new List<List<SortedSet<string>>>();
            List<FrequentItem> scs = new List<FrequentItem>();
            individualItemList = Init(dataSet);
            foreach (var dsItem in dataSet)
            {
                foreach (var subItem in dsItem)
                {
                    if (subItem.Count >= 2)
                    {
                        individualItemList.Add(new List<SortedSet<string>> { subItem });
                    }
                }
            }
            this.tempIList = new List<List<SortedSet<string>>>(individualItemList);
            int itemsCount = individualItemList.Count;
            for (int i = 1; individualItemList.Count != 0; i++)
            {
                List<List<SortedSet<string>>> candidateSet = GenerateCandidate(individualItemList, i);
                scs.Clear();
                foreach (List<SortedSet<string>> sequenceItem in dataSet)
                {
                    foreach (List<SortedSet<string>> candidate in candidateSet)
                    {
                        if (IsSubSequence(candidate, sequenceItem))
                        {
                            if (scs.Any(s => IfEqualLists(s.seq, candidate)))
                            {
                                var tmp = scs.FirstOrDefault(s => IfEqualLists(s.seq, candidate));
                                tmp.count += 1;
                            }
                            else
                            {
                                scs.Add(new FrequentItem()
                                {
                                    seq = candidate,
                                    count = 1
                                });
                            }
                        }
                    }
                }

                individualItemList.Clear();
                foreach(FrequentItem item in scs)
                {
                    if(item.count >= supportMin)
                    {
                        individualItemList.Add(item.seq);
                        frequent.Add(new FrequentItem()
                        {
                            seq = item.seq,
                            count=item.count
                        });
                    }
                }
            }

            List<Sequence> sequence = new List<Sequence>();
            foreach(var i in frequent)
            {
                var supp = Support(i.seq, dataSet);
                if(supp >= supportMin)
                {
                    sequence.Add(new Sequence()
                    {
                        sequence = i.seq,
                        Support = i.count
                    });
                }
            }
            return sequence.OrderBy(x => Count(x.sequence)).ToArray();
        }


        private bool IsSubSequence(List<SortedSet<string>> l1, List<SortedSet<string>> l2)
        {
            int checkindex = 0;
            foreach (var i in l2)
            {
                if (i.IsSupersetOf(l1[checkindex]))
                    checkindex++;
                if (checkindex == l1.Count)
                    return true;
            }
            return false;
        }

        private int Support(List<SortedSet<string>> set, IList<List<SortedSet<string>>> dataset)
        {
            int count = 0;
            foreach (List<SortedSet<string>> sequenceItem in dataset)
            {
                if (IsSubSequence(set, sequenceItem))
                    count++;
            }
            return count;
        }

        private List<SortedSet<string>> SequenceUnion(List<SortedSet<string>> l1, List<SortedSet<string>> l2, int k)
        {
            try
            {
                List<SortedSet<string>> tl1 = new List<SortedSet<string>>(l1);
                List<SortedSet<string>> tl2 = new List<SortedSet<string>>(l2);
                List<string> a = new List<string>();
                List<string> b = new List<string>();
                foreach (var i in tl1)
                    foreach (var str in i)
                        a.Add(str);
                foreach (var i in tl2)
                    foreach (var str in i)
                        b.Add(str);
                for (int j = 0; j <= k - 3; j++)
                {
                    if (a[j + 1] != b[j])
                        return null;
                }
                if (tl1.Count >= tl2.Count)
                {
                    tl1.RemoveRange(1, tl1.Count - 1);
                    tl1.AddRange(tl2);
                    return tl1;
                }
                else
                {
                    tl2.RemoveRange(0, tl2.Count - 1);
                    tl1.AddRange(tl2);
                    return tl1;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private int Count(List<SortedSet<string>> set)
        {
            int c = 0;
            foreach (SortedSet<string> i in set)
                c += i.Count;
            return c;
        }

        private bool IfEqualLists(List<SortedSet<string>> a, List<SortedSet<string>> b)
        {
            if (a.Count == b.Count)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (!a[i].SequenceEqual(b[i]))
                        return false;
                }
                return true;
            }
            return false;
        }



        private List<List<SortedSet<string>>> GenerateCandidate(List<List<SortedSet<string>>> input, int k)
        {
            List<SortedSet<string>> temp;
            List<List<SortedSet<string>>> re = new List<List<SortedSet<string>>>();
            foreach (List<SortedSet<string>> i in tempIList)
            {
                if (Count(i) == k && !re.Any(x => IfEqualLists(x, i)))
                    re.Add(i);
            }
            foreach (List<SortedSet<string>> i in input)
            {
                foreach (List<SortedSet<string>> j in input)
                {
                    temp = new List<SortedSet<string>>(i);
                    if (k == 1)
                        continue;
                    if (k == 2)
                        temp.AddRange(j);
                    else
                    {
                        temp = SequenceUnion(temp, j,k);
                        if (temp == null)
                            continue;
                    }
                    if (Count(temp) == k && !re.Any(x => IfEqualLists(x, temp)))
                        re.Add(temp);
                }
            }
            return re;
        }
    }
}
