using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    public class UsCensusCsv
    {
        public string stateId;
        public string state;
        public long population;
        public long housingUnit;
        public decimal totalArea;
        public decimal waterArea;
        public decimal landArea;
        public decimal populationDensity;
        public decimal housingDensity;

        public UsCensusCsv(string stateId,string state , string population,  string housingUnit,
            string totalArea, string  waterArea,  string landArea, 
            string  populationDensity,  string housingDensity)
        {
            this.state = state;
            this.stateId = stateId;
            this.population = Convert.ToInt32(population);
            this.landArea = Convert.ToDecimal(landArea);
            this.populationDensity = Convert.ToDecimal(populationDensity);
            this.totalArea = Convert.ToDecimal(totalArea);
            this.housingUnit = Convert.ToInt32(housingUnit);
            this.housingDensity = Convert.ToDecimal(housingDensity);
            this.waterArea = Convert.ToDecimal(waterArea);
        }
    }
}
