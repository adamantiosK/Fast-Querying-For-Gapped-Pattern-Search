using FSGPM.Algorithms;
using FSGPM.DataAccess;
using FSGPM.Enum;
using FSGPM.Interfaces;
using Microsoft.VisualBasic;
using System;

namespace FSGPM.Services
{
    public class OverleafService : IOverleafService
    {
        private IDatabaseService _databaseService;

        public OverleafService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public string CreateNewPreProccessingOverTakingLineGraphForDataSetResult(Guid DataSetGuid, bool AverageRunningTimeGraphTrueAmmortizedFalse)
        {
            var results = _databaseService.GetApprovedResultsForDataSet(DataSetGuid);

            var algorithmNames = new List<string>()
            {
                #region SA_Scan_Filters
                //AlgoNameEnum.SA_Scan_VLG.GetDescription(),
                AlgoNameEnum.SA_Scan_BitVector.GetDescription(),
                //AlgoNameEnum.SA_Scan_BackBitVector.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_BitVector.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_BackBitVector.GetDescription(),
                #endregion

                //#region SA_Scan_Binary_Search_Filters
                //AlgoNameEnum.SA_Scan_VLG_Binary_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_BitVector_Binary_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_BackBitVector_Binary_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_Binary_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_BitVector_Binary_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_BackBitVector_Binary_Search.GetDescription(),
                //#endregion

                //#region SA_Scan_Graph_Search_Filters
                //AlgoNameEnum.SA_Scan_Graph_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_BitVector_Graph_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_BackBitVector_Graph_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_Graph_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_BitVector_Graph_Search.GetDescription(),
                //AlgoNameEnum.SA_Scan_TextChecking_BackBitVector_Graph_Search.GetDescription(),
                //#endregion

                //#region AC_GraphSearch_Filters
                //AlgoNameEnum.AC_Automaton_VLG.GetDescription(),
                ////AlgoNameEnum.AC_Automaton_BitVector_Graph_Search.GetDescription(),
                ////AlgoNameEnum.AC_Automaton_BackBitVector_Graph_Search.GetDescription(),
                ////AlgoNameEnum.AC_Automaton_TextChecking_Graph_Search.GetDescription(),
                ////AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Graph_Search.GetDescription(),
                ////AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Graph_Search.GetDescription(),
                //#endregion

                //#region AC_Scan_Filters
                //AlgoNameEnum.AC_Automaton_VLG_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BitVector_Intersect_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_BackBitVector_Intersect_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_TextChecking_Intersect_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Intersect_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Intersect_Search.GetDescription(),
                //#endregion

                //#region AC_Scan_Binary_Search_Filters
                //AlgoNameEnum.AC_Automaton_VLG_Binary_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_BitVector_Binary_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_BackBitVector_Binary_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_TextChecking_Binary_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Binary_Search.GetDescription(),
                //AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Binary_Search.GetDescription(),
                //#endregion
            };

            var toReturnString = "\\pgfplotstableread{\r\n";
            toReturnString += GetNamesString(algorithmNames.Count);
            toReturnString += AverageRunningTimeGraphTrueAmmortizedFalse?
                GetLineGraphAverageRunningTimeWithSpreadedPreProccessingPoints(algorithmNames, results):
                GetLineGraphWithAmmortizedRunningTimeAfterConsideringPreProccessingPoints(algorithmNames, results);

            toReturnString += "\\begin{figure}[H]\r\n\\centering\r\n\\begin{tikzpicture}[spy using outlines = {circle, size=2cm, magnification=10, connect spies}]\r\n\\begin{axis}[\r\n    width=15cm,\r\n    height=6.6cm,\r\n    ylabel = {Unit},\r\n    ymin = 0,\r\n    enlarge x limits = false,\r\n    ymajorgrids = true,\r\n    legend style = {at={(0.5,-0.1)}, anchor=north},\r\n    cycle list name=DTU,\r\n    every axis plot/.append style={fill opacity=0},\r\n    ] \r\n";

            for (int i = 0; i < algorithmNames.Count; i++)
            {
                toReturnString += "\\addplot table[x=x,y={Name "+(i+1)+"}]{\\lineGraphMagnifyData}; \r\n";
            }

            toReturnString += "\r\n\\coordinate (spypoint) at (axis cs:3,10.5); % Delete this line to remove magnifying glass\r\n\\coordinate (magnifyglass) at (axis cs:3.6,12); % Delete this line to remove magnifying glass\r\n\\legend{"+GetLegendsForAlgos(algorithmNames)+"} \r\n\\end{axis} \r\n\r\n\\spy [black, size=2cm] on (spypoint) in node[fill=white] at (magnifyglass); % Delete this line to remove magnifying glass\r\n\\end{tikzpicture}\r\n\\caption{Line graph with magnifying glass}\r\n\\label{fig:linegraphmagnify}\r\n\\end{figure}";

            return toReturnString;
        }

