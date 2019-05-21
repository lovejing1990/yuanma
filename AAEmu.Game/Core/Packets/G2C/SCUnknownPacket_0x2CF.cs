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

        public SCUnknownPacket_0x2CF(byte protectFaction, DateTime time) : base(SCOffsets.SCUnknownPacket_0x2CF, 5)
        {
            _protectFaction = protectFaction;
            _time = time;

            var date = _time.ToString("g");

            _year = Convert.ToUInt32(date.Substring(6,4));
            _month = Convert.ToUInt32(date.Substring(3, 2));
            _day = Convert.ToUInt32(date.Substring(0, 2));
            if (date.Length<16)
            {
                _hour = Convert.ToUInt32(date.Substring(11, 1)); // 20.07.2015 0:00:00
                _min = Convert.ToUInt32(date.Substring(13, 2));
            }
            else
            {
                _hour = Convert.ToUInt32(date.Substring(11, 2)); // 20.07.2015 11:43:33
                _min = Convert.ToUInt32(date.Substring(14, 2));
            }
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
