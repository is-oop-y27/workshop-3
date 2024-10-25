using Expressions.Results;

namespace Expressions.Expressions;

public class ExpressionEvaluationContext : IExpressionEvaluationContext
{
    private readonly Dictionary<string, double> _values;

    private ExpressionEvaluationContext(Dictionary<string, double> values)
    {
        _values = values;
    }

    public static Builder Build => new Builder();

    public VariableResolutionResult TryGetVariable(string name)
    {
        return _values.TryGetValue(name, out double value)
            ? new VariableResolutionResult.Found(value)
            : new VariableResolutionResult.NotFound();
    }

    public class Builder
    {
        private readonly Dictionary<string, double> _values = [];

        public Builder AddVariable(string name, double value)
        {
            _values[name] = value;
            return this;
        }

        public ExpressionEvaluationContext Build()
            => new ExpressionEvaluationContext(_values);
    }
}