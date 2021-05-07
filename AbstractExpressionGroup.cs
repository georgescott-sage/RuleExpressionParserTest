using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RuleExpressionParserTest
{
    public class AbstractExpressionGroup
    {
        private readonly string value;

        public AbstractExpressionGroup(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }

        protected static T ParseExpressionGroup<T>(string value, Dictionary<string, T> PredefinedValues)
        {
            var exception = new InvalidDataContractException($"Invalid value for type {typeof(T).Name}");
            if (string.IsNullOrEmpty(value))
                throw exception;

            if (!PredefinedValues.ContainsKey(value))
                throw exception;

            return PredefinedValues[value];
        }

    }
}
