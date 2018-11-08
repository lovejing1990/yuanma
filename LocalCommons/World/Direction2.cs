using System;

namespace LocalCommons.World
{
	/// <summary>
	/// Describes the direction an entity is looking at.
	/// </summary>
	public struct Direction2
	{
		public readonly float Cos;
		public readonly float Sin;

		/// <summary>
		/// Creates new direction from values.
		/// </summary>
		/// <param name="cos"></param>
		/// <param name="sin"></param>
		public Direction2(float cos, float sin)
		{
			this.Cos = cos;
			this.Sin = sin;
		}

		/// <summary>
		/// Creates new direction from direction.
		/// </summary>
		/// <param name="dir"></param>
		public Direction2(Direction2 dir)
		{
			this.Cos = dir.Cos;
			this.Sin = dir.Sin;
		}

		/// <summary>
		/// Creates direction from degree, e.g. 0~360,
		/// going anti-clockwise, 0 being down.
		/// </summary>
		/// <param name="degree"></param>
		public Direction2(double degree)
		{
			degree -= 45;
			degree *= Math.PI / 180.0;

			this.Cos = (float)Math.Cos(degree);
			this.Sin = (float)Math.Sin(degree);
		}
	}
}
