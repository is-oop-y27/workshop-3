using Expressions;
using Expressions.Results;

namespace Articles.Expressions.Expressions;

public class StyledExpression : IExpression
{
    private readonly IExpression _expression;
    private readonly IRenderableModifier _modifier;

    public StyledExpression(IExpression expression, IRenderableModifier modifier)
    {
        _expression = expression;
        _modifier = modifier;
    }

    public ExpressionEvaluationResult Evaluate(
        IExpressionEvaluationContext context)
    {
        return _expression.Evaluate(context) switch
        {
            ExpressionEvaluationResult.Full full
                => new ExpressionEvaluationResult.Full(new StyledExpressionValue(full.Value, _modifier)),

            ExpressionEvaluationResult.Partial partial
                => new ExpressionEvaluationResult.Partial(new StyledExpression(partial.Value, _modifier)),

            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public string Format()
    {
        return _modifier.Modify(_expression.Format());
    }
}