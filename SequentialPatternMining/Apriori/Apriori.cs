using Accord.Math;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SequentialPatternMining
{
    public class Apriori
    {
        CancellationToken token = new CancellationToken();

        private int supportMin;
        private double minConfidence;
        private Dictionary<SortedSet<string>, int> frequent;
        public Dictionary<SortedSet<string>, int> Frequent => frequent;
        public CancellationToken Token
        {
            get => token;
            set => token = value;
        }

        public Apriori(int support, double confidence)
        {
            supportMin = support;
            this.minConfidence = confidence;
            frequent = new Dictionary<SortedSet<string>, int>();
        }

        public AssociationRule[] Learn(string[][] dataset, double[] weights = null)
        {
            return Learn(dataset.Apply(xi => new SortedSet<string>(xi)), weights);
        }

        public AssociationRule[] Learn(SortedSet<string>[] transactionSet, double[] weights = null)
        {
            if (weights != null)
                throw new Exception();

            frequent.Clear();
            HashSet<SortedSet<string>> individualItemList = new HashSet<SortedSet<string>>(new SetComparer());
            Dictionary<SortedSet<string>, int> suppCountingSet = new Dictionary<SortedSet<string>, int>(new SetComparer());

            foreach (SortedSet<string> transaction in transactionSet)
                foreach (string item in transaction)
                    individualItemList.Add(new SortedSet<string>() { item });
            int itemsCount = individualItemList.Count;

            for (int i = 1; individualItemList.Count != 0; i++)
            {
                HashSet<SortedSet<string>> candidateSet = GenerateCandidate(individualItemList, i);
                suppCountingSet.Clear();
                foreach (SortedSet<string> transaction in transactionSet)
                {
                    foreach (SortedSet<string> candidate in candidateSet)
                    {
                        if (candidate.IsSubsetOf(transaction))
                        {
                            int count;
                            if (suppCountingSet.TryGetValue(candidate, out count))
                                suppCountingSet[candidate] = count + 1;
                            else
                                suppCountingSet[candidate] = 1;
                        }
                    }
                }

                individualItemList.Clear();
                foreach (KeyValuePair<SortedSet<string>, int> pair in suppCountingSet)
                {
                    if (pair.Value >= supportMin)
                    {
                        individualItemList.Add(pair.Key);
                        frequent.Add(pair.Key, pair.Value);
                    }
                }
            }

            List<AssociationRule> rules = new List<AssociationRule>();

            // Generate association rules from the most frequent itemsets
            foreach (SortedSet<string> item in frequent.Keys)
            {
                double total = support(item, transactionSet);

                // generate all non-empty subsets of I
                foreach (SortedSet<string> subset in item.Subsets())
                {
                    double itemSupport = support(subset, transactionSet);
                    double itemConfidence = total / itemSupport;
                    if (itemConfidence >= minConfidence && itemSupport >= supportMin)
                    {
                        SortedSet<string> y = new SortedSet<string>(item);
                        y.ExceptWith(subset);
                        if (y.Count > 0)
                        {
                            rules.Add(new AssociationRule()
                            {
                                Confidence = itemConfidence,
                                Support = total,
                                X = subset,
                                Y = y,
                            });
                        }
                        else
                        {
                            rules.Add(new AssociationRule()
                            {
                                Confidence = itemConfidence,
                                Support = total,
                                X = subset,
                                Y = new SortedSet<string>(),
                            });
                        }
                    }
                }
            }

            return rules.ToArray();
        }

        private int support(ISet<string> items, IList<SortedSet<string>> dataset)
        {
            int count = 0;
            foreach (var transaction in dataset)
                if (items.IsSubsetOf(transaction))
                    count++;

            return count;
        }

        internal class SetComparer : IEqualityComparer<SortedSet<string>>
        {
            public bool Equals(SortedSet<string> x, SortedSet<string> y)
            {
                return x.SetEquals(y);
            }

            public int GetHashCode(SortedSet<string> obj)
            {
                // TODO: Change to something more efficient
                int sum = 0;
                foreach (string i in obj)
                    sum ^= i.GetHashCode();
                return sum;
            }
        }

        private HashSet<SortedSet<string>> GenerateCandidate(HashSet<SortedSet<string>> transactionSet, int k)
        {
            HashSet<SortedSet<string>> result = new HashSet<SortedSet<string>>(new SetComparer());

            foreach (SortedSet<string> transaction in transactionSet)
            {
                foreach (SortedSet<string> item in transactionSet)
                {
                    SortedSet<string> temp = new SortedSet<string>(transaction);
                    temp.UnionWith(item);
                    if (temp.Count == k)
                        result.Add(temp);
                }
            }

            return result;
        }
    }
}
