using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        

        static string wrongDataFilePath = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\IndiaStateCoe.csv";

        static string IndianStateCensus = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";

        static string wrongIndianStateCensusFileHeader = @"State,Population,AreaInSqKm,DensitPerSqKm";

        static string indianStateCodeFilePathWrongDelimeter = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\DifferentDelimiter.csv";

        static string wrongDelimiterHeader = "country-state-district-taluk";

        static string indianStateCodeFilePath = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\IndiaStateCod.csv";

        static string WrongIndianStateCodeFileTypePath = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";

        static string IndianStateCodeFilePathWrongDelimeter = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\WrongDelimiterIndiaStateCode.csv";

        static string IndianStateCodeFilePathWrongHeader = @"C:\Users\HP\Desktop\csharp\IndianStateCensusAnalyserProblem\CensusAnalyserTest\CSVFiles\WrongHeaderIndiaStateCode.csv";




        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecords;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecords=censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29,totalRecord.Count);
            Assert.AreEqual(37,stateRecords.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDataFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensus, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }


        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, wrongIndianStateCensusFileHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        [Test]
        public void GivenIndianStateCodeFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCodeFilePathWrongDelimeter, Country.INDIA, wrongDelimiterHeader));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }


        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecords = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecords.Count);
        }

        [Test]
        public void GivenWrongStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFileTypePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        [Test]
        public void GivenIndianStateCodeFileUC2_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongDelimeter, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        [Test]
        public void GivenIndianStateCodeFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongHeader, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }


  
}