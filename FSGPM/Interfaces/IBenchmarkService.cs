namespace FSGPM.Interfaces
{
    public interface IBenchmarkService
    {
        public bool RunBenchMarksForAvailableAlgorithms(Guid reportProgressGuid);
    }
}
