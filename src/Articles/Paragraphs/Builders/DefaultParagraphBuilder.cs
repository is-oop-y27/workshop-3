namespace Articles.Paragraphs.Builders;

public class DefaultParagraphBuilder : ParagraphBuilderBase
{
    protected override IParagraph Build(
        IRenderable title,
        IReadOnlyCollection<IRenderable> sections,
        IRenderable? footer)
    {
        return new Paragraph(
            title,
            sections,
            footer);
    }
}