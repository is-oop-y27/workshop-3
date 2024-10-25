using Expressions.Results;

namespace Expressions;

public interface IExpression
{
    ExpressionEvaluationResult Evaluate(IExpressionEvaluationContext context);

    string Format();
}