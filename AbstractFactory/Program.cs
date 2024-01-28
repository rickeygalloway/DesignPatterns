// See https://aka.ms/new-console-template for more information
using AbstractFactory;

Console.WriteLine("Factory Pattern #1");
var belgiumShoppingCartFactory = new BelguimShoppingCartPurchaseFactory();
var shoppingCart = new ShoppingCart(belgiumShoppingCartFactory);
shoppingCart.CalculateCost();

var franceShoppingCartFactory = new FranceShoppingCartPurchaseFactory();
shoppingCart = new ShoppingCart(franceShoppingCartFactory);
shoppingCart.CalculateCost();

Console.WriteLine("Factory Pattern #2");

var cart = ShoppingCartFactory.GetShoppingCart(ShoppingCountry.Belgium);
shoppingCart = new ShoppingCart(cart);
shoppingCart.CalculateCost();

cart = ShoppingCartFactory.GetShoppingCart(ShoppingCountry.France);
shoppingCart = new ShoppingCart(cart);
shoppingCart.CalculateCost();
Console.ReadKey();