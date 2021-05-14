using System.Collections.Generic;

namespace RuleExpressionParserTest.ExpressionGroups
{

    public class ConditionOperator : AbstractExpressionGroup
    {
        public static readonly Dictionary<string, ConditionOperator> PredefinedValues;
        public static readonly ConditionOperator Equal = new ConditionOperator("=");
        public static readonly ConditionOperator GreaterThan = new ConditionOperator(">");
        public static readonly ConditionOperator GreaterThanEqual = new ConditionOperator(">=");
        public static readonly ConditionOperator LessThan = new ConditionOperator("<");
        public static readonly ConditionOperator LessThanEqual = new ConditionOperator("<=");

        static ConditionOperator()
        {
            PredefinedValues = new Dictionary<string, ConditionOperator>();
            PredefinedValues.Add(Equal.Value, Equal);
            PredefinedValues.Add(GreaterThan.Value, GreaterThan);
            PredefinedValues.Add(GreaterThanEqual.Value, GreaterThanEqual);
            PredefinedValues.Add(LessThan.Value, LessThan);
            PredefinedValues.Add(LessThanEqual.Value, LessThanEqual);
        }

        public ConditionOperator(string value) : base(value)
        {
        }

        public static ConditionOperator ParseValue(string value)
        {
            return ParseExpressionGroup<ConditionOperator>(value, PredefinedValues);
        }
    }
}
