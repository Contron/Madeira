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
	/// A collection of abstracted 3D graphics methods for OpenGL.
	/// </summary>
	public static class Graphics3D
	{
		/// <summary>
		/// Rotates by the specified angle.
		/// </summary>
		/// <param name="angle">the angle</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		public static void Rotate(double angle, double x, double y, double z)
		{
			//rotate
			GL.Rotate(angle, x, y, z);
		}

		/// <summary>
		/// Translates to the specified position.
		/// </summary>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		public static void Translate(double x, double y, double z)
		{
			//translate
			GL.Translate(x, y, z);
		}

		/// <summary>
		/// Scales by the specified amount.
		/// </summary>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		public static void Scale(double x, double y, double z)
		{
			//scale
			GL.Scale(x, y, z);
		}

		/// <summary>
		/// Draws a cube.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		/// <param name="length">the length</param>
		public static void DrawCube(Colour colour, double x, double y, double z, double width, double height, double length)
		{
			Graphics3D.DoCube(PrimitiveType.Lines, colour, null, x, y, z, width, height, length);
		}

		/// <summary>
		/// Draws a cube.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void DrawCube(Colour colour, Vector position, Vector size)
		{
			Graphics3D.DoCube(PrimitiveType.Lines, colour, null, position.X, position.Y, position.Z, size.X, size.Y, size.Z);
		}

		/// <summary>
		/// Fills a cube.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		/// <param name="length">the length</param>
		public static void FillCube(Colour colour, double x, double y, double z, double width, double height, double length)
		{
			Graphics3D.DoCube(PrimitiveType.Quads, colour, null, x, y, z, width, height, length);
		}

		/// <summary>
		/// Fills a cube.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void FillCube(Colour colour, Vector position, Vector size)
		{
			Graphics3D.DoCube(PrimitiveType.Quads, colour, null, position.X, position.Y, position.Z, size.X, size.Y, size.Z);
		}

		/// <summary>
		/// Fills a textured cube.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the texture</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		/// <param name="length">the length</param>
		public static void FillTexturedCube(Colour colour, Texture texture, double x, double y, double z, double width, double height, double length)
		{
			Graphics3D.DoCube(PrimitiveType.Quads, colour, texture, x, y, z, width, height, length);
		}

		/// <summary>
		/// Fills a textured cube.
		/// </summary>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the texture</param>
		/// <param name="position">the position</param>
		/// <param name="size">the size</param>
		public static void FillTexturedCube(Colour colour, Texture texture, Vector position, Vector size)
		{
			Graphics3D.DoCube(PrimitiveType.Quads, colour, texture, position.X, position.Y, position.Z, size.X, size.Y, size.Z);
		}

		/// <summary>
		/// Performs a cube rendering operation.
		/// </summary>
		/// <param name="primitiveType">the primitive type</param>
		/// <param name="colour">the colour</param>
		/// <param name="texture">the texture</param>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		/// <param name="length">the length</param>
		private static void DoCube(PrimitiveType primitiveType, Colour colour, Texture texture, double x, double y, double z, double width, double height, double length)
		{
			//push
			GL.PushAttrib(AttribMask.ColorBufferBit | AttribMask.TextureBit);

			if (colour != null)
			{
				//colour
				colour.Apply();
			}

			if (texture != null)
			{
				//bind
				texture.Bind();
			}

			//begin
			GL.Begin(primitiveType);

			//top
			GL.TexCoord2(0.0, 0.0);
			GL.Vertex3(x, y + height, z);
			GL.TexCoord2(1.0, 0.0);
			GL.Vertex3(x + width, y + height, z);
			GL.TexCoord2(1.0, 1.0);
			GL.Vertex3(x + width, y + height, z + length);
			GL.TexCoord2(0.0, 1.0);
			GL.Vertex3(x, y + height, z + length);

			//bottom
			GL.TexCoord2(0.0, 0.0);
			GL.Vertex3(x, y, z);
			GL.TexCoord2(1.0, 0.0);
			GL.Vertex3(x + width, y, z);
			GL.TexCoord2(1.0, 1.0);
			GL.Vertex3(x + width, y, z + length);
			GL.TexCoord2(0.0, 1.0);
			GL.Vertex3(x, y, z + length);

			//end
			GL.End();
			GL.PopAttrib();
		}
	}
}
