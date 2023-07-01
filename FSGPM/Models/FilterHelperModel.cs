namespace FSGPM.Models
{
    public class FilterHelperModel
    {
        public List<SA_Scan_Model> intervalModels { get; set; }
        public int[] SA { get; set; }
        public string T { get; set; }
        public int min_gap { get; set; }
        public int max_gap { get; set; }
        public List<string> patterns { get; set; }
    }
}
