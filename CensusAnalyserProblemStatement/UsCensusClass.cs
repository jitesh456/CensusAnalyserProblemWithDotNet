﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblemStatement
{
   public class UsCensusClass:CensusAdapter
    {
        Dictionary<string, CensusDto> censusData = new Dictionary<string, CensusDto>();

        readonly string headers = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        public Dictionary<String,CensusDto> LoadCensusData(string filePath)
        {
            string[] lines;
            try
            {
                lines = base.LoadCsvFileInStringArray(filePath, headers);
                foreach (string line in lines.Skip(1))
                {
                    string[] columns = line.Split(',');
                    censusData.Add(columns[0], new CensusDto(new UsCensusCsv(columns[0], columns[1], columns[2], columns[3]
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

            return censusData;
        }
    }
}
