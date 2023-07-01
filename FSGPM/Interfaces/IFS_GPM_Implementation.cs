using FSGPM.DataAccess;
using FSGPM.Models;

namespace FSGPM.Interfaces
{
    public interface IFS_GPM_Implementation
    {
        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel);
        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel);

    }
}
