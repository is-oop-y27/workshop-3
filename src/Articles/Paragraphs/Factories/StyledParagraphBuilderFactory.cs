using Articles.Paragraphs.Builders;

namespace Articles.Paragraphs.Factories;

public class StyledParagraphBuilderFactory : IParagraphBuilderFactory
{
    private readonly IRenderableModifier _modifier;

    public StyledParagraphBuilderFactory(IRenderableModifier modifier)
    {
        _modifier = modifier;
    }

    public IParagraphHeaderSelector Create()
    {
        return new StyledParagraphBuilder(_modifier);
    }
}