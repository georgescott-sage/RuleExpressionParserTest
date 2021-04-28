using System;
using System.Text.RegularExpressions;

namespace RuleExpressionParserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string testExpression = "Tenant Must Have FeatureAllowanceCounter[Product_Users] <= 5";

            ExpressionParser parser = new ExpressionParser();

            var result = parser.IsValid(testExpression);

            var message = result ? "Allowed" : "Not allowed";

            Console.WriteLine(message);
        }
    }

    public class ExpressionParser
    {
        Regex regex = 
            new Regex("^(?'Bucket'(Account|Business|Tenant))\\s(?'Constraint'(Must Have|Must Not Have))\\s(?'ContextKey'(Product|Module|Feature|FeatureAllowanceCounter))\\[(?'ContextValue'.*)\\]\\s(?'ConditionOperator'(=|>|>=|<|<=))\\s(?'ConditionValue'([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]))$");

        public bool IsValid(string expression)
        {
            Match match = regex.Match(expression);

            if (match.Success)
            {
                Console.WriteLine(match.Groups["Bucket"].Value);
            }
            return false;
        }

    }
}
