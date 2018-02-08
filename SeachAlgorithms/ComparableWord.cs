using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms
{
    public class ComparableWord : IComparable 
    {
        public string Value;

        public ComparableWord(string value)
        {
            this.Value = value;
        }

        public int CompareTo(object obj)
        {
            return string.Compare(this.Value.ToLower(), obj.ToString().ToLower());
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
