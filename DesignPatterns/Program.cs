using DesignPatterns;
using DesignPatternsPrototype;

// Builder is used to construct object without worrying about inner implementation
Builder.Execute();

// Fluent builder returns same type as base type so that function calls can be chained
FluentBuilder.Execute();

// Factory mainly solves the problem of having two constructors with same signature
Factory.Execute();

// Difference between factory & Abstract Factory is that in Abstract Factory we don't return concrete objects. We return either Abstract class or Interface
AbstractFactory.Execute();

// Prototype is used when we want to create a clone of an object
Prototype.Execute();

// Singleton is used when we want only one instance to be available, and no one should be able to create a new instance
Singleton.Execute();

// Adapter is used to enhance capabilities of existing class without modifying it
Adapter.Execute();

// Bridge is used to avoid cartesian products due to inheritance. Favour Aggregation over Composition
Bridge.Execute();


// Used to execute instructions one after another (eg. input validations)
ChainOfResponsibility.Execute();

// Used for defining high level implementation first, and then detailed implementation later using different strategies
Strategy.Execute();

// TBD
Composite.Execute();
Decorator.Execute();
Facade.Execute();
Flyweight.Execute();
Proxy.Execute();
Command.Execute();
Interpreter.Execute();
Iterator.Execute();
Mediator.Execute();
Memento.Execute();
NullObject.Execute();
Observer.Execute();
State.Execute();
TemplateMethod.Execute();
Visitor.Execute();