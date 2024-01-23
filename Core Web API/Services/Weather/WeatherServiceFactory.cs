namespace Core_Web_API.Services.Weather
{
	public static class WeatherServiceFactory
	{
		public static IWeatherService GetWeatherService(string serviceName)
		{
			switch (serviceName.ToLower())
			{
				case "openweathermap":
					return new Core_Web_API.Services.Weather.OpenWeatherMapService.OpenWeatherMapService();

				case "weatherapi":
					return new Core_Web_API.Services.Weather.WeatherApiService.WeatherApiService();

				default:
					throw new NotSupportedException($"Weather service provider '{serviceName}' is not supported.");
			}
		}
	}
}