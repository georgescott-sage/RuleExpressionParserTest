using RuleExpressionParserTest.ExpressionGroup;

namespace RuleExpressionParserTest
{
    internal class QueryDetail
    {
        public Bucket Bucket { get; set; }
        public Constraint Constraint { get; set; }
        public ContextKey ContextKey { get; set; }
        public string ContextValue { get; set; }
        public ConditionOperator ConditionOperator { get; set; }
        public string ConditionValue { get; set; }
    }
}
