using Expressions;
using Expressions.Contexts;
using Expressions.Expressions;
using Expressions.Extensions;

Console.Clear();

IExpressionEvaluationContext context = ExpressionEvaluationContext
    .Build
    .WithVariable("x", 4)
    .Build();

IExpression expression = new VariableExpression("x")
    .Add(new ConstantExpression(2))
    .Multiply(new ConstantExpression(3));

Console.WriteLine(expression.Evaluate(context));