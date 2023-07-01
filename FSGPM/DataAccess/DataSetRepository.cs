using FSGPM.Interfaces;
using FSGPM.Models;
using static System.Net.Mime.MediaTypeNames;

namespace FSGPM.DataAccess
{
    public class DataSetRepository : IDataSetRepository
    {
        private IDatabaseService _databaseService;

        public DataSetRepository(IDatabaseService databaseService) 
        {
            _databaseService = databaseService;
        }

        public bool ApproveResultsFromResultGuid(Guid ResultGuid)
        {
            return _databaseService.ApproveResultsFromResultGuid(ResultGuid);
        }

        public List<ConstraintModel> GetAllConstraintSets()
        {
            return _databaseService.GetAllConstraintModels();
        }

        public string GetDataSetTextByGuid(Guid dataSetGuid)
        {
            return _databaseService.GetGuidFromString(dataSetGuid);
        }

        public bool IsDataSetCalculatedInDB(Guid DataSetGuid)
        {
            return _databaseService.GetDataSetModelByGuid(DataSetGuid).SACalculated;
        }

        public List<AlgoData> LoadAllAvailableDataSets()
        {
            return AlgoMethodHelper.UnPackAllDictionaryValuesToAlgoData(
                _databaseService.GetAllDistinctDataSets(
                    _databaseService.GetAllDistinctAvailableDataSetsGuids())
                );
        }

        public void SaveCalculatedSuffixArrayResults(Guid DataSetGuid, int[] suffixArrayBuild, long elapsedTime)
        {
            _databaseService.SaveCalculatedSuffixArrayResults(DataSetGuid, suffixArrayBuild, elapsedTime);
        }

        public bool SaveNewCreatedDataSet(DataSetWithMostOccouringStrings dataModel)
        {
            _databaseService.UpdateTextInDataSet(dataModel.DataSetGuid, dataModel.TextT);

            _databaseService.CreateConstraintWithConstraintCounts((Guid)dataModel.DataSetGuid);

            _databaseService.CreateGeneratedPatterns((Guid)dataModel.DataSetGuid, dataModel);

            return true;
        }


    }
}
