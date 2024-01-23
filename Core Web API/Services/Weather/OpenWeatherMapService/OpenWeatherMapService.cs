namespace Core_Web_API.Services.Weather.OpenWeatherMapService
{
	using System.Threading.Tasks;
	using Core_Web_API.Model.Weather;

	public class OpenWeatherMapService : BaseService, IWeatherService
	{
		// Implement the OpenWeatherMap API calls here

		public async Task<WeatherForecast> GetWeatherForecast(string postalCode)
		{
			return this.SampleWeatherForecast;
		}
	}
}