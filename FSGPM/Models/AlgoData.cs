namespace FSGPM.Models
{
    public class AlgoData
    {
        public Guid DS_Result_Guid { get; set; }
        public Guid DataSetGuid { get; set; }
        public string? TextT { get; set; }
        public List<string>? Patterns { get; set; }
        public int PatternLength { get; set; }
        public int K_Selection { get; set; }

    }
}
