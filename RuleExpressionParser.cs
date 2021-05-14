using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RuleExpressionParserTest.ExpressionGroups;
using RuleExpressionParserTest.Models;

namespace RuleExpressionParserTest
{
    public class RuleExpressionParser
    {
        public bool IsValid(string expression)
        {
            var bucketOptions = GetMatchGroup<Bucket>(Bucket.PredefinedValues);
            var contraintOptions = GetMatchGroup<Constraint>(Constraint.PredefinedValues);
            var contextKeyOptions = GetMatchGroup<ContextKey>(ContextKey.PredefinedValues);
            var conditionOptions = GetMatchGroup<ConditionOperator>(ConditionOperator.PredefinedValues);

            string regexString = $"^({bucketOptions})\\s({contraintOptions})\\s({contextKeyOptions})\\[(?'ContextValue'.*)\\]\\s({conditionOptions})\\s(?'ConditionValue'([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]))$";
            Regex regex = new Regex(regexString);
            Match match = regex.Match(expression);

            if (!match.Success)
            {
                return false;
            }

            var queryDetail = new RuleExpression()
            {
                Bucket = Bucket.ParseValue(match.Groups["Bucket"].Value),
                Constraint = Constraint.ParseValue(match.Groups["Constraint"].Value),
                ContextKey = ContextKey.ParseValue(match.Groups["ContextKey"].Value),
                ContextValue = match.Groups["ContextValue"].Value,
                ConditionOperator = ConditionOperator.ParseValue(match.Groups["ConditionOperator"].Value),
                ConditionValue = match.Groups["ConditionValue"].Value
            };

            Console.WriteLine($"Bucket: {queryDetail.Bucket.Value}");
            Console.WriteLine($"Constraint: {queryDetail.Constraint.Value}");
            Console.WriteLine($"ContextKey: {queryDetail.ContextKey.Value}");
            Console.WriteLine($"ContextValue: {queryDetail.ContextValue}");
            Console.WriteLine($"ConditionOperator: {queryDetail.ConditionOperator.Value}");
            Console.WriteLine($"ConditionValue: {queryDetail.ConditionValue}");
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
    }
}
