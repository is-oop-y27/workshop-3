using System.Drawing;

namespace Articles.Modifiers;

public class ColorModifier(Color color) : IRenderableModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Rgb(color.R, color.G, color.B).Text(value);
    }
}