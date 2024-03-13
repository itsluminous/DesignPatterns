namespace DesignPatterns;

interface IDatabase<T>
{
    bool Add(T key);
    bool Remove(T key);
    string GetAll();
}

// Singleton 
class FruitDatabase : IDatabase<string>
{
    private HashSet<string> Fruits;

    private FruitDatabase() =>  Fruits = new HashSet<string>();

    private static FruitDatabase instance = new FruitDatabase();
    public static FruitDatabase Instance => instance;

    public bool Add(string fruit) =>  Fruits.Add(fruit);

    public bool Remove(string fruit) => Fruits.Remove(fruit);

    public string GetAll() => string.Join(", ", Fruits);
}

class Singleton
{
    public static void Execute()
    {
        Console.WriteLine("----- Singleton -----");
        var db = FruitDatabase.Instance;
        db.Add("Apple");
        db.Add("Banana");
        db.Add("Mango");
        db.Remove("Apple");
        Console.WriteLine(db.GetAll());
    }
}