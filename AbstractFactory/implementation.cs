using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
	public enum ShoppingCountry
	{
		Belgium,
		France
	}

	public interface IShoppingCartPurchaseFactory
	{
		IDiscountService CreateDiscountService();

		IShippingCostService CreateShippingCostService();
	}

	//Shipping Cost
	public interface IShippingCostService
	{
		decimal? ShippingCost { get; }
	}

	public class BelgiumShippingCostService : IShippingCostService
	{
		public decimal? ShippingCost => 20;
	}

	public class FranceShippingCostService : IShippingCostService
	{
		public decimal? ShippingCost => 25;
	}

	//Discount
	public interface IDiscountService
	{
		int DiscountPercentage { get; }
	}

	public class BelgiumDiscountService : IDiscountService
	{
		public int DiscountPercentage => 20;
	}

	public class FranceDiscountService : IDiscountService
	{
		public int DiscountPercentage => 10;
	}

	public class BelguimShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
	{
		public IDiscountService CreateDiscountService()
		{
			return new BelgiumDiscountService();
		}

		public IShippingCostService CreateShippingCostService()
		{
			return new BelgiumShippingCostService();
		}
	}

	public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
	{
		public IDiscountService CreateDiscountService()
		{
			return new FranceDiscountService();
		}

		public IShippingCostService CreateShippingCostService()
		{
			return new FranceShippingCostService();
		}
	}

	public static class ShoppingCartFactory
	{
		public static IShoppingCartPurchaseFactory GetShoppingCart(ShoppingCountry country)
		{
			IShoppingCartPurchaseFactory factory;
			switch (country)
			{
				case ShoppingCountry.France:
					factory = new FranceShoppingCartPurchaseFactory();
					break;

				case ShoppingCountry.Belgium:
					factory = new BelguimShoppingCartPurchaseFactory();
					break;

				default:
					throw new ArgumentException("Invalid shopping country.");
			}

			return factory ?? throw new Exception("Factory not initialized.");
		}
	}

	public class ShoppingCart
	{
		private readonly IDiscountService _discountService;
		private readonly IShippingCostService _shippingCostService;
		private int _orderCost;

		public ShoppingCart(IShoppingCartPurchaseFactory factory)
		{
			_discountService = factory.CreateDiscountService();
			_shippingCostService = factory.CreateShippingCostService();
			_orderCost = 200;
		}

		public void CalculateCost()
		{
			Console.WriteLine("			Total Cost: " + (_orderCost - (_orderCost / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCost));
		}
	}
}