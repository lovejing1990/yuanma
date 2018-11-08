using ArcheAgeGame.ArcheAge.Network.Connections;
using LocalCommons.Network;

namespace ArcheAgeGame.ArcheAge.Network
{
    public sealed class NP_SCLeaveWorldGrantedPacket_0x0003 : NetPacket
    {
        public NP_SCLeaveWorldGrantedPacket_0x0003() : base(01, 0x0003)
        {
            ns.Write((byte)0x00); //target c
        }
    }
}