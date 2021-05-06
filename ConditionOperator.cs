using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace RuleExpressionParserTest
{
    public class ConditionOperator
    {
        private readonly string value;
        private static readonly Dictionary<string, ConditionOperator> predefinedValues;

        public static readonly ConditionOperator Equal = new ConditionOperator("=");
        public static readonly ConditionOperator GreaterThan = new ConditionOperator(">");
        public static readonly ConditionOperator GreaterThanEqual = new ConditionOperator(">=");
        public static readonly ConditionOperator LessThan = new ConditionOperator("<");
        public static readonly ConditionOperator LessThanEqual = new ConditionOperator("<=");

        static ConditionOperator()
        {
            predefinedValues = new Dictionary<string, ConditionOperator>();
            predefinedValues.Add(Equal.Value, Equal);
            predefinedValues.Add(GreaterThan.Value, GreaterThan);
            predefinedValues.Add(GreaterThanEqual.Value, GreaterThanEqual);
            predefinedValues.Add(LessThan.Value, LessThan);
            predefinedValues.Add(LessThanEqual.Value, LessThanEqual);
        }

        private ConditionOperator(string value)
        {
            this.value = value;
        }

        public static string GetMatchGroup()
        {
            var options = String.Join("|", predefinedValues.Select(KVP => KVP.Value.Value )); 
            return $"?'ConditionOperator'({options})";
        }

        public static ConditionOperator ParseValue(string value)
        {
            var exception = new InvalidDataContractException($"Invalid value for type {nameof(ConditionOperator)}");
            if (string.IsNullOrEmpty(value))
                throw exception;

            string key = value.ToLower();
            if (!predefinedValues.ContainsKey(key))
                throw exception;

            return predefinedValues[key];
        }

        public string Value
        {
            get { return value; }
        }
    }

}
