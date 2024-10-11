namespace Articles.Paragraphs;

public interface IParagraphBuilder
{
    IParagraphBuilder AddSection(IRenderable section);

    IParagraphBuilder WithFooter(IRenderable footer);

    IParagraph Build();
}

public interface IParagraphTitleBuilder
{
    IParagraphBuilder WithTitle(IRenderable title);
}