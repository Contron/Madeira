using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Utilities
{
	/// <summary>
	/// A collection of useful debug utilities.
	/// </summary>
	public static class Debug
	{
		/// <summary>
		/// Writes formatted information to the console.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="arguments">the format arguments</param>
		public static void Information(string message, params object[] arguments)
		{
			Debug.Information(string.Format(message, arguments));
		}

		/// <summary>
		/// Writes information to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Information(string message)
		{
			Debug.WriteLine(ConsoleColor.Cyan, message);
		}

		/// <summary>
		/// Writes a warning message to the console.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="arguments">the format arguments</param>
		public static void Warning(string message, params object[] arguments)
		{
			Debug.Warning(string.Format(message, arguments));
		}

		/// <summary>
		/// Writes a formatted warning to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Warning(string message)
		{
			Debug.WriteLine(ConsoleColor.Yellow, message);
		}

		/// <summary>
		/// Writes a formatted error message to the console.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="arguments">the format arguments</param>
		public static void Error(string message, params object[] arguments)
		{
			Debug.Error(string.Format(message, arguments));
		}

		/// <summary>
		/// Writes an error to the console.
		/// </summary>
		/// <param name="message">the message</param>
		public static void Error(string message)
		{
			Debug.WriteLine(ConsoleColor.Red, message);
		}

		/// <summary>
		/// Writes the specified message line with the specified colour and formatting options to the console.
		/// </summary>
		/// <param name="consoleColor">the console colour</param>
		/// <param name="message">the message</param>
		/// <param name="arguments">the arguments</param>
		public static void WriteLine(ConsoleColor consoleColor, string message, params object[] arguments)
		{
			Debug.WriteLine(consoleColor, string.Format(message, arguments));
		}

		/// <summary>
		/// Writes the specified message line with the specified colour to the console.
		/// </summary>
		/// <param name="consoleColor">the console colour</param>
		/// <param name="message">the message</param>
		public static void WriteLine(ConsoleColor consoleColor, string message)
		{
			Debug.Write(consoleColor, message + Environment.NewLine);
		}

		/// <summary>
		/// Writes the specified message with the specified colour to the console.
		/// </summary>
		/// <param name="consoleColor">the console colour</param>
		/// <param name="message">the message</param>
		public static void Write(ConsoleColor consoleColor, string message)
		{
			Console.ForegroundColor = consoleColor;
            Console.Write(string.Format("[{0}] {1}", DateTime.Now.ToString("HH:mm:ss"), message));
			Console.ResetColor();
		}
	}
}
