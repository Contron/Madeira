using Madeira.Maths;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Core.Visuals
{
	/// <summary>
	/// A collection of generic OpenGL methods.
	/// </summary>
	public static class Graphics
	{
		/// <summary>
		/// Pushes the current attributes to the stack.
		/// </summary>
		public static void PushAttributes()
		{
			GL.PushAttrib(AttribMask.AllAttribBits);
		}

		/// <summary>
		/// Pops the previous attributes from the stack.
		/// </summary>
		public static void PopAttributes()
		{
			GL.PopAttrib();
		}

		/// <summary>
		/// Pushes the current matrix to the stack.
		/// </summary>
		public static void PushMatrix()
		{
			GL.PushMatrix();
		}

		/// <summary>
		/// Pops the previous matrix from the stack.
		/// </summary>
		public static void PopMatrix()
		{
			GL.PopMatrix();
		}

		/// <summary>
		/// Initialises a 2D viewport.
		/// </summary>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		public static void Initialise2D(int width, int height)
		{
			GL.Disable(EnableCap.DepthTest);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			GL.Ortho(0, width, height, 0, -1, 1);

			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
		}

		/// <summary>
		/// Initialises a 3D scene.
		/// </summary>
		/// <param name="width">the width</param>
		/// <param name="height">the height</param>
		/// <param name="fieldOfView">the field of view</param>
		/// <param name="nearZ">the near Z</param>
		/// <param name="farZ">the far Z</param>
		public static void Initialise3D(int width, int height, double fieldOfView, double nearZ, double farZ)
		{
			GL.Enable(EnableCap.DepthTest);

			GL.Viewport(0, 0, width, height);
			var projection = Matrix4.CreatePerspectiveFieldOfView((float) Math.PI / (float) fieldOfView, (float) width / (float) height, (float) nearZ, (float) farZ);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref projection);

			Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref modelview);
			GL.LoadIdentity();
		}

		/// <summary>
		/// Clears the main buffer with the specified colour.
		/// </summary>
		/// <param name="red">the red</param>
		/// <param name="green">the green</param>
		/// <param name="blue">the blue</param>
		public static void Clear(double red, double green, double blue)
		{
			GL.ClearColor((float) red, (float) green, (float) blue, 1F);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
		}

		/// <summary>
		/// Clears the main buffer with the specified colour.
		/// </summary>
		/// <param name="colour">the colour</param>
		public static void Clear(Colour colour)
		{
			Graphics.Clear(colour.Red, colour.Green, colour.Blue);
		}
	}
}
