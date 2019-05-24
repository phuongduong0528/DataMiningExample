using Accord.Math;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequentialPatternMining
{
    public class Apriori
    {
        CancellationToken token = new CancellationToken();

        private ToolStripProgressBar progressBar;
        private List<List<int>> transactionIndex;
        private int supportMin;
        private double minConfidence;
        private Dictionary<SortedSet<string>, int> frequent;
        private AssociationRuleMatcher classifier;
        public Dictionary<SortedSet<string>, int> Frequent => frequent;
        public AssociationRuleMatcher Classifier => classifier;
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
            progressBar = null;
        }

        public Apriori(int support, double confidence, ToolStripProgressBar progressBar)
        {
            supportMin = support;
            this.minConfidence = confidence;
            frequent = new Dictionary<SortedSet<string>, int>();
            this.progressBar = progressBar;
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
                InitProgressBar(transactionSet.Length, 1);
                HashSet<SortedSet<string>> candidateSet = GenerateCandidate(individualItemList, i);
                suppCountingSet.Clear();
                foreach (SortedSet<string> transaction in transactionSet)
                {
                    UpdateProgressBar();
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
                FinishProgressBar();

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
            classifier = new AssociationRuleMatcher(itemsCount, rules.ToArray());
            return rules.ToArray();
        }

        public async Task<AssociationRule[]> LearnAsync(SortedSet<string>[] transactionSet, double[] weights = null)
        {
            AssociationRule[] a = await Task.Run(() => Learn(transactionSet, weights));
            return a;
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

        private void InitProgressBar(int max, int step)
        {
            try
            {
                if (progressBar != null)
                {
                    progressBar.Control.Invoke((Action)(() => { progressBar.Visible = true; }));
                    progressBar.Control.Invoke((Action)(() => { progressBar.Maximum = max; }));
                    progressBar.Control.Invoke((Action)(() => { progressBar.Step = 1; }));
                    progressBar.Control.Invoke((Action)(() => { progressBar.Value = 0; }));
                }
            }
            catch (Exception)
            {

            }
        }

        private void UpdateProgressBar()
        {
            try
            {
                if (progressBar != null)
                {
                    progressBar.Control.Invoke((Action)(() => { progressBar.PerformStep(); }));
                }
            }
            catch (Exception)
            {

            }
        }

        private void FinishProgressBar()
        {
            try
            {
                if(progressBar != null)
                {
                    progressBar.Control.Invoke((Action)(() => { progressBar.Value = 0; }));
                    //progressBar.Control.Invoke((Action)(() => { progressBar.Visible = false; }));
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
