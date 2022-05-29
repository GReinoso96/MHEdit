using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Equipment
{
    internal class MH1Armor
    {
        public MH1Armor(byte modelMale, byte modelFemale, byte type, byte rarity, uint price, byte defense, sbyte resFire, sbyte resWater, sbyte resThunder, sbyte resDragon, byte unk1, ushort unk2, uint nameOffset)
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
        public byte Unk1 { get; set; }
        public UInt16 Unk2 { get; set; }
        public UInt32 NameOffset { get; set; }
    }
}
