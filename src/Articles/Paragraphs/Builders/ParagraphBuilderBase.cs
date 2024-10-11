namespace Articles.Paragraphs.Builders;

public abstract class ParagraphBuilderBase :
    IParagraphTitleBuilder,
    IParagraphBuilder
{
    private IRenderable? _title;
    private readonly List<IRenderable> _sections = [];
    private IRenderable? _footer;

    public IParagraphBuilder WithTitle(IRenderable title)
    {
        _title = title;
        return this;
    }

    public IParagraphBuilder AddSection(IRenderable section)
    {
        _sections.Add(section);
        return this;
    }

    public IParagraphBuilder WithFooter(IRenderable footer)
    {
        _footer = footer;
        return this;
    }

    public IParagraph Build()
    {
        return Build(
            _title ?? throw new ArgumentNullException(),
            _sections.ToArray(),
            _footer);
    }

    protected abstract IParagraph Build(
        IRenderable title,
        IReadOnlyCollection<IRenderable> sections,
        IRenderable? footer);
}