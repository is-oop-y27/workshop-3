namespace Articles.Paragraphs;

public interface IParagraphHeaderSelector
{
    IParagraphBuilder WithHeader(IRenderable renderable);
}

public interface IParagraphBuilder
{
    IParagraphBuilder AddSection(IRenderable renderable);

    IParagraphBuilder WithFooter(IRenderable renderable);

    IParagraph Build();
}