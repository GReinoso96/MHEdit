using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.DTO
{
    internal class MHGArmor
    {
        public MHGArmor(byte modelMale, byte modelFemale, byte type, byte rarity, uint price, byte defense, sbyte resFire, sbyte resWater, sbyte resThunder, sbyte resDragon, ushort unk1, byte unk2, uint nameOffset, byte skillID1, sbyte skillValue1, byte skillID2, sbyte skillValue2, byte skillID3, sbyte skillValue3, byte skillID4, sbyte skillValue4, byte skillID5, sbyte skillValue5, ushort unk3)
        {
            ModelMale = modelMale;
            ModelFemale = modelFemale;
            Type = type;
            Rarity = rarity;
            Price = price;
            Defense = defense;
            ResFire = resFire;
            ResWater = resWater;
            ResThunder = resThunder;
            ResDragon = resDragon;
            Unk1 = unk1;
            Unk2 = unk2;
            NameOffset = nameOffset;
            SkillID1 = skillID1;
            SkillValue1 = skillValue1;
            SkillID2 = skillID2;
            SkillValue2 = skillValue2;
            SkillID3 = skillID3;
            SkillValue3 = skillValue3;
            SkillID4 = skillID4;
            SkillValue4 = skillValue4;
            SkillID5 = skillID5;
            SkillValue5 = skillValue5;
            Unk3 = unk3;
        }

        public byte ModelMale { get; set; }
        public byte ModelFemale { get; set; }
        public byte Type { get; set; }
        public byte Rarity { get; set; }
        public UInt32 Price { get; set; }
        public byte Defense { get; set; }
        public sbyte ResFire { get; set; }
        public sbyte ResWater { get; set; }
        public sbyte ResThunder { get; set; }
        public sbyte ResDragon { get; set; }
        public UInt16 Unk1 { get; set; }
        public byte Unk2 { get; set; }
        public UInt32 NameOffset { get; set; }
        public Byte SkillID1 { get; set; }
        public SByte SkillValue1 { get; set; }
        public Byte SkillID2 { get; set; }
        public SByte SkillValue2 { get; set; }
        public Byte SkillID3 { get; set; }
        public SByte SkillValue3 { get; set; }
        public Byte SkillID4 { get; set; }
        public SByte SkillValue4 { get; set; }
        public Byte SkillID5 { get; set; }
        public SByte SkillValue5 { get; set; }
        public UInt16 Unk3 { get; set; }
    }
}
