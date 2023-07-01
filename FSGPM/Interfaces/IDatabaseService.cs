using FSGPM.DataAccess;
using FSGPM.Enum;
using FSGPM.Models;
using static System.Net.Mime.MediaTypeNames;

namespace FSGPM.Interfaces
{
    public interface IDatabaseService
    {
        public Guid GetNewReportProgressIdentifier();
        public ReportStatusModel GetReportProgressFromIdentifier(Guid reportProgressIdentifier);
        public void UpdateReportProgressStatus(Guid reportProgressIdentifier, ReportStatusEnum reportEnum, string progressStatus);
        public Guid InsertNewDataSet(string? textT, string? DataSetName);
        public void CreateConstraintWithConstraintCounts(Guid dataSetGuid);
        public void CreateGeneratedPatterns(Guid dataSetGuid, DataSetWithMostOccouringStrings dataModel);
        public List<Guid> GetAllDistinctAvailableDataSetsGuids();
        public List<AlgorithmDataSets> GetAllDistinctDataSets(List<Guid> distinctGuids);
        public List<ConstraintModel> GetAllConstraintModels();
        public void SaveResultToDatabase(List<AlgoDataSetResult> results);
        public string GetGuidFromString(Guid dataSetGuid);
        public void UpdateTextInDataSet(Guid dataSetGuid, string text);
        public List<AlgoDataSetResultApproved> GetApprovedResultsForDataSet(Guid DataResultGuids);
        public string GetDataSetName(Guid dataSetGuid);
        public bool ApproveResultsFromResultGuid(Guid ResultGuid);
        public DataSet GetDataSetModelByGuid(Guid dataSetGuid);
        public void SaveCalculatedSuffixArrayResults(Guid DataSetGuid, int[] suffixArrayBuild, long elapsedTime);
        public (int[] suffixArrayBuild, long elapsedTime) GetSAandETbyDataSetGuid(Guid dataSetGuid);
    }
}
