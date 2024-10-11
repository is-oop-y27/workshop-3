using System.Text;

namespace Articles.Paragraphs;

public class Paragraph : IParagraph
{
    private readonly IRenderable _title;
    private readonly IReadOnlyCollection<IRenderable> _section;
    private readonly IRenderable? _footer;

    public Paragraph(
        IRenderable title,
        IReadOnlyCollection<IRenderable> section,
        IRenderable? footer)
    {
        _title = title;
        _section = section;
        _footer = footer;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append("\n");
        builder.Append(_title.Render());
        builder.Append("\n");
        builder.AppendJoin("\n", _section.Select(x => x.Render()));

        if (_footer is not null)
        {
            builder.Append("\n");
            builder.Append(_footer.Render());
        }

        return builder.ToString();
    }
}