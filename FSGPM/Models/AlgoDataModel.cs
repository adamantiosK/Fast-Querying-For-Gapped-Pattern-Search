namespace FSGPM.Models
{
    public class AlgoDataModel
    {
        public Guid ReportProgressGuid { get; set; }
        //public Guid DataSetGuid { get; set; }
        public string AlgorithmProgress { get; set; }
        public List<ConstraintModel>? ConstraintModels { get; set; }
        public List<AlgoData>? AvailableAlgoSets { get; set; }
    }
}
