namespace DesignPatternsPrototype;

public interface IDeepCopyable<T> where T : new()
{
    void CopyTo(T target);

    public T DeepCopy()
    {
        T clone = new T();
        CopyTo(clone);
        return clone;
    }
}

public class Address : IDeepCopyable<Address>
{
    public string StreetName;
    public int HouseNumber;

    public Address() { }

    public Address(string streetName, int houseNumber)
    {
        StreetName = streetName;
        HouseNumber = houseNumber;
    }

    public void CopyTo(Address target)
    {
        target.StreetName = StreetName;
        target.HouseNumber = HouseNumber;
    }

    public override string ToString()
    {
        return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }
}

public class Person : IDeepCopyable<Person>
{
    public string[] Names;
    public Address Address;

    public Person() { }

    public Person(string[] names, Address address)
    {
        Names = names;
        Address = address;
    }

    public virtual void CopyTo(Person target)
    {
        target.Names = (string[])Names.Clone();
        target.Address = Address.DeepCopy();  // this uses extension method
    }

    public override string ToString()
    {
        return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
    }
}

public class Employee : Person, IDeepCopyable<Employee>
{
    public int Salary;

    public void CopyTo(Employee target)
    {
        base.CopyTo(target);
        target.Salary = Salary;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
    }
}

public static class DeepCopyExtensions
{
    public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new()
    {
        return item.DeepCopy();
    }

    public static T DeepCopy<T>(this T person) where T : Person, new()
    {
        return ((IDeepCopyable<T>) person).DeepCopy();
    }
}

class Prototype
{
    public static void Execute()
    {
        Console.WriteLine("----- Prototype -----");
        var john = new Employee
        {
            Names = ["John", "Doe"],
            Address = new Address { HouseNumber = 123, StreetName = "London Road" },
            Salary = 321000
        };
        var copy = john.DeepCopy();

        copy.Names[1] = "Smith";
        copy.Address.HouseNumber++;
        copy.Salary = 123000;
        
        Console.WriteLine(john);
        Console.WriteLine(copy);
    }
}