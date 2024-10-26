using Expressions.Results;

namespace Expressions.Contexts;

public class ExpressionEvaluationContext : IExpressionEvaluationContext
{
    private readonly IReadOnlyDictionary<string, double> _values;

    private ExpressionEvaluationContext(IReadOnlyDictionary<string, double> values)
    {
        _values = values;
    }

    public static Builder Build => new();

    public VariableResolutionResult TryResolveVariable(string name)
    {
        return _values.TryGetValue(name, out double value)
            ? new VariableResolutionResult.Found(value)
            : new VariableResolutionResult.NotFound();
    }

    public class Builder
    {
        private readonly Dictionary<string, double> _values = [];

        public Builder WithVariable(string name, double value)
        {
            _values[name] = value;
            return this;
        }

        public ExpressionEvaluationContext Build()
        {
            return new ExpressionEvaluationContext(_values);
        }
    }
}