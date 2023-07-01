using FSGPM.Helper;
using FSGPM.Models;
using System.Collections;
using static FSGPM.Algo_Helper_Implementations.SuffixArrayBuilder;

namespace FSGPM.Algo_Helper_Implementations
{
    public static class SA_SCAN_Helper
    {
        public static List<List<int>> FindOccourances(List<SA_Scan_Model> intervalModel, int patternLength, int min_gap, int max_gap)
        {
            return FindAllOcourances(intervalModel[0].PatternArray, intervalModel[0].M, intervalModel[1].PatternArray, intervalModel[1].M,intervalModel.Skip(2).ToList(), min_gap, max_gap, new List<int>(), new List<List<int>>());
        }

        public static List<List<int>> FindOccourancesBinaySearch(List<SA_Scan_Model> intervalModel, int patternLength, int min_gap, int max_gap)
        {
            return FindAllOcourancesBinarySearch(intervalModel[0].PatternArray, intervalModel[0].M, intervalModel[1].PatternArray, intervalModel[1].M, intervalModel.Skip(2).ToList(), min_gap, max_gap, new List<int>(), new List<List<int>>());       
        }

        public static List<List<int>> FindOccourancesBinaySearchWithPruning(List<SA_Scan_Model> intervalModel, int patternLength, int min_gap, int max_gap)
        {
            var dictionaryGuid = Guid.NewGuid();
            var resultsToReturn = FindAllOcourancesBinarySearchWithPruning(dictionaryGuid, intervalModel[0].PatternArray, intervalModel[0].M, intervalModel[1].PatternArray, intervalModel[1].M, intervalModel.Skip(2).ToList(), min_gap, max_gap, new List<int>(), new List<List<int>>());
            SA_Search_Pruning_Singleton.DeleteInstance(dictionaryGuid);

            return resultsToReturn;
        }

        public static List<SA_Scan_Model> GetModelListFromBuilder(List<string> patterns, int[] SA, string T)
        {
            var intervalModel = new List<SA_Scan_Model>() { };

            foreach (var pattern in patterns)
            {
                var interval = Search(pattern, T, SA);
                int m = interval.Item2 - interval.Item1 + 1;
                int[] PatternArray = SA.Skip(interval.Item1).Take(m).ToArray();
                LSDRadixSort.Sort(PatternArray);

                intervalModel.Add(
                        new SA_Scan_Model()
                        {
                            PatternArray = PatternArray,
                            M = m
                        }
                    );
            }

            return intervalModel;
        }

        private static List<List<int>> FindAllOcourances(int[] A, int m_a, int[] B, int m_b, List<SA_Scan_Model> leftOverPatterns, int min_gap, int max_gap,
        List<int> currentRoadMap, List<List<int>> patternLocationsToReturn)
        {
            for (int i = 0, j = 0; i < m_a; i++)
            {
                while (j < m_b && B[j] < (A[i] + min_gap)) j++;
                while (j < m_b && B[j] <= (A[i] + max_gap))
                {
                    var intervalsRoadMap = currentRoadMap.GetRange(0, currentRoadMap.Count);
                    intervalsRoadMap.Add(A[i]);

                    if (leftOverPatterns.Count > 0)
                    {
                        patternLocationsToReturn = FindAllOcourances(new int[] { B[j] }, 1, leftOverPatterns[0].PatternArray, leftOverPatterns[0].M,
                            leftOverPatterns.Skip(1).ToList(), min_gap, max_gap, intervalsRoadMap, patternLocationsToReturn);
                    }
                    else
                    {
                        intervalsRoadMap.Add(B[j]);
                        patternLocationsToReturn.Add(intervalsRoadMap);
                    }
                    j++;
                }
                j = 0;
            }

            return patternLocationsToReturn;
        }

