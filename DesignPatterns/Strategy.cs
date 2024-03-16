using System.Text;

namespace DesignPatterns;

public enum OutputFormat
{
    Html,
    Markdown
}

interface IListStrategy
{
    void Start(StringBuilder sb);
    void End(StringBuilder sb);
    void AddListItem(StringBuilder sb, string item);
}

public class HtmlListStrategy : IListStrategy
{
    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($"  <li> {item} </li");
    }

    public void End(StringBuilder sb)
    {
        sb.AppendLine("</ul>");
    }

    public void Start(StringBuilder sb)
    {
        sb.AppendLine("<ul>");
    }
}

public class MarkdownListStrategy : IListStrategy
{
    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($"* {item}");
    }

    public void End(StringBuilder sb)
    {
    }

    public void Start(StringBuilder sb)
    {   
    }
}

public class TextProcessor
{
    IListStrategy strategy;
    StringBuilder sb = new StringBuilder();
    public void SetOutputFormat(OutputFormat format)
    {
        switch (format){
            case OutputFormat.Html:
                strategy = new HtmlListStrategy();
                break;
            case OutputFormat.Markdown:
                strategy = new MarkdownListStrategy();
                break;
            default:
                throw new ArgumentException(nameof(format));
        }
    }

    public void AppendList(IEnumerable<string> listItems)
    {
        if(strategy is null)
            throw new Exception("Initialize strategy first");

        strategy.Start(sb);
        foreach(var li in listItems)
            strategy.AddListItem(sb, li);
        strategy.End(sb);
    }

    public void Clear() => sb.Clear();

    public override string ToString() => sb.ToString();
}

class Strategy
{
    public static void Execute()
    {
        Console.WriteLine("----- Strategy -----");
        var list = new []{"apple", "banana", "grapes"};
        var tp = new TextProcessor();

        tp.SetOutputFormat(OutputFormat.Html);
        tp.AppendList(list);
        Console.WriteLine(tp);

        tp.Clear();

        tp.SetOutputFormat(OutputFormat.Markdown);
        tp.AppendList(list);
        Console.WriteLine(tp);
    }
}