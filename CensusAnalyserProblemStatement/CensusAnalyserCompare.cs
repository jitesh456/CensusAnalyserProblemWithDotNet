using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    public class CensusAnalyserCompare : Comparer<IndianCensusDao>
    {
        public enum SortByField
        {
            STATE,
            STATE_CODE,
        }

        public SortByField compareByField;

        public  CensusAnalyserCompare(SortByField sortByField)
        {
            compareByField = sortByField;
        }
        public override int Compare(IndianCensusDao x, IndianCensusDao y)
        {
            switch (compareByField) {

                case SortByField.STATE:
                    return x.state.CompareTo(y.state);
                case SortByField.STATE_CODE:
                    return x.stateCode.CompareTo(y.stateCode);
                default:
                    break;
            }
            return x.state.CompareTo(y.state);
        }
    }
}
