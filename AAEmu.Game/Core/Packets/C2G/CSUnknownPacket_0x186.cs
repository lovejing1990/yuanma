using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.C2G
{
    public class CSUnknownPacket_0x186 : GamePacket
    {
        public CSUnknownPacket_0x186() : base(CSOffsets.CSUnknownPacket_0x186, 1)
        {
        }

        public override void Read(PacketStream stream)
        {
            _log.Debug("CSUnknownPacket_0x186");
        }
    }
}
