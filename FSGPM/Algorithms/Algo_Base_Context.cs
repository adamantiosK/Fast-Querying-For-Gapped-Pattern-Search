using FSGPM.Algo_Helper_Implementations;
using FSGPM.DataAccess;
using FSGPM.Enum;
using FSGPM.Interfaces;
using FSGPM.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace FSGPM.Algorithms
{
    public class Algo_Base_Context : ISA_Scan_Base_Context
    {
        private IDatabaseService _databaseService;
        private IReportStatusService _reportStatusService;

        public Algo_Base_Context(IDatabaseService databaseService, IReportStatusService reportStatusService)
        {
            _databaseService = databaseService;
            _reportStatusService = reportStatusService;
        }

        public List<AlgoDataSetResult> RunSaScanShell(
            AlgoDataModel algoModel,
            Func<List<string>, int[], string, List<SA_Scan_Model>> getIntervalModel,
            List<Func<FilterHelperModel, List<SA_Scan_Model>>> filterMethods,
            Func<List<SA_Scan_Model>, int, int, int, List<List<int>>> findOccurrences,
            string _AlgorithmName, bool preProcessSuffixArray)
        {
            var resultList = new List<AlgoDataSetResult>();

            foreach ((var algoSet, int algoSetIndex) in algoModel.AvailableAlgoSets.Select((set, i) => (set, i)))
            {
                var SA_Archieve_Singleton_Instance = SA_Archieve_Singleton.Instance;
                int[] suffixArray = new int[0];
                long elapsedTimeOverheadMs = 0;

                if (preProcessSuffixArray)
                {
                    if (SA_Archieve_Singleton_Instance.HasSuffixArrayBeenCalculated(algoSet.DataSetGuid))
                    {
                        (suffixArray, elapsedTimeOverheadMs) = SA_Archieve_Singleton_Instance.Get_SA_From_DataSetGuid(algoSet.DataSetGuid);
                    }
                    else
                    {
                        _reportStatusService.UpdateReportProgressStatus(algoModel.ReportProgressGuid, ReportStatusEnum.InProgress, "Suffix Array Build ");

                        if (_databaseService.GetDataSetModelByGuid(algoSet.DataSetGuid).SACalculated)
                        {
                            (suffixArray, elapsedTimeOverheadMs) = _databaseService.GetSAandETbyDataSetGuid(algoSet.DataSetGuid);
                        }
                        else
                        {
                            Stopwatch overheadStopWatch = new Stopwatch();
                            overheadStopWatch.Start();
                            suffixArray = ExternalImportedCodeFunctions.GetSuffixFromExternalCPlusPlusImplementation(algoModel.AvailableAlgoSets[0].TextT ?? string.Empty);
                            overheadStopWatch.Stop();
                            elapsedTimeOverheadMs = overheadStopWatch.ElapsedMilliseconds;
                        }

                        SA_Archieve_Singleton_Instance.AddSuffixArrayCalculationsToDictionary(algoSet.DataSetGuid, suffixArray, elapsedTimeOverheadMs);
                    }
                }

                foreach ((var constraint, int constraintIndex) in algoModel.ConstraintModels.Select((c, i) => (c, i)))
                {
                    _reportStatusService.UpdateReportProgressStatus(algoModel.ReportProgressGuid, ReportStatusEnum.InProgress,
                        string.Format("In Progress ({0}/{1} Data Sets, {2}/{3} Constraints, {4} Algorithms )",
                        algoSetIndex + 1, algoModel.AvailableAlgoSets.Count, constraintIndex + 1, algoModel.ConstraintModels.Count, algoModel.AlgorithmProgress));

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    var results = SA_Scan(getIntervalModel, filterMethods, findOccurrences, algoSet.Patterns ?? new List<string>(), constraint.ConstraintMin, constraint.ConstraintMax, suffixArray, algoSet.TextT ?? string.Empty);

                    stopwatch.Stop();
                    long elapsedTimeMs = stopwatch.ElapsedMilliseconds;

                    resultList.Add(new AlgoDataSetResult()
                    {
                        AlgoResultGuid = Guid.NewGuid(),
                        DS_Result_Guid = algoModel.ReportProgressGuid,
                        AlgorithmName = _AlgorithmName,
                        K_Selection = algoSet.K_Selection,
                        DataSetGuid = algoSet.DataSetGuid,
                        ConstraintCountGuid = constraint.ConstraintCountGuid,
                        PatternLength = algoSet.PatternLength,
                        Miliseconds = elapsedTimeMs,
                        Miliseconds_Preproccesing = elapsedTimeOverheadMs,
                        Miliseconds_AverageRun = preProcessSuffixArray ? 
                              elapsedTimeMs + ( elapsedTimeOverheadMs / (algoModel.AvailableAlgoSets.Count / algoModel.AvailableAlgoSets.Select(s => s.DataSetGuid).Distinct().Count())) :
                               elapsedTimeMs,
                        PatternsFound = results.Count

                    });
                }
            }

            _databaseService.SaveResultToDatabase(resultList);
            return resultList;
        }

        private List<List<int>> SA_Scan(Func<List<string>, int[], string, List<SA_Scan_Model>> getIntervalModel,
        List<Func<FilterHelperModel, List<SA_Scan_Model>>> filterMethods,
        Func<List<SA_Scan_Model>, int, int, int, List<List<int>>> findOccurrences,
        List<string> patterns, int min_gap, int max_gap, int[] SA, string T)
        {
            var intervalModel = getIntervalModel(patterns, SA, T);

            foreach (var filterMethod in filterMethods)
            {
                intervalModel = filterMethod(new FilterHelperModel()
                {
                    intervalModels = intervalModel,
                    SA = SA,
                    T = T,
                    min_gap = min_gap,
                    max_gap = max_gap,
                    patterns = patterns
                });
            }

            return findOccurrences(intervalModel,patterns[0].Length, min_gap, max_gap);
        }
    }
}
