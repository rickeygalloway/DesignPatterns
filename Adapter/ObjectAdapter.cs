using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAdapter
{
	public class CityFromExternalSystem
	{
		public string Name { get; private set; }
		public string NickName { get; private set; }
		public int Population { get; private set; }

		public CityFromExternalSystem(string name, string nickName, int population)
		{
			Name = name;
			NickName = nickName;
			Population = population;
		}
	}

	public class ExternalSystem
	{
		public CityFromExternalSystem GetCity()
		{
			return new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
		}
	}

	public class City
	{
		public string FullName { get; private set; }
		public long Population { get; private set; }

		public City(string fullName, long population)
		{
			FullName = fullName;
			Population = population;
		}
	}

	public interface ICityAdapter
	{
		City GetCity();
	}

	public class CityAdapter : ICityAdapter
	{
		public ExternalSystem ExternalSystem { get; private set; } = new();

		public City GetCity()
		{
			var cityFromExternalSystem = ExternalSystem.GetCity();

			return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}", cityFromExternalSystem.Population);
		}
	}
}