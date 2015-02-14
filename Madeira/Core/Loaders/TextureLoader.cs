using Madeira.Resources;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core.Loaders
{
	/// <summary>
	/// Represents the loader for loading textures.
	/// </summary>
	public class TextureLoader : Loader<Texture>
	{
		/// <summary>
		/// Loads a texture from the specified file.
		/// </summary>
		/// <param name="file">the file</param>
		/// <returns>the texture</returns>
		protected override Texture Load(string file)
		{
			//bitmap
			var bitmap = new Bitmap(file);
			var width = bitmap.Width;
			var height = bitmap.Height;
			var bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			//id
			var id = GL.GenTexture();

			//binding
			GL.BindTexture(TextureTarget.Texture2D, id);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Nearest);

			//create
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);

			//free
			bitmap.UnlockBits(bitmapData);
			bitmap.Dispose();

			return new Texture(id, width, height);
		}
	}
}
