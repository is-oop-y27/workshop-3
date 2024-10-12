namespace Articles.Articles;

public class ArticleBuilder : IArticleBuilder
{
    private readonly List<IParagraph> _paragraphs = [];
    private IRenderable? _name;
    private IRenderable? _author;

    public IArticleBuilder WithName(IRenderable name)
    {
        _name = name;
        return this;
    }

    public IArticleBuilder AddParagraph(IParagraph paragraph)
    {
        _paragraphs.Add(paragraph);
        return this;
    }

    public IArticleBuilder WithAuthor(IRenderable author)
    {
        _author = author;
        return this;
    }

    public IArticle Build()
    {
        return new Article(
            _name ?? throw new ArgumentNullException(),
            _paragraphs.ToArray(),
            _author ?? throw new ArgumentNullException());
    }
}