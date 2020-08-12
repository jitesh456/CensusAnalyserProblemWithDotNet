using NUnit.Framework;
using CensusAnalyserProblemStatement;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        private readonly string INDIA_STATE_CODE_FILE_INCORRECT_HEADER = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\IndiaStateCodeIncorrectHeader.csv";


        CensusAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        [Test]
        public void GivenCensusDataFilePath_WhenProper_ShouldReturn_AllRecordCount()
        {
            int actualResult = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA,INDIAN_CENSUS_FILE_PATH);
            Assert.AreEqual(29, actualResult);
        }

        [Test]
        public void GivenCensusDataFilePath_WhenNotProper_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH_INCORRECT));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.FILE_NOT_FOUND
                , ex.exceptionType);
        }


        [Test]
        public void GivenCensusDataFilePath_WhenFilePathEmpty_ShouldProperException()
        {

            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, ""));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }


        [Test]
        public void GivenCensusDataFilePath_WhenFieFormateIsIncorrect_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA, WRONG_INDIAN_CENSUS_FILE_FORMATE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void givenCensusDataFilePath_WhenFileDelimeterIncorrect_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA, WRONG_DELIMETER_INDIAN_CENSUS_FILE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.WRONG_FILE_DELIMETER
                , ex.exceptionType);
        }

        [Test]
        public void GivenCensusDataFilePath_WhenFileWithIncorrectHeader_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA,WRONG_HEADER_INDIAN_CENSUS_FILE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INCORRECT_HEADER
                , ex.exceptionType);
        }

        [Test]
        public void GivenIndainStateCodedata_WhenCorrect_ShouldReturnTotalCount()
        {
            int actualCount = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INDIAN_STATE_CODE_FILE);
            Assert.AreEqual(29, actualCount);
        }

        [Test]
        public void GivenStateCensusFile_WhenNotProper_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INDIAN_STATE_CODE_FILE_INVORRECT_PATH));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.FILE_NOT_FOUND
                , ex.exceptionType);
        }


        [Test]
        public void GivenStateCensusFile_WhenEmptyFileName_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, ""));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void GivenStateCensusFile_WhenIncorrectFormate_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INCORRECT_INDIAN_STATE_CODE_FILE_FORMATE));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void GivenStateCensusFile_WhenIncorrectHeaderShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INDIA_STATE_CODE_FILE_INCORRECT_HEADER));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INCORRECT_HEADER
                , ex.exceptionType);
        }

        [Test]
        public void GivenCensusData_WhenCorrect_ShouldReturnSortedData()
        {
            censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH,INDIAN_STATE_CODE_FILE);
            string sortedCensusData = censusAnalyser
                .GetSortedData(CensusAnalyserCompare.SortByField.STATE,"ASE");
            CensusDao[] sortedData = JsonConvert.DeserializeObject<CensusDao[]>(sortedCensusData);
            Assert.AreEqual("Andhra Pradesh", sortedData[0].state);
        }


        [Test]
        public void GivenCensusData_WhenCorrect_ShouldReturnSortedDataAccourdingToStateCode()
        {
            censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INDIAN_STATE_CODE_FILE);
            string sortedCensusData = censusAnalyser
                .GetSortedData(CensusAnalyserCompare.SortByField.STATE_CODE,"ASE");
            CensusDao[] sortedData = JsonConvert.DeserializeObject<CensusDao[]>(sortedCensusData);
            Assert.AreEqual("AP", sortedData[0].stateCode);
        }

        [Test]
        public void GivenCensusData_WhenCorrect_ShouldReturnSortedDataAccourdingToPopulation()
        {
            censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INDIAN_STATE_CODE_FILE);
            string sortedCensusData = censusAnalyser
                .GetSortedData(CensusAnalyserCompare.SortByField.POPULATION,"ASE");
            CensusDao[] sortedData = JsonConvert.DeserializeObject<CensusDao[]>(sortedCensusData);
            Assert.AreEqual(607688, sortedData[0].population);
        }

        [Test]
        public void GivenCensusData_WhenCorrect_ShouldReturnSortedDataAccourdingToDensity()
        {
            censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INDIAN_STATE_CODE_FILE);
            string sortedCensusData = censusAnalyser.
                GetSortedData(CensusAnalyserCompare.SortByField.DENSITY,"DESC");
            CensusDao[] sortedData = JsonConvert.DeserializeObject<CensusDao[]>(sortedCensusData);
            Assert.AreEqual(1102, sortedData[0].densityPerSqKm);
        }

        [Test]
        public void GivenCensusData_WhenCorrect_ShouldReturnSortedDataAccourdingToArea()
        {
            censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, INDIAN_CENSUS_FILE_PATH, INDIAN_STATE_CODE_FILE);
            string sortedCensusData =censusAnalyser.GetSortedData(CensusAnalyserCompare.SortByField.AREA,"DESC");
            CensusDao[] sortedData = JsonConvert.DeserializeObject<CensusDao[]>(sortedCensusData);
            Assert.AreEqual(342239, sortedData[0].areaInSqKm);
        }

    }
}