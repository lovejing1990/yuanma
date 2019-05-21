using System.Collections.Generic;
using AAEmu.Commons.Network;
using AAEmu.Commons.Utils;
using AAEmu.Game.Core.Managers;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Models.Game.Char;
using AAEmu.Game.Models.Game.Housing;
using AAEmu.Game.Models.Game.Items;
using AAEmu.Game.Models.Game.NPChar;
using AAEmu.Game.Models.Game.Skills;
using AAEmu.Game.Models.Game.Units;
using AAEmu.Game.Models.Game.Shipyard;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AAEmu.Game.Core.Packets.G2C
{
    public class SCUnitStatePacket : GamePacket
    {
        private readonly Unit _unit;
        private readonly byte _type;
        private readonly byte _modelPostureType;

        public SCUnitStatePacket(Unit unit) : base(SCOffsets.SCUnitStatePacket, 5)
        {
            _unit = unit;

            if (_unit is Character)
            {
                _type = 0;
                _modelPostureType = 0;
            }
            else if (_unit is Npc npc)
            {
                _type = 1;
                _modelPostureType = npc.Template.AnimActionId > 0 ? (byte)4 : (byte)0;
            }
            else if (_unit is Slave)
            {
                _type = 2;
                _modelPostureType = 8;
            }
            else if (_unit is House)
            {
                _type = 3;
                _modelPostureType = 1;
            }
            else if (_unit is Transfer)
            {
                _type = 4;
                _modelPostureType = 0;
            }
            else if (_unit is Mount)
            {
                _type = 5;
                _modelPostureType = 0;
            }
            else if (_unit is Shipyard)
            {
                _type = 6;
                _modelPostureType = 0;
            }
        }

        public override PacketStream Write(PacketStream stream)
        {
            #region read_8030

            stream.WriteBc(_unit.ObjId);
            stream.Write(_unit.Name);

            #region read_A3C0

            stream.Write(_type);
            switch (_type) // UnitOwnerInfo?
            {
                case 0:
                    var character = _unit as Character;
                    stream.Write(character.Id); // type(id)
                    stream.Write(0L);          // v
                    break;
                case 1:
                    var npc = _unit as Npc;

                    stream.WriteBc(npc.ObjId);
                    stream.Write(npc.TemplateId); // npc templateId
                    stream.Write(0u);            // type(id)
                    stream.Write((byte)0);      // clientDriven
                    break;
                case 2:
                    var slave = _unit as Slave;

                    stream.Write(0u);                 // type(id)
                    stream.Write(slave.TlId);        // tl
                    stream.Write(slave.TemplateId); // type(id)
                    stream.Write(0u);              // type(id)
                    break;
                case 3:
                    var house = _unit as House;

                    var buildStep = house.CurrentStep == -1 ? 0 : -house.Template.BuildSteps.Count + house.CurrentStep;

                    stream.Write(house.TlId); // tl
                    stream.Write(house.TemplateId); // house templateId
                    stream.Write((short)buildStep); // buildstep
                    break;
                case 4:
                    var transfer = _unit as Transfer;

                    stream.Write(transfer.TlId); // tl
                    stream.Write(transfer.TemplateId); // transfer templateId
                    break;
                case 5:
                    var mount = _unit as Mount;

                    stream.Write(mount.TlId); // tl
                    stream.Write(mount.TemplateId); // npc teplateId
                    stream.Write(mount.OwnerId); // characterId (masterId)
                    break;
                case 6:
                    var shipyard = _unit as Shipyard;

                    stream.Write(shipyard.Template.Id); // type(id)
                    stream.Write(shipyard.Template.TemplateId); // type(id)
                    break;
            }

            #endregion

            if (_unit.OwnerId > 0) // master
            {
                var name = NameManager.Instance.GetCharacterName(_unit.OwnerId);
                stream.Write(name ?? "");
            }
            else
                stream.Write("");

            stream.WritePosition(_unit.Position.X, _unit.Position.Y, _unit.Position.Z); // posXYZ
            stream.Write(_unit.Scale); // scale
            stream.Write(_unit.Level); // level
            stream.Write((byte)0); // level
            for (var i = 0; i < 4; i++)
                stream.Write((sbyte)-1); // slot
            stream.Write(_unit.ModelId); // modelRef

            #region CharacterInfo_3EB0

            var index = 0;
            var validFlags = 0;
            if (_unit is Character character2)
            {
                // calculate validFlags
                foreach (var item in character2.Inventory.Equip)
                {
                    if (item != null)
                        validFlags |= 1 << index;
                    index++;
                }
                stream.Write((uint)validFlags); // validFlags for 3.0.3.0
                foreach (var item in character2.Inventory.Equip)
                {
                    if (item != null)
                        stream.Write(item);
                }
            }
            else if (_unit is Npc npc)
            {
                // calculate validFlags
                foreach (var item in npc.Equip)
                {
                    if (item != null)
                        validFlags |= 1 << index;
                    index++;
                }
                stream.Write((uint)validFlags); // validFlags for 3.0.3.0

                for (var i = 0; i < npc.Equip.Length; i++)
                {
                    var item = npc.Equip[i];

                    if (item is BodyPart)
                        stream.Write(item.TemplateId);
                    else if (item != null)
                    {
                        if (i == 27) // Cosplay
                            stream.Write(item);
                        else
                        {
                            stream.Write(item.TemplateId);
                            stream.Write(0L);
                            stream.Write((byte)0);
                        }
                    }
                }
            }

            if (_unit is Character)
            {
                stream.Write((uint)0); // flags for 3.0.3.0
            }
            #endregion

            stream.Write(_unit.ModelParams); // CustomModel_3570

            stream.WriteBc(0);
            stream.Write(_unit.Hp * 100); // preciseHealth
            stream.Write(_unit.Mp * 100); // preciseMana

            var point = -1;                   // point TODO UnitAttached
            if (point == -1)
            {
                stream.Write((sbyte)point);
            }
            else
            {
                stream.Write((sbyte)0);    //TODO что должно быть?
                stream.WriteBc(0);
            }
            var point2 = -1;               // TODO что это?
            if (point2 == -1)
            {
                stream.Write((sbyte)point2);  // point2
            }
            else
            {
                stream.Write((sbyte)0);    //TODO not -1
                stream.WriteBc(0);

                stream.Write(0);  // space
                stream.Write(0);  // spot
                stream.Write(0);  // type
            }
            //if (_unit is Character character3)
            //{
            //    if (character3.Bonding == null)
            //        stream.Write((sbyte)-1); // point
            //    else
            //    {
            //        stream.Write((sbyte)-1); // point
            //        stream.WriteBc(0);
            //    }
            //}
            //else if (_unit is Slave slave)
            //{
            //    if (slave.BondingObjId > 0)
            //        stream.WriteBc(slave.BondingObjId);
            //    else
            //        stream.Write((sbyte)-1);
            //}
            //else
            //    stream.Write((sbyte)-1); // point


            #region ModelPosture_9CF0

            // TODO UnitModelPosture
            stream.Write(_modelPostureType); // type
            stream.Write(false);             // isLooted

            switch (_modelPostureType)
            {
                case 1: // build
                    stream.Write(false); // flags Byte
                    break;
                case 4: // npc
                    var npc = _unit as Npc;
                    stream.Write(npc.Template.AnimActionId); // animId
                    stream.Write(true);                     // activate
                    break;
                case 7:
                    stream.Write(0u);    // type(id)
                    stream.Write(0f);    // growRate
                    stream.Write(0);     // randomSeed
                    stream.Write(false); // flags Byte
                    break;
                case 8: // slave
                    stream.Write(0f);    // pitch
                    stream.Write(0f);    // yaw
                    break;
            }
            #endregion

            stream.Write(_unit.ActiveWeapon);

            if (_unit is Character character4)
            {
                var learnedSkillCount = (byte)character4.Skills.Skills.Count;
                var passiveBuffCount = (byte)character4.Skills.PassiveBuffs.Count;

                stream.Write(learnedSkillCount);  // learnedSkillCount
                stream.Write(passiveBuffCount);  // passiveBuffCount
                stream.Write(0);                // highAbilityRsc

                foreach (var skill in character4.Skills.Skills.Values)
                {
                    stream.WritePisc(skill.Id);
                }
                foreach (var buff in character4.Skills.PassiveBuffs.Values)
                {
                    stream.WritePisc(buff.Id);
                }
            }
            else if(_unit is Npc npc)
            {

                stream.Write((byte)1);  // learnedSkillCount
                stream.Write((byte)0);  // passiveBuffCount
                stream.Write(0);        // highAbilityRsc

                stream.WritePisc(npc.Template.BaseSkillId);
            }
            else
            {
                stream.Write((byte)0); // learnedSkillCount
                stream.Write((byte)0); // passiveBuffCount
                stream.Write(0);       // highAbilityRsc
            }

            if (_type == 3)
            {
                stream.Write(_unit.Position.RotationZ);
            }
            else
            {
                stream.Write(_unit.Position.RotationX);
                stream.Write(_unit.Position.RotationY);
                stream.Write(_unit.Position.RotationZ);
            }

            stream.Write(_unit.RaceGender);

            if (_unit is Character character5)
            {
                stream.WritePisc(0, 0, character5.Appellations.ActiveAppellation, 0); // pisc
            }
            else
            {
                stream.WritePisc(0, 0, 0, 0); // pisc
            }

            stream.WritePisc(_unit.Faction?.Id ?? 0, _unit.Expedition?.Id ?? 0, 0, 0); // pisc

            stream.WritePisc(0, 0, 0, 0); // pisc

            if (_unit is Character character6)
            {
                var flags = new BitSet(16); // short

                if (character6.Invisible)
                {
                    flags.Set(5);
                }

                if (character6.IdleStatus)
                {
                    flags.Set(13);
                }

                //stream.WritePisc(0, 0); // очки чести полученные в PvP, кол-во убийств в PvP
                stream.Write(flags.ToByteArray()); // flags(ushort)
                /*
                * 0x01 - 8bit - режим боя
                * 0x04 - 6bit - невидимость?
                * 0x08 - 5bit - дуэль
                * 0x40 - 2bit - gmmode, дополнительно 7 байт
                * 0x80 - 1bit - дополнительно tl(ushort), tl(ushort), tl(ushort), tl(ushort)
                * 0x0100 - 16bit - дополнительно 3 байт (bc), firstHitterTeamId(uint)
                * 0x0400 - 14bit - надпись "Отсутсвует" под именем
                */
            }
            else if (_unit is Npc)
            {
                stream.Write((ushort)8192); // flags
            }
            else
            {
                stream.Write((ushort)0); // flags
            }

            if (_unit is Character character7)
            {
                var activeAbilities = character7.Abilities.GetActiveAbilities();

                foreach (var ability in character7.Abilities.Values)
                {
                    stream.Write(ability.Exp);
                    stream.Write(ability.Order);
                }

                stream.Write((byte)activeAbilities.Count); // nActive
                foreach (var ability in activeAbilities)
                {
                    stream.Write((byte)ability);
                }

                foreach (var ability in character7.Abilities.Values)
                {
                    stream.Write(ability.Exp);
                    //stream.Write(0);
                    stream.Write((byte)0);  //ability.Order
                    stream.Write((byte)0);  // cannotLevelUp
                }

                // TODO проверить
                byte nHighActive = 0;
                byte nActive = 0;
                stream.Write(nHighActive); // nHighActive
                stream.Write(nActive);    // nActive
                while (nHighActive > 0)
                {
                    while (nActive > 0)
                    {
                        stream.Write(0); // active
                        nActive--;
                    }
                    nHighActive--;
                }

                stream.WriteBc(0);      // objId
                stream.Write((byte)0); // camp

                //for (var i = 0; i < 6; i++)
                //{
                //    stream.Write(0); // stp
                //}
                stream.Write((byte)30);  // stp
                stream.Write((byte)60);  // stp
                stream.Write((byte)50);  // stp
                stream.Write((byte)0);   // stp
                stream.Write((byte)40);  // stp
                stream.Write((byte)100); // stp

                stream.Write((byte)7); // flags
                character7.VisualOptions.Write(stream, 0x20); // cosplay_visual

                stream.Write(1); // premium

                for (var i = 0; i < 5; i++)
                {
                    stream.Write(0); // stats
                }

                stream.Write(0); // extendMaxStats
                stream.Write(0); // applyExtendCount
                stream.Write(0); // applyNormalCount
                stream.Write(0); // applySpecialCount
                stream.WritePisc(0, 0, 0, 0);
                stream.WritePisc(0, 0);
                stream.Write(0); // accountPrivilege
            }
            #endregion

            #region read_7F50

            var goodBuffs = new List<Effect>();
            var badBuffs = new List<Effect>();
            var hiddenBuffs = new List<Effect>();

            if (_unit is Character)
            {
                _unit.Effects.GetAllBuffs(goodBuffs, badBuffs, hiddenBuffs);

                stream.Write((byte)goodBuffs.Count); // TODO max 32
                foreach (var effect in goodBuffs)
                {
                    // Begin read_7В10
                    stream.Write(effect.Template.BuffId); // buffId
                    // Begin read_6AC0
                    stream.Write((byte)0); // _type

                    switch (_type)
                    {
                        case 0:
                        case 1:
                        case 4:
                            stream.WriteBc(_unit.ObjId);
                            break;
                        case 2:
                            stream.WriteBc(_unit.ObjId);
                            stream.Write(effect.SkillCaster);
                            /*
                             SkillCaster включает в себя
                             ItemId = stream.ReadUInt64();
                             ItemTemplateId = stream.ReadUInt32();
                             Type1 = stream.ReadByte();
                             Type2 = stream.ReadUInt32();
                            */
                            break;
                        case 3:
                            stream.WriteBc(_unit.ObjId);
                            stream.Write(effect.Skill.Id); // mountSkillTyp
                            break;
                    }

                    // End read_6AC0
                    stream.Write(effect.Caster.Level); // sourceLevel
                    stream.Write((short)1); // sourceAbLevel

                    stream.WritePisc(0, 0, 0, 0u);
                    stream.WritePisc(effect.Skill.Id, 1, 0, 0u);
                    // End read_7В10

                    /*
                    stream.Write(effect.Index);
                    stream.Write(effect.Template.BuffId);
                    stream.Write(effect.SkillCaster);
                    stream.Write(0u);                      // type(id)
                    stream.Write(effect.Caster.Level);     // sourceLevel
                    stream.Write((short)1);                // sourceAbLevel
                    stream.Write(effect.Duration);         // totalTime
                    stream.Write(effect.GetTimeElapsed()); // elapsedTime
                    stream.Write((uint)effect.Tick);       // tickTime
                    stream.Write(0);                       // tickIndex
                    stream.Write(1);                       // stack
                    stream.Write(0);                       // charged
                    stream.Write(0u);                      // type(id) -> cooldownSkill
                    */
                }

                stream.Write((byte)badBuffs.Count); // TODO max 24
                foreach (var effect in badBuffs)
                {
                    // Begin read_7В10
                    stream.Write(effect.Template.BuffId); // buffId
                    // Begin read_6AC0
                    stream.Write((byte)0); // _type

                    switch (_type)
                    {
                        case 0:
                        case 1:
                        case 4:
                            stream.WriteBc(_unit.ObjId);
                            break;
                        case 2:
                            stream.WriteBc(_unit.ObjId);
                            stream.Write(effect.SkillCaster);
                            /*
                             SkillCaster включает в себя
                             ItemId = stream.ReadUInt64();
                             ItemTemplateId = stream.ReadUInt32();
                             Type1 = stream.ReadByte();
                             Type2 = stream.ReadUInt32();
                            */
                            break;
                        case 3:
                            stream.WriteBc(_unit.ObjId);
                            stream.Write(effect.Skill.Id); // mountSkillTyp
                            break;
                    }

                    // End read_6AC0
                    stream.Write(effect.Caster.Level); // sourceLevel
                    stream.Write((short)1); // sourceAbLevel

                    stream.WritePisc(0, 0, 0, 0u);
                    stream.WritePisc(effect.Skill.Id, 1, 0, 0u);
                    // End read_7В10
                }

                stream.Write((byte)hiddenBuffs.Count); // TODO max 24
                foreach (var effect in hiddenBuffs)
                {
                    // Begin read_7В10
                    stream.Write(effect.Template.BuffId); // buffId
                    // Begin read_6AC0
                    stream.Write((byte)0); // _type

                    switch (_type)
                    {
                        case 0:
                        case 1:
                        case 4:
                            stream.WriteBc(_unit.ObjId);
                            break;
                        case 2:
                            stream.WriteBc(_unit.ObjId);
                            stream.Write(effect.SkillCaster);
                            /*
                             SkillCaster включает в себя
                             ItemId = stream.ReadUInt64();
                             ItemTemplateId = stream.ReadUInt32();
                             Type1 = stream.ReadByte();
                             Type2 = stream.ReadUInt32();
                            */
                            break;
                        case 3:
                            stream.WriteBc(_unit.ObjId);
                            stream.Write(effect.Skill.Id); // mountSkillTyp
                            break;
                    }

                    // End read_6AC0
                    stream.Write(effect.Caster.Level); // sourceLevel
                    stream.Write((short)1); // sourceAbLevel

                    stream.WritePisc(0, 0, 0, 0u);
                    stream.WritePisc(effect.Skill.Id, 1, 0, 0u);
                    // End read_7В10
                }
            }
            else
            {
                stream.Write((byte)0); // goodBuffs
                stream.Write((byte)0); // badBuffs
                stream.Write((byte)0); // hiddenBuffs
            }

            #endregion

            return stream;
        }
    }
}

