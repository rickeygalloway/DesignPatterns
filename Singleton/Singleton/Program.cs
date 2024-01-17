using Singleton;

Console.Title = "Singleton";
var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if (instance1 == instance2) {
	Console.WriteLine("Instances are the same");
}

instance1.Log($"Message from {nameof(instance1)}");
instance1.Log($"Message from {nameof(instance2)}");
Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");

// See https://aka.ms/new-console-template for more information
Console.ReadLine();