using System;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core_Web_API.Model.Weather;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core_Web_API.Services.Weather.WeatherApiService
{
	public class WeatherApiService : BaseService, IWeatherService
	{
		private static readonly HttpClient httpClient = new HttpClient();

		public async Task<WeatherForecast> GetWeatherForecast(string postalCode)
		{
			var apiUrl = $"http://api.weatherapi.com/v1/current.json?key={key}&q={postalCode}&aqi=no";

			var response = await httpClient.GetAsync(apiUrl);
			if (response.IsSuccessStatusCode)
			{
				var weatherForecast = new WeatherForecast();

				try
				{
					var json = await response.Content.ReadAsStringAsync();
					var responseData = JsonSerializer.Deserialize<WeatherApiResponseData>(json);

					if (responseData != null)
					{
						// Map the response data to your WeatherForecast model
						weatherForecast = new WeatherForecast
						{
							City = responseData.Location.Name,
							State = responseData.Location.Region,
							RawDate = DateTime.Now.Date,
							TemperatureC = responseData.Current.Temp_c,
							Summary = responseData.Current.Condition.Text,
							RainChance = responseData.Current.Precip_mm
						};
					}
				}
				catch (Exception ex)
				{
					//just return sample for now
					return this.SampleWeatherForecast;
					//System.Diagnostics.Debug.WriteLine(ex.Message);
					//throw;
				}

				return weatherForecast;
			}

			throw new Exception($"Failed to retrieve weather forecast. Status code: {response.StatusCode}");
		}
	}
}