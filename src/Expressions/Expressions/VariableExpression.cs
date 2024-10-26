using Expressions.Results;

namespace Expressions.Expressions;

public class VariableExpression : IExpression
{
    private readonly string _variableName;

    public VariableExpression(string variableName)
    {
        _variableName = variableName;
    }

    public ExpressionEvaluationResult Evaluate(
        IExpressionEvaluationContext context)
    {
        return context.TryResolveVariable(_variableName) switch
        {
            VariableResolutionResult.Found found
                => new ExpressionEvaluationResult.Full(new ConstantExpression(found.Value)),

            VariableResolutionResult.NotFound
                => new ExpressionEvaluationResult.Partial(this),

            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public string Format()
        => _variableName;
}