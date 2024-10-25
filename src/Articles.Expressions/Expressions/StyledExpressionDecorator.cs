using Expressions;
using Expressions.Results;

namespace Articles.Expressions.Expressions;

public class StyledExpressionDecorator : IExpression
{
    private readonly IExpression _expression;
    private readonly IRendenrableModifier _modifier;

    public StyledExpressionDecorator(
        IExpression expression,
        IRendenrableModifier modifier)
    {
        _expression = expression;
        _modifier = modifier;
    }

    public ExpressionEvaluationResult Evaluate(IExpressionEvaluationContext context)
    {
        return _expression.Evaluate(context) switch
        {
            ExpressionEvaluationResult.Full full
                => new ExpressionEvaluationResult.Full(
                    new StyledExpressionValueDecorator(full.Value, _modifier)),

            ExpressionEvaluationResult.Partial partial
                => new ExpressionEvaluationResult.Partial(
                    new StyledExpressionDecorator(partial.Expression, _modifier)),

            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public string Format()
        => _modifier.Modify(_expression.Format());
}