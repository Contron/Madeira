using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Maths
{
	/// <summary>
	/// Represents a position in 3D space.
	/// </summary>
	public class Vector
	{
		/// <summary>
		/// Adds two vectors.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Vector operator +(Vector first, Vector second)
		{
			return new Vector(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
		}

		/// <summary>
		/// Subtracts two vectors.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Vector operator -(Vector first, Vector second)
		{
			return new Vector(first.X - second.X, first.Y - second.Y, first.Z + second.Z);
		}

		/// <summary>
		/// Multiplies a vector.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="amount">the amount</param>
		/// <returns>the result</returns>
		public static Vector operator *(Vector first, double amount)
		{
			return new Vector(first.X * amount, first.Y * amount, first.Z * amount);
		}

		/// <summary>
		/// Multiplies two vectors.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Vector operator *(Vector first, Vector second)
		{
			return new Vector(first.X * second.X, first.Y * second.Y, first.Z * second.Z);
		}

		/// <summary>
		/// Divides a vector.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="amount">the amount</param>
		/// <returns>the result</returns>
		public static Vector operator /(Vector first, double amount)
		{
			return new Vector(first.X / amount, first.Y / amount, first.Z / amount);
		}

		/// <summary>
		/// Divides two vectors.
		/// </summary>
		/// <param name="first">the first</param>
		/// <param name="second">the second</param>
		/// <returns>the result</returns>
		public static Vector operator /(Vector first, Vector second)
		{
			return new Vector(first.X / second.X, first.Y / second.Y, first.Z / second.Z);
		}

		/// <summary>
		/// Creates a new vector.
		/// </summary>
		/// <param name="x">the X</param>
		/// <param name="y">the Y</param>
		/// <param name="z">the Z</param>
		public Vector(double x, double y, double z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		/// <summary>
		/// Creates a new vector from an existing vector.
		/// </summary>
		/// <param name="vector">the vector</param>
		public Vector(Vector vector) : this(vector.X, vector.Y, vector.Z)
		{

		}

		/// <summary>
		/// Returns a string representation of the vector.
		/// </summary>
		/// <returns>a string representation</returns>
		public override string ToString()
		{
			return string.Format("Vector (X: {0}, Y: {1}, Z: {2})", this.X, this.Y, this.Z);
		}

		/// <summary>
		/// Inverses the vector.
		/// </summary>
		/// <returns>the result</returns>
		public Vector Inverse()
		{
			return new Vector(-this.X, -this.Y, -this.Z);
		}

		/// <summary>
		/// Fractions the vector.
		/// </summary>
		/// <returns>the result</returns>
		public Vector Fraction()
		{
			return new Vector(1 / this.X, 1 / this.Y, 1 / this.Z);
		}

		/// <summary>
		/// Normalises the vector.
		/// </summary>
		/// <returns>the result</returns>
		public Vector Normalise()
		{
			//distance
			var distance = this.Length();

			return new Vector(this.X / distance, this.Y / distance, this.Z / distance);
		}

		/// <summary>
		/// Returns the length of the vector.
		/// </summary>
		/// <returns>the length</returns>
		public double Length()
		{
			return Math.Sqrt((this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z));
		}

		/// <summary>
		/// Returns the distance between the specified vector.
		/// </summary>
		/// <param name="vector">the vector</param>
		/// <returns>the result</returns>
		public double Distance(Vector vector)
		{
			var offsetX = (this.X - vector.X);
			var offsetY = (this.Y - vector.Y);
			var offsetZ = (this.Z - vector.Z);

			var distance = Math.Sqrt((offsetX * offsetX) + (offsetY * offsetY) + (offsetZ * offsetZ));

			return distance;
		}

		/// <summary>
		/// Gets the left vector.
		/// </summary>
		public static Vector Left
		{
			get
			{
				return new Vector(-1, 0, 0);
			}
		}

		/// <summary>
		/// Gets the right vector.
		/// </summary>
		public static Vector Right
		{
			get
			{
				return new Vector(1, 0, 0);
			}
		}

		/// <summary>
		/// Gets the up vector.
		/// </summary>
		public static Vector Up
		{
			get
			{
				return new Vector(0, 1, 0);
			}
		}

		/// <summary>
		/// Gets the down vector.
		/// </summary>
		public static Vector Down
		{
			get
			{
				return new Vector(0, -1, 0);
			}
		}

		/// <summary>
		/// Gets the zero vector.
		/// </summary>
		public static Vector Zero
		{
			get
			{
				return new Vector(0, 0, 0);
			}
		}

		/// <summary>
		/// Gets the forward vector.
		/// </summary>
		public static Vector Forward
		{
			get
			{
				return new Vector(0, 0, 1);
			}
		}

		/// <summary>
		/// Gets the backward vector.
		/// </summary>
		public static Vector Backward
		{
			get
			{
				return new Vector(0, 0, -1);
			}
		}

		/// <summary>
		/// Gets or sets the X value of the vector.
		/// </summary>
		public double X
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Y value of the vector.
		/// </summary>
		public double Y
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Z value of the vector.
		/// </summary>
		public double Z
		{
			get;
			set;
		}
	}
}
