using System.Drawing;
using Articles;
using Articles.Articles;
using Articles.Drawer;
using Articles.Expressions.Expressions;
using Articles.Expressions.Renderables;
using Articles.Modifiers;
using Articles.Paragraphs;
using Articles.Paragraphs.Builders;
using Articles.Paragraphs.Factories;
using Articles.Renderables;
using Expressions;
using Expressions.Expressions;
using Expressions.Extensions;

Console.Clear();

IDrawer drawer = new ConsoleDrawer();

IParagraphBuilderFactory factory = new DefaultParagraphBuilderFactory();

var article = CreateArticle(new ArticleBuilder(), factory);


drawer.Draw(article);

static IArticle CreateArticle(
    IArticleBuilder builder,
    IParagraphBuilderFactory paragraphFactory)
{
    builder.WithName(
        new Text("My article").AddModifier(new ColorModifier(Color.Pink)));

    IExpression expression = new VariableExpression("z")
        .Multiply(
            new StyledExpressionDecorator(
                new VariableExpression("x").Add(new VariableExpression("y")),
                new ColorModifier(Color.Green)));

    ExpressionEvaluationContext context = ExpressionEvaluationContext.Build
        .AddVariable("x", 2)
        .Build();

    builder.AddParagraph(paragraphFactory.Create()
        .WithTitle(new Text("My Expression"))
        .AddSection(new ExpressionRenderable(expression, context))
        .Build());

    for (int i = 0; i < 1; i++)
    {
        builder.AddParagraph(CreateParagraph(paragraphFactory));
    }

    builder.WithAuthor(new Text("ronimizy"));

    return builder.Build();
}

static IParagraph CreateParagraph(IParagraphBuilderFactory factory)
{
    return factory.Create()
        .WithTitle(new Text("My paragraph"))
        .AddSection(new Text("Section"))
        .AddSection(new Text("Section"))
        .AddSection(new Text("Section"))
        .AddSection(new Text("Section"))
        .AddSection(new Text("Section"))
        .Build();
}