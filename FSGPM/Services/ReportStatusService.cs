using FSGPM.DataAccess;
using FSGPM.Enum;
using FSGPM.Interfaces;
using FSGPM.Models;

namespace FSGPM.Services
{
    public class ReportStatusService : IReportStatusService
    {

        private IDatabaseService _databaseService;

        public ReportStatusService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public Guid GetNewReportProgressIdentifier()
        {
            return _databaseService.GetNewReportProgressIdentifier();
        }

        public ReportStatusModel GetReportProgressFromIdentifier(Guid reportStatusGuid)
        {
            return _databaseService.GetReportProgressFromIdentifier(reportStatusGuid);
        }

        public void UpdateReportProgressStatus(Guid reportProgressIdentifier, ReportStatusEnum reportEnum, string progressStatus)
        {
            _databaseService.UpdateReportProgressStatus(reportProgressIdentifier, reportEnum, progressStatus);
        }
    }
}
