using System;
using System.Text.RegularExpressions;

namespace RuleExpressionParserTest
{
    public class ExpressionParser
    {
        Regex regex = 
            new Regex("^(?'Bucket'(Account|Business|Tenant))\\s(?'Constraint'(Must Have|Must Not Have))\\s(?'ContextKey'(Product|Module|Feature|FeatureAllowanceCounter))\\[(?'ContextValue'.*)\\]\\s(?'ConditionOperator'(=|>|>=|<|<=))\\s(?'ConditionValue'([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]))$");

        public bool IsValid(string expression)
        {
            Match match = regex.Match(expression);

            if (!match.Success)
            {
                return false;
            }
            Console.WriteLine(match.Groups["Bucket"].Value);
            Console.WriteLine(match.Groups["Constraint"].Value);
            Console.WriteLine(match.Groups["ContextKey"].Value);
            Console.WriteLine(match.Groups["ContextValue"].Value);
            Console.WriteLine(match.Groups["ConditionOperator"].Value);
            Console.WriteLine(match.Groups["ConditionValue"].Value);
            return true;
        }

    }

    

    public enum Bucket
    {
        Account,
        Business,
        Tenant
    }
}
