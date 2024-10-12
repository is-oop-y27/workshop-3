namespace Articles.Renderables;

public class Text : IText<Text>
{
    private readonly List<IRenderableModifier> _modifiers;

    public Text(string value)
    {
        Value = value;
        _modifiers = [];
    }

    private Text(string value, IEnumerable<IRenderableModifier> modifiers)
    {
        Value = value;
        _modifiers = modifiers.ToList();
    }

    public string Value { get; set; }

    public Text Clone()
        => new(Value, _modifiers);

    public string Render()
    {
        return _modifiers.Aggregate(
            Value,
            (v, m) => m.Modify(v));
    }

    public Text AddModifier(IRenderableModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }
}