using FSGPM.Algo_Helper_Implementations;
using FSGPM.DataAccess;
using FSGPM.Models;

namespace FSGPM.Interfaces
{
    public interface IDataSetRepository
    {
        public bool SaveNewCreatedDataSet(DataSetWithMostOccouringStrings dataModel);
        public List<AlgoData> LoadAllAvailableDataSets();

        public List<ConstraintModel> GetAllConstraintSets();

        public string GetDataSetTextByGuid(Guid dataSetGuid);

        public bool ApproveResultsFromResultGuid(Guid ResultGuid);
        public bool IsDataSetCalculatedInDB(Guid DataSetGuid);
        public void SaveCalculatedSuffixArrayResults(Guid DataSetGuid, int[] suffixArrayBuild, long elapsedTime);
    }
}
