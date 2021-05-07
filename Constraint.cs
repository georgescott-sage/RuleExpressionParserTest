using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleExpressionParserTest
{
    public class Constraint : AbstractExpressionGroup
    {
        public static readonly Dictionary<string, Constraint> PredefinedValues;
        public static readonly Constraint MustHave = new Constraint("Must Have");
        public static readonly Constraint MustNotHave = new Constraint("Must Not Have");

        static Constraint()
        {
            PredefinedValues = new Dictionary<string, Constraint>();
            PredefinedValues.Add(MustHave.Value, MustHave);
            PredefinedValues.Add(MustNotHave.Value, MustNotHave);
        }

        public Constraint(string value) : base(value)
        {
        }

        public static Constraint ParseValue(string value)
        {
            return ParseExpressionGroup<Constraint>(value, PredefinedValues);
        }
    }
}
