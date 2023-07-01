using FSGPM.Algorithms;
using FSGPM.DataAccess;
using FSGPM.Enum;
using FSGPM.Interfaces;
using FSGPM.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FSGPM.Services
{
    public class BenchmarkService : IBenchmarkService
    {
        private IReportStatusService _reportStatusService;
        private IDataSetRepository _dataSetRepsitory;
        private readonly List<IFS_GPM_Implementation> _algorithms;

        public BenchmarkService(IReportStatusService reportStatusService, IDataSetRepository dataSetRepsitory, IServiceProvider serviceProvider)
        {
            _reportStatusService = reportStatusService;
            _dataSetRepsitory = dataSetRepsitory;
            this._algorithms = serviceProvider.GetServices<IFS_GPM_Implementation>().ToList();
        }

        public bool RunBenchMarksForAvailableAlgorithms(Guid reportProgressGuid)
        {
            _reportStatusService.UpdateReportProgressStatus(reportProgressGuid, ReportStatusEnum.Loading, ReportStatusEnum.Loading.GetDescription());

            var allAvailableAlgoData = _dataSetRepsitory.LoadAllAvailableDataSets();

            _reportStatusService.UpdateReportProgressStatus(reportProgressGuid, ReportStatusEnum.InProgress, "Algorithm run Initialized");

            RunAllAlgorithmsAgainstSelectedDataSets(reportProgressGuid, allAvailableAlgoData);


            _reportStatusService.UpdateReportProgressStatus(reportProgressGuid, ReportStatusEnum.Completed, ReportStatusEnum.Completed.GetDescription());

            return true;
        }

        private void RunAllAlgorithmsAgainstSelectedDataSets(Guid ReportProgressGuid, List<AlgoData> availableAlgoSets) 
        {
            var constraints = _dataSetRepsitory.GetAllConstraintSets();

            foreach ((IFS_GPM_Implementation algorithm, int index) in _algorithms.Select((algo, i) => (algo, i)))
            {
                RunAlgoForSelectedImplementation(algorithm, new AlgoDataModel(){
                    ReportProgressGuid= ReportProgressGuid,
                    //DataSetGuid = availableAlgoSets[0].DataSetGuid == null? Guid.Empty: (Guid) availableAlgoSets[0].DataSetGuid,
                    AlgorithmProgress = string.Format("{0}/{1}",index + 1, _algorithms.Count),
                    AvailableAlgoSets = availableAlgoSets,
                    ConstraintModels = constraints
                });
            }
        } 

        public void RunAlgoForSelectedImplementation(IFS_GPM_Implementation algorithms, AlgoDataModel algoModel)
        {
            // Get the type of the instance
            Type type = algorithms.GetType();

            // Get the MethodInfo for the MyMethod method
            MethodInfo method = type.GetMethod("RunAlgoWithDataSetsAndSaveResults");

            // Invoke the MyMethod method on the instance
            method.Invoke(algorithms, new object[] { algoModel });
        }
    }
}
