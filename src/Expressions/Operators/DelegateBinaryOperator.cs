using Expressions.Expressions;

namespace Expressions.Operators;

public class DelegateBinaryOperator : IBinaryOperator
{
    private readonly Func<double, double, double> _func;

    public DelegateBinaryOperator(Func<double, double, double> func)
    {
        _func = func;
    }

    public IExpressionValue Apply(IExpressionValue left, IExpressionValue right)
        => new ConstantExpression(_func.Invoke(left.Value, right.Value));
}