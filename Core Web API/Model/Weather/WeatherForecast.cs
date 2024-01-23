using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Core_Web_API.Model.Weather
{
	public class WeatherForecast
	{
		internal string? City { private get; set; }
		internal string? State { private get; set; }
		public string? Location => City + ", " + State;

		internal DateTime RawDate { private get; set; }
		public string Date => RawDate.ToString("MMMM d, yyyy hh:mm tt");

		public float TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string? Summary { get; set; }

		public float RainChance { get; set; }

		public string? Notes { get; set; }
	}

}