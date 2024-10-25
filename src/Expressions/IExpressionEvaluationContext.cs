using Expressions.Results;

namespace Expressions;

public interface IExpressionEvaluationContext
{
    VariableResolutionResult TryGetVariable(string name);
}