using System.Drawing;
using Articles;
using Articles.Articles;
using Articles.Drawers;
using Articles.Expressions.Expressions;
using Articles.Expressions.Extensions;
using Articles.Expressions.Renderables;
using Articles.Modifiers;
using Articles.Paragraphs;
using Articles.Paragraphs.Factories;
using Articles.Renderables;
using Expressions;
using Expressions.Contexts;
using Expressions.Expressions;
using Expressions.Extensions;

Console.Clear();

IDrawer drawer = new ConsoleDrawer();

IArticleBuilder builder = new ArticleBuilder();

IParagraphBuilderFactory factory = new DefaultParagraphBuilderFactory();

IArticle article = CreateArticle(builder, factory);

IArticleBuilder editingBuilder = article.Direct(new ArticleBuilder());

IArticle article2 = editingBuilder
    .AddParagraph(factory.Create().WithHeader(new Text("adawdawdaw122341241")).Build())
    .Build();

drawer.Draw(article2);

static IArticle CreateArticle(
    IArticleBuilder builder,
    IParagraphBuilderFactory factory)
{
    builder = builder
        .WithName(new Text("My Article").AddModifier(new BoldModifier()))
        .WithAuthor(new Text("ronimizy").AddModifier(new ColorModifier(Color.Red)));

    IExpression expression = new VariableExpression("x")
        .Add(new ConstantExpression(2))
        .Multiply(new ConstantExpression(3))
        .WithModifier(new ColorModifier(Color.Green));

    ExpressionEvaluationContext context = ExpressionEvaluationContext.Build
        .WithVariable("x", 4)
        .Build();

    var renderableExpression = new ExpressionRenderable(expression, context);

    builder = builder.AddParagraph(factory.Create()
        .WithHeader(new Text("My expression"))
        .AddSection(renderableExpression)
        .Build());

    // for (var i = 0; i < 10; i++)
    // {
    //     builder = builder.AddParagraph(CreateParagraph(factory));
    // }

    return builder.Build();
}

static IParagraph CreateParagraph(IParagraphBuilderFactory factory)
{
    IParagraphHeaderSelector builder = factory.Create();

    IParagraph paragraph = builder
        .WithHeader(new Text("Header").AddModifier(new BoldModifier()))
        .AddSection(new Text("1213421342341234124141424124124"))
        .WithFooter(new Text("aaaaqaaaa"))
        .Build();

    return paragraph;
}