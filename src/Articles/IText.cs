namespace Articles;

public interface IText<T> : IRenderable
    where T : IText<T>
{
    T Clone();

    T AddModifier(IRenderableModifier modifier);
}