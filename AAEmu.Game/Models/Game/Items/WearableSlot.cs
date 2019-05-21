namespace AAEmu.Game.Models.Game.Items
{
    public class WearableSlot
    {
        public uint Id { get; set; } // добавил поле с не повторяющимися данными
        public uint SlotTypeId { get; set; }
        public int Coverage { get; set; }
    }
}
