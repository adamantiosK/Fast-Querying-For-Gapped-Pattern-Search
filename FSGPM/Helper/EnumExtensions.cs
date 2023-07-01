using FSGPM.Enum;
using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T enumerationValue) where T : struct
    {
        Type type = enumerationValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
        }

        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
        if (memberInfo.Length > 0)
        {
            object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }

        return enumerationValue.ToString();
    }

    public static Guid GetGuid(this ConstraintCountEnum type)
    {
        switch (type)
        {
            case ConstraintCountEnum.SmallConstraintGap:
                return new Guid("0043e140-dbf0-4b1a-b1de-7d99907b738a");
            case ConstraintCountEnum.MediumConstraintGap:
                return new Guid("abd5a210-143e-4c2c-8290-bda6096fadd8");
            case ConstraintCountEnum.LargeConstraintGap:
                return new Guid("510b08de-edb0-4670-9a58-2818a6ad3e84");
            default:
                throw new ArgumentException("Invalid GuidType value.");
        }
    }
}
