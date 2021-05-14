using System.Collections.Generic;

namespace RuleExpressionParserTest.ExpressionGroups
{
    public class Bucket : AbstractExpressionGroup
    {
        public static readonly Dictionary<string, Bucket> PredefinedValues;
        public static readonly Bucket Account = new Bucket("Account");
        public static readonly Bucket Business = new Bucket("Business");
        public static readonly Bucket Tenant = new Bucket("Tenant");


        static Bucket()
        {
            PredefinedValues = new Dictionary<string, Bucket>();
            PredefinedValues.Add(Account.Value, Account);
            PredefinedValues.Add(Business.Value, Business);
            PredefinedValues.Add(Tenant.Value, Tenant);
        }

        public Bucket(string value) : base(value)
        {
        }

        public static Bucket ParseValue(string value)
        {
            return ParseExpressionGroup<Bucket>(value, PredefinedValues);
        }
    }
}
