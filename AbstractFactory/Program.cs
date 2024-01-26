// See https://aka.ms/new-console-template for more information
using AbstractFactory;

Console.WriteLine("Hello, World!");

var belgiumShoppingCartFactory = new BelguimShoppingCaredPurchaseFactory();
var shoppingCart = new ShoppingCart(belgiumShoppingCartFactory);
shoppingCart.CalculateCost();

var franceShoppingCartFactory = new FranceShoppingCaredPurchaseFactory();
shoppingCart = new ShoppingCart(franceShoppingCartFactory);
shoppingCart.CalculateCost();

Console.ReadKey();