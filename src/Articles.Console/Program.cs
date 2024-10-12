using System.Drawing;
using Articles;
using Articles.Articles;
using Articles.Drawers;
using Articles.Modifiers;
using Articles.Paragraphs;
using Articles.Paragraphs.Factories;
using Articles.Renderables;

Console.Clear();

IDrawer drawer = new ConsoleDrawer();

IArticleBuilder builder = new ArticleBuilder();

IParagraphBuilderFactory factory = new StyledParagraphBuilderFactory(
    new ColorModifier(Color.SpringGreen));

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

    for (var i = 0; i < 10; i++)
    {
        builder = builder.AddParagraph(CreateParagraph(factory));
    }

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