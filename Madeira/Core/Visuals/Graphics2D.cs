using Madeira.Maths;
using Madeira.Resources;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core.Visuals
{
	/// <summary>
	/// A collection of abstracted 2D graphics methods for OpenGL.
	/// </summary>
	public static class Graphics2D
	{
		/// <summary>
		/// Rotates by the specified angle.
		/// </summary>
		/// <param name="angle">the angle</param>
		public static void Rotate(double angle)
		{
			GL.Rotate(angle, 0, 0, 1);
		}

		/// <summary>
		/// Translates to the specified position.
		/// </summary>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		public static void Translate(double x, double y)
		{
			GL.Translate(x, y, 0);
		}

		/// <summary>
		/// Scales by the specified amount.
		/// </summary>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		public static void Scale(double x, double y)
		{
			GL.Scale(x, y, 0);
		}

		/// <summary>
		/// Draws a rectangle.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		public static void DrawRectangle(Colour colour, double x, double y, double width, double height)
		{
			Graphics2D.DoRectangle(PrimitiveType.Lines, colour, null, x, y, width, height);
		}

		/// <summary>
		/// Draws a rectangle.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void DrawRectangle(Colour colour, Point position, Point size)
		{
			Graphics2D.DoRectangle(PrimitiveType.Lines, colour, null, position.X, position.Y, size.X, size.Y);
		}

		/// <summary>
		/// Fills a rectangle.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		public static void FillRectangle(Colour colour, double x, double y, double width, double height)
		{
			Graphics2D.DoRectangle(PrimitiveType.Quads, colour, null, x, y, width, height);
		}

		/// <summary>
		/// Fills a rectangle.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void FillRectangle(Colour colour, Point position, Point size)
		{
			Graphics2D.DoRectangle(PrimitiveType.Quads, colour, null, position.X, position.Y, size.X, size.Y);
		}

		/// <summary>
		/// Draws a texture.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the texture</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		public static void DrawTexture(Colour colour, Texture texture, double x, double y, double width, double height)
		{
			Graphics2D.DoRectangle(PrimitiveType.Quads, colour, texture, x, y, width, height);
		}

		/// <summary>
		/// Draws a texture.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the texture</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void DrawTexture(Colour colour, Texture texture, Point position, Point size)
		{
			Graphics2D.DoRectangle(PrimitiveType.Quads, colour, texture, position.X, position.Y, size.X, size.Y);
		}

		/// <summary>
		/// Draws a piece of text.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the font texture</param>
		/// <param name="text">the text</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="size">the size</param>
		public static void DrawText(Colour colour, Texture texture, string text, double x, double y, int size)
		{
			Graphics2D.DoText(colour, texture, text, x, y, size);
		}

		/// <summary>
		/// Draws a piece of text.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the font texture</param>
		/// <param name="text">the text</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void DrawText(Colour colour, Texture texture, string text, Point position, int size)
		{
			Graphics2D.DoText(colour, texture, text, position.X, position.Y, size);
		}

		/// <summary>
		/// Draws a point.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="size">the size</param>
		public static void DrawPoint(Colour colour, double x, double y, double size)
		{
			Graphics2D.DoPoint(colour, null, x, y, size);
		}

		/// <summary>
		/// Draws a point.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void DrawPoint(Colour colour, Point position, double size)
		{
			Graphics2D.DoPoint(colour, null, position.X, position.Y, size);
		}

		/// <summary>
		/// Draws a sprite.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the texture</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="size">the size</param>
		public static void DrawSprite(Colour colour, Texture texture, double x, double y, double size)
		{
			Graphics2D.DoPoint(colour, texture, x, y, size);
		}

		/// <summary>
		/// Draws a sprite.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the texture</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void DrawSprite(Colour colour, Texture texture, Point position, double size)
		{
			Graphics2D.DoPoint(colour, texture, position.X, position.Y, size);
		}

		/// <summary>
		/// Measures the length of the specified text.
		/// </summary>
		/// <param name="text">the text</param>
		/// <param name="size">the size</param>
		/// <returns>the length</returns>
		public static double MeasureText(string text, int size)
		{
			return (text.Length * size);
		}

		private static void DoRectangle(PrimitiveType primitiveType, Colour colour, Texture texture, double x, double y, double width, double height)
		{
			GL.PushAttrib(AttribMask.ColorBufferBit | AttribMask.TextureBit);

			if (colour != null)
			{
				colour.Apply();
			}

			if (texture != null)
			{
				texture.Bind();
			}

			GL.Begin(primitiveType);

			GL.TexCoord2(0.0, 0.0);
			GL.Vertex2(x, y);
			GL.TexCoord2(1.0, 0.0);
			GL.Vertex2(x + width, y);
			GL.TexCoord2(1.0, 1.0);
			GL.Vertex2(x + width, y + height);
			GL.TexCoord2(0.0, 1.0);
			GL.Vertex2(x, y + height);

			GL.End();
			GL.PopAttrib();
		}

		private static void DoText(Colour colour, Texture texture, string text, double x, double y, int size)
		{
			GL.PushAttrib(AttribMask.ColorBufferBit | AttribMask.TextureBit);

			if (colour != null)
			{
				colour.Apply();
			}

            if (texture != null)
            {
                texture.Bind();
            }

			GL.Begin(PrimitiveType.Quads);

			var amount = 16;
			var spacing = (texture.Width / amount);
			var textureSpacing = ((double) spacing / texture.Width);

			for (var index = 0; index < text.Length; index++)
			{
				var character = text[index];

				if (character == ' ')
				{
					continue;
				}

				var actualX = x + (size * index);
				var textureX = ((character % amount) * spacing) / (double) texture.Width;
				var textureY = ((character / amount) * spacing) / (double) texture.Height;

				GL.TexCoord2(textureX, textureY);
				GL.Vertex2(actualX, y);
				GL.TexCoord2(textureX + textureSpacing, textureY);
				GL.Vertex2(actualX + size, y);
				GL.TexCoord2(textureX + textureSpacing, textureY + textureSpacing);
				GL.Vertex2(actualX + size, y + size);
				GL.TexCoord2(textureX, textureY + textureSpacing);
				GL.Vertex2(actualX, y + size);
			}

			GL.End();
			GL.PopAttrib();
		}

		private static void DoPoint(Colour colour, Texture texture, double x, double y, double size)
		{
			GL.PushAttrib(AttribMask.ColorBufferBit | AttribMask.TextureBit);

			if (colour != null)
			{
				colour.Apply();
			}

			if (texture != null)
			{
				texture.Bind();
			}

			GL.PointSize((float) size);

			GL.Begin(PrimitiveType.Points);
			GL.Vertex2(x, y);
			GL.End();

			GL.PopAttrib();
		}
	}
}
