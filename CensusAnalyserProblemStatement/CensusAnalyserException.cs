using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblemStatement
{
    
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE, WRONG_FILE_DELIMETER,INCORRECT_HEADER
        }

        public ExceptionType exceptionType;

        public CensusAnalyserException(string message,ExceptionType exceptionType):base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
