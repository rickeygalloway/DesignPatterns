using System.Net;
using Core_Web_API.Model.Weather;
using Core_Web_API.Services.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Core_Web_API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet("{postalCode}", Name = "GetWeatherForecast")]
		[ProducesResponseType(typeof(WeatherForecast), (int)HttpStatusCode.OK)]
		[SwaggerOperation(
			Summary = "Get the weather forecast based on postal code",
			Description = "Retrieves the weather forecast for a specific location."
		)]
		public async Task<WeatherForecast> GetAsync([SwaggerParameter("The postal code of the location for which the weather forecast is requested", Required = true)] string postalCode,
			[SwaggerParameter("The type of API to use for retrieving the weather forecast. Valid values are 'weatherapi' and 'openweathermap'.", Required = false)] string apiType = "weatherapi")
		{
			var service = WeatherServiceFactory.GetWeatherService(apiType);

			var weatherForecast = await service.GetWeatherForecast(postalCode);
			weatherForecast.Notes = apiType;

			return weatherForecast;
		}
	}
}