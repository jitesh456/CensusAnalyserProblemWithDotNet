using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyserProblemStatement
{
    public class IndianCensusClass:CensusAdapter
    {
        Dictionary<string,CensusDao> indianCensusDatas = new Dictionary<string,CensusDao>();
        
        String headers = "State,Population,AreaInSqKm,DensityPerSqKm";
        String headersOfStateCode = "SrNo,State Name,TIN,StateCode";

        public Dictionary<string, CensusDao>  LoadCensusData(params string[] filePath)
        {

            string[] lines;
            try
            {
                lines = base.LoadCsvFileInStringArray(filePath[0], headers);
                foreach (string line in lines.Skip(1))
                {
                    string[] columns = line.Split(',');
                    indianCensusDatas.Add(columns[0],new CensusDao(new IndianCensusDataCsv(columns[0], columns[1], columns[2], columns[3])));
                }
                if(filePath.Count()>1)
                    LoadSateCodeData(filePath[1]);

            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException("FILE NOT FOUND", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            catch (IndexOutOfRangeException e) {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.WRONG_FILE_DELIMETER);
            }

            return indianCensusDatas;
        }

        public int LoadSateCodeData(string filePath)
        {
            string[] lines;
            try
            {
                lines = base.LoadCsvFileInStringArray(filePath, headersOfStateCode);
                foreach (string line in lines.Skip(1))
                {
                    string[] columns = line.Split(',');
                    foreach (var element in indianCensusDatas) {
                        if (element.Key.Equals(columns[1])) {
                            element.Value.stateCode = columns[3];
                        }
                    }
                    
                }
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException("FILE NOT FOUND", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.WRONG_FILE_DELIMETER);
            }

            return indianCensusDatas.Count;
        }


        

    }
}
