using System.Globalization;
using Expressions.Results;

namespace Expressions.Expressions;

public class ConstantExpression : IExpressionValue
{
    public ConstantExpression(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public ExpressionEvaluationResult Evaluate(IExpressionEvaluationContext context)
    {
        return new ExpressionEvaluationResult.Full(this);
    }

    public string Format()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }
}