using Expressions;
using Expressions.Results;

namespace Articles.Expressions.Expressions;

public class StyledExpressionValueDecorator : IExpressionValue
{
    private readonly IExpressionValue _value;
    private readonly IRendenrableModifier _modifier;

    public StyledExpressionValueDecorator(
        IExpressionValue value,
        IRendenrableModifier modifier)
    {
        _value = value;
        _modifier = modifier;
    }

    public double Value => _value.Value;

    public ExpressionEvaluationResult Evaluate(IExpressionEvaluationContext context)
    {
        return new ExpressionEvaluationResult.Full(this);
    }

    public string Format()
    {
        return _modifier.Modify(_value.Format());
    }
}