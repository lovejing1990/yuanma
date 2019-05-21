using AAEmu.Game.Models.Game.DoodadObj.Templates;
using AAEmu.Game.Models.Game.Units;

namespace AAEmu.Game.Models.Game.DoodadObj.Funcs
{
    public class DoodadFuncConsumeChangerModel : DoodadFuncTemplate
    {
        public string Name { get; set; } // для 1.2
        //public string Model { get; set; } // для 3.5.5.3

        public override void Use(Unit caster, Doodad owner, uint skillId)
        {
            _log.Debug("DoodadFuncConsumeChangerModel");
        }
    }
}
