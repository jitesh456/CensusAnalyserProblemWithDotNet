using NUnit.Framework;
using CensusAnalyserProblemStatement;

namespace Tests
{
    public class AnalyseIndianCensusData
    {
        private string INDIAN_CENSUS_FILE_PATH = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusData.csv";
        private string WRONG_INDIAN_CENSUS_FILE_FORMATE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusData.txt";
        private string WRONG_DELIMETER_INDIAN_CENSUS_FILE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusDataWrongDelimeter.csv";
        private string WRONG_HEADER_INDIAN_CENSUS_FILE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusDataWrongHeader.csv";


        AnalyseCensusData analyseCensusData;

        [SetUp]
        public void Setup()
        {
            analyseCensusData = new AnalyseCensusData();
        }

        [Test]
        public void givenCensusDataFilePath_WhenProper_ShouldReturn_AllRecordCount()
        {
            int actualResult = analyseCensusData.loadCensusData(INDIAN_CENSUS_FILE_PATH);
            Assert.AreEqual(29, actualResult);
        }

        [Test]
        public void givenCensusDataFilePath_WhenNotProper_ShouldProperException() {
            var ex = Assert.Throws<CensusAnalyserException>(()=>analyseCensusData.loadCensusData(INDIAN_CENSUS_FILE_PATH+"s12"));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.FILE_NOT_FOUND
                , ex.exceptionType);
        }

        
        [Test]
        public void givenCensusDataFilePath_WhenFilePathEmpty_ShouldProperException()
        {

            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.loadCensusData(""));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }


        [Test]
        public void givenCensusDataFilePath_WhenFieFormateIsIncorrect_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.loadCensusData(WRONG_INDIAN_CENSUS_FILE_FORMATE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void givenCensusDataFilePath_WhenFileDelimeterIncorrect_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.loadCensusData(WRONG_DELIMETER_INDIAN_CENSUS_FILE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.WRONG_FILE_DELIMETER
                , ex.exceptionType);
        }

        [Test]
        public void givenCensusDataFilePath_WhenFileWithIncorrectHeader_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.loadCensusData(WRONG_HEADER_INDIAN_CENSUS_FILE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INCORRECT_HEADER
                , ex.exceptionType);
        }
    }
}