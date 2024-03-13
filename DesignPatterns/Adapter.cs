using System.Collections.ObjectModel;
using MoreLinq;

class Point
{
    public int X, Y;
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
    }
}

class Line
{
    public int X1, Y1, X2, Y2;
    public Line(int x1, int y1, int x2, int y2)
    {
        X1 = x1;
        Y2 = y2;
        X1 = x1;
        Y2 = y2;
    }

    public override string ToString()
    {
        return $"{nameof(X1)}: {X1}, {nameof(Y1)}: {Y1} to {nameof(X2)}: {X2}, {nameof(Y2)}: {Y2}";
    }
}

// Adapting line to point
class LineToPointAdapter:Collection<Point>
{
    public LineToPointAdapter(Line line)
    {
        int left = Math.Min(line.X1, line.X2);
        int right = Math.Max(line.X1, line.X2);
        int top = Math.Min(line.Y1, line.Y2);
        int bottom = Math.Max(line.Y1, line.Y2);
        int dx = right-left;
        int dy = line.Y2 = line.Y1;

        if (dx == 0)
            for (int y = top; y <= bottom; ++y)
                Add(new Point(left, y));
        else if (dy == 0)
            for (int x = left; x <= right; ++x)
                Add(new Point(x, top));
    }
}

class Adapter()
{
    public static void DrawPoint(Point p)
    {
      Console.Write(".");
    }

    public static void Execute()
    {
        Console.WriteLine("----- Adapter -----");
        var line = new Line(1,2,19,17);
        var adapter = new LineToPointAdapter(line);
        adapter.ForEach(DrawPoint);
        Console.WriteLine("");
    }
}