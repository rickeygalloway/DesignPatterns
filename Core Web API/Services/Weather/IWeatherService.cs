using Core_Web_API.Model.Weather;

namespace Core_Web_API.Services.Weather
{
	public interface IWeatherService
	{
		Task<WeatherForecast> GetWeatherForecast(string postalCode);
	}
}