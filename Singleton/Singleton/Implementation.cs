using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
	public class Logger
	{
		private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());

		//Lazy<T> above replaces this 
		//private static Logger? _instance;

		public static Logger Instance
		{
			get
			{
				return _lazyLogger.Value;

				//Replaced by line above
				//if (_instance == null)
				//{
				//	_instance = new Logger();
				//}

				//return _instance;
			}
		}

		protected Logger() { }


		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
}