        public string CreateNewBoxPlotWithResultData(Guid DataSetGuid,bool breakUpPatternLengthResults)
        {
            var algorithmNames = new List<List<string>>()
            {
                new List<string>() {
                    #region SA_Scan_Filters
                AlgoNameEnum.SA_Scan_VLG.GetDescription(),
                AlgoNameEnum.SA_Scan_BitVector.GetDescription(),
                AlgoNameEnum.SA_Scan_BackBitVector.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_BitVector.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_BackBitVector.GetDescription(),
                    #endregion
                },
                new List<string>() {
                    #region SA_Scan_Binary_Search_Filters
                AlgoNameEnum.SA_Scan_VLG_Binary_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_BitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_BackBitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_Binary_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_BitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_BackBitVector_Binary_Search.GetDescription(),
                #endregion
                },
                new List<string>() { 
                    #region SA_Scan_Graph_Search_Filters
                AlgoNameEnum.SA_Scan_Graph_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_BitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_BackBitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_Graph_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_BitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.SA_Scan_TextChecking_BackBitVector_Graph_Search.GetDescription(),
                #endregion
                },
                new List<string>() {
                    #region AC_GraphSearch_Filters
                AlgoNameEnum.AC_Automaton_VLG.GetDescription(),
                AlgoNameEnum.AC_Automaton_BitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BackBitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Graph_Search.GetDescription(),
                #endregion
                },
                new List<string>() {
                    #region AC_Scan_Filters
                AlgoNameEnum.AC_Automaton_VLG_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BitVector_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BackBitVector_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Intersect_Search.GetDescription(),
                #endregion
                },
                new List<string>() {
                    #region AC_Scan_Binary_Search_Filters
                AlgoNameEnum.AC_Automaton_VLG_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BackBitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Binary_Search.GetDescription(),
                #endregion
                }
            };
            var toReturnString = string.Empty;

            foreach (var algorithmSet in algorithmNames)
            {
                toReturnString += CreateNewBoxPlot(DataSetGuid, algorithmSet, breakUpPatternLengthResults) + "\r\n\r\n\r\n";
            }

            return toReturnString;
        }

