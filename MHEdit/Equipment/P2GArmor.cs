using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Equipment
{
    internal class P2GArmor
    {
        public P2GArmor(ushort modelMale, ushort modelFemale, byte type, byte rarity, ushort unk1, uint price, byte defense, sbyte resFire, sbyte resWater, sbyte resThunder, sbyte resDragon, sbyte resIce, byte slots, byte series, byte armorSphere, byte armorSpherePlus, byte armorSphereHard, byte armorSphereHeavy, byte armorSphereRoyal, byte armorSphereTrue, byte maxLevel, byte unk2, ushort sortOrder, byte skillId1, sbyte skillAmount1, byte skillId2, sbyte skillAmount2, byte skillId3, sbyte skillAmount3, byte skillId4, sbyte skillAmount4, byte skillId5, sbyte skillAmount5)
        {
            ModelMale = modelMale;
            ModelFemale = modelFemale;
            Type = type;
            Rarity = rarity;
            Unk1 = unk1;
            Price = price;
            Defense = defense;
            ResFire = resFire;
            ResWater = resWater;
            ResThunder = resThunder;
            ResIce = resIce;
            ResDragon = resDragon;
            Slots = slots;
            Series = series;
            ArmorSphere = armorSphere;
            ArmorSpherePlus = armorSpherePlus;
            ArmorSphereHard = armorSphereHard;
            ArmorSphereHeavy = armorSphereHeavy;
            ArmorSphereRoyal = armorSphereRoyal;
            ArmorSphereTrue = armorSphereTrue;
            MaxLevel = maxLevel;
            Unk2 = unk2;
            SortOrder = sortOrder;
            SkillId1 = skillId1;
            SkillAmount1 = skillAmount1;
            SkillId2 = skillId2;
            SkillAmount2 = skillAmount2;
            SkillId3 = skillId3;
            SkillAmount3 = skillAmount3;
            SkillId4 = skillId4;
            SkillAmount4 = skillAmount4;
            SkillId5 = skillId5;
            SkillAmount5 = skillAmount5;
        }

        public UInt16 ModelMale { get; set; }
        public UInt16 ModelFemale { get; set; }
        public byte Type { get; set; }
        public byte Rarity { get; set; }
        public UInt16 Unk1 { get; set; }
        public UInt32 Price { get; set; }
        public byte Defense { get; set; }
        public sbyte ResFire { get; set; }
        public sbyte ResWater { get; set; }
        public sbyte ResThunder { get; set; }
        public sbyte ResIce { get; set; }
        public sbyte ResDragon { get; set; }
        public byte Slots { get; set; }
        public byte Series { get; set; }
        public byte ArmorSphere { get; set; }
        public byte ArmorSpherePlus { get; set; }
        public byte ArmorSphereHard { get; set; }
        public byte ArmorSphereHeavy { get; set; }
        public byte ArmorSphereRoyal { get; set; }
        public byte ArmorSphereTrue { get; set; }
        public byte MaxLevel { get; set; }
        public byte Unk2 { get; set; }
        public UInt16 SortOrder { get; set; }
        public byte SkillId1 { get; set; }
        public sbyte SkillAmount1 { get; set; }
        public byte SkillId2 { get; set; }
        public sbyte SkillAmount2 { get; set; }
        public byte SkillId3 { get; set; }
        public sbyte SkillAmount3 { get; set; }
        public byte SkillId4 { get; set; }
        public sbyte SkillAmount4 { get; set; }
        public byte SkillId5 { get; set; }
        public sbyte SkillAmount5 { get; set; }
    }
}
