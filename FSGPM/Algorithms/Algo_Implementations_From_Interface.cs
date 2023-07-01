using FSGPM.Algo_Helper_Implementations;
using FSGPM.DataAccess;
using FSGPM.Enum;
using FSGPM.Interfaces;
using FSGPM.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Diagnostics;
using System.Collections.Generic;

namespace FSGPM.Algorithms
{
    #region SA_Scan_Filters
    public class SA_Scan_VLG : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_VLG.GetDescription();

        public SA_Scan_VLG(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                SA_SCAN_Helper.FindOccourances, AlgorithmName, true);
        }
    }
    public class SA_Scan_BitVector : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BitVector.GetDescription();

        public SA_Scan_BitVector(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, true);
        }
    }
    public class SA_Scan_BackBitVector : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BackBitVector.GetDescription();

        public SA_Scan_BackBitVector(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking.GetDescription();

        public SA_Scan_TextChecking(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BitVector : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BitVector.GetDescription();

        public SA_Scan_TextChecking_BitVector(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BackBitVector : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BackBitVector.GetDescription();

        public SA_Scan_TextChecking_BackBitVector(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, true);
        }
    }
    #endregion

    #region SA_Scan_Binary_Search_Filters
    public class SA_Scan_VLG_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_VLG_Binary_Search.GetDescription();

        public SA_Scan_VLG_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, true);
        }
    }
    public class SA_Scan_BitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BitVector_Binary_Search.GetDescription();

        public SA_Scan_BitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, true);
        }
    }
    public class SA_Scan_BackBitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BackBitVector_Binary_Search.GetDescription();

        public SA_Scan_BackBitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_Binary_Search.GetDescription();

        public SA_Scan_TextChecking_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BitVector_Binary_Search.GetDescription();

        public SA_Scan_TextChecking_BitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BackBitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BackBitVector_Binary_Search.GetDescription();

        public SA_Scan_TextChecking_BackBitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, true);
        }
    }

    #endregion

    #region SA_Scan_Binary_Search_With_Pruning_Filters
    public class SA_Scan_VLG_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_VLG_Binary_SearchWithPruning.GetDescription();

        public SA_Scan_VLG_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, true);
        }
    }
    public class SA_Scan_BitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BitVector_Binary_SearchWithPruning.GetDescription();

        public SA_Scan_BitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, true);
        }
    }
    public class SA_Scan_BackBitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BackBitVector_Binary_SearchWithPruning.GetDescription();

        public SA_Scan_BackBitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_Binary_SearchWithPruning.GetDescription();

        public SA_Scan_TextChecking_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BitVector_Binary_SearchWithPruning.GetDescription();

        public SA_Scan_TextChecking_BitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BackBitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BackBitVector_Binary_SearchWithPruning.GetDescription();

        public SA_Scan_TextChecking_BackBitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, true);
        }
    }

    #endregion

    #region SA_Scan_Graph_Search_Filters
    public class SA_Scan_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_Graph_Search.GetDescription();

        public SA_Scan_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, true);
        }
    }
    public class SA_Scan_BitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BitVector_Graph_Search.GetDescription();

        public SA_Scan_BitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, true);
        }
    }
    public class SA_Scan_BackBitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_BackBitVector_Graph_Search.GetDescription();

        public SA_Scan_BackBitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_Graph_Search.GetDescription();

        public SA_Scan_TextChecking_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BitVector_Graph_Search.GetDescription();

        public SA_Scan_TextChecking_BitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, true);
        }
    }
    public class SA_Scan_TextChecking_BackBitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.SA_Scan_TextChecking_BackBitVector_Graph_Search.GetDescription();

        public SA_Scan_TextChecking_BackBitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                SA_SCAN_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, true);
        }
    }
    #endregion

    #region AC_GraphSearch_Filters
    public class AC_Automaton_VLG : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_VLG.GetDescription();

        public AC_Automaton_VLG(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BitVector_Graph_Search.GetDescription();

        public AC_Automaton_BitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BackBitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BackBitVector_Graph_Search.GetDescription();

        public AC_Automaton_BackBitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_Graph_Search.GetDescription();

        public AC_Automaton_TextChecking_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Graph_Search.GetDescription();

        public AC_Automaton_TextChecking_BitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BackBitVector_Graph_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Graph_Search.GetDescription();

        public AC_Automaton_TextChecking_BackBitVector_Graph_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                Aho_Corasick_Helper.FindOccourances_BlackBoxImplementation, AlgorithmName, false);
        }
    }
    #endregion

    #region AC_Scan_Filters
    public class AC_Automaton_VLG_Intersect_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_VLG_Intersect_Search.GetDescription();

        public AC_Automaton_VLG_Intersect_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                SA_SCAN_Helper.FindOccourances, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BitVector_Intersect_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BitVector_Intersect_Search.GetDescription();

        public AC_Automaton_BitVector_Intersect_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BackBitVector_Intersect_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BackBitVector_Intersect_Search.GetDescription();

        public AC_Automaton_BackBitVector_Intersect_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_Intersect_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_Intersect_Search.GetDescription();

        public AC_Automaton_TextChecking_Intersect_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BitVector_Intersect_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Intersect_Search.GetDescription();

        public AC_Automaton_TextChecking_BitVector_Intersect_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BackBitVector_Intersect_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Intersect_Search.GetDescription();

        public AC_Automaton_TextChecking_BackBitVector_Intersect_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourances, AlgorithmName, false);
        }
    }
    #endregion

    #region AC_Scan_Binary_Search_Filters
    public class AC_Automaton_VLG_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_VLG_Binary_Search.GetDescription();

        public AC_Automaton_VLG_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BitVector_Binary_Search.GetDescription();

        public AC_Automaton_BitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BackBitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BackBitVector_Binary_Search.GetDescription();

        public AC_Automaton_BackBitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_Binary_Search.GetDescription();

        public AC_Automaton_TextChecking_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Binary_Search.GetDescription();

        public AC_Automaton_TextChecking_BitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BackBitVector_Binary_Search : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Binary_Search.GetDescription();

        public AC_Automaton_TextChecking_BackBitVector_Binary_Search(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearch, AlgorithmName, false);
        }
    }
    #endregion

    #region AC_Scan_Binary_Search_With_Pruning_Filters
    public class AC_Automaton_VLG_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_VLG_Binary_SearchWithPruning.GetDescription();

        public AC_Automaton_VLG_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>(), // no Filter Methods
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BitVector_Binary_SearchWithPruning.GetDescription();

        public AC_Automaton_BitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, false);
        }
    }
    public class AC_Automaton_BackBitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_BackBitVector_Binary_SearchWithPruning.GetDescription();

        public AC_Automaton_BackBitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_Binary_SearchWithPruning.GetDescription();

        public AC_Automaton_TextChecking_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BitVector_Binary_SearchWithPruning.GetDescription();

        public AC_Automaton_TextChecking_BitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilter },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, false);
        }
    }
    public class AC_Automaton_TextChecking_BackBitVector_Binary_SearchWithPruning : IFS_GPM_Implementation
    {
        private readonly ISA_Scan_Base_Context _algoBaseContext;
        public string AlgorithmName { get; } = AlgoNameEnum.AC_Automaton_TextChecking_BackBitVector_Binary_SearchWithPruning.GetDescription();

        public AC_Automaton_TextChecking_BackBitVector_Binary_SearchWithPruning(ISA_Scan_Base_Context algoBaseContext)
        {
            _algoBaseContext = algoBaseContext;
        }

        public void RunAlgoWithDataSetsAndSaveResults(AlgoDataModel algoModel)
        {
            RunClassSpecification(algoModel);
        }

        public List<AlgoDataSetResult> RunAlgoWithDataSetsAndSaveAndReturnResults(AlgoDataModel algoModel)
        {
            return RunClassSpecification(algoModel);
        }

        private List<AlgoDataSetResult> RunClassSpecification(AlgoDataModel algoModel)
        {
            return _algoBaseContext.RunSaScanShell(
                algoModel,
                Aho_Corasick_Helper.GetModelListFromBuilder,
                new List<Func<FilterHelperModel, List<SA_Scan_Model>>>() { Filters_Helper.ApplyDirectTextCheckingFilter, Filters_Helper.ApplyBitVectorFilterWithBackwardFiltering },
                SA_SCAN_Helper.FindOccourancesBinaySearchWithPruning, AlgorithmName, false);
        }
    }
    #endregion
}