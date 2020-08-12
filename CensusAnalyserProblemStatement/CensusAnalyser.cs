using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyserProblemStatement
{
   public class CensusAnalyser
    {
        public enum Country {
            INDIA,US
        }
        
        Dictionary<string, CensusDao> censusDatas = new Dictionary<string, CensusDao>();

        public int LoadCensusData( Country country,params string[]  filePath)
        {
            censusDatas = new CensusAdapterFactory().LoadCesusData(country, filePath);
            return censusDatas.Count;

        }

        public string GetSortedData(CensusAnalyserCompare.SortByField sortByField, String order)
        {
            CensusAnalyserCompare analyserCompare = new CensusAnalyserCompare(sortByField);
            var indianCensusDataList = censusDatas.Select(x => x.Value).ToList();
            indianCensusDataList.Sort(analyserCompare);
            if (order.Equals("DESC"))
            {
                indianCensusDataList.Reverse();
            }

            return JsonConvert.SerializeObject(indianCensusDataList);
        }

    }

}
