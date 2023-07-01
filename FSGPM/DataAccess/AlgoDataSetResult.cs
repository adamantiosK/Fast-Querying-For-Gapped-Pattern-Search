using System.ComponentModel.DataAnnotations;

namespace FSGPM.DataAccess
{
    public class AlgoDataSetResult
    {
        [Key]
        public Guid AlgoResultGuid { get; set; }
        public Guid DS_Result_Guid { get; set; }
        public string? AlgorithmName { get; set; }
        public int K_Selection { get; set; }
        public Guid? DataSetGuid { get; set; }
        public Guid ConstraintCountGuid { get; set; }
        public int PatternLength { get; set; }
        public long Miliseconds { get; set; }
        public long Miliseconds_Preproccesing { get; set; }
        public long Miliseconds_AverageRun { get; set; }

        public int PatternsFound { get; set; }

    }
}
