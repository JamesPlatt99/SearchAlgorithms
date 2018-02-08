using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeachAlgorithms.Searches
{
    class BinarySearch<T> where T : IComparable
    {
        #region Properties
        private T[] _data;
        #endregion

        #region Constructors
        public BinarySearch(T[] data)
        {
            _data = data;
        }
        public BinarySearch(IEnumerable<T> data)
        {
            _data = data.ToArray<T>();
        }

        #endregion

        #region Public Methods        
        public bool ExistsInData(T value)
        {
            var indexes = new Indexes(0, _data.Length - 1);
            while (value.CompareTo(GetMidValue(indexes)) != 0)
            {
                if (indexes.Min >= indexes.Max -1)
                {
                    return (value.CompareTo(_data[indexes.Min]) == 0 || value.CompareTo(_data[indexes.Max]) == 0);
                }
                indexes = GetIndexes(indexes, value);
            }
            return true;
        }
        #endregion

        #region Helper Methods

        private Indexes GetIndexes(Indexes indexes, T value)
        {
            if (value.CompareTo(GetMidValue(indexes)) > 0) {
                indexes.Min = GetMidIndex(indexes);
            }
            else
            {
                indexes.Max = GetMidIndex(indexes);
            }
            return indexes;
        }

        private T GetMidValue(Indexes indexes)
        {
            return _data[GetMidIndex(indexes)];
        }

        private int GetMidIndex(Indexes indexes)
        {
            return (indexes.Min + indexes.Max) / 2;
        }

        #endregion

    }

    class Indexes
    {
        public int Min;
        public int Max;

        public Indexes(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
