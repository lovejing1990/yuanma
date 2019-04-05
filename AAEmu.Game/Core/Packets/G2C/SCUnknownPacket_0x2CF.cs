using System;
using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;

namespace AAEmu.Game.Core.Packets.G2C
{
    public class SCUnknownPacket_0x2CF : GamePacket
    {
        private readonly byte _protectFaction;
        private readonly DateTime _time;
        private readonly uint _year;
        private readonly uint _month;
        private readonly uint _day;
        private readonly uint _hour;
        private readonly uint _min;

        public SCUnknownPacket_0x2CF(byte protectFaction, DateTime time, uint year, uint month, uint day, uint hour, uint min)
            : base(SCOffsets.SCUnknownPacket_0x2CF, 5)
        {
            _protectFaction = protectFaction;
            _time = time;
            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _min = min;
        }

        public override PacketStream Write(PacketStream stream)
        {
            stream.Write(_protectFaction);
            stream.Write(_time);
            stream.Write(_year);
            stream.Write(_month);
            stream.Write(_day);
            stream.Write(_hour);
            stream.Write(_min);
            return stream;
        }
    }
}
