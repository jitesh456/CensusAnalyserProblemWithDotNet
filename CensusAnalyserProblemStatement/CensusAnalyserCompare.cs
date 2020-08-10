using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    class CensusAnalyserCompare : Comparer<IndianCensusDataCsv>
    {
        
        public override int Compare(IndianCensusDataCsv x, IndianCensusDataCsv y)
        {
            return x.state.CompareTo(y.state);
        }
    }
}
