using Expressions.Results;

namespace Expressions;

public interface IExpressionEvaluationContext
{
    VariableResolutionResult TryResolveVariable(string name);
}