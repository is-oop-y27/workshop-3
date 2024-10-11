using System.Text;

namespace Articles.Articles;

public class Article : IArticle
{
    private readonly IRenderable _name;
    private readonly IReadOnlyCollection<IParagraph> _paragraphs;
    private readonly IRenderable _author;

    public Article(
        IRenderable name,
        IReadOnlyCollection<IParagraph> paragraphs,
        IRenderable author)
    {
        _name = name;
        _paragraphs = paragraphs;
        _author = author;
    }

    public IArticleBuilder Direct(IArticleBuilder builder)
    {
        builder = builder.WithName(_name);
        builder = builder.WithAuthor(_author);

        foreach (IParagraph paragraph in _paragraphs)
        {
            builder = builder.AddParagraph(paragraph);
        }

        return builder;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append(_name.Render());
        builder.Append("\n");
        builder.AppendJoin("\n\n", _paragraphs.Select(x => x.Render()));

        builder.Append("\n\n");
        builder.Append(_author.Render());

        return builder.ToString();
    }
}