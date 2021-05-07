using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RuleExpressionParserTest
{
    public class ExpressionParser
    {
        public bool IsValid(string expression)
        {
            var bucketOptions = BuildMatchGroup<Bucket>();
            var contraintOptions = GetMatchGroup<Constraint>(Constraint.PredefinedValues);
            var contextKeyOptions = BuildMatchGroup<ContextKey>();
            var conditionOptions = GetMatchGroup<ConditionOperator>(ConditionOperator.PredefinedValues);

            string regexString = $"^({bucketOptions})\\s({contraintOptions})\\s({contextKeyOptions})\\[(?'ContextValue'.*)\\]\\s({conditionOptions})\\s(?'ConditionValue'([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]))$";
            Regex regex = new Regex(regexString);
            Console.WriteLine(regexString);
            Match match = regex.Match(expression);

            if (!match.Success)
            {
                return false;
            }

            var queryDetail = new QueryDetail()
            {
                Bucket = ParseEnum<Bucket>(match.Groups["Bucket"].Value),
                Constraint = Constraint.ParseValue(match.Groups["Constraint"].Value),
                ContextKey = ParseEnum<ContextKey>(match.Groups["ContextKey"].Value),
                ContextValue = match.Groups["ContextValue"].Value,
                ConditionOperator = ConditionOperator.ParseValue(match.Groups["ConditionOperator"].Value),
                ConditionValue = match.Groups["ConditionValue"].Value
            };

            //Where to get tennantID?
            //where to get product info?
            //should expression also have an error code/message?
            //count before change or after?

            return true;
        }

        public static string GetMatchGroup<T>(Dictionary<string, T> predefinedValues) where T : AbstractExpressionGroup
        {
            var options = String.Join("|", predefinedValues.Select(KVP => KVP.Value.Value )); 
            return $"?'{typeof(T).Name}'({options})";
        }

        private static string GetEnumValues<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>();
            return string.Join('|', values);
        }

        public static string BuildMatchGroup<T>() where T : Enum
        {
            var typeName = typeof(T).Name;
            var options = System.Enum.GetNames(typeof(T));
            return $"?'{typeName}'({String.Join('|', options)})";
        }

        public static T ParseEnum<T>(string enumString) where T : struct
        {
            Enum.TryParse(enumString, out T enumResult);
            return enumResult;
        }
    }
}
