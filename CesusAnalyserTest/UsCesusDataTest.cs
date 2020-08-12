using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CensusAnalyserProblemStatement;
using Newtonsoft.Json;


namespace CesusAnalyserTest
{
    class UsCesusDataTest
    {
        private readonly string US_CENSUS_FILE_PATH = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\USCensusData.csv";
        private readonly string US_CENSUS_FILE_PATH_INCORRECT_FILE_DELIMETER = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\USCensusDataIncorrectFileDelimeter.csv";
        private readonly string US_CENSUS_FILE_PATH_INCORRECT_HEADER = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\USCensusDataIncorrectHeader.csv";
        private readonly string US_CENSUS_FILE_PATH_FORMATE_INCORRECT = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\resource\\USCensusData.txt";
        private readonly string US_CENSUS_FILE_PATH_INCORRECT = "C:\\Users\\jites\\source\\repos\\CensusAnalyserProblemStatement\\CesusAnalyserTest\\USCensusData.csv";

        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        [Test]
        public void givenUsCensusFile_WhenCorrect_ShouldReturnCount()
        {
            int count = censusAnalyser.LoadCensusData(CensusAnalyser.Country.US, US_CENSUS_FILE_PATH);
            Assert.AreEqual(51, count);

        }

        [Test]
        public void GivenUsCensusDataFilePath_WhenNotProper_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.US, US_CENSUS_FILE_PATH_INCORRECT));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.FILE_NOT_FOUND
                , ex.exceptionType);
        }


        [Test]
        public void GivenUsCensusDataFilePath_WhenFilePathEmpty_ShouldProperException()
        {

            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.
            LoadCensusData(CensusAnalyser.Country.US, ""));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }


        [Test]
        public void GivenCensusDataFilePath_WhenFieFormateIsIncorrect_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.US, US_CENSUS_FILE_PATH_FORMATE_INCORRECT));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INVALID_FILE_TYPE
                , ex.exceptionType);
        }

        [Test]
        public void GivenUsCensusDataFilePath_WhenFileDelimeterIncorrect_ShouldProperException()
        {
            var ex  =Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.US, US_CENSUS_FILE_PATH_INCORRECT_FILE_DELIMETER));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.WRONG_FILE_DELIMETER
                , ex.exceptionType);
        }

        [Test]
        public void GivenUsCensusDataFilePath_WhenFileWithIncorrectHeader_ShouldProperException()
        {
            var ex = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.US, US_CENSUS_FILE_PATH_INCORRECT_HEADER));
            Assert.AreEqual(CensusAnalyserException
                .ExceptionType.INCORRECT_HEADER
                , ex.exceptionType);
        }

        [Test]
        public void GivenUsCensusDataFile_WhenCorrect_ShouldReturnSortedDataAccourdingToPopulation() {
            censusAnalyser.LoadCensusData(CensusAnalyser.Country.US, US_CENSUS_FILE_PATH);
            string sortedCensusData = censusAnalyser.GetSortedData(CensusAnalyserCompare.SortByField.POPULATION, "DESC");
            CensusDao[] sortedData = JsonConvert.DeserializeObject<CensusDao[]>(sortedCensusData);
            Assert.AreEqual(342239, sortedData[0].population);

        }
    }
}