using DesignPatterns;
using DesignPatternsPrototype;

// Builder is used to construct object without worrying about inner implementation
Builder.Execute();

// Fluent builder returns same type as base type so that function calls can be chained
FluentBuilder.Execute();

// Factory mainly solves the problem of having two constructors with same signature
// Also, it is used when instead of me creating objects, I just ask Factory to give me an object which follows certain rules
Factory.Execute();

// Difference between factory & Abstract Factory is that in Abstract Factory we don't return concrete objects. We return either Abstract class or Interface
// So abstract factory is a factory of factories
// Refer : https://www.youtube.com/watch?v=5hXZnI86E2Y
AbstractFactory.Execute();

// Prototype is used when we want to create a clone of an object
Prototype.Execute();

// Singleton is used when we want only one instance to be available, and no one should be able to create a new instance
Singleton.Execute();

// Adapter is used to enhance capabilities of existing class without modifying it
// better example : https://www.youtube.com/watch?v=eR22JuwTa54
Adapter.Execute();

// Bridge is used to avoid cartesian products due to inheritance. Favour Aggregation over Composition
Bridge.Execute();


// Used to execute instructions one after another (eg. input validations)
ChainOfResponsibility.Execute();

// Used for defining high level implementation first, and then detailed implementation later using different strategies
Strategy.Execute();

// TBD
Composite.Execute();

Facade.Execute();   // Eg: https://www.youtube.com/watch?v=Dv88HvVeo3M
Flyweight.Execute();    // Eg. https://www.youtube.com/watch?v=8cL9KbHS5kE

// When we want to add new functionality to an existing object without inheriting (because parent may be sealed), so maintain OCP
Decorator.Execute();
Proxy.Execute();
Command.Execute();
Interpreter.Execute();
Iterator.Execute();
Mediator.Execute();
Memento.Execute();
NullObject.Execute();
Observer.Execute();
State.Execute();    // Eg. https://www.youtube.com/watch?v=wOXs5Z_z0Ew
TemplateMethod.Execute();
Visitor.Execute();

// Decorator
// Observer