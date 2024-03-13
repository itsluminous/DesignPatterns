public interface IRenderer
{
    void Render(float radius);
}

public class VectorRenderer : IRenderer
{
    public void Render(float radius)
    {
      Console.WriteLine($"Drawing a circle of radius {radius}");
    }
}

public class RasterRenderer : IRenderer
{
    public void Render(float radius)
    {
      Console.WriteLine($"Drawing pixels for a circle of radius {radius}");
    }
}

abstract class Shape
{
    protected IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
}

class Circle : Shape
{
    float radius;
    public Circle(IRenderer renderer, float radius) : base(renderer)
    {
        this.radius = radius;
    }

    public override void Draw()
    {
        renderer.Render(radius);
    }
}

class Bridge()
{
    public static void Execute()
    {
        Console.WriteLine("----- Bridge -----");
        var renderer = new VectorRenderer();
        var circle = new Circle(renderer, 9);
        circle.Draw();
    }
}