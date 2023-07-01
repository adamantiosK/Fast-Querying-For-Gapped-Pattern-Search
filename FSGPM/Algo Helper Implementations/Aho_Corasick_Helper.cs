using FSGPM.Models;
using Microsoft.IdentityModel.Protocols;
using System.Reflection;

namespace FSGPM.Algo_Helper_Implementations
{
    public class Aho_Corasick_Helper
    {
        public static List<SA_Scan_Model> GetModelListFromBuilder(List<string> patterns, int[] SA, string T)
        {
            return new VLGSearch().Search(patterns.ToArray(), T);
        }

        public static List<List<int>> FindOccourances_BlackBoxImplementation(List<SA_Scan_Model> intervalModel, int patternLength, int min_gap, int max_gap)
        {
            List<List<int>> results = new List<List<int>>();
            List<Tuple<int, int>> occurrences = intervalModel.Select((m, i) => m.PatternArray.Select(o => Tuple.Create(i, o))).SelectMany(x => x).ToList();
            List<List<Tuple<int, int>>> relevantRanges = new List<List<Tuple<int, int>>>(intervalModel.Count);

            for (int i = 0; i < intervalModel.Count; i++)
            {
                relevantRanges.Add(new List<Tuple<int, int>>());
            }

            foreach (var occurrence in occurrences)
            {
                int patternIndex = occurrence.Item1;
                int position = occurrence.Item2 - (patternLength - 1);

                if (patternIndex == 0 || relevantRanges[patternIndex - 1].Any(range => position >= range.Item1 && position <= range.Item2))
                {
                    if (patternIndex < intervalModel.Count - 1)
                    {
                        int rangeStart = position + min_gap;
                        int rangeEnd = position + max_gap;
                        relevantRanges[patternIndex].Add(new Tuple<int, int>(rangeStart, rangeEnd));
                    }
                    else
                    {
                        var match = new List<List<int>>
                    {
                        new List<int>() { position }
                    };

                        var currentPatternIndex = patternIndex;
                        var currentPositions = new List<int>() { position };

                        while (currentPatternIndex >= 0)
                        {
                            var turnPositions = currentPositions;
                            currentPositions = new List<int>();
                            if (currentPatternIndex > 0)
                            {
                                foreach (var currentPosition in turnPositions)
                                {
                                    var turnPositionsVar = relevantRanges[currentPatternIndex - 1].Where(range => currentPosition >= range.Item1 && currentPosition <= range.Item2)?.Select(range => range.Item1 - min_gap).ToList() ?? new List<int>();
                                    currentPositions.AddRange(turnPositionsVar);

                                    var matchingList = match.First(list => list.Last() == currentPosition);

                                    // Create the new lists
                                    var newLists = new List<List<int>>();
                                    foreach (int turnPosition in turnPositionsVar)
                                    {
                                        var newList = new List<int>(matchingList)
                                    {
                                        turnPosition
                                    };

                                        newLists.Add(newList);
                                    }

                                    // Remove the old list from match and add the new ones
                                    match.Remove(matchingList);
                                    foreach (List<int> newList in newLists)
                                    {
                                        match.Add(newList);
                                    }

                                }


                            }

                            currentPatternIndex--;
                        }

                        foreach (var list in match)
                        {
                            list.Reverse();
                        }

                        results.AddRange(match);
                    }
                }
            }
            return results;
        }
    }
}