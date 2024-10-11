namespace Articles.Renderables;

public class Text : IText<Text>
{
    private readonly List<IRendenrableModifier> _modifiers;

    public Text(string value)
    {
        Value = value;
        _modifiers = [];
    }

    private Text(string value, IEnumerable<IRendenrableModifier> modifiers)
    {
        Value = value;
        _modifiers = modifiers.ToList();
    }

    public string Value { get; set; }

    public string Render()
    {
        return _modifiers.Aggregate(
            Value,
            (v, m) => m.Modify(v));
    }

    public Text Clone()
        => new Text(Value, _modifiers);

    public Text AddModifier(IRendenrableModifier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }
}