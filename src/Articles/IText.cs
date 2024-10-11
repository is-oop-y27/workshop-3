namespace Articles;

public interface IText<T> : IRenderable
    where T : IText<T>
{
    string Value { get; set; }

    T Clone();

    T AddModifier(IRendenrableModifier modifier);
}