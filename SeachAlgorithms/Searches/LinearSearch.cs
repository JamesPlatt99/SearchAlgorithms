using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeachAlgorithms.Searches
{
    class LinearSearch<T> where T : IComparable
    {
        #region Properties
        private T[] _data;
        #endregion

        #region Constructors
        public LinearSearch(T[] data)
        {
            _data = data;
        }
        public LinearSearch(IEnumerable<T> data)
        {
            _data = data.ToArray<T>();
        }

        #endregion

        #region Public Methods
        public bool ExistsInData(T value)
        {
            foreach(T dataValue in _data)
            {
                if(value.CompareTo(dataValue) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
