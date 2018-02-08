using System;
using System.Collections.Generic;
using System.Text;

namespace SeachAlgorithms.Searches
{
    interface ISearcher<T> where T:IComparable
    {
        bool ExistsInData(T value);
    }
}
