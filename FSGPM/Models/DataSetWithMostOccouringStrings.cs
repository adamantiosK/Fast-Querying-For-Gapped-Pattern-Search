namespace FSGPM.Models
{
    public class DataSetWithMostOccouringStrings
    {

        public Guid DataSetGuid { get; set; }
        public string TextT { get; set; }   
        public List<string>? MostOccouringStringLengthThree { get; set; }
        public List<string>? MostOccouringStringLengthFive { get; set; }
        public List<string>? MostOccouringStringLengthSeven { get; set; }
    }
}
