namespace Core_Web_API.Services.Weather
{
	using System;

	public class WeatherServiceException : Exception
	{
		public WeatherServiceException(string message) : base(message)
		{
		}
	}
}