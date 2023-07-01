using FSGPM.Helper;
using FSGPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSGPM_Test.TestCaseData
{
    public static class TestCaseDataProvider
    {
        // initialize charList here
        private static readonly List<char> charList = new List<char>() { 'A', 'U', 'G', 'T', 'B', 'C', 'E', 'D' };

        public static AlgoDataModel GetGenomeInstance(int p, List<List<int>> IndexPositionsOfPatterns)
        {
            var patternList = new List<string>();
            var patterns = new List<IndexedPattern>();

            foreach (var i in IndexPositionsOfPatterns)
            {
                var pattern = GapCreatorHelper.CreateGap(charList, p, patternList);

                patternList.Add(pattern);
                patterns.Add(new IndexedPattern()
                {
                    Indexes = i,
                    Pattern = pattern
                });

            }

            var textT = FillIndexedPattern(patterns);

            var algoData = new AlgoDataModel()
            {
                AvailableAlgoSets = new List<AlgoData>()
                {
                    new AlgoData()
                    {
                        Patterns = patternList,
                        TextT = textT,
                        K_Selection = patternList.Count,
                        DataSetGuid = Guid.NewGuid(),
                        PatternLength = p
                    }
                },
                ConstraintModels = new List<ConstraintModel>()
                {
                    new ConstraintModel()
                    {
                        ConstraintCountGuid = Guid.NewGuid(),
                        ConstraintMin = 100,
                        ConstraintMax = 110
                    }
                },
                ReportProgressGuid = Guid.NewGuid()
            };

            return algoData;
        }

        public static (AlgoDataModel, int expectedResult) GetGenome3K3PInstance()
        {

            var IndexPositionsOfPatterns = new List<List<int>>()
            {
                new List<int> { 3 },
                new List<int> { 105, 111 },
                new List<int> { 212 },
            };
            var p = 3;
            var expectedResult = 2;

            var patternList = new List<string>();
            var patterns = new List<IndexedPattern>();

            foreach (var i in IndexPositionsOfPatterns)
            {
                var IsPattern = true;
                var pattern = GapCreatorHelper.CreateGap(charList, p, patternList, IsPattern);

                patternList.Add(pattern);
                patterns.Add(new IndexedPattern()
                {
                    Indexes = i,
                    Pattern = pattern
                });

            }

            var textT = FillIndexedPattern(patterns);

            var algoData = new AlgoDataModel()
            {
                AvailableAlgoSets = new List<AlgoData>()
                {
                    new AlgoData()
                    {
                        Patterns = patternList,
                        TextT = textT,
                        K_Selection = patternList.Count,
                        DataSetGuid = Guid.NewGuid(),
                        PatternLength = p
                    }
                },
                ConstraintModels = new List<ConstraintModel>()
                {
                    new ConstraintModel()
                    {
                        ConstraintCountGuid = Guid.NewGuid(),
                        ConstraintMin = 100,
                        ConstraintMax = 110
                    }
                },
                ReportProgressGuid = Guid.NewGuid()
            };

            return (algoData, expectedResult);
        }

        private static string FillIndexedPattern(List<IndexedPattern> indexedPatterns)
        {
            // Calculate the maximum index and create the result array
            int maxIndex = indexedPatterns.Max(ip => ip.Indexes.Max()) + indexedPatterns[0].Pattern.Length;
            char[] result = new char[maxIndex];

            // Fill in the patterns
            foreach (IndexedPattern indexedPattern in indexedPatterns)
            {
                foreach (int index in indexedPattern.Indexes)
                {
                    for (int i = 0; i < indexedPattern.Pattern.Length; i++)
                    {
                        result[index + i] = indexedPattern.Pattern[i];
                    }
                }
            }

            // Find the remaining ranges to fill in
            List<(int start, int end)> remainingRanges = new List<(int start, int end)>();
            int currentRangeStart = -1;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '\0')
                {
                    if (currentRangeStart == -1)
                    {
                        currentRangeStart = i;
                    }
                }
                else
                {
                    if (currentRangeStart != -1)
                    {
                        remainingRanges.Add((currentRangeStart, i));
                        currentRangeStart = -1;
                    }
                }
            }
            if (currentRangeStart != -1)
            {
                remainingRanges.Add((currentRangeStart, result.Length));
            }

            // Fill in the remaining ranges with 'p'
            foreach ((int start, int end) in remainingRanges)
            {
                for (int i = start; i < end; i++)
                {
                    result[i] = 'p';
                }
            }

            var textToReturn = new string(result).Replace("p", string.Empty);

            var patterns = indexedPatterns.Select(s => s.Pattern).ToList();

            foreach ((int start, int end) in remainingRanges)
            {
                textToReturn = AddStringAtIndex(textToReturn, GapCreatorHelper.CreateGap(charList, (end - start), patterns), start);
            }

            // Convert the result array to a string and return it
            return textToReturn;
        }

        public static string AddStringAtIndex(string baseString, string stringToAdd, int index)
        {
            StringBuilder builder = new StringBuilder(baseString);
            builder.Insert(index, stringToAdd);
            return builder.ToString();
        }

    }
    
    public class IndexedPattern
    {
        public string Pattern { get; set; }
        public List<int> Indexes { get; set; }
    }
}
