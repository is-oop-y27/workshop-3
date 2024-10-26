using Expressions;
using Expressions.Results;

namespace Articles.Expressions.Expressions;

public class StyledExpressionValue : IExpressionValue
{
    private readonly IExpressionValue _expression;
    private readonly IRenderableModifier _modifier;

    public StyledExpressionValue(IExpressionValue expression, IRenderableModifier modifier)
    {
        _expression = expression;
        _modifier = modifier;
    }

    public double Value => _expression.Value;

    public ExpressionEvaluationResult Evaluate(IExpressionEvaluationContext context)
        => new ExpressionEvaluationResult.Full(this);

    public string Format()
    {
        return _modifier.Modify(_expression.Format());
    }
}