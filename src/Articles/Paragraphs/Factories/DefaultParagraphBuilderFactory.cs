using Articles.Paragraphs.Builders;

namespace Articles.Paragraphs.Factories;

public class DefaultParagraphBuilderFactory : IParagraphBuilderFactory
{
    public IParagraphTitleBuilder Create()
    {
        return new DefaultParagraphBuilder();
    }
}