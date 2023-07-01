using System.ComponentModel.DataAnnotations;

namespace FSGPM.DataAccess
{
    public class Pattern
    {
        [Key]
        public Guid PatternGuid { get; set; }
        public Guid DataSetGuid { get; set; }
        public string? PatternText { get; set; }
        public bool DefaultPatternLength { get; set; }

    }
}
