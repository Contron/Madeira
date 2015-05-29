using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Maths
{
	/// <summary>
	/// Represents a position in 2D space.
	/// </summary>
	public class Point
	{
		/// <summary>
		/// Adds two points.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Point operator +(Point first, Point second)
		{
			return new Point(first.X + second.X, first.Y + second.Y);
		}

		/// <summary>
		/// Subtracts two points.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Point operator -(Point first, Point second)
		{
			return new Point(first.X - second.X, first.Y - second.Y);
		}

		/// <summary>
		/// Multiplies a point.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="amount">the amount</param>
		/// <returns>the result</returns>
		public static Point operator *(Point first, double amount)
		{
			return new Point(first.X * amount, first.Y * amount);
		}

		/// <summary>
		/// Multiplies two points.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Point operator *(Point first, Point second)
		{
			return new Point(first.X * second.X, first.Y * second.Y);
		}

		/// <summary>
		/// Divides a point.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="amount">the amount</param>
		/// <returns>the result</returns>
		public static Point operator /(Point first, double amount)
		{
			return new Point(first.X / amount, first.Y / amount);
		}

		/// <summary>
		/// Divides two points.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Point operator /(Point first, Point second)
		{
			return new Point(first.X / second.X, first.Y / second.Y);
		}

		/// <summary>
		/// Creates a new point.
		/// </summary>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		public Point(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		/// <summary>
		/// Creates a new point from an existing point.
		/// </summary>
		/// <param name="point">the point</param>
		public Point(Point point) : this(point.X, point.Y)
		{

		}

		/// <summary>
		/// Returns a string representation of the point.
		/// </summary>
		/// <returns>a string representation</returns>
		public override string ToString()
		{
			return string.Format("Point (X: {0}, Y: {1})", this.X, this.Y);
		}

		/// <summary>
		/// Inverses the point.
		/// </summary>
		/// <returns>the result</returns>
		public Point Inverse()
		{
			return new Point(-this.X, this.Y);
		}

		/// <summary>
		/// Fractions the point.
		/// </summary>
		/// <returns>the result</returns>
		public Point Fraction()
		{
			return new Point(1 / this.X, 1 / this.Y);
		}

		/// <summary>
		/// Normalises the point.
		/// </summary>
		/// <returns>the result</returns>
		public Point Normalise()
		{
			//distance
			var distance = this.Length();

			return new Point(this.X / distance, this.Y / distance);
		}

		/// <summary>
		/// Returns the length of the point.
		/// </summary>
		/// <returns>the length</returns>
		public double Length()
		{
			return Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
		}

		/// <summary>
		/// Returns the distance between the specified point.
		/// </summary>
		/// <param name="point">the point</param>
		/// <returns>the result</returns>
		public double Distance(Point point)
		{
			var offsetX = (this.X - point.X);
			var offsetY = (this.Y - point.Y);

			var distance = Math.Sqrt((offsetX * offsetX) + (offsetY * offsetY));

			return distance;
		}

		/// <summary>
		/// Gets the left point.
		/// </summary>
		public static Point Left
		{
			get
			{
				return new Point(-1, 0);
			}
		}

		/// <summary>
		/// Gets the right point.
		/// </summary>
		public static Point Right
		{
			get
			{
				return new Point(1, 0);
			}
		}

		/// <summary>
		/// Gets the up point.
		/// </summary>
		public static Point Up
		{
			get
			{
				return new Point(0, -1);
			}
		}

		/// <summary>
		/// Gets the down point.
		/// </summary>
		public static Point Down
		{
			get
			{
				return new Point(0, 1);
			}
		}

		/// <summary>
		/// Gets the zero point.
		/// </summary>
		public static Point Zero
		{
			get
			{
				return new Point(0, 0);
			}
		}

		/// <summary>
		/// Gets or sets the X value of the point.
		/// </summary>
		public double X
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Y value of the point.
		/// </summary>
		public double Y
		{
			get;
			set;
		}
	}
}
