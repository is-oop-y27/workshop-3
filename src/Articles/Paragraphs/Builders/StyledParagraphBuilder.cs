namespace Articles.Paragraphs.Builders;

internal class StyledParagraphBuilder : ParagraphBuilderBase
{
    private readonly IRenderableModifier _modifier;

    public StyledParagraphBuilder(IRenderableModifier modifier)
    {
        _modifier = modifier;
    }

    protected override IParagraph Create(
        IRenderable header,
        IReadOnlyCollection<IRenderable> sections,
        IRenderable? footer)
    {
        var paragraph = new Paragraph(header, sections, footer);
        return new StyledParagraph(paragraph, _modifier);
    }
}