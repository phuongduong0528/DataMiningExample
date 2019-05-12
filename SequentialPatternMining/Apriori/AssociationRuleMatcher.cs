using Accord.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPatternMining
{
    public class AssociationRuleMatcher
    {
        int items;
        AssociationRule[] rules;
        double confidence;

        public AssociationRuleMatcher(int items, AssociationRule[] rules)
        {
            this.items = items;
            this.rules = rules;
        }

        public int NumberOfInputs
        {
            get { return items; }
        }

        public int NumberOfOutputs
        {
            get { return NumberOfClasses; }
        }

        public int NumberOfClasses
        {
            get { return rules.Length; }
        }

        public AssociationRule[] Rules
        {
            get { return rules; }
            set { rules = value; }
        }

        public double Confidence
        {
            get { return confidence; }
            set { confidence = value; }
        }

        public double[] Scores(SortedSet<string> input, ref SortedSet<string>[] decision)
        {
            Dictionary<SortedSet<string>, double> matches = new Dictionary<SortedSet<string>, double>(new Apriori.SetComparer());
            foreach (var rule in rules)
            {
                if (rule.Matches(input))
                {
                    if (!rule.Y.IsSubsetOf(input) && rule.Confidence > confidence)
                    {
                        if (matches.ContainsKey(rule.Y))
                            matches[rule.Y] += rule.Confidence;
                        else
                            matches[rule.Y] = rule.Confidence;
                    }
                }
            }

            decision = new SortedSet<string>[matches.Count];
            double[] scores = new double[matches.Count];

            int i = 0;
            foreach (var pair in matches)
            {
                decision[i] = pair.Key;
                scores[i] = pair.Value;
                i++;
            }

            Array.Sort(scores, decision);
            Array.Reverse(scores);
            Array.Reverse(decision);

            return scores;
        }

        public double[] Scores(SortedSet<string> input, ref SortedSet<string>[] decision, double[] result)
        {
            var r = Scores(input, ref decision);
            Array.Copy(r, result, r.Length);
            return result;
        }

        public SortedSet<string>[] Decide(SortedSet<string> input)
        {
            SortedSet<string>[] decision = null;
            Scores(input, ref decision);
            return decision;
        }

        public SortedSet<string>[][] Decide(SortedSet<string>[] input)
        {
            return Decide(input, new SortedSet<string>[input.Length][]);
        }

        public SortedSet<string>[][] Decide(SortedSet<string>[] input, SortedSet<string>[][] result)
        {
            for (int i = 0; i < input.Length; i++)
                result[i] = Decide(input[i]);
            return result;
        }

        public double[][] Scores(SortedSet<string>[] input, ref SortedSet<string>[][] decision)
        {
            return Scores(input, ref decision, new double[input.Length][]);
        }

        public double[][] Scores(SortedSet<string>[] input, ref SortedSet<string>[][] decision, double[][] result)
        {
            var r = Scores(input, ref decision);
            r.CopyTo(result);
            return r;
        }

        public SortedSet<string>[] Transform(SortedSet<string> input)
        {
            return Decide(input);
        }

        public SortedSet<string>[][] Transform(SortedSet<string>[] input)
        {
            return Decide(input);
        }

        public SortedSet<string>[][] Transform(SortedSet<string>[] input, SortedSet<string>[][] result)
        {
            return Decide(input);
        }

        public double[] Scores(string[] input, ref string[][] decision)
        {
            SortedSet<string>[] d = null;
            var r = Scores(new SortedSet<string>(input), ref d);
            decision = d.Apply(x => x.ToArray());
            return r;
        }

        public double[] Scores(string[] input, ref string[][] decision, double[] result)
        {
            SortedSet<string>[] d = null;
            var r = Scores(new SortedSet<string>(input), ref d);
            decision = d.Apply(x => x.ToArray());
            Array.Copy(r, result, r.Length);
            return r;
        }

        public double[][] Scores(string[][] input, ref string[][][] decision)
        {
            return Scores(input, ref decision, new double[input.Length][]);
        }

        public double[][] Scores(string[][] input, ref string[][][] decision, double[][] result)
        {
            for (int i = 0; i < input.Length; i++)
                result[i] = Scores(input[i], ref decision[i]);
            return result;
        }

        public string[][] Decide(string[] input)
        {
            return Decide(new SortedSet<string>(input)).Apply(x => x.ToArray());
        }

        public string[][][] Decide(string[][] input)
        {
            return Decide(input, new string[input.Length][][]);
        }

        public string[][][] Decide(string[][] input, string[][][] result)
        {
            for (int i = 0; i < input.Length; i++)
                result[i] = Decide(input[i]);
            return result;
        }

        public string[][] Transform(string[] input)
        {
            return Decide(input);
        }

        public string[][][] Transform(string[][] input)
        {
            return Decide(input);
        }

        public string[][][] Transform(string[][] input, string[][][] result)
        {
            return Decide(input, result);
        }
    }
}
