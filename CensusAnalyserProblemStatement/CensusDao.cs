using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
   public  class CensusDao
    {
        public string state;
        public long population;
        public long areaInSqKm;
        public long densityPerSqKm;
        public string stateCode;

        public CensusDao()
        { }

        public CensusDao(IndianCensusDataCsv indianCensusData) {
            state = indianCensusData.state;
            population = indianCensusData.population;
            areaInSqKm = indianCensusData.areaInSqKm;
            densityPerSqKm = indianCensusData.densityPerSqKm;
        }
        public CensusDao(UsCensusCsv usCensus)
        {
            state = usCensus.state;
            population = usCensus.population;
            areaInSqKm = Convert.ToInt32(usCensus.totalArea);
            densityPerSqKm =Convert.ToInt32(usCensus.housingDensity);
            state = usCensus.stateId;
        }


    }
}
