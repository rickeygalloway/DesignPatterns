using System.Text.Json.Serialization;

namespace Core_Web_API.Services.Weather.WeatherApiService
{
	public class WeatherApiResponseData
	{
		[JsonPropertyName("location")]
		public LocationData Location { get; set; }

		[JsonPropertyName("current")]
		public CurrentWeatherData Current { get; set; }
	}

	public class LocationData
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("region")]
		public string Region { get; set; }

		[JsonPropertyName("country")]
		public string Country { get; set; }
	}

	public class CurrentWeatherData
	{
		[JsonPropertyName("temp_c")]
		public float Temp_c { get; set; }

		[JsonPropertyName("condition")]
		public WeatherCondition Condition { get; set; }

		[JsonPropertyName("precip_mm")]
		public float Precip_mm { get; set; }
	}

	public class WeatherCondition
	{
		[JsonPropertyName("text")]
		public string Text { get; set; }

		[JsonPropertyName("icon")]
		public string Icon { get; set; }
	}
}