using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.DTO
{
    internal class MH1Melee
    {
        public MH1Melee(byte model, byte rarity, ushort sharpness, uint price, ushort attack, byte defense, byte fire, byte water, byte thunder, byte dragon, byte poison, byte paralysis, byte sleep, ushort sortOrder, uint nameOffset)
        {
            Model = model;
            Rarity = rarity;
            Sharpness = sharpness;
            Price = price;
            Attack = attack;
            Defense = defense;
            Fire = fire;
            Water = water;
            Thunder = thunder;
            Dragon = dragon;
            Poison = poison;
            Paralysis = paralysis;
            Sleep = sleep;
            SortOrder = sortOrder;
            NameOffset = nameOffset;
        }

        public byte Model { get; set; }
        public byte Rarity { get; set; }
        public UInt16 Sharpness { get; set; }
        public UInt32 Price { get; set; }
        public UInt16 Attack { get; set; }
        public byte Defense { get; set; }
        public byte Fire { get; set; }
        public byte Water { get; set; }
        public byte Thunder { get; set; }
        public byte Dragon { get; set; }
        public byte Poison { get; set; }
        public byte Paralysis { get; set; }
        public byte Sleep { get; set; }
        public UInt16 SortOrder { get; set; }
        public UInt32 NameOffset { get; set; }
    }
}
