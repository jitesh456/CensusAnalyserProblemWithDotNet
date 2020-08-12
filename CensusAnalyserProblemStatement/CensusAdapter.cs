using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CensusAnalyserProblemStatement
{
    public abstract class CensusAdapter
    {

       protected string[] LoadCsvFileInStringArray(string filePath, string header)
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
