namespace DesignPatterns;

public class Point
{
    double x,y;

    // this is private so that no one directly creates Point instance
    private Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point NewCartesianPoint(double x, double y)
    {
        return new Point(x,y);
    }

    public static Point NewPolarPoint(double rho, double theta)
    {
        return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }

    public override string ToString()
    {
        return $"x = {x}, y = {y}";
    }
}

class Factory
{
    public static void Execute()
    {
        Console.WriteLine("----- Factory -----");

        var cPoint = Point.NewCartesianPoint(10,20);
        Console.WriteLine($"Cartesian Point : {cPoint}");

        var pPoint = Point.NewPolarPoint(10,90);
        Console.WriteLine($"Polar Point : {pPoint}");
    }
}