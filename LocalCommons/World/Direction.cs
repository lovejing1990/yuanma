using System;

namespace LocalCommons.World
{
	/// <summary>
	/// Describes the direction an entity is looking at.
	/// </summary>
	public struct Direction
	{
	    /// <summary>
	    /// X rotate (left/right).
	    /// </summary>
	    public readonly sbyte X;

        /// <summary>
        /// Y rotate (up/down).
        /// </summary>
        public readonly sbyte Y;

        /// <summary>
        /// Z rotate (depth).
        /// </summary>
        public readonly sbyte Z;

        public Direction(sbyte x, sbyte y, sbyte z)
        {
	        this.X = x;
	        this.Y = y;
	        this.Z = z;
        }

	    public Direction(Direction rot)
	    {
		    this.X = rot.X;
		    this.Y = rot.Y;
		    this.Z = rot.Z;
	    }

        /// <summary>
        /// Returns new position with X, Y, and Z being 0.
        /// </summary>
        public static Direction Zero => new Direction(0, 0, 0);
	}
}
