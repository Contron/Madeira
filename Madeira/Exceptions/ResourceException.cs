using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Exceptions
{
	/// <summary>
	/// Represents a resource exception.
	/// </summary>
	public class ResourceException : Exception
	{
		/// <summary>
		/// Creates a new resource exception.
		/// </summary>
		/// <param name="message">the message</param>
		/// <param name="innerException">the inner exception</param>
		public ResourceException(string message, Exception innerException = null) : base(message, innerException)
		{

		}
	}
}
