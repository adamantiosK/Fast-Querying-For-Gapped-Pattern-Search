using FSGPM.Algo_Helper_Implementations;
using FSGPM.Interfaces;
using FSGPM.Models;
using System.Diagnostics;

namespace FSGPM.Services
{
    public class DataSetService : IDataSetService
    {
        private IDataSetRepository _dataSetRepository;

        public DataSetService(IDataSetRepository dataSetRepository)
        {
            _dataSetRepository= dataSetRepository;
        }

        public bool CreateSuffixArrayCalculationForDataSet(Guid DataSetGuid){
            if(!_dataSetRepository.IsDataSetCalculatedInDB(DataSetGuid)){
                var text = _dataSetRepository.GetDataSetTextByGuid(DataSetGuid).Replace("\n", "").Replace("\r", "").Replace("\n\r", "");

                Stopwatch overHeadStopWatch = new Stopwatch();
                overHeadStopWatch.Start();
                var suffixArray = SuffixArrayBuilder.PrefixDoublingSA(text);
                overHeadStopWatch.Stop();
                var elapsedTime = overHeadStopWatch.ElapsedMilliseconds;

                _dataSetRepository.SaveCalculatedSuffixArrayResults(DataSetGuid, suffixArray, elapsedTime);

                return true;
            }
            return false;
        }

        public bool ApproveResultsFromResultGuid(Guid ResultGuid)
        {
            return _dataSetRepository.ApproveResultsFromResultGuid(ResultGuid);
        }

        public bool CreateANewDataSetPatterns(Guid DataSetGuid)
        {
            var dataText = _dataSetRepository.GetDataSetTextByGuid(DataSetGuid).Replace("\n", "").Replace("\r", "").Replace("\n\r","");

            _dataSetRepository.SaveNewCreatedDataSet(new DataSetWithMostOccouringStrings()
            {
                DataSetGuid = DataSetGuid,
                TextT = dataText,
                MostOccouringStringLengthThree = GetTopNStrings(dataText ?? "", 3),
                MostOccouringStringLengthFive = GetTopNStrings(dataText ?? "", 5),
                MostOccouringStringLengthSeven = GetTopNStrings(dataText ?? "", 7)
            });

            return true;
        }
        public List<string> GetTopNStrings(string text, int length, int n = 100)
        {
            List<string> substrings = new List<string>();
            for (int i = 0; i <= text.Length - length; i++)
            {
                substrings.Add(text.Substring(i, length));
            }

            Dictionary<string, int> freqDict = new Dictionary<string, int>();
            foreach (string substring in substrings)
            {
                if (freqDict.ContainsKey(substring))
                {
                    freqDict[substring]++;
                }
                else
                {
                    freqDict[substring] = 1;
                }
            }

            var sortedDict = freqDict.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key);

            var topNSubstrings = sortedDict.Take(n).Select(kv => kv.Key).ToList();

            return topNSubstrings;
        }

    }
}
