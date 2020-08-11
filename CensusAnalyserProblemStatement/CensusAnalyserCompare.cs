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
            POPULATION,
            DENSITY,
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
                case SortByField.POPULATION:
                    return x.population.CompareTo(y.population);
                case SortByField.DENSITY:
                    return x.densityPerSqKm.CompareTo(y.densityPerSqKm);
                default:
                    break;
            }
            return x.state.CompareTo(y.state);
        }
    }
}
