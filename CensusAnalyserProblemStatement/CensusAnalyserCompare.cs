using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    class CensusAnalyserCompare : Comparer<IndianCensusDao>
    {
        public override int Compare(IndianCensusDao x, IndianCensusDao y)
        {
            return x.state.CompareTo(y.state);
        }
    }
}
