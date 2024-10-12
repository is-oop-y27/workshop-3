namespace Articles.Paragraphs;

public class StyledParagraph : IParagraph
{
    private readonly IParagraph _paragraph;
    private readonly IRenderableModifier _modifier;

    public StyledParagraph(
        IParagraph paragraph,
        IRenderableModifier modifier)
    {
        _paragraph = paragraph;
        _modifier = modifier;
    }

    public string Render()
    {
        return _modifier.Modify(_paragraph.Render());
    }
}