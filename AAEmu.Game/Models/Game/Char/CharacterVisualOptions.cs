using AAEmu.Commons.Network;

namespace AAEmu.Game.Models.Game.Char
{
    public class CharacterVisualOptions : PacketMarshaler
    {
        private byte _voptflag;
        public byte[] Stp;
        public bool Helmet;
        public bool BackHoldable;
        public bool Cosplay;
        public bool CosplayBackpack;
        public bool CosplayVisual;

        public override void Read(PacketStream stream)
        {
            _voptflag = stream.ReadByte();

            if ((_voptflag & 1) == 1) // stp
            {
                Stp = stream.ReadBytes(6);
            }

            if ((_voptflag & 2) == 2)
            {
                Helmet = stream.ReadBoolean(); // helmet
            }

            if ((_voptflag & 4) == 4)
            {
                BackHoldable = stream.ReadBoolean(); // back_holdable
            }

            if ((_voptflag & 8) == 8)
            {
                Cosplay = stream.ReadBoolean(); // cosplay
            }

            if ((_voptflag & 0x10) == 0x10)
            {
                CosplayBackpack = stream.ReadBoolean(); // cosplay_backpack
            }

            if ((_voptflag & 0x20) == 0x20)
            {
                CosplayVisual = stream.ReadBoolean(); // cosplay_visual
            }
        }

        public override PacketStream Write(PacketStream stream)
        {
            stream.Write(_voptflag);  // voptflag

            return Write(stream, _voptflag);
        }

        public PacketStream Write(PacketStream stream, byte voptflag)
        {
            if ((voptflag & 1) == 1)
            {
                stream.Write(Stp); // stp
            }

            if ((voptflag & 2) == 2)
            {
                stream.Write(Helmet); // helmet
            }

            if ((voptflag & 4) == 4)
            {
                stream.Write(BackHoldable); // back_holdable
            }

            if ((voptflag & 8) == 8)
            {
                stream.Write(Cosplay); // cosplay
            }

            if ((voptflag & 0x10) == 0x10)
            {
                stream.Write(CosplayBackpack); // cosplay_backpack
            }

            if ((voptflag & 0x20) == 0x20)
            {
                stream.Write(CosplayVisual); // cosplay_visual
            }

            return stream;
        }
    }
}
