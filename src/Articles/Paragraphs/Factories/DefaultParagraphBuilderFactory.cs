using Articles.Paragraphs.Builders;

namespace Articles.Paragraphs.Factories;

public class DefaultParagraphBuilderFactory : IParagraphBuilderFactory
{
    public IParagraphHeaderSelector Create()
    {
        return new DefaultParagraphBuilder();
    }
}