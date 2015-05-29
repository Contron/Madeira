using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Resources
{
	/// <summary>
	/// Represents an OpenGL texture.
	/// </summary>
	public class Texture
	{
		/// <summary>
		/// Creates a new texture.
		/// </summary>
		/// <param name="id">the ID</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		internal Texture(int id, int width, int height)
		{
			this.ID = id;

			this.Width = width;
			this.Height = height;
		}

		/// <summary>
		/// Returns a string representation of the texture.
		/// </summary>
		/// <returns>a string representation</returns>
		public override string ToString()
		{
			return string.Format("Texture (ID: {0}, Width: {1}, Height: {2})", this.ID, this.Width, this.Height);
		}

		/// <summary>
		/// Binds the texture.
		/// </summary>
		public void Bind()
		{
			GL.Enable(EnableCap.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, this.ID);
		}

		/// <summary>
		/// Unbinds the texture.
		/// </summary>
		public void Unbind()
		{
			GL.Disable(EnableCap.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, 0);
		}

		/// <summary>
		/// Gets the ID of the texture.
		/// </summary>
		public int ID
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the width of the texture.
		/// </summary>
		public int Width
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the height of the texture.
		/// </summary>
		public int Height
		{
			get;
			private set;
		}
	}
}
