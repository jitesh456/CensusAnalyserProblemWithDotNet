using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblemStatement
{
    public class AnalyseCensusData
    {
        List<IndianCensusDataCsv> indianCensusDataList = new List<IndianCensusDataCsv>();
        IEnumerable<IndianCensusDataCsv> indianCensusDatas;
        List<IndianStateCodeCsv> indianStateCodeDataList = new List<IndianStateCodeCsv>();
        IEnumerable<IndianStateCodeCsv> indianStateCodeDatas;
        String headers = "State,Population,AreaInSqKm,DensityPerSqKm";
        String headersOfStateCode = "SrNo,State Name,TIN,StateCode";

        public int loadCensusData(string filePath)
        {

            string[] lines;
            try
            {
                if (!Path.GetExtension(filePath).Contains(".csv"))
                {
                    throw new CensusAnalyserException("Invalid file type",
                        CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
                }

                lines = File.ReadAllLines(filePath);

                if (!lines[0].Contains(headers))
                {
                    throw new CensusAnalyserException("Header is Not Correct",CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
                }

                foreach (string line in lines.Skip(1))
                {
                    string[] columns = line.Split(',');
                    indianCensusDataList.Add(new IndianCensusDataCsv(columns[0], columns[1], columns[2], columns[3]));
                }

            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException("FILE NOT FOUND", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            catch (IndexOutOfRangeException e) {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.WRONG_FILE_DELIMETER);
            }
            
            indianCensusDatas = indianCensusDataList.AsEnumerable();
            return indianCensusDatas.Count();
        }

        public int loadSateCodeData(string filePath)
        {
            string[] lines;
            try
            {
                if (!Path.GetExtension(filePath).Contains(".csv"))
                {
                    throw new CensusAnalyserException("Invalid file type",
                        CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
                }

                lines = File.ReadAllLines(filePath);

                if (!lines[0].Contains(headersOfStateCode))
                {
                    throw new CensusAnalyserException("Header is Not Correct", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
                }

                foreach (string line in lines.Skip(1))
                {
                    string[] columns = line.Split(',');
                    indianStateCodeDataList.Add(new IndianStateCodeCsv(columns[0], columns[1], columns[2], columns[3]));
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

          indianStateCodeDatas = indianStateCodeDataList.AsEnumerable();
            return indianStateCodeDatas.Count();
        }
    }
}
