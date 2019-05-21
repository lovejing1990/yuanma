using System;
using AAEmu.Commons.Network;
using AAEmu.Game.Core.Managers;
using AAEmu.Game.Models.Game.Items.Templates;

namespace AAEmu.Game.Models.Game.Items
{
    public class EquipItem : Item
    {
        public override byte DetailType => 1;
        
        public byte Durability { get; set; }
        public uint RuneId { get; set; }
        public uint[] GemIds { get; set; }
        public ushort TemperPhysical { get; set; }
        public ushort TemperMagical { get; set; }

        public virtual int Str => 0;
        public virtual int Dex => 0;
        public virtual int Sta => 0;
        public virtual int Int => 0;
        public virtual int Spi => 0;
        public virtual byte MaxDurability => 0;

        public int RepairCost
        {
            get
            {
                var template = (EquipItemTemplate)Template;
                var grade = ItemManager.Instance.GetGradeTemplate(Grade);
                var cost = (ItemManager.Instance.GetDurabilityRepairCostFactor() * 0.0099999998f) *
                           (1f - Durability * 1f / MaxDurability) * template.Price;
                cost = cost * grade.RefundMultiplier * 0.0099999998f;
                cost = (float)Math.Ceiling(cost);
                if (cost < 0 || cost < int.MinValue || cost > int.MaxValue)
                    cost = 0;
                return (int)cost;
            }
        }

        public EquipItem()
        {
            GemIds = new uint[7];
        }

        public EquipItem(ulong id, ItemTemplate template, int count) : base(id, template, count)
        {
            GemIds = new uint[7];
        }

        public override void ReadDetails(PacketStream stream)
        {
            // for 1.2
            //stream.ReadInt32();
            //Durability = stream.ReadByte();
            //stream.ReadInt16();
            //RuneId = stream.ReadUInt32();

            //stream.ReadBytes(12);

            //for (var i = 0; i < GemIds.Length; i++)
            //    GemIds[i] = stream.ReadUInt32();

            //TemperPhysical = stream.ReadUInt16();
            //TemperMagical = stream.ReadUInt16();
            // for 3.0.3.0
            Durability = stream.ReadByte();
            stream.ReadInt16();     // chargeCount
            stream.ReadUInt64(); // chargeTime
            TemperPhysical = stream.ReadUInt16(); // scaledA
            TemperMagical = stream.ReadUInt16();  // scaledB

            //foreach (var gemId in GemIds)
            //    stream.Write(gemId);

            var mGems = stream.ReadPisc(4);
            GemIds[0] = (uint)mGems[0];
            GemIds[1] = (uint)mGems[1];
            GemIds[2] = (uint)mGems[2];
            GemIds[3] = (uint)mGems[3];

            mGems = stream.ReadPisc(4);
            GemIds[4] = (uint)mGems[0];
            GemIds[5] = (uint)mGems[1];
            GemIds[6] = (uint)mGems[2];

            mGems = stream.ReadPisc(4);
            mGems = stream.ReadPisc(4);
        }

        public override void WriteDetails(PacketStream stream)
        {
            // for 1.2
            //stream.Write(0);
            //stream.Write(Durability);
            //stream.Write((short)0);
            //stream.Write(RuneId);

            //stream.Write((uint)0);
            //stream.Write((uint)0);
            //stream.Write((uint)0);

            //foreach (var gemId in GemIds)
            //    stream.Write(gemId);

            //stream.Write(TemperPhysical);
            //stream.Write(TemperMagical);
            // for 3.0.3.0
            stream.Write(Durability);
            stream.Write((short)0);           // chargeCount
            stream.Write(DateTime.MinValue); // chargeTime
            stream.Write(TemperPhysical);   // scaledA
            stream.Write(TemperMagical);   // scaledB

            //foreach (var gemId in GemIds)
            //    stream.Write(gemId);

            stream.WritePisc(GemIds[0], GemIds[1], GemIds[2], GemIds[3]);
            stream.WritePisc(GemIds[4], GemIds[5], GemIds[6], 0);
            stream.WritePisc(0, 0, 0, 0);
            stream.WritePisc(0, 0, 0, 0);
        }
    }
}
