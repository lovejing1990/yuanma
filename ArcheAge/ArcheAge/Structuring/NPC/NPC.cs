using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalCommons.Utilities;
using LocalCommons.World;

namespace ArcheAgeGame.ArcheAge.Structuring.NPC
{
	public class NPC
	{
		/// <summary>
		/// Online Object ID
		/// </summary>
		public Uint24 LiveObjectID { get; set; }

		/// <summary>
		/// NPC ID
		/// </summary>
		public UInt32 ID { get; set; }

		/// <summary>
		/// Model ID
		/// </summary>
		public UInt32 ModelID { get; set; }

		/// <summary>
		/// Type Default 1
		/// </summary>
		public byte Type { get; set; } = 1;

		/// <summary>
		/// 坐标 X Y Z
		/// </summary>
		public Position Position { get; set; } = new Position(0, 0, 0);
		/// <summary>
		/// scale 中文不知道
		/// </summary>
		public float Scale { get; set; }

		/// <summary>
		/// Level
		/// </summary>
		public byte Level { get; set; }

		/// <summary>
		/// bc 未知
		/// </summary>
		public Uint24 BC { get; set; }

		public UInt32 FactionId { get; set; }

	}
}
