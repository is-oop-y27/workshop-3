namespace Expressions.Operators;

public interface IBinaryOperator
{
    IExpressionValue Apply(IExpressionValue left, IExpressionValue right);
}