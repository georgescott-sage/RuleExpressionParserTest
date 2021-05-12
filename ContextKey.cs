using System.Collections.Generic;

namespace RuleExpressionParserTest
{
    public class ContextKey : AbstractExpressionGroup
    {
        public static readonly Dictionary<string, ContextKey> PredefinedValues;
        public static readonly ContextKey Product = new ContextKey("Product");
        public static readonly ContextKey Module = new ContextKey("Module");
        public static readonly ContextKey Feature = new ContextKey("Feature");
        public static readonly ContextKey FeatureAllowanceCounter = new ContextKey("FeatureAllowanceCounter");

        static ContextKey()
        {
            PredefinedValues = new Dictionary<string, ContextKey>();
            PredefinedValues.Add(Product.Value, Product);
            PredefinedValues.Add(Module.Value, Module);
            PredefinedValues.Add(Feature.Value, Feature);
            PredefinedValues.Add(FeatureAllowanceCounter.Value, FeatureAllowanceCounter);
        }

        public ContextKey(string value) : base(value)
        {
        }

        public static ContextKey ParseValue(string value)
        {
            return ParseExpressionGroup<ContextKey>(value, PredefinedValues);
        }
    }

}
