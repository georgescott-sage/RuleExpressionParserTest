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
            Console.WriteLine($"parsed string: {match.Groups["Bucket"].Value}");
            Enum.TryParse(match.Groups["Bucket"].Value, out Bucket bucketEnum);
            Console.WriteLine($"parsed enum: {bucketEnum.ToString()}");

            // Console.WriteLine(match.Groups["Constraint"].Value);
            // Console.WriteLine(match.Groups["ContextKey"].Value);
            // Console.WriteLine(match.Groups["ContextValue"].Value);
            // Console.WriteLine(match.Groups["ConditionOperator"].Value);
            // Console.WriteLine(match.Groups["ConditionValue"].Value);

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

    }
}
