﻿using DesignPatterns;

// Builder is used to construct object without worrying about inner implementation
Builder.Execute();

// Fluent builder returns same type as base type so that function calls can be chained
FluentBuilder.Execute();

// Factory mainly solves the problem of having two constructors with same signature
Factory.Execute();

// Difference between factory & Abstract Factory is that in Abstract Factory we don't return concrete objects. We return either Abstract class or Interface
AbstractFactory.Execute();