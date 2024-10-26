using Expressions;

namespace Articles.Expressions.Renderables;

public class ExpressionRenderable : IRenderable
{
    private readonly IExpression _expression;
    private readonly IExpressionEvaluationContext _context;

    public ExpressionRenderable(
        IExpression expression,
        IExpressionEvaluationContext context)
    {
        _expression = expression;
        _context = context;
    }

    public string Render()
    {
        return _expression.Evaluate(_context).ToString();
    }
}