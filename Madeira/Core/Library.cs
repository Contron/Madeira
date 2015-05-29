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
		public Library()
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
			var type = typeof(T);

			if (!this.loaders.ContainsKey(type))
			{
				throw new LibraryException("No appropriate loader.");
			}

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
		public void Register(Type type, Loader loader)
		{
			Debug.Information("Registering loader for type '{0}'...", type.Name);

			this.loaders[type] = loader;
		}

		private void RegisterDefaultLoaders()
		{
			this.Register(typeof(Texture), new TextureLoader());
			this.Register(typeof(Sound), new SoundLoader());
		}

		private string LocateResource(string file)
		{
			var root = Path.Combine(Directory.GetCurrentDirectory());

			var mainFile = Path.Combine(root, Library.Resources, file);
			var fallbackFile = Path.Combine(root, "..", "..", Library.Resources, file);

            if (File.Exists(mainFile))
			{
                return mainFile;
			}

            if (File.Exists(fallbackFile))
			{
                return fallbackFile;
			}

			if (File.Exists(file))
			{
                return file;
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
