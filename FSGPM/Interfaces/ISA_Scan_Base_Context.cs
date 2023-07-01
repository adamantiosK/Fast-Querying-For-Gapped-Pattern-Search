using FSGPM.DataAccess;
using FSGPM.Models;

namespace FSGPM.Interfaces
{
    public interface ISA_Scan_Base_Context
    {
        public List<AlgoDataSetResult> RunSaScanShell(AlgoDataModel algoModel, 
            Func<List<string>, int[], string, List<SA_Scan_Model>> getIntervalModel,
            List<Func<FilterHelperModel, List<SA_Scan_Model>>> filterMethods,
            Func<List<SA_Scan_Model>, int, int, int, List<List<int>>> findOccurrences,
            string _AlgorithmName, bool preProcessSuffixArray);
    }
}
