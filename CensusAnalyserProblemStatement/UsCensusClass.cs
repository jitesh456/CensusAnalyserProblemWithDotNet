using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblemStatement
{
   public class UsCensusClass
    {
        Dictionary<string, CensusDao> censusData = new Dictionary<string, CensusDao>();

        readonly string headers = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        public int LoadCensusData(string filePath)
        {
            string[] lines;
            try
            {
                lines = LoadCsvFileInStringArray(filePath, headers);
                foreach (string line in lines.Skip(1))
                {
                    string[] columns = line.Split(',');
                    censusData.Add(columns[0], new CensusDao(new UsCensusCsv(columns[0], columns[1], columns[2], columns[3]
                        ,columns[4],columns[5],columns[6],columns[7],columns[8])));
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

            return censusData.Count;
        }

     
          
        private string[] LoadCsvFileInStringArray(string filePath, string header)
        {
            string[] lines;
            if (!Path.GetExtension(filePath).EndsWith(".csv"))
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

        
    }
}
