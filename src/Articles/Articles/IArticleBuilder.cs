namespace Articles.Articles;

public interface IArticleBuilder
{
    IArticleBuilder WithName(IRenderable name);

    IArticleBuilder AddParagraph(IParagraph paragraph);

    IArticleBuilder WithAuthor(IRenderable author);

    IArticle Build();
}