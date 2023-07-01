using FSGPM.Models;

namespace FSGPM.Interfaces
{
    public interface IDataSetService
    {
        public bool CreateANewDataSetPatterns(Guid DataSetGuid);
        public bool ApproveResultsFromResultGuid(Guid ResultGuid);
        public bool CreateSuffixArrayCalculationForDataSet(Guid DataSetGuid);
    }
}
