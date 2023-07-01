using System.ComponentModel;

namespace FSGPM.Enum
{
    public enum ReportStatusEnum
    {
        [Description("Report Progress Initialized")]
        Created,
        [Description("Algorithms & Data are being prepared.")]
        Loading,
        [Description("In Progress ({0}/{1} Data Sets, {2}/{3} Algo Sets, {4}/{5} Constraints )")]
        InProgress,
        [Description("Completed")]
        Completed
    }
}