using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.Sorting
{
    public interface ISorter<T> where T : IComparable
    {
        List<T> Sort(List<T> list);
        String GetName();
    }
}
