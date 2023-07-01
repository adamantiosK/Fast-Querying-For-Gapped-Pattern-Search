using FSGPM.Enum;
using FSGPM.Models;

namespace FSGPM.Interfaces
{
    public interface IReportStatusService
    {
        public Guid GetNewReportProgressIdentifier();
        public ReportStatusModel GetReportProgressFromIdentifier(Guid reportStatusGuid);
        public void UpdateReportProgressStatus(Guid reportProgressIdentifier, ReportStatusEnum reportEnum, string progressStatus);
    }
}
