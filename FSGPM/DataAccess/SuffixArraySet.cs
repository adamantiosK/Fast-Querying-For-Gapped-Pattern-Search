using System.ComponentModel.DataAnnotations;

public class SuffixArraySet {
    [Key]
    public Guid SuffixArrayGuid{ get; set; }
    public Guid DataSetGuid { get; set; }
    public string SuffixArray { get; set; }
}