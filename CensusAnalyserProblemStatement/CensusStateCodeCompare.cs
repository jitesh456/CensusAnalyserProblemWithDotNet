using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    class CensusStateCodeCompare : Comparer<IndianStateCodeCsv>
    {
        public override int Compare(IndianStateCodeCsv x, IndianStateCodeCsv y)
        {
            return x.stateCode.CompareTo(y.stateCode);
        }
    }
}
