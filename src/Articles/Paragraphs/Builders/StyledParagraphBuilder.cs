using Articles.Renderables;

namespace Articles.Paragraphs.Builders;

public class StyledParagraphBuilder(IRendenrableModifier modifier) :
    ParagraphBuilderBase
{
    protected override IParagraph Build(
        IRenderable title,
        IReadOnlyCollection<IRenderable> sections,
        IRenderable? footer)
    {
        var paragraph = new Paragraph(
            title,
            sections,
            footer);

        return new ModifierParagraph(paragraph, modifier);
    }
}