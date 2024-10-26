using Expressions.Expressions;
using Expressions.Operators;

namespace Expressions.Extensions;

public static class ExpressionsExtensions
{
    public static IExpression Add(this IExpression left, IExpression right)
    {
        var op = new DelegateBinaryOperator((l, r) => l + r);
        return new BinaryOperatorExpression(left, right, op, "+");
    }

    public static IExpression Subtract(this IExpression left, IExpression right)
    {
        var op = new DelegateBinaryOperator((l, r) => l - r);
        return new BinaryOperatorExpression(left, right, op, "-");
    }

    public static IExpression Multiply(this IExpression left, IExpression right)
    {
        var op = new DelegateBinaryOperator((l, r) => l * r);
        return new BinaryOperatorExpression(left, right, op, "*");
    }

    public static IExpression Divide(this IExpression left, IExpression right)
    {
        var op = new DelegateBinaryOperator((l, r) => l / r);
        return new BinaryOperatorExpression(left, right, op, "/");
    }
}