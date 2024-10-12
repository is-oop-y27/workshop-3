namespace Articles.Paragraphs.Builders;

internal class DefaultParagraphBuilder : ParagraphBuilderBase
{
    protected override IParagraph Create(
        IRenderable header,
        IReadOnlyCollection<IRenderable> sections,
        IRenderable? footer)
    {
        return new Paragraph(header, sections, footer);
    }
}