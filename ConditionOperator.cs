using System.Runtime.Serialization;

namespace RuleExpressionParserTest
{
    public enum ConditionOperator
    {
        [EnumMember(Value = "=")]
        Equals,
        [EnumMember(Value = ">")]
        GreaterThan,
        [EnumMember(Value = ">=")]
        GreaterThanEqual,
        [EnumMember(Value = "<")]
        LessThan,
        [EnumMember(Value = "<=")]
        LessThanEqual
    }
}
