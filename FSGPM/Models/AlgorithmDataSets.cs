namespace FSGPM.Models
{
    public class AlgorithmDataSets
    {
        public Guid DataSetGuid { get; set; }
        public string? TextT { get; set; }
        public Dictionary<int,Dictionary<int,List<string>>>? TwoDimensionalDictionaryLengthPatternCount { get; set; }
    }
}
