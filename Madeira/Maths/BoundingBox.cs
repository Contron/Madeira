using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madeira.Maths
{
	/// <summary>
	/// Represents an axis-aligned bounding box for simple collision detection.
	/// </summary>
	public class BoundingBox
	{
		/// <summary>
		/// Returns if the specified bounding boxes intersect.
		/// </summary>
		/// <param name="start1">the first start</param>
		/// <param name="size1">the first size</param>
		/// <param name="start2">the second start</param>
		/// <param name="size2">the second size</param>
		/// <returns>if any intersection occurs</returns>
		public static bool Intersects(Vector start1, Vector size1, Vector start2, Vector size2)
		{
			return ((start1.X + size1.X) >= start2.X &&
				(start1.Y + size1.Y) >= start2.Y &&
				(start1.Z + size1.Z) >= start2.Z &&
				(start1.X <= (start2.X + size2.X)) &&
				(start1.Y <= (start2.Y + size2.Y)) &&
				(start1.Z <= (start2.Z + size2.Z)));
		}

		/// <summary>
		/// Returns if the specified bounding boxes intersect.
		/// </summary>
		/// <param name="start1">the first start</param>
		/// <param name="size1">the first size</param>
		/// <param name="start2">the second start</param>
		/// <param name="size2">the second size</param>
		/// <returns>if any intersection occurs</returns>
		public static bool Intersects(Point start1, Point size1, Point start2, Point size2)
		{
			return ((start1.X + size1.X) >= start2.X &&
				(start1.Y + size1.Y) >= start2.Y &&
				(start1.X <= (start2.X + size2.X)) &&
				(start1.Y <= (start2.Y + size2.Y)));
		}
	}
}
