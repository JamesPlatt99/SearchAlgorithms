using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms
{
    class ComparableWord : IComparable 
    {
        public string Value;

        public ComparableWord(string value)
        {
            this.Value = value;
        }

        public int CompareTo(object obj)
        {
            return this.Value.CompareTo(obj.ToString());
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
