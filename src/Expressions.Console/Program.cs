// See https://aka.ms/new-console-template for more information

using Expressions;
using Expressions.Expressions;
using Expressions.Extensions;

Console.Clear();

ExpressionEvaluationContext context = ExpressionEvaluationContext.Build
    .AddVariable("x", 2)
    .AddVariable("y", 10)
    .Build();

IExpression expression = new ConstantExpression(2)
    .Multiply(new VariableExpression("x"))
    .Divide(new VariableExpression("y"));

Console.WriteLine(expression.Evaluate(context));