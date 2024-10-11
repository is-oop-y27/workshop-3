using System.Drawing;
using Articles;
using Articles.Articles;
using Articles.Drawer;
using Articles.Modifiers;
using Articles.Paragraphs;
using Articles.Paragraphs.Builders;
using Articles.Paragraphs.Factories;
using Articles.Renderables;

Console.Clear();

IDrawer drawer = new ConsoleDrawer();

IParagraphBuilderFactory factory = new StyledParagraphBuilderFactory(
    new DimModifier());

var article = CreateArticle(new ArticleBuilder(), factory);

drawer.Draw(article);

static IArticle CreateArticle(
    IArticleBuilder builder,
    IParagraphBuilderFactory paragraphFactory)
{
    builder.WithName(
        new Text("My article").AddModifier(new ColorModifier(Color.Pink)));

    for (int i = 0; i < 5; i++)
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