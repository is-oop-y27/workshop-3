using System.Text;

namespace Articles.Articles;

internal class Article : IArticle
{
    private readonly IRenderable _name;
    private readonly IReadOnlyCollection<IParagraph> _paragraphs;
    private readonly IRenderable? _author;

    public Article(
        IRenderable name,
        IReadOnlyCollection<IParagraph> paragraphs,
        IRenderable? author)
    {
        _name = name;
        _paragraphs = paragraphs;
        _author = author;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append(_name.Render());

        builder.Append("\n");
        builder.AppendJoin("\n\n", _paragraphs.Select(x => x.Render()));

        if (_author is not null)
        {
            builder.Append("\n\n");
            builder.Append(_author.Render());
        }

        return builder.ToString();
    }

    public IArticleBuilder Direct(IArticleBuilder builder)
    {
        builder = builder.WithName(_name);

        if (_author is not null)
        {
            builder = builder.WithAuthor(_author);
        }

        builder = _paragraphs.Aggregate(
            builder,
            (b, p) => b.AddParagraph(p));

        return builder;
    }
}