        private string CreateNewBoxPlot(Guid DataSetGuid, List<string> algorithmNames, bool breakUpPatternLengthResults)
        {
            var results = _databaseService.GetApprovedResultsForDataSet(DataSetGuid);
            var patternLengthCounts = results.Select(x => x.PatternLength).Distinct().OrderBy(s => s).ToList();

            var PlotResults = new List<BoxPlotModel>();

            foreach (var algorithmName in algorithmNames)
            {
                var filteredData = new List<long>();

                if (breakUpPatternLengthResults)
                {
                    foreach (var patternLength in patternLengthCounts)
                    {
                        filteredData = results.Where(x => x.AlgorithmName == algorithmName && x.PatternLength == patternLength)
                            .Select(x => x.Miliseconds).ToList();

                        if (filteredData.Count > 0)
                        {
                            PlotResults.Add(new BoxPlotModel()
                            {
                                lowerWhisker = filteredData.Min(),
                                upperWhisker = filteredData.Max(),
                                lowerQuartile = GetPercentile(filteredData, 0.25),
                                median = GetPercentile(filteredData, 0.5),
                                upperQuartile = GetPercentile(filteredData, 0.75),
                            });
                        }
                    }
                }
                else
                {
                    filteredData = results.Where(x => x.AlgorithmName == algorithmName).Select(x => x.Miliseconds_AverageRun).ToList();
                    if (filteredData.Count > 0)
                    {
                        PlotResults.Add(new BoxPlotModel()
                        {
                            lowerWhisker = filteredData.Min(),
                            upperWhisker = filteredData.Max(),
                            lowerQuartile = GetPercentile(filteredData, 0.25),
                            median = GetPercentile(filteredData, 0.5),
                            upperQuartile = GetPercentile(filteredData, 0.75),
                        });
                    }

                }

            }

            var initialOverleafBoxPlotPart = 
                "\\begin{figure}[H]\r\n\\centering\r\n\\begin{tikzpicture}\r\n\\begin{axis}[\r\n    boxplot/draw direction=y,\r\n    xtick={"+ GetCommaSeparatedInts(breakUpPatternLengthResults ? (algorithmNames.Count * patternLengthCounts.Count) : algorithmNames.Count) + "},\r\n    xticklabels={"+ GetCommaSeparatedInts(algorithmNames, patternLengthCounts, breakUpPatternLengthResults) + "},\r\n    x axis line style={opacity=0},\r\n    enlarge y limits,\r\n    ymajorgrids,\r\n    cycle list name=DTU,\r\n    every axis plot/.append style={semithick},\r\n]";

            foreach (var Plot in PlotResults)
            {
                initialOverleafBoxPlotPart += "\\addplot+[draw=black,\r\nboxplot prepared={\r\nlower whisker=" + Plot.lowerWhisker + ", lower quartile=" + Plot.lowerQuartile + ",\r\nmedian=" + Plot.median + ",\r\nupper quartile=" + Plot.upperQuartile + ", upper whisker=" + Plot.upperWhisker + ",\r\n},\r\n] coordinates {};";
            }

            initialOverleafBoxPlotPart += "\\end{axis}\r\n\\end{tikzpicture}\r\n\\caption{"+GetDataSetName(DataSetGuid) +"}\r\n\\label{fig:boxplot}\r\n\\end{figure}";

            return initialOverleafBoxPlotPart;
        }


        private string GetLegendsForAlgos(List<string> algorithmNames)
        {
            return string.Join(",", algorithmNames);
        }

        private string GetLineGraphAverageRunningTimeWithSpreadedPreProccessingPoints(List<string> algorithms, List<AlgoDataSetResultApproved> algoDataSetResultApproved)
        {
            var extraCalculation = 0;
            var stringToReturn = "";
            var count = 1;

            while (extraCalculation < 3)
            {
                double SA_Long = 0;
                double AH_Long = 0;

                var roundResults = new string[algorithms.Count];
                for (int i = 0; i < algorithms.Count; i++)
                {
                    var roundAlgoResults = algoDataSetResultApproved.Where(n => n.AlgorithmName == algorithms[i]);

                    if (IsPreProccessingAlgo(algorithms[i]))
                    {
                        var average_Long = ((roundAlgoResults.Select(s => s.Miliseconds).Average() + roundAlgoResults.Select(s => s.Miliseconds_Preproccesing).ToList()[0]) / count);

                        if (i == 0)
                        {
                            SA_Long = average_Long;
                        }

                        roundResults[i] = average_Long.ToString();

                    }
                    else
                    {
                        AH_Long = roundAlgoResults.Select(s => s.Miliseconds).Average();
                        roundResults[i] = AH_Long.ToString();
                    }
                }

                if (SA_Long < AH_Long){
                    extraCalculation++;
                }

                stringToReturn += (count).ToString() + " " + string.Join(" ", roundResults) + "\r\n";

                count = count * 2;
            }

            return stringToReturn + "\r\n}\\lineGraphMagnifyData";
        }

