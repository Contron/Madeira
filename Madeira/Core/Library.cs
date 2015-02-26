using Madeira.Core.Loaders;
using Madeira.Exceptions;
using Madeira.Resources;
using Madeira.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core
{
	/// <summary>
	/// Represents an asset library to load and consume resources.
	/// </summary>
	public class Library
	{
		/// <summary>
		/// Creates a new library.
		/// </summary>
		internal Library()
		{
			this.loaders = new Dictionary<Type, Loader>();

			this.RegisterDefaultLoaders();
		}

		/// <summary>
		/// Returns the resource for the specified file, loading it if necessary.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="file"></param>
		/// <returns></returns>
		public T Get<T>(string file)
		{
			//type
			var type = typeof(T);

			if (!this.loaders.ContainsKey(type))
			{
				throw new LibraryException("No appropriate loader.");
			}

			//load
			var path = this.LocateResource(file);
			var loader = (Loader<T>) this.loaders[type];
			var result = loader.Get(path);

			return result;
		}

		/// <summary>
		/// Registers a loader to handle the specified type.
		/// </summary>
		/// <param name="type">the type</param>
		/// <param name="loader">the loader</param>
		public void RegisterLoader(Type type, Loader loader)
		{
			//debug
			Debug.Information("Registering loader for type '{0}'...", type.Name);

			//set
			this.loaders[type] = loader;
		}

		/// <summary>
		/// Registers the default loaders.
		/// </summary>
		private void RegisterDefaultLoaders()
		{
			//add
			this.RegisterLoader(typeof(Texture), new TextureLoader());
			this.RegisterLoader(typeof(Sound), new SoundLoader());
		}

		/// <summary>
		/// Locates the full path for the specified file, attempting to locate it with three attempts.
		/// The first attempt will search in the resources folder.
		/// The second attempt will search two levels up in the resources folder (in the case of Debug mode).
		/// The third attempt will search simply for the file on its own.
		/// </summary>
		/// <param name="file">the file</param>
		/// <returns>the full path</returns>
		private string LocateResource(string file)
		{
			//root
			var root = Path.Combine(Directory.GetCurrentDirectory());

			//directories
			var mainPath = Path.Combine(root, Library.Resources, file);
			var fallbackPath = Path.Combine(root, "..", "..", Library.Resources, file);
			var absolutePath = file;

			if (File.Exists(mainPath))
			{
				return mainPath;
			}

			if (File.Exists(fallbackPath))
			{
				return fallbackPath;
			}

			if (File.Exists(absolutePath))
			{
				return absolutePath;
			}

			throw new LibraryException("Resource not found.");
		}

		/// <summary>
		/// Gets the path to the resources folder.
		/// </summary>
		public static readonly string Resources = "Resources";

		private Dictionary<Type, Loader> loaders;
	}
}
