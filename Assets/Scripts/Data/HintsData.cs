using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public class HintsData
    {
        public List<int> Hints;

        public HintsData()
        {
            Hints = new List<int>();
        }
    }
}