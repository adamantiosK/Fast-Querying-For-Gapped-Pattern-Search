using System.ComponentModel;

namespace FSGPM.Enum
{
    public enum AlgoNameEnum
    {
        #region SA_Scan_Filters
        [Description("SA")]
        SA_Scan_VLG, 
        [Description("SA-BV")]
        SA_Scan_BitVector,
        [Description("SA-BBV")]
        SA_Scan_BackBitVector,
        [Description("SA-TC")]
        SA_Scan_TextChecking,
        [Description("SA-TCBV")]
        SA_Scan_TextChecking_BitVector,
        [Description("SA-TCBBV")]
        SA_Scan_TextChecking_BackBitVector,
        #endregion

        #region SA_Scan_Binary_Search_Filters
        [Description("SA-B")]
        SA_Scan_VLG_Binary_Search,
        [Description("SA-BV-B")]
        SA_Scan_BitVector_Binary_Search,
        [Description("SA-BBV-B")]
        SA_Scan_BackBitVector_Binary_Search,
        [Description("SA-TC-B")]
        SA_Scan_TextChecking_Binary_Search,
        [Description("SA-TCBV-B")]
        SA_Scan_TextChecking_BitVector_Binary_Search,
        [Description("SA-TCBBV-B")]
        SA_Scan_TextChecking_BackBitVector_Binary_Search,
        #endregion

        #region SA_Scan_Binary_Search_With_Pruning_Filters
        [Description("SA-BP")]
        SA_Scan_VLG_Binary_SearchWithPruning,
        [Description("SA-BV-BP")]
        SA_Scan_BitVector_Binary_SearchWithPruning,
        [Description("SA-BBV-BP")]
        SA_Scan_BackBitVector_Binary_SearchWithPruning,
        [Description("SA-TC-BP")]
        SA_Scan_TextChecking_Binary_SearchWithPruning,
        [Description("SA-TCBV-BP")]
        SA_Scan_TextChecking_BitVector_Binary_SearchWithPruning,
        [Description("SA-TCBBV-BP")]
        SA_Scan_TextChecking_BackBitVector_Binary_SearchWithPruning,
        #endregion

        #region SA_Scan_Graph_Search_Filters
        [Description("SA-G")]
        SA_Scan_Graph_Search,
        [Description("SA-BV-G")]
        SA_Scan_BitVector_Graph_Search,
        [Description("SA-BBV-G")]
        SA_Scan_BackBitVector_Graph_Search,
        [Description("SA-TC-G")]
        SA_Scan_TextChecking_Graph_Search,
        [Description("SA-TCBV-G")]
        SA_Scan_TextChecking_BitVector_Graph_Search,
        [Description("SA-TCBBV-G")]
        SA_Scan_TextChecking_BackBitVector_Graph_Search,
        #endregion

        #region AC_GraphSearch_Filters
        [Description("AC-G")]
        AC_Automaton_VLG,
        [Description("AC-BV-G")]
        AC_Automaton_BitVector_Graph_Search,
        [Description("AC-BBV-G")]
        AC_Automaton_BackBitVector_Graph_Search,
        [Description("AC-TC-G")]
        AC_Automaton_TextChecking_Graph_Search,
        [Description("AC-TCBV-G")]
        AC_Automaton_TextChecking_BitVector_Graph_Search,
        [Description("AC-TCBBV-G")]
        AC_Automaton_TextChecking_BackBitVector_Graph_Search,
        #endregion

        #region AC_Scan_Filters
        [Description("AC")]
        AC_Automaton_VLG_Intersect_Search,
        [Description("AC-BV")]
        AC_Automaton_BitVector_Intersect_Search,
        [Description("AC-BBV")]
        AC_Automaton_BackBitVector_Intersect_Search,
        [Description("AC-TC")]
        AC_Automaton_TextChecking_Intersect_Search,
        [Description("AC-TCBV")]
        AC_Automaton_TextChecking_BitVector_Intersect_Search,
        [Description("AC-TCBBV")]
        AC_Automaton_TextChecking_BackBitVector_Intersect_Search,
        #endregion

        #region AC_Scan_Binary_Search_Filters
        [Description("AC-B")]
        AC_Automaton_VLG_Binary_Search,
        [Description("AC-BV-B")]
        AC_Automaton_BitVector_Binary_Search,
        [Description("AC-BBV-B")]
        AC_Automaton_BackBitVector_Binary_Search,
        [Description("AC-TC-B")]
        AC_Automaton_TextChecking_Binary_Search,
        [Description("AC-TCBV-B")]
        AC_Automaton_TextChecking_BitVector_Binary_Search,
        [Description("AC-TCBBV-B")]
        AC_Automaton_TextChecking_BackBitVector_Binary_Search,
        #endregion

        #region AC_Scan_Binary_Search_With_Pruning_Filters
        [Description("AC-BP")]
        AC_Automaton_VLG_Binary_SearchWithPruning,
        [Description("AC-BV-BP")]
        AC_Automaton_BitVector_Binary_SearchWithPruning,
        [Description("AC-BBV-BP")]
        AC_Automaton_BackBitVector_Binary_SearchWithPruning,
        [Description("AC-TC-BP")]
        AC_Automaton_TextChecking_Binary_SearchWithPruning,
        [Description("AC-TCBV-BP")]
        AC_Automaton_TextChecking_BitVector_Binary_SearchWithPruning,
        [Description("AC-TCBBV-BP")]
        AC_Automaton_TextChecking_BackBitVector_Binary_SearchWithPruning,
        #endregion
    }
}
