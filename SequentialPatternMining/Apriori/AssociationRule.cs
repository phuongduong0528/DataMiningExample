using Accord.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPatternMining
{
    public class AssociationRule
    {
        public SortedSet<string> X { get; set; }
        public SortedSet<string> Y { get; set; }
        public double Support { get; set; }
        public double Confidence { get; set; }
        public bool Matches(SortedSet<string> input)
        {
            return X.IsSubsetOf(input);
        }
        public bool Matches(string[] input)
        {
            return X.IsSubsetOf(input);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(X.ToArray().ToString(OctaveArrayFormatProvider.InvariantCulture));
            sb.Append(" -> ");
            sb.Append(Y.ToArray().ToString(OctaveArrayFormatProvider.InvariantCulture));
            sb.AppendFormat("; support: {0}, confidence: {1}", Support, Confidence);
            return sb.ToString();
        }
    }
}
