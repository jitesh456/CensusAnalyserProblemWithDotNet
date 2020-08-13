using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    public class CensusAnalyserCompare : Comparer<CensusDto>
    {
        public enum SortByField
        {
            STATE,
            STATE_CODE,
            POPULATION,
            DENSITY,
            AREA,
            HOUSING_UNIT,
            POPULATION_DENSITY,
            LAND_AREA,
            WATER_AREA,
    }

        public SortByField compareByField;

        public  CensusAnalyserCompare(SortByField sortByField)
        {
            compareByField = sortByField;
        }
        public override int Compare(CensusDto x, CensusDto y)
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
                case SortByField.AREA:
                    return x.areaInSqKm.CompareTo(y.areaInSqKm);
                case SortByField.HOUSING_UNIT:
                    return x.housingUnit.CompareTo(y.housingUnit);
                case SortByField.POPULATION_DENSITY:
                    return x.populationDensity.CompareTo(y.populationDensity);
                case SortByField.LAND_AREA:
                    return x.housingUnit.CompareTo(y.housingUnit);
                case SortByField.WATER_AREA:
                    return x.housingUnit.CompareTo(y.housingUnit);
                default:
                    break;
            }
            return x.state.CompareTo(y.state);
        }
    }
}
