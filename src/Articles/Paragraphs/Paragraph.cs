using System.Text;

namespace Articles.Paragraphs;

internal class Paragraph : IParagraph
{
    private readonly IRenderable _header;
    private readonly IReadOnlyCollection<IRenderable> _sections;
    private readonly IRenderable? _footer;

    public Paragraph(
        IRenderable header,
        IReadOnlyCollection<IRenderable> sections,
        IRenderable? footer)
    {
        _header = header;
        _sections = sections;
        _footer = footer;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append("\n");
        builder.Append(_header.Render());

        builder.Append("\n");
        builder.AppendJoin("\n", _sections.Select(x => x.Render()));

        if (_footer is not null)
        {
            builder.Append("\n");
            builder.Append(_footer.Render());
        }

        return builder.ToString();
    }
}