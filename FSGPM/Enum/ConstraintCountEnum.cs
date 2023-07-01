using System.ComponentModel;

namespace FSGPM.Enum
{
    public enum ConstraintCountEnum
    {
        [Description("Cs")]
        SmallConstraintGap,
        [Description("Cm")]
        MediumConstraintGap,
        [Description("Cl")]
        LargeConstraintGap
    }
}