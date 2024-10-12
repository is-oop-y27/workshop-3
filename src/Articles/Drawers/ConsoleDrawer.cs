namespace Articles.Drawers;

public class ConsoleDrawer : IDrawer
{
    public void Draw(IRenderable renderable)
    {
        Console.WriteLine(renderable.Render());
    }
}