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
            Console.WriteLine(testExpression);
            Parse(testExpression);

            Console.WriteLine();

            string testExpression2 = "Business Must Not Have Product[Accounting] > 0";
            Console.WriteLine(testExpression2);
            Parse(testExpression2);
        }

        private static void Parse(string testExpression)
        {
            RuleExpressionParser parser = new RuleExpressionParser();

            var result = parser.IsValid(testExpression);

            var message = result ? "Parsed :)" : "No Parsed :(";

            Console.WriteLine(message);
        }
    }
}
