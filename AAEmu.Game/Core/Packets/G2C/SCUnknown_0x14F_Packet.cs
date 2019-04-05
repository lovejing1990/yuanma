using System;
using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Models.Game.Skills;

namespace AAEmu.Game.Core.Packets.G2C
{
    public class SCUnknown_0x14F_Packet : GamePacket
    {
        private readonly uint _acount;
        private readonly byte _AccountAttributeKind;
        private readonly uint _extraKind;
        private readonly byte _worldId;
        private readonly uint _count;
        private readonly DateTime _startDate;
        private readonly DateTime _endData;

        public SCUnknown_0x14F_Packet() : base(SCOffsets.SCUnknown_0x14F_Packet, 5)
        {
            _acount = 1;
            _AccountAttributeKind = (byte) 1;
            _extraKind = 0;
            _worldId = 0xff;
            _count = 0;
            _startDate = DateTime.Now;
            _endData = DateTime.MinValue;
        }

        public override PacketStream Write(PacketStream stream)
        {
            stream.Write(_acount);
            for (var i = 0; i < _acount; i++)
            {
                stream.Write(_AccountAttributeKind); // chatTypeGroup
                stream.Write(_extraKind);
                stream.Write(_worldId);
                stream.Write(_count);
                stream.Write(_startDate);
                stream.Write(_endData);
            }
            return stream;
        }
    }
}
