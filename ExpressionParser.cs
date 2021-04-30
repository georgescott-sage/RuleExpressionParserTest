using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RuleExpressionParserTest
{
    public class ExpressionParser
    {
        Regex regex = 
            new Regex("^(?'Bucket'(Account|Business|Tenant))\\s(?'Constraint'(Must Have|Must Not Have))\\s(?'ContextKey'(Product|Module|Feature|FeatureAllowanceCounter))\\[(?'ContextValue'.*)\\]\\s(?'ConditionOperator'(=|>|>=|<|<=))\\s(?'ConditionValue'([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]))$");

        public bool IsValid(string expression)
        {
            var contraintOptions = GetStringOptions<Constraint>();
            Console.WriteLine(contraintOptions);

            var bucketOptions = GetStringOptions<Bucket>();
            Console.WriteLine(bucketOptions);

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
