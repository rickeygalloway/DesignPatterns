// See https://aka.ms/new-console-template for more information
using ObjectAdapter;
using ClassAdapter;

Console.WriteLine("Object Adapter");

ObjectAdapter.ICityAdapter adapter = new ObjectAdapter.CityAdapter();

var city = adapter.GetCity();

Console.WriteLine($"		City: {city.FullName} , {city.Population}");

Console.WriteLine("Object Adapter");

ClassAdapter.ICityAdapter classAdapter = new ClassAdapter.CityAdapter();

var classCity = classAdapter.GetCity();

Console.WriteLine($"		City: {classCity.FullName} , {classCity.Population}");
Console.ReadLine();