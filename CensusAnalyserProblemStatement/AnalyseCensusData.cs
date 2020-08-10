using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyserProblemStatement
{
    public class AnalyseCensusData
    {
        List<IndianCensusDataCsv> indianCensusDataList = new List<IndianCensusDataCsv>();
        List<IndianStateCodeCsv> indianStateCodeDataList = new List<IndianStateCodeCsv>();

        String headers = "State,Population,AreaInSqKm,DensityPerSqKm";
        String headersOfStateCode = "SrNo,State Name,TIN,StateCode";

        public int loadCensusData(string filePath)
        {

            string[] lines;
            try
            {
                lines = loadCsvFileInStringArray(filePath, headers);
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

            return indianCensusDataList.Count;
        }

        public int loadSateCodeData(string filePath)
        {
            string[] lines;
            try
            {
                lines = loadCsvFileInStringArray(filePath, headersOfStateCode);
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

            return indianStateCodeDataList.Count;
        }


        private string[] loadCsvFileInStringArray(string filePath, string header)
        {

            string[] lines;
            if (!Path.GetExtension(filePath).Contains(".csv"))
            {
                throw new CensusAnalyserException("Invalid file type",
                    CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }

            lines = File.ReadAllLines(filePath);

            if (!lines[0].Contains(header))
            {
                throw new CensusAnalyserException("Header is Not Correct", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }

            return lines;
        }

        public string getSortedData()
        {
            CensusAnalyserCompare analyserCompare= new CensusAnalyserCompare();
            indianCensusDataList.Sort(analyserCompare);
            return JsonConvert.SerializeObject(indianCensusDataList);
        }

    }
}
