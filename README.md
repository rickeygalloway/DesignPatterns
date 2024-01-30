# C# Design Patterns
Plurasight course used to get back up to speed with .NET.  Lots of work on design patterns and newer .NET features.


# Tools
 - Visual Studio 2022
 - .NET 8
 - Pluralsight
 - Github


# Singleton Pattern - 2024-01-16

Creational pattern of a class to ensure it has only a single class instance.  Example: Logger, DB Connection, caching, configuration settings

Using Lazy<T> implementation


# Factory Method Pattern - 2024-01-16

Creational pattern that provides an interface for creating objects of similar types.  Code example was weird for this one.  This is more like I've done in the past:

```csharp
using System;

// Abstract Product
public interface IAnimal
{
    void MakeSound();
}

// Concrete Products
public class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}

// Factory
public static class AnimalFactory
{
    public static IAnimal CreateAnimal(string animalType)
    {
        switch (animalType.ToLower())
        {
            case "dog":
                return new Dog();
            case "cat":
                return new Cat();
            default:
                throw new ArgumentException("Invalid animal type.");
        }
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        IAnimal myAnimal = AnimalFactory.CreateAnimal("dog");
        myAnimal.MakeSound();  // Output: Woof!

        myAnimal = AnimalFactory.CreateAnimal("cat");
        myAnimal.MakeSound();  // Output: Meow!
    }
}
```


# Weather REST API - 2024-01-19

Creation API service for using different weather api services. Used AI to generate some of the tedious classes for me.

 - REST API
 - Factory Pattern
 - Third Party API
 - Swagger API documentation

 I will come back to build on this
 

# Abstract Factory Pattern - 2024-01-26

Creation pattern related to factory pattern above. Often called Factory Pattern.

# Adapter Pattern (Wrapper Pattern) - 2024-01-28

Structural pattern used to let classes work together because of incompatable interfaces. Object adapter and Class adapter

# Chain of Responsibility Pattern - 2024-01-28

Behavioral pattern used to set order of operations by chaining them together of events - example of usage:
```
var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain.SetSuccessor(new DocumentLastModifiedHandler())
	.SetSuccessor(new DocumentLastModifiedHandler())
	.SetSuccessor(new DocumentApprovedByLitigation())
	.SetSuccessor(new DocumentApprovedByManagment());
```
