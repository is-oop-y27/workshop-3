namespace Articles.Modifiers;

public class DimModifier : IRendenrableModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Dim(value);
    }
}