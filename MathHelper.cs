using MathNet.Symbolics;
using System.Collections.Generic;

namespace Lab5
{
	public static class MathHelper
	{
        public static double CalculateVoltage(double wt)
        {
            string function = "125 * sin(wt/3) - 30 * wt";

            SymbolicExpression expression = Infix.ParseOrThrow(function);
            Dictionary<string, FloatingPoint> variables = new Dictionary<string, FloatingPoint>
            {
                { "wt", wt }
            };

            return expression.Evaluate(variables).RealValue;
        }
    }
}
