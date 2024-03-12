namespace DesignPatterns;

class AbstractFactory()
{
    public static void Execute()
    {
        Console.WriteLine("----- Abstract Factory -----");
        Console.WriteLine("Difference between factory & Abstract Factory is that in Abstract Factory we don't return concrete objects. We return Abstract class or Interface");
    }
}