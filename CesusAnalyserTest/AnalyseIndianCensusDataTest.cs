using NUnit.Framework;
using CensusAnalyserProblemStatement;
using Newtonsoft.Json;

namespace Tests
{
    public class AnalyseIndianCensusData
    {
        private readonly string INDIAN_CENSUS_FILE_PATH = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusData.csv";
        private readonly string INDIAN_CENSUS_FILE_PATH_INCORRECT = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\IndiaStateCensusData.csv";
        private readonly string WRONG_INDIAN_CENSUS_FILE_FORMATE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusData.txt";
        private readonly string WRONG_DELIMETER_INDIAN_CENSUS_FILE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusDataWrongDelimeter.csv";
        private readonly string WRONG_HEADER_INDIAN_CENSUS_FILE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCensusDataWrongHeader.csv";
        private readonly string INDIAN_STATE_CODE_FILE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCode.csv";
        private readonly string INDIAN_STATE_CODE_FILE_INVORRECT_PATH = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\IndiaStateCode.csv";
        private readonly string INCORRECT_INDIAN_STATE_CODE_FILE_FORMATE = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCode.txt";
        private readonly string INDIA_STATE_CODE_FILE_INCORRECT_DELIMETER = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCodeIncorrectDelimeter.csv";
        private readonly string INDIA_STATE_CODE_FILE_INCORRECT_HEADER = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCodeIncorrectHeader.csv";


        AnalyseCensusData analyseCensusData;

        [SetUp]
        public void Setup()
        {
            analyseCensusData = new AnalyseCensusData();
        }

        [Test]
        public void GivenCensusDataFilePath_WhenProper_ShouldReturn_AllRecordCount()
        {
            int actualResult = analyseCensusData.LoadCensusData(INDIAN_CENSUS_FILE_PATH);
            Assert.AreEqual(29, actualResult);
        }

        [Test]
        public void GivenCensusDataFilePath_WhenNotProper_ShouldProperException() {
            var ex = Assert.Throws<CensusAnalyserException>(()=>analyseCensusData.
            LoadCensusData(INDIAN_CENSUS_FILE_PATH_INCORRECT));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.FILE_NOT_FOUND
                , ex.exceptionType);
        }

        
        [Test]
        public void GivenCensusDataFilePath_WhenFilePathEmpty_ShouldProperException()
        {

            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.LoadCensusData(""));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }


        [Test]
        public void GivenCensusDataFilePath_WhenFieFormateIsIncorrect_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.
            LoadCensusData(WRONG_INDIAN_CENSUS_FILE_FORMATE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void givenCensusDataFilePath_WhenFileDelimeterIncorrect_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.
            LoadCensusData(WRONG_DELIMETER_INDIAN_CENSUS_FILE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.WRONG_FILE_DELIMETER
                , ex.exceptionType);
        }

        [Test]
        public void GivenCensusDataFilePath_WhenFileWithIncorrectHeader_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.
            LoadCensusData(WRONG_HEADER_INDIAN_CENSUS_FILE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INCORRECT_HEADER
                , ex.exceptionType);
        }

        [Test]
        public void GivenIndainStateCodedata_WhenCorrect_ShouldReturnTotalCount()
        {
            analyseCensusData.LoadCensusData(INDIAN_CENSUS_FILE_PATH);
            int actualCount=analyseCensusData.LoadSateCodeData(INDIAN_STATE_CODE_FILE);
            Assert.AreEqual(29, actualCount);

        }

        [Test]
        public void GivenStateCensusFile_WhenNotProper_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.
            LoadSateCodeData(INDIAN_STATE_CODE_FILE_INVORRECT_PATH));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.FILE_NOT_FOUND
                , ex.exceptionType);
        }


        [Test]
        public void GivenStateCensusFile_WhenEmptyFileName_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.
            LoadSateCodeData(""));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void GivenStateCensusFile_WhenIncorrectFormate_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.
            LoadSateCodeData(INCORRECT_INDIAN_STATE_CODE_FILE_FORMATE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void GivenStateCensusFile_WhenIncorrectHeaderShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => analyseCensusData.
            LoadSateCodeData(INDIA_STATE_CODE_FILE_INCORRECT_HEADER));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INCORRECT_HEADER
                , ex.exceptionType);
        }

        [Test]
        public void GivenCensusData_WhenCorrect_ShouldReturnSortedData()
        {
            analyseCensusData.LoadCensusData(INDIAN_CENSUS_FILE_PATH);
            string sortedCensusData = analyseCensusData.GetSortedData(CensusAnalyserCompare.SortByField.STATE);
            IndianCensusDataCsv[] sortedData= JsonConvert.DeserializeObject<IndianCensusDataCsv[]>(sortedCensusData);
            Assert.AreEqual("Andhra Pradesh", sortedData[0].state);
        }


        [Test]
        public void GivenCensusData_WhenCorrect_ShouldReturnSortedDataAccourdingToStateCode()
        {
            analyseCensusData.LoadCensusData(INDIAN_CENSUS_FILE_PATH);
            analyseCensusData.LoadSateCodeData(INDIAN_STATE_CODE_FILE);
            string sortedCensusData = analyseCensusData.GetSortedData(CensusAnalyserCompare.SortByField.STATE_CODE);
            IndianStateCodeCsv[] sortedData = JsonConvert.DeserializeObject<IndianStateCodeCsv[]>(sortedCensusData);
            Assert.AreEqual("AP", sortedData[0].stateCode);
        }

    }
}