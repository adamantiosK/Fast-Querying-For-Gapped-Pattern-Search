using FSGPM.Algorithms;
using FSGPM.DataAccess;
using FSGPM.Helper;
using FSGPM.Interfaces;
using FSGPM.Models;
using FSGPM_Test.TestCaseData;
using Moq;

namespace FSGPM_Test
{
    [TestClass]
    public class AC_Automaton_BV_VLG_Test
    {

        [TestMethod]
        public void OneCustomPatternToBeFoundTestWithPatternThreeAndKTwo()
        {
            var IndexPositionsOfPatterns = new List<List<int>>()
            {
                new List<int> { 3 },
                new List<int> { 103, 111 },
                new List<int> { 203, 213 },
            };
            var p = 3;
            var expectedResult = 3;

            var algoImplementation = ClassInstansiation();
            var algoData = TestCaseDataProvider.GetGenomeInstance(p, IndexPositionsOfPatterns);

            var results = algoImplementation.RunAlgoWithDataSetsAndSaveAndReturnResults(algoData);
            Assert.AreEqual(expectedResult, results[0].PatternsFound);
        }

        [TestMethod]
        public void OneCustomPatternToBeFoundTestWithManyPatterns()
        {
            var IndexPositionsOfPatterns = new List<List<int>>()
            {
                new List<int> { 5, 16, 109, 122, 160, 200, 300 },
                new List<int> { 106, 212, 265, 308, 390, 408 },
                new List<int> { 207, 260, 315, 495 , 509, 514},
            };
            var p = 3;
            var expectedResult = 4;

            var algoImplementation = ClassInstansiation();
            var algoData = TestCaseDataProvider.GetGenomeInstance(p, IndexPositionsOfPatterns);

            var results = algoImplementation.RunAlgoWithDataSetsAndSaveAndReturnResults(algoData);
            Assert.AreEqual(expectedResult, results[0].PatternsFound);
        }

        [TestMethod]
        public void OnePatternToBeFoundTestWithPatternThreeAndKTwo()
        {
            var algoImplementation = ClassInstansiation();
            var (algoData, expectedResult) = TestCaseDataProvider.GetGenome3K3PInstance();

            var results = algoImplementation.RunAlgoWithDataSetsAndSaveAndReturnResults(algoData);
            Assert.AreEqual(expectedResult, results[0].PatternsFound);
        }

        private AC_Automaton_BitVector_Binary_Search ClassInstansiation()
        {
            var mockDatabaseService = new Mock<IDatabaseService>();
            var mockReportStatusService = new Mock<IReportStatusService>();

            mockDatabaseService.Setup(x => x.GetDataSetModelByGuid(It.IsAny<Guid>()))
                .Returns((Guid guid) => new DataSet { DataSetGuid = guid, SACalculated = false });

            var algoBaseContext = new Algo_Base_Context(mockDatabaseService.Object, mockReportStatusService.Object);

            return new AC_Automaton_BitVector_Binary_Search(algoBaseContext);
        }
    }
}
