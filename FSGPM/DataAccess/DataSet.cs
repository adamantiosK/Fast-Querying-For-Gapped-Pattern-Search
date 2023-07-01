using System.ComponentModel.DataAnnotations;

namespace FSGPM.DataAccess
{
    public class DataSet
    {
        [Key]
        public Guid DataSetGuid { get; set; }
        public string Text { get; set; }
        public string DataSetName { get; set; }
        public bool AvailableToRun { get; set; }
        public bool SACalculated { get; set; }
        public long OverHeadMsCalculated { get; set; }
    }
}
