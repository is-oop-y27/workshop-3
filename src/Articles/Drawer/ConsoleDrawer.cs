namespace Articles.Drawer;

public class ConsoleDrawer : IDrawer
{
    public void Draw(IRenderable renderable)
    {
        Console.WriteLine(renderable.Render());
    }
}