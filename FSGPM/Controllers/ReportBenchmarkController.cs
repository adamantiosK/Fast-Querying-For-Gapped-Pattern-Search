using FSGPM.Interfaces;
using FSGPM.Models;
using Microsoft.AspNetCore.Mvc;

namespace FSGPM.Controllers
{
    [ApiController]
    [Route("api/BenchMarkController")]
    public class ReportBenchmarkController : ControllerBase
    {
        private IReportStatusService _reportStatusService;
        private IBenchmarkService _benchmarkService;
        private IDataSetService _dataSetService;
        private IStatService _statService;
        private IOverleafService _overleafService;

        public ReportBenchmarkController(IOverleafService overleafService, IReportStatusService reportStatusService, IBenchmarkService benchmarkService, IDataSetService dataSetService, IStatService statService)
        {
            _reportStatusService = reportStatusService;
            _benchmarkService = benchmarkService;
            _dataSetService = dataSetService;
            _statService = statService;
            _overleafService = overleafService;
        }

        [HttpGet("NewReportStatusGuid", Name = "GetNewReportProgressIdentifier")]
        public IActionResult GetNewReportStatusGuid()
        {
            return Ok(_reportStatusService.GetNewReportProgressIdentifier());
        }

        [HttpGet("GetReportProgressFromIdentifier/{guid}", Name = "GetReportProgressFromIdentifier")]
        public IActionResult GetReportStatus(Guid guid)
        {
            return Ok(_reportStatusService.GetReportProgressFromIdentifier(guid));
        }


        [HttpGet("GetReportProgressFromIdentifier/Results/{guid}/{booleanValue}", Name = "GetReportResultsFromIdentifier")]
        public IActionResult GetReportResults(Guid guid, bool booleanValue)
        {
            return Ok(_statService.GetBenchMarksByGuid(guid, booleanValue));
        }


        [HttpGet("GetOldBenchMarks", Name = "GetOldBenchMarks")]
        public IActionResult GetOldBenchMarks()
        {
            return Ok(_statService.GetOldBenchMarks());
        }


        [HttpPost("RunBenchMarksForAvailableAlgorithms/{guid}", Name = "RunBenchMarksForAvailableAlgorithms")]
        public IActionResult RunBenchmarks(Guid guid)
        {
            return Ok(_benchmarkService.RunBenchMarksForAvailableAlgorithms(guid));
        }

        [HttpPost("RunBenchMarksForAvailableAlgorithms/newDataSet", Name = "CreateNewDataSetWithConstraint")]
        public IActionResult CreateNewDataSetWithConstraint(Guid DataSetGuid)
        {
            return Ok(_dataSetService.CreateANewDataSetPatterns(DataSetGuid));
        }

        [HttpPost("AlgorithmDataPreProccessing/newSuffixArraySet", Name = "CreateSuffixArrayCalculationForDataSet")]
        public IActionResult CreateSuffixArrayCalculationForDataSet(Guid DataSetGuid) {
            return Ok(_dataSetService.CreateSuffixArrayCalculationForDataSet(DataSetGuid));
        }


        [HttpPost("OverleafGraphs/BoxPlot", Name = "CreateNewBoxPlotFromResultsFromDataSet")]
        public IActionResult CreateNewBoxPlotWithResultData(Guid DataSetGuid, bool breakUpPatternLengthResults)
        {
            return Ok(_overleafService.CreateNewBoxPlotWithResultData(DataSetGuid, breakUpPatternLengthResults));
        }

        [HttpGet("OverleafGraphs/LineGraph", Name = "CreateNewLineGraphFromResultsFromDataSet")]
        public IActionResult CreateNewLineGraphWithResultData(Guid DataSetGuid, bool graphBool)
        {
            return Ok(_overleafService.CreateNewPreProccessingOverTakingLineGraphForDataSetResult(DataSetGuid, graphBool));
        }


        [HttpPost("Results/Approve", Name = "ApproveResultsFromGuid")]
        public IActionResult ApproveResultsFromResultGuid(Guid ResultGuid)
        {
            return Ok(_dataSetService.ApproveResultsFromResultGuid(ResultGuid));
        }

    }
}
