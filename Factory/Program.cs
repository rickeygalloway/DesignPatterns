using Factory;

var factories = new List<DiscountFactory> {
	new CodeDiscountFactory(Guid.NewGuid()),
	new CountryDiscountFactory("BE")
};

foreach (var fact in factories)
{
	var service = fact.CreateDiscountService();
	Console.WriteLine($"Percentage {service.DiscountPercentage} " + $"from {service}");
}

Console.ReadLine();
