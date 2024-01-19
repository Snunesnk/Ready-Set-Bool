using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadySetBoole.Ex03
{
    public class BooleanEvaluation
    {
        public static bool Evaluate(string formula)
        {
            var values = formula.Where(char.IsDigit).ToArray();
            var operators = formula.Where(c => !char.IsDigit(c)).ToArray();
            bool? result = values[0] == '1';
            values = values.Skip(1).ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                switch (operators[i])
                {
                    case '&':
                        result = result.Value && values[i] == '1';
                        break;
                    case '|':
                        result = result.Value || values[i] == '1';
                        break;
                    case '!':
                        result = !result.Value;
                        break;
                    case '>':
                        result = !result.Value || values[i] == '1';
                        break;
                    case '=':
                        result = result.Value == (values[i] == '1');
                        break;
                    default:
                        throw new ArgumentException($"Invalid operator: {operators[i]}");
                }
            }

            return result.Value;
        }
    }
}
