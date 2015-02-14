using Madeira.Exceptions;
using Madeira.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core
{
	/// <summary>
	/// Represents a loader to load resources from file.
	/// </summary>
	public abstract class Loader
	{

	}
	
	/// <summary>
	/// Represents a loader for the specified type.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class Loader<T> : Loader
	{
		/// <summary>
		/// Creates a new loader.
		/// </summary>
		internal Loader()
		{
			this.resources = new Dictionary<string, T>();
		}

		/// <summary>
		/// Returns the resource for the specified file, loading it if necessary.
		/// </summary>
		/// <param name="file">the file</param>
		/// <returns>the resource</returns>
		public T Get(string file)
		{
			if (!this.resources.ContainsKey(file))
			{
				//debug
				Debug.Information("Loading resource '{0}'...", file);

				try
				{
					//load
					this.resources[file] = this.Load(file);
				}
				catch (Exception exception)
				{
					throw new LibraryException("Could not load resource.", exception);
				}
			}

			return this.resources[file];
		}

		/// <summary>
		/// Loads a resource from the specified file.
		/// </summary>
		/// <param name="file">the file</param>
		/// <returns>the resource</returns>
		protected virtual T Load(string file)
		{
			return default(T);
		}

		private Dictionary<string, T> resources;
	}
}
