namespace Articles.Paragraphs.Builders;

internal abstract class ParagraphBuilderBase :
    IParagraphHeaderSelector,
    IParagraphBuilder
{
    private readonly List<IRenderable> _sections = [];
    private IRenderable? _header;
    private IRenderable? _footer;

    public IParagraphBuilder WithHeader(IRenderable renderable)
    {
        _header = renderable;
        return this;
    }

    public IParagraphBuilder AddSection(IRenderable renderable)
    {
        _sections.Add(renderable);
        return this;
    }

    public IParagraphBuilder WithFooter(IRenderable renderable)
    {
        _footer = renderable;
        return this;
    }

    public IParagraph Build()
    {
        return Create(
            _header ?? throw new InvalidOperationException(),
            _sections.ToArray(),
            _footer);
    }

    protected abstract IParagraph Create(
        IRenderable header,
        IReadOnlyCollection<IRenderable> sections,
        IRenderable? footer);
}