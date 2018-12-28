using LocalCommons.Network;
using LocalCommons.Utilities;

namespace ArcheAgeGame.ArcheAge.Network.Packets.Server
{
	public class SCUnitsRemovedPacket : NetPacket
	{

		public SCUnitsRemovedPacket(Uint24 objectId) : base(01, 0x065)
		{
			var count = 1; //количество Юнитов
			ns.Write((ushort)count); //count h
			for (var i = 0; i < count; i++)
			{
				ns.Write((Uint24)objectId); //удаляемый объект gameObjectId d3
			}
		}
	}
}
