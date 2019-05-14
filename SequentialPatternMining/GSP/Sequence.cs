using Accord.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequentialPatternMining.GSP
{
    public class Sequence
    {
        public List<SortedSet<string>> sequence;
        public double Support { get; set; }

        public string GetSequence()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var a in sequence)
            {
                sb.Append(a.ToArray().ToString(OctaveArrayFormatProvider.InvariantCulture));
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in sequence)
            {
                sb.Append(item.ToArray().ToString(OctaveArrayFormatProvider.InvariantCulture));
            }
            sb.Append("->");
            sb.Append($"Support: {Support}");
            return sb.ToString();
        }
    }
}
