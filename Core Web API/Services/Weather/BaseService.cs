using Core_Web_API.Model.Weather;

namespace Core_Web_API.Services.Weather
{
	public abstract class BaseService
	{
		protected WeatherForecast SampleWeatherForecast = new WeatherForecast
		{
			City = "Sample City",
			State = "Sample State",
			RawDate = DateTime.Now.Date,
			TemperatureC = 5,
			Summary = "Sample Summary",
			RainChance = 0
		};
	}
}
