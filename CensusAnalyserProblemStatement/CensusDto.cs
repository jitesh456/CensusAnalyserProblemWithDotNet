﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
   public  class CensusDto
    {
        public string state;
        public long population;
        public long areaInSqKm;
        public long densityPerSqKm;
        public string stateCode;
        public decimal waterArea;
        public decimal landArea;
        public decimal populationDensity;
        public long housingUnit;

        public CensusDto(){ }

        public CensusDto(IndianCensusDataCsv indianCensusData) {
            state = indianCensusData.state;
            population = indianCensusData.population;
            areaInSqKm = indianCensusData.areaInSqKm;
            densityPerSqKm = indianCensusData.densityPerSqKm;
        }
        public CensusDto(UsCensusCsv usCensus)
        {
            state = usCensus.state;
            population = usCensus.population;
            areaInSqKm = Convert.ToInt32(usCensus.totalArea);
            densityPerSqKm =Convert.ToInt32(usCensus.housingDensity);
            stateCode = usCensus.stateId;
            waterArea = usCensus.waterArea;
            landArea = usCensus.landArea;
            populationDensity = usCensus.populationDensity;
            housingUnit = usCensus.housingUnit;
            
        }


    }
}
