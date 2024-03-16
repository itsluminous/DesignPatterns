namespace DesignPatterns;

class Creature
{
    public string Name;
    public int Attack, Defense;

    public Creature(string name, int attack, int defence)
    {
        Name = name;
        Attack = attack;
        Defense = defence;
    }

    public override string ToString()
    {
        return $"{Name} has attack of {Attack} and defence of {Defense}";
    }
}

class CreatureModifier
{
    protected Creature creature;
    CreatureModifier next;
    public CreatureModifier(Creature creature)
    {
        if(creature == null)
            throw new ArgumentNullException(nameof(creature));
        this.creature = creature;
    }

    public void Add(CreatureModifier cm)
    {
        if(next == null)
            next = cm;
        else
            next.Add(cm);
    }

    public virtual void Handle() => next?.Handle();
}

class NoBonusesModifier : CreatureModifier
{
    public NoBonusesModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
        Console.WriteLine($"From now, no effect of new bonuses for {creature.Name}");
        // we don't call base.Handle() here to stop the chain
    }
}

class DoubleAttackModifier : CreatureModifier
{
    public DoubleAttackModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
        Console.WriteLine($"Doubling the attack for {creature.Name}");
        creature.Attack *= 2;
        base.Handle();
    }
}

class IncreaseDefenseModifier : CreatureModifier
{
    public IncreaseDefenseModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
        Console.WriteLine($"Increasing defence by 2 for {creature.Name}");
        creature.Defense += 2;
        base.Handle();
    }
}

class MinusOneAttackModifier : CreatureModifier
{
    public MinusOneAttackModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
        Console.WriteLine($"Reducing attack by 1 for {creature.Name}");
        creature.Attack--;
        base.Handle();
    }
}

class ChainOfResponsibility
{
    public static void Execute()
    {
        Console.WriteLine("----- ChainOfResponsibility -----");
        var goblin = new Creature("Goblin", 2, 2);
        Console.WriteLine(goblin);

        var modifiers = new CreatureModifier(goblin); 
        modifiers.Add(new NoBonusesModifier(goblin));       // comment this out so that other bonuses can be applied in chain
        modifiers.Add(new DoubleAttackModifier(goblin));
        modifiers.Add(new IncreaseDefenseModifier(goblin));
        modifiers.Add(new MinusOneAttackModifier(goblin));

        modifiers.Handle();

        Console.WriteLine(goblin);
    }
}