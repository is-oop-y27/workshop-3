using Articles.Expressions.Expressions;
using Expressions;

namespace Articles.Expressions.Extensions;

public static class ExpressionExtensions
{
    public static IExpression WithModifier(
        this IExpression expression,
        IRenderableModifier modifier)
    {
        return new StyledExpression(expression, modifier);
    }

    public static IExpressionValue WithModifier(
        this IExpressionValue expression,
        IRenderableModifier modifier)
    {
        return new StyledExpressionValue(expression, modifier);
    }
}