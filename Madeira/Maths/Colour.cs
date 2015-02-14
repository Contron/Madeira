﻿using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Maths
{
	/// <summary>
	/// Represents a colour with red, green, and blue values.
	/// </summary>
	public class Colour
	{
		/// <summary>
		/// Adds two colours.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Colour operator +(Colour first, Colour second)
		{
			return new Colour(first.Red + second.Red, first.Green + second.Green, first.Blue + second.Blue, first.Alpha + second.Alpha);
		}

		/// <summary>
		/// Subtracts two colours.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Colour operator -(Colour first, Colour second)
		{
			return new Colour(first.Red - second.Red, first.Green - second.Green, first.Blue - second.Blue, first.Alpha - second.Alpha);
		}

		/// <summary>
		/// Multiplies two colours.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Colour operator *(Colour first, Colour second)
		{
			return new Colour(first.Red * second.Red, first.Green * second.Green, first.Blue * second.Blue, first.Alpha * second.Alpha);
		}

		/// <summary>
		/// Divides two colours.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Colour operator /(Colour first, Colour second)
		{
			return new Colour(first.Red / second.Red, first.Green / second.Green, first.Blue / second.Blue, first.Alpha / second.Alpha);
		}

		/// <summary>
		/// Creates a new colour.
		/// </summary>
		/// <param name="red">the red</param>
		/// <param name="green">the green</param>
		/// <param name="blue">the blue</param>
		/// <param name="alpha">the alpha</param>
		public Colour(double red, double green, double blue, double alpha)
		{
			this.Red = red;
			this.Green = green;
			this.Blue = blue;

			this.Alpha = alpha;
		}

		/// <summary>
		/// Creates a new colour.
		/// </summary>
		/// <param name="red"></param>
		/// <param name="green"></param>
		/// <param name="blue"></param>
		public Colour(double red, double green, double blue) : this(red, green, blue, 1)
		{
			
		}

		/// <summary>
		/// Creates a new colour from an existing colour.
		/// </summary>
		/// <param name="colour">the colour</param>
		public Colour(Colour colour) : this(colour.Red, colour.Green, colour.Blue)
		{

		}

		/// <summary>
		/// Returns a string representation of the colour.
		/// </summary>
		/// <returns>a string representation</returns>
		public override string ToString()
		{
			return string.Format("Colour (Red: {0}, Green: {1}, Blue: {2}, Alpha: {3})", this.Red, this.Green, this.Blue);
		}

		/// <summary>
		/// Applies the colour.
		/// </summary>
		public void Apply()
		{
			//set
			GL.Color4(this.Red, this.Green, this.Blue, this.Alpha);
		}

		/// <summary>
		/// The white colour.
		/// </summary>
		public static Colour White
		{
			get
			{
				return new Colour(1, 1, 1);
			}
		}

		/// <summary>
		/// The black colour.
		/// </summary>
		public static Colour Black
		{
			get
			{
				return new Colour(0, 0, 0);
			}
		}

		/// <summary>
		/// The solid red colour.
		/// </summary>
		public static Colour SolidRed
		{
			get
			{
				return new Colour(1, 0, 0);
			}
		}

		/// <summary>
		/// The solid green colour.
		/// </summary>
		public static Colour SolidGreen
		{
			get
			{
				return new Colour(0, 1, 0);
			}
		}

		/// <summary>
		/// The solid blue colour.
		/// </summary>
		public static Colour SolidBlue
		{
			get
			{
				return new Colour(0, 0, 1);
			}
		}

		/// <summary>
		/// The grey colour.
		/// </summary>
		public static Colour Grey
		{
			get
			{
				return new Colour(0.6, 0.6, 0.6);
			}
		}

		/// <summary>
		/// The brown colour.
		/// </summary>
		public static Colour Brown
		{
			get
			{
				return new Colour(0.4, 0.15, 1);
			}
		}

		/// <summary>
		/// The purple colour.
		/// </summary>
		public static Colour Purple
		{
			get
			{
				return new Colour(0.7, 0, 1);
			}
		}

		/// <summary>
		/// The yellow colour.
		/// </summary>
		public static Colour Yellow
		{
			get
			{
				return new Colour(1, 1, 0);
			}
		}

		/// <summary>
		/// The magenta colour.
		/// </summary>
		public static Colour Magenta
		{
			get
			{
				return new Colour(1, 0, 1);
			}
		}

		/// <summary>
		/// The cyan colour.
		/// </summary>
		public static Colour Cyan
		{
			get
			{
				return new Colour(0, 1, 1);
			}
		}

		/// <summary>
		/// The red value of the colour
		/// </summary>
		public double Red
		{
			get;
			set;
		}

		/// <summary>
		/// The green value of the colour.
		/// </summary>
		public double Green
		{
			get;
			set;
		}

		/// <summary>
		/// The blue value of the colour.
		/// </summary>
		public double Blue
		{
			get;
			set;
		}

		/// <summary>
		/// The alpha of the colour.
		/// </summary>
		public double Alpha
		{
			get;
			set;
		}
	}
}