        private static List<List<int>> FindAllOcourancesBinarySearch(int[] A, int m_a, int[] B, int m_b, List<SA_Scan_Model> leftOverPatterns, int min_gap, int max_gap,
        List<int> currentRoadMap, List<List<int>> patternLocationsToReturn)
        {
            for (int i = 0, j = 0; i < m_a; i++)
            {
                j = BinaryTree.FindNextElementIndex(B, A[i] + min_gap - 1);

                while (j < m_b && j != -1 && B[j] <= (A[i] + max_gap))
                {
                    var intervalsRoadMap = currentRoadMap.GetRange(0, currentRoadMap.Count);
                    intervalsRoadMap.Add(A[i]);

                    if (leftOverPatterns.Count > 0)
                    {
                        patternLocationsToReturn = FindAllOcourancesBinarySearch(new int[] { B[j] }, 1, leftOverPatterns[0].PatternArray, leftOverPatterns[0].M,
                            leftOverPatterns.Skip(1).ToList(), min_gap, max_gap, intervalsRoadMap, patternLocationsToReturn);
                    }
                    else
                    {
                        intervalsRoadMap.Add(B[j]);
                        patternLocationsToReturn.Add(intervalsRoadMap);
                    }
                    j++;
                }
                j = 0;
            }

            return patternLocationsToReturn;
        }

        private static List<List<int>> FindAllOcourancesBinarySearchWithPruning(Guid prunedInstanceGuid, int[] A, int m_a, int[] B, int m_b, List<SA_Scan_Model> leftOverPatterns, int min_gap, int max_gap,
        List<int> currentRoadMap, List<List<int>> patternLocationsToReturn)
        {
            var copyOfExistingLocationsToReturn = new List<List<int>>(patternLocationsToReturn);
            for (int i = 0, j = 0; i < m_a; i++)
            {
                j = BinaryTree.FindNextElementIndex(B, A[i] + min_gap - 1);
                var prunedInstance = SA_Search_Pruning_Singleton.GetInstance(prunedInstanceGuid);

                if (j < m_b && j != -1 && B[j] <= (A[i] + max_gap) && prunedInstance.IsIndexedPruned(A[i]))
                {
                    patternLocationsToReturn.AddRange(prunedInstance.GetPrunedDirectories(A[i], currentRoadMap));
                }
                else
                {

                    while (j < m_b && j != -1 && B[j] <= (A[i] + max_gap))
                    {
                        var intervalsRoadMap = currentRoadMap.GetRange(0, currentRoadMap.Count);
                        intervalsRoadMap.Add(A[i]);

                        if (leftOverPatterns.Count > 0)
                        {
                            patternLocationsToReturn = FindAllOcourancesBinarySearchWithPruning(prunedInstanceGuid, new int[] { B[j] }, 1, leftOverPatterns[0].PatternArray, leftOverPatterns[0].M,
                                leftOverPatterns.Skip(1).ToList(), min_gap, max_gap, intervalsRoadMap, patternLocationsToReturn);
                        }
                        else
                        {
                            intervalsRoadMap.Add(B[j]);
                            patternLocationsToReturn.Add(intervalsRoadMap);
                        }
                        j++;
                 
                    }
                    prunedInstance.InsertRoadMaps(A[i], patternLocationsToReturn.Except(copyOfExistingLocationsToReturn).ToList());
                }
                prunedInstance.MarkIndexAsPrunned(A[i]);
            }

            return patternLocationsToReturn;
        }

        private static Tuple<int, int> Search(string pattern, string text, int[] SA)
        {
            int n = text.Length;
            int m = pattern.Length;
            int l = 0, r = n - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int cmp = string.Compare(text.Substring(SA[mid], Math.Min(m, n - SA[mid])), pattern);
                if (cmp < 0) l = mid + 1;
                else r = mid - 1;
            }
            int start = l;
            r = n - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int cmp = string.Compare(text.Substring(SA[mid], Math.Min(m, n - SA[mid])), pattern);
                if (cmp > 0) r = mid - 1;
                else l = mid + 1;
            }
            int end = r;
            if (start > end) return new Tuple<int, int>(-1, -1);
            else return new Tuple<int, int>(start, end);
        }
    }
}