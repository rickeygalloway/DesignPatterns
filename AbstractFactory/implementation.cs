using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
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

	public class BelguimShoppingCaredPurchaseFactory : IShoppingCartPurchaseFactory
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

	public class FranceShoppingCaredPurchaseFactory : IShoppingCartPurchaseFactory
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
			Console.WriteLine("Total Cost: " + (_orderCost - (_orderCost / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCost));
		}
	}
}