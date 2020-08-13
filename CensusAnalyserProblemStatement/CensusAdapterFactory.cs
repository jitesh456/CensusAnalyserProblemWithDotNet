using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    public class CensusAdapterFactory
    {
        public Dictionary<string, CensusDto> LoadCesusData(CensusAnalyser.Country country, params string[] filePath) {
            switch (country) {

                case CensusAnalyser.Country.INDIA:
                    return new IndianCensusClass().LoadCensusData(filePath);
                case CensusAnalyser.Country.US:
                    return new UsCensusClass().LoadCensusData(filePath[0]);
                default:
                    throw new CensusAnalyserException("NOT A VALID COUNTY",CensusAnalyserException.ExceptionType.NOT_A_VALID_COUNTY);
            }
        }
    }
}
