using System.ComponentModel.DataAnnotations;

namespace FSGPM.DataAccess
{
    public class ConstraintCount
    {
        [Key]
        public Guid ConstraintCountGuid { get; set; }
        public int ConstraintMin { get; set; }
        public int ConstraintMax { get; set; }
    }
}