        private bool IsPreProccessingAlgo(string algoName)
        {
            var noPreProccessingTimeAlgos = new List<string>()
            {
                #region AC_GraphSearch_Filters
                AlgoNameEnum.AC_Automaton_VLG.GetDescription(),
                AlgoNameEnum.AC_Automaton_BitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BackBitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Graph_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Graph_Search.GetDescription(),
                #endregion

                #region AC_Scan_Filters
                AlgoNameEnum.AC_Automaton_VLG_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BitVector_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BackBitVector_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Intersect_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Intersect_Search.GetDescription(),
                #endregion

                #region AC_Scan_Binary_Search_Filters
                AlgoNameEnum.AC_Automaton_VLG_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_BackBitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Binary_Search.GetDescription(),
                AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Binary_Search.GetDescription(),
                #endregion
            };

            return !noPreProccessingTimeAlgos.Contains(algoName);
        }

        private string GetLineGraphWithAmmortizedRunningTimeAfterConsideringPreProccessingPoints(List<string> algorithms, List<AlgoDataSetResultApproved> algoDataSetResultApproved)
        {
            var extraCalculation = 0;
            var stringToReturn = "";
            var count = 1;

            var amortizedValues = new List<List<double>>();
            var runningTimeList = new List<double>();

            var firstRound = new string[algorithms.Count];
            var secondRound = new string[algorithms.Count];

            for (int i = 0; i < algorithms.Count; i++)
            {
                amortizedValues.Add(new List<double>());
                var roundSet = algoDataSetResultApproved.Where(n => n.AlgorithmName == algorithms[i]).ToList();

                var preProccessing = (roundSet[0].Miliseconds_Preproccesing);
                var runningTime = roundSet.Select(s => s.Miliseconds).Average();

                amortizedValues[i].Add(preProccessing + runningTime);
                runningTimeList.Add(runningTime);

                firstRound[i] = "0";
                secondRound[i] = (preProccessing + runningTime).ToString();
            }

            stringToReturn += "0 " + string.Join(" ", firstRound) + "\r\n";
            stringToReturn += "1 " + string.Join(" ", secondRound) + "\r\n";


            while (extraCalculation < 2)
            {
                var roundResults = new string[algorithms.Count];
                for (int i = 0; i < algorithms.Count; i++)
                {
                    var runningTimeOfAlgo = runningTimeList[i] * (count / 2);
                    var combinedWithNextRound = amortizedValues[i].Last() + runningTimeOfAlgo;
                    roundResults[i] = combinedWithNextRound.ToString();

                    amortizedValues[i].Add(combinedWithNextRound);
                }

                if (amortizedValues[0].Last() < amortizedValues[1].Last())
                {
                    extraCalculation++;
                }

                stringToReturn += (count).ToString() + " " + string.Join(" ", roundResults) + "\r\n";

                count = count * 2;
            }

            return stringToReturn + "\r\n}\\lineGraphMagnifyData";
        }

        private string GetNamesString(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n must be a positive integer.");
            }

            string result = "x";
            for (int i = 1; i <= n; i++)
            {
                result += $" {{Name {i}}}";
            }

            return result + "\r\n";
        }

        private string GetDataSetName(Guid dataSetGuid)
        {
            return _databaseService.GetDataSetName(dataSetGuid);
        }

        private long GetPercentile(List<long> data, double percentile)
        {
            data.Sort();
            int index = (int)Math.Ceiling(data.Count * percentile) - 1;
            return data[index];
        }

        public string GetCommaSeparatedInts(List<string> strings, List<int> pattenLengthsCount, bool breakUpPatternLengthResults )
        {
            var newStrings = new List<string>();

            for (int i = 0; i < strings.Count; i++)
            {
                for (int j = 0; j < pattenLengthsCount.Count; j++)
                {
                    newStrings.Add( $"{strings[i]} ({pattenLengthsCount[j].ToString()})");
                }
            }

            return breakUpPatternLengthResults ? string.Join(",", newStrings) : string.Join(",", strings);
        }

        public string GetCommaSeparatedInts(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n must be a positive integer.");
            }

            string result = "1";
            for (int i = 2; i <= n; i++)
            {
                result += "," + i.ToString();
            }

            return result;
        }
    }

    public class BoxPlotModel {
        public long lowerWhisker { get; set; }
        public long upperWhisker { get; set; }
        public long lowerQuartile { get; set; }
        public long median { get; set; }
        public long upperQuartile { get; set; }
    }
}
