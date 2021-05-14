using RuleExpressionParserTest.ExpressionGroups;

namespace RuleExpressionParserTest
{
    internal class RuleExpression
    {
        public Bucket Bucket { get; set; }
        public Constraint Constraint { get; set; }
        public ContextKey ContextKey { get; set; }
        public string ContextValue { get; set; }
        public ConditionOperator ConditionOperator { get; set; }
        public string ConditionValue { get; set; }
    }
}
