namespace Expressions.Results;

public abstract record ExpressionEvaluationResult
{
    private ExpressionEvaluationResult() { }

    public sealed record Full(IExpressionValue Value) : ExpressionEvaluationResult
    {
        public override string ToString() => Value.Format();
    }

    public sealed record Partial(IExpression Expression) : ExpressionEvaluationResult
    {
        public override string ToString() => Expression.Format();
    }
}