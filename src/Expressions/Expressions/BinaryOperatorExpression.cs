using Expressions.Operators;
using Expressions.Results;

namespace Expressions.Expressions;

public class BinaryOperatorExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;
    private readonly IBinaryOperator _operator;
    private readonly string _stringRepresentation;

    public BinaryOperatorExpression(
        IExpression left,
        IExpression right,
        IBinaryOperator @operator,
        string stringRepresentation)
    {
        _left = left;
        _right = right;
        _operator = @operator;
        _stringRepresentation = stringRepresentation;
    }

    public ExpressionEvaluationResult Evaluate(IExpressionEvaluationContext context)
    {
        return (_left.Evaluate(context), _right.Evaluate(context)) switch
        {
            (ExpressionEvaluationResult.Full l, ExpressionEvaluationResult.Full r)
                => new ExpressionEvaluationResult.Full(_operator.Apply(l.Value, r.Value)),

            (ExpressionEvaluationResult.Full l, ExpressionEvaluationResult.Partial r)
                => new ExpressionEvaluationResult.Partial(new BinaryOperatorExpression(
                    l.Value,
                    r.Expression,
                    _operator,
                    _stringRepresentation)),

            (ExpressionEvaluationResult.Partial l, ExpressionEvaluationResult.Full r)
                => new ExpressionEvaluationResult.Partial(new BinaryOperatorExpression(
                    l.Expression,
                    r.Value,
                    _operator,
                    _stringRepresentation)),

            (ExpressionEvaluationResult.Partial l, ExpressionEvaluationResult.Partial r)
                => new ExpressionEvaluationResult.Partial(new BinaryOperatorExpression(
                    l.Expression,
                    r.Expression,
                    _operator,
                    _stringRepresentation)),

            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public string Format()
    {
        return $"({_left.Format()} {_stringRepresentation} {_right.Format()})";
    }
}