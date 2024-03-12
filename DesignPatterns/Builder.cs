using System.Text;

namespace DesignPatterns;


public class HtmlElement
{
    public string Name, Text;
    public List<HtmlElement> Elements = new List<HtmlElement>();
    private const int indentSize = 2;

    public HtmlElement(){}

    public HtmlElement(string name, string text)
    {
        this.Name = name;
        this.Text = text;
    }
    
    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var ind = new string(' ', indent*indentSize);
        sb.AppendLine($"{ind}<{Name}>");

        if(!string.IsNullOrEmpty(Text))
            sb.AppendLine(new string(' ', (indent+1)*indentSize) + Text);

        foreach(var element in Elements)
            sb.Append(element.ToStringImpl(indent + 1));

        sb.AppendLine($"{ind}</{Name}>");
        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }
}

class HtmlBuilder
{
    HtmlElement root = new();

    public HtmlBuilder(string rootName) => root.Name = rootName;

    public void AddChild(string childName, string childText)
    {
        var child = new HtmlElement(childName, childText);
        root.Elements.Add(child);
    }

    public HtmlBuilder AddChildFluent(string childName, string childText)
    {
        var child = new HtmlElement(childName, childText);
        root.Elements.Add(child);
        return this;
    }

    public override string ToString()
    {
        return root.ToString();
    }
}

class Builder()
{
    public static void Execute()
    {
        Console.WriteLine("----- Builder -----");
        var builder = new HtmlBuilder("ul");

        // non-fluent builder
        builder.AddChild("li", "Potato");
        builder.AddChild("li", "Brinjal");

        // fluent builder
        builder.AddChildFluent("li", "Apple").AddChildFluent("li", "Banana");
        Console.WriteLine(builder);
    }
}