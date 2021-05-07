using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace RuleExpressionParserTest
{
    public class ConditionOperator
    {
        private readonly string value;
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

        private ConditionOperator(string value)
        {
            this.value = value;
        }

        public static ConditionOperator ParseValue(string value)
        {
            var exception = new InvalidDataContractException($"Invalid value for type {nameof(ConditionOperator)}");
            if (string.IsNullOrEmpty(value))
                throw exception;

            string key = value.ToLower();
            if (!PredefinedValues.ContainsKey(key))
                throw exception;

            return PredefinedValues[key];
        }

        public string Value
        {
            get { return value; }
        }
    }

}
