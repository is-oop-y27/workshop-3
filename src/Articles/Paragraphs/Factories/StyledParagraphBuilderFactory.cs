using Articles.Paragraphs.Builders;

namespace Articles.Paragraphs.Factories;

public class StyledParagraphBuilderFactory(IRendenrableModifier modifier) :
    IParagraphBuilderFactory
{
    public IParagraphTitleBuilder Create()
    {
        return new StyledParagraphBuilder(modifier);
    }
}