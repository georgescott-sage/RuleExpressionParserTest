using System;
using System.Text.RegularExpressions;

namespace RuleExpressionParserTest
{
    public class ExpressionParser
    {
        public bool IsValid(string expression)
        {
            var bucketOptions = GetStringOptions<Bucket>();
            var contraintOptions = GetStringOptions<Constraint>();
            var contextKeyOptions = GetStringOptions<ContextKey>();

            string regexString = $"^(?'Bucket'({bucketOptions}))\\s(?'Constraint'({contraintOptions}))\\s(?'ContextKey'({contextKeyOptions}))\\[(?'ContextValue'.*)\\]\\s(?'ConditionOperator'(=|>|>=|<|<=))\\s(?'ConditionValue'([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]))$";
            Regex regex = new Regex(regexString);

            Match match = regex.Match(expression);

            if (!match.Success)
            {
                return false;
            }
            // Console.WriteLine($"parsed string: {match.Groups["Bucket"].Value}");
            // Enum.TryParse(match.Groups["Bucket"].Value, out Bucket bucketEnum);
            // Console.WriteLine($"parsed enum: {bucketEnum.ToString()}");

            var queryDetail = new QueryDetail()
            {
                Bucket = ParseEnum<Bucket>(match.Groups["Bucket"].Value),
                Constraint = ParseEnum<Constraint>(match.Groups["Contraint"].Value),
                ContextKey = ParseEnum<ContextKey>(match.Groups["ContextKey"].Value),
                ContextValue = match.Groups["ContextValue"].Value,
                ContextOperator = match.Groups["ConditionOperator"].Value,
                ConditionValue = match.Groups["ConditionValue"].Value

            };

            Console.WriteLine(queryDetail.Bucket);
            //Where to get tennantID?
            //where to get product info?
            //should expression also have an error code/message?
            //count before change or after?


            //SELECT Count FROM TenantFeatureAllowanceCounters WHERE FeatureAllowanceKey = Product_Users AND TenantID = ???
            //must not have
            //if Count <= 5

            return true;
        }

        public static string GetStringOptions<T>() where T : struct
        {
            var options = System.Enum.GetNames(typeof(T));
            return String.Join('|', options);
        }

        public static T ParseEnum<T>(string enumString) where T : struct
        {
            Enum.TryParse(enumString, out T enumResult);
            return enumResult;
        }

    }
}
