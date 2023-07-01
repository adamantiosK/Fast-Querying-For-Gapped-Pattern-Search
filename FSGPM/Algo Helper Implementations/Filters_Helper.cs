using FSGPM.Models;
using System;
using System.Text;

namespace FSGPM.Algo_Helper_Implementations
{
    public static class Filters_Helper
    {
        public static List<SA_Scan_Model> ApplyBitVectorFilter(FilterHelperModel filterHelperModel)
        {
            var b = 0;

            switch (filterHelperModel.max_gap - filterHelperModel.min_gap)
            {
                case 1000:
                    b = 1024;
                    break;
                case 100:
                    b = 102;
                    break;
                default:
                    b = 10;
                    break;
            }


            for (int i = 0; i < filterHelperModel.intervalModels.Count - 1; i++)
            {
                int[] F_vector = new int[filterHelperModel.T.Length / b + 1]; 

                foreach (var pa in filterHelperModel.intervalModels[i].PatternArray)
                {
                    var min = Math.Max((pa + filterHelperModel.min_gap) / b, 0);
                    var max = Math.Min((pa + filterHelperModel.max_gap) / b, F_vector.Length - 1); 

                    for (int j = min; j <= max; j++)
                    {
                        F_vector[j] = 1;
                    }
                }

                List<int> filteredPatternArrayList = new List<int>();

                foreach (var array in filterHelperModel.intervalModels[i + 1].PatternArray)
                {
                    var blockIndex = array / b;
                    if (blockIndex < F_vector.Length && F_vector[blockIndex] == 1)
                    {
                        filteredPatternArrayList.Add(array);
                    }
                }

                filterHelperModel.intervalModels[i + 1].PatternArray = filteredPatternArrayList.ToArray();
                filterHelperModel.intervalModels[i + 1].M = filteredPatternArrayList.Count();

            }

            return filterHelperModel.intervalModels;
        }

        public static List<SA_Scan_Model> ApplyBitVectorFilterWithBackwardFiltering(FilterHelperModel filterHelperModel)
        {
            var b = 8;

            for (int i = 0; i < filterHelperModel.intervalModels.Count - 1; i++)
            {
                int[] F_vector = new int[filterHelperModel.T.Length / b + 1];

                foreach (var pa in filterHelperModel.intervalModels[i].PatternArray)
                {
                    var min = Math.Max((pa + filterHelperModel.min_gap) / b, 0); // Include lower bound check
                    var max = Math.Min((pa + filterHelperModel.max_gap) / b, F_vector.Length - 1); // Adjust to filter size

                    for (int j = min; j <= max; j++)
                    {
                        F_vector[j] = 1;
                    }
                }

                List<int> filteredPatternArrayList = new List<int>();

                foreach (var array in filterHelperModel.intervalModels[i + 1].PatternArray)
                {
                    var blockIndex = array / b;
                    if (blockIndex < F_vector.Length && F_vector[blockIndex] == 1)
                    {
                        filteredPatternArrayList.Add(array);
                    }
                }

                // Check if |A2| < m1/2 and perform second round of filtering if so
                if (filteredPatternArrayList.Count < filterHelperModel.intervalModels[i].PatternArray.Length / 2)
                {
                    // Clear F
                    Array.Clear(F_vector, 0, F_vector.Length);

                    // Set bits in F based on A2
                    foreach (var array in filteredPatternArrayList)
                    {
                        var min = Math.Max((array - filterHelperModel.max_gap) / b, 0); // Note the switch of max_gap and min_gap
                        var max = Math.Min((array - filterHelperModel.min_gap) / b, F_vector.Length - 1);

                        for (int j = min; j <= max; j++)
                        {
                            F_vector[j] = 1;
                        }
                    }

                    // Filter A1
                    List<int> filteredPatternArray1 = new List<int>();
                    foreach (var array in filterHelperModel.intervalModels[i].PatternArray)
                    {
                        var blockIndex = array / b;
                        if (blockIndex < F_vector.Length && F_vector[blockIndex] == 1)
                        {
                            filteredPatternArray1.Add(array);
                        }
                    }

                    // Replace original A1 with filtered A1
                    filterHelperModel.intervalModels[i].PatternArray = filteredPatternArray1.ToArray();
                    filterHelperModel.intervalModels[i].M = filteredPatternArray1.Count();

                }

                // Replace original A2 with filtered A2
                filterHelperModel.intervalModels[i + 1].PatternArray = filteredPatternArrayList.ToArray();
                filterHelperModel.intervalModels[i + 1].M = filteredPatternArrayList.Count();
            }

            return filterHelperModel.intervalModels;
        }

        public static List<SA_Scan_Model> ApplyDirectTextCheckingFilter(FilterHelperModel filterHelperModel)
        {
            double percentage = 0.8; // 20%

            for (int i = 0; i < filterHelperModel.intervalModels.Count - 1; i++)
            {
                double ONE = filterHelperModel.intervalModels[i].PatternArray.Length;
                double two = filterHelperModel.intervalModels[i + 1].PatternArray.Length * (1 - percentage);

                bool isSignificantlySmaller = ONE  <= two;

                if (isSignificantlySmaller && 
                    filterHelperModel.intervalModels[i].PatternArray.Count() > 0 &&
                    filterHelperModel.intervalModels[i+1].PatternArray.Count() > (filterHelperModel.max_gap - filterHelperModel.min_gap))
                {
                    filterHelperModel.intervalModels[i + 1] = DirectTextCheckingFilter(filterHelperModel.T, filterHelperModel.intervalModels[i].PatternArray, filterHelperModel.patterns[i+1], filterHelperModel.min_gap, filterHelperModel.max_gap);
                }
            }

            return filterHelperModel.intervalModels;
        }

        private static SA_Scan_Model DirectTextCheckingFilter(string T, int[] p1Positions, string pattern2, int min_gap, int max_gap)
        {
            List<int> filteredIndexes = new List<int>();

            foreach (var p1Pos in p1Positions)
            {
                int start = p1Pos + min_gap;
                int end = p1Pos + max_gap + pattern2.Length;

                end = Math.Min(end, T.Length - 1);

                List<int> p2Matches = new List<int>();

                if (start < T.Length) {
                    p2Matches = KMPSearch(T.Substring(start, end - start + 1), pattern2);
                }

                filteredIndexes.AddRange(p2Matches.Select(matchPos => matchPos + start));
            }

            return new SA_Scan_Model() { 
                PatternArray = filteredIndexes.ToArray(),
                M = filteredIndexes.Count()
            };
        }

        private static List<int> KMPSearch(string text, string pattern)
        {
            List<int> result = new List<int>();
            int m = pattern.Length;
            int n = text.Length;

            int[] lps = ComputeLPSArray(pattern);

            int i = 0; // index for text
            int j = 0; // index for pattern

            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == m)
                {
                    result.Add(i - j);
                    j = lps[j - 1];
                }
                else if (i < n && pattern[j] != text[i])
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }

            return result;
        }

        private static int[] ComputeLPSArray(string pattern)
        {
            int m = pattern.Length;
            int[] lps = new int[m];
            int len = 0; 
            int i = 1;

            lps[0] = 0;

            while (i < m)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else // (pat[i] != pat[len])
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else // if (len == 0)
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}
