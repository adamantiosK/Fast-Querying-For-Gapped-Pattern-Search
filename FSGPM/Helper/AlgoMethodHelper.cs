using FSGPM.Enum;
using FSGPM.Models;
using System.ComponentModel;
using System.Reflection;

public static class AlgoMethodHelper
{
    public static List<AlgoData> UnPackAllDictionaryValuesToAlgoData(List<AlgorithmDataSets> availableDataSets)
    {
        var algoDataList = new List<AlgoData>();

        foreach (var algoDataSet in availableDataSets)
        {
            algoDataList.AddRange(UnPackDictionaryValuesToAlgoData(algoDataSet));
        }
        return algoDataList;
    }

    private static List<AlgoData> UnPackDictionaryValuesToAlgoData(AlgorithmDataSets algoDataSet)
    {
        var algoDataList = new List<AlgoData>();

        foreach (var kvp in algoDataSet.TwoDimensionalDictionaryLengthPatternCount)
        {
            var l_k = kvp.Key;
            var pc_k_value = kvp.Value;

            foreach (var innerKvp in pc_k_value)
            {
                var pc_k = innerKvp.Key;
                List<string> value = innerKvp.Value;

                algoDataList.Add(new AlgoData()
                {
                    DataSetGuid = algoDataSet.DataSetGuid,
                    TextT = algoDataSet.TextT,
                    PatternLength = pc_k,
                    K_Selection = l_k,
                    Patterns = value

                });
            }
        }
        return algoDataList;
    }
}
