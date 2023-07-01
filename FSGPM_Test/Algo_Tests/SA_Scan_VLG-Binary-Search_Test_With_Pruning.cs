using FSGPM.Algorithms;
using FSGPM.DataAccess;
using FSGPM.Interfaces;
using FSGPM.Models;
using FSGPM_Test.TestCaseData;
using Moq;

namespace FSGPM_Test
{
    [TestClass]
    public class SA_Scan_VLG_Binary_Search_Test_With_Pruning
    {

        [TestMethod]
        public void OneCustomPatternToBeFoundTestWithPatternThreeAndKTwo()
        {
            var IndexPositionsOfPatterns = new List<List<int>>()
            {
                new List<int> { 3, 8 },
                new List<int> { 103, 108 },
                new List<int> { 208, 218 },
                new List<int> { 322, 328 }
            };

            var p = 3;
            var expectedResult = 4;

            var algoImplementation = ClassInstansiation();
            var algoData = TestCaseDataProvider.GetGenomeInstance(p, IndexPositionsOfPatterns);

            var results = algoImplementation.RunAlgoWithDataSetsAndSaveAndReturnResults(algoData);
            Assert.AreEqual(expectedResult, results[0].PatternsFound);
        }


        [TestMethod]
        public void OneCustomWithZeroResult()
        {
            var IndexPositionsOfPatterns = new List<List<int>>()
            {
                new List<int> { 3, 8 },
                new List<int> { 103, 108 },
                new List<int> { 290 },
                new List<int> { 322, 328 }
            };

            var p = 3;
            var expectedResult = 0;

            var algoImplementation = ClassInstansiation();
            var algoData = TestCaseDataProvider.GetGenomeInstance(p, IndexPositionsOfPatterns);

            var results = algoImplementation.RunAlgoWithDataSetsAndSaveAndReturnResults(algoData);
            Assert.AreEqual(expectedResult, results[0].PatternsFound);
        }

        [TestMethod]
        public void OneCustomPatternWithBinarySearchMinusOne()
        {
            var IndexPositionsOfPatterns = new List<List<int>>()
            {
                new List<int> { 3 },
                new List<int> { 103, 111 , 215},
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

        //[TestMethod]
        //public void OneCustomPatternToBeFoundTestWithALotOfPatterns()
        //{
        //    var IndexPositionsOfPatterns = new List<List<int>>()
        //    {
        //        new List<int> { 4, 17, 110, 123, 163, 203, 303, 407, 511, 616, 724, 817, 921, 1029,
        //            1131, 1242, 1350, 1463, 1567, 1672, 1783, 1891, 2001, 2109, 2213, 2318, 2420, 2523,
        //            //2631, 2735, 2840, 2949, 3053, 3158, 3267, 3371, 3480, 3584, 3692, 3799, 3903, 4012,
        //            //4116, 4225, 4329, 4434, 4543, 4647, 4751, 4860, 4964, 5073, 5177, 5282, 5391, 5495,
        //            //5604, 5708, 5817, 5921, 6026, 6135, 6239, 6348, 6452, 6557, 6666, 6770, 6875, 6984,
        //            //7088, 7197, 7301, 7406, 7515, 7619, 7728, 7832, 7937, 8046, 8150, 8254, 8363, 8467, 
        //            8576, 8680, 8785, 8894, 8998 },
        //        new List<int> { 8, 27, 113, 137, 169, 317, 422, 527, 632, 738, 839, 947, 1055, 1167,
        //            //1276, 1386, 1499, 1603, 1708, 1819, 1927, 2037, 2145, 2249, 2354, 2456, 2559, 2667, 
        //            //2771, 2876, 2985, 3089, 3194, 3303, 3407, 3516, 3620, 3729, 3833, 3938, 4047, 4151,
        //            //4260, 4364, 4469, 4578, 4682, 4786, 4895, 4999, 5108, 5212, 5317, 5426, 5530, 5639,
        //            //5743, 5848, 5957, 6061, 6170, 6274, 6379, 6488, 6592, 6697, 6806, 6910, 7019, 7123,
        //            7228, 7337, 7441, 7550, 7654, 7759, 7868, 7972, 8081, 8185, 8290, 8399, 8503, 8612, 
        //            8716, 8821, 8930, 9034 },
        //        new List<int> { 14, 41, 126, 155, 179, 215, 233, 341, 446, 551, 656, 762, 863, 971, 1079, 1191,
        //            1300, 1410, 1523, 1627, 1732, 1843, 1951, 2061, 2169, 2273, 2378, 2480, 2583, 2691, 
        //            //2795, 2900, 3009, 3113, 3218, 3327, 3431, 3540, 3644, 3753, 3857, 3962, 4071, 4175,
        //            //4284, 4388, 4493, 4602, 4706, 4810, 4919, 5023, 5132, 5236, 5341, 5450, 5554, 5663, 
        //            //5767, 5872, 5981, 6085, 6194, 6298, 6403, 6512, 6616, 6721, 6830, 6934, 7043, 7147,
        //            7252, 7361, 7465, 7574, 7678, 7783, 7892, 7996, 8105, 8209, 8314, 8423, 8527, 8636,
        //            8740, 8845, 8954, 9058 }
        //    };

        //    var p = 3;
        //    var expectedResult = 1;

        //    var algoImplementation = ClassInstansiation();
        //    var algoData = TestCaseDataProvider.GetGenomeInstance(p, IndexPositionsOfPatterns);

        //    var results = algoImplementation.RunAlgoWithDataSetsAndSaveResults(algoData);
        //    Assert.AreEqual(expectedResult, results[0].PatternsFound);
        //}

        [TestMethod]
        public void OnePatternToBeFoundTestWithPatternThreeAndKTwo()
        {
            var algoImplementation = ClassInstansiation();
            var (algoData, expectedResult) = TestCaseDataProvider.GetGenome3K3PInstance();

            var results = algoImplementation.RunAlgoWithDataSetsAndSaveAndReturnResults(algoData);
            Assert.AreEqual(expectedResult, results[0].PatternsFound);
        }

        private SA_Scan_VLG_Binary_SearchWithPruning ClassInstansiation()
        {
            var mockDatabaseService = new Mock<IDatabaseService>();
            var mockReportStatusService = new Mock<IReportStatusService>();

            mockDatabaseService.Setup(x => x.GetDataSetModelByGuid(It.IsAny<Guid>()))
                .Returns((Guid guid) => new DataSet { DataSetGuid = guid, SACalculated = false });

            var algoBaseContext = new Algo_Base_Context(mockDatabaseService.Object, mockReportStatusService.Object);

            return new SA_Scan_VLG_Binary_SearchWithPruning(algoBaseContext);
        }
    }
}
