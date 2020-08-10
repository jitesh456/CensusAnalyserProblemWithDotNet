using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    class IndianCensusDao
    {
        public string state;
        public long population;
        public long areaInSqKm;
        public long densityPerSqKm;
        public string stateCode;

        public IndianCensusDao(IndianCensusDataCsv indianCensusData) {
            state = indianCensusData.state;
            population = indianCensusData.population;
            areaInSqKm = indianCensusData.areaInSqKm;
            densityPerSqKm = indianCensusData.densityPerSqKm;
        }

    }
}
