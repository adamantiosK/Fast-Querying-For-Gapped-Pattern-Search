using System.ComponentModel.DataAnnotations;

namespace FSGPM.DataAccess
{
    public class Constraint
    {
        [Key]
        public Guid ConstraintGuid { get; set; }
        public Guid DataSetGuid { get; set; }
        public Guid ConstraintCountGuid { get; set; }   
        public bool IsDefault { get; set; }
    }
}
