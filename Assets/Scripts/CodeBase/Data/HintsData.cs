using System;
using System.Collections.Generic;

namespace CodeBase.Data
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