using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Equipment
{
    internal class P2GMelee
    {
        public P2GMelee(ushort model, byte rarity, byte unk1, uint price, ushort sharpness, ushort attack, sbyte defense, sbyte affinity, byte elementId, byte elementValue, byte statusId, byte statusValue, byte slots, byte unk2, byte extraBit, ushort sortOrder, byte unk3)
        {
            Model = model;
            Rarity = rarity;
            Unk1 = unk1;
            Price = price;
            Sharpness = sharpness;
            Attack = attack;
            Defense = defense;
            Affinity = affinity;
            ElementId = elementId;
            ElementValue = elementValue;
            StatusId = statusId;
            StatusValue = statusValue;
            Slots = slots;
            Unk2 = unk2;
            ExtraBit = extraBit;
            SortOrder = sortOrder;
            Unk3 = unk3;
        }

        public UInt16 Model { get; set; }
        public byte Rarity { get; set; }
        public byte Unk1 { get; set; }
        public UInt32 Price { get; set; }
        public UInt16 Sharpness { get; set; }
        public UInt16 Attack { get; set; }
        public sbyte Defense { get; set; }
        public sbyte Affinity { get; set; }
        public byte ElementId { get; set; }
        public byte ElementValue { get; set; }
        public byte StatusId { get; set; }
        public byte StatusValue { get; set; }
        public byte Slots { get; set; }
        public byte Unk2 { get; set; }
        public byte ExtraBit { get; set; }
        public UInt16 SortOrder { get; set; }
        public byte Unk3 { get; set; }
    }
}
