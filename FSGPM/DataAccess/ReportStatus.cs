using System.ComponentModel.DataAnnotations;

namespace FSGPM.DataAccess
{
    public class ReportStatus
    {
        [Key]
        public Guid StatusGuid { get; set; }
        public string? ProgressStatus { get; set; }
        public bool? ReportCompleted { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
