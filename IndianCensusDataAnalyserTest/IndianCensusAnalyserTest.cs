using NUnit.Framework;
namespace IndianCensusDataAnalyserTest
{
    public class IndianCensusAnalyserTest
    {
        string INDIAN_CENSUS_FILE_PATH = "C:\Users\jites\source\repos\CensusAnalyser\IndianCensusDataAnalyserTest\resource\IndiaStateCensusData.csv";

        CensusAnalyser.AnalyseIndianCensusData analyseIndianCensus;

        [SetUp]
        public void Setup()
        {
            analyseIndianCensus = new CensusAnalyser.AnalyseIndianCensusData();
        }

        [Test]
        public void givenCensusDataFilePath_WhenProper_ShouldReturn_AllRecordCount()
        {
            int actualResult=analyseIndianCensus.loadCensusData(INDIAN_CENSUS_FILE_PATH);

            Assert.AreEqual(30, actualResult);
            Assert.Pass();
        }
    }
}