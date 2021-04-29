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
}
