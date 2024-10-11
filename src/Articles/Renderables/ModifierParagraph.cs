namespace Articles.Renderables;

public class ModifierParagraph : IParagraph
{
    private readonly IParagraph _renderable;
    private readonly IRendenrableModifier _modifier;

    public ModifierParagraph(
        IParagraph renderable,
        IRendenrableModifier modifier)
    {
        _renderable = renderable;
        _modifier = modifier;
    }

    public string Render()
    {
        return _modifier.Modify(_renderable.Render());
    }
}