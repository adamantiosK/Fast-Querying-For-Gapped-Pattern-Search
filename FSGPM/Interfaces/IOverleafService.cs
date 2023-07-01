namespace FSGPM.Interfaces
{
    public interface IOverleafService
    {
        public string CreateNewBoxPlotWithResultData(Guid DataResultGuid, bool breakUpPatternLengthResults);
        public string CreateNewPreProccessingOverTakingLineGraphForDataSetResult(Guid DataSetGuid, bool AverageRunningTimeGraphTrueAmmortizedFalse);
    }
}
