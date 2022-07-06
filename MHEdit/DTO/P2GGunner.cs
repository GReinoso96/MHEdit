using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.DTO
{
    internal class P2GGunner
    {
        public P2GGunner(ushort model, byte rarity, byte unk1, uint price, ushort damage, sbyte defense, byte recoil, byte slots, sbyte affinity, ushort sortOrder, byte ammoConfig, byte elementId, byte elementValue, byte reloadSpeed, uint unk2, byte ammoUsable1, byte ammoUsable2, byte ammoUsable3, byte ammoUsable4)
        {
            Model = model;
            Rarity = rarity;
            Unk1 = unk1;
            Price = price;
            Damage = damage;
            Defense = defense;
            Recoil = recoil;
            Slots = slots;
            Affinity = affinity;
            SortOrder = sortOrder;
            AmmoConfig = ammoConfig;
            ElementId = elementId;
            ElementValue = elementValue;
            ReloadSpeed = reloadSpeed;
            Unk2 = unk2;
            AmmoUsable1 = ammoUsable1;
            AmmoUsable2 = ammoUsable2;
            AmmoUsable3 = ammoUsable3;
            AmmoUsable4 = ammoUsable4;
        }

        public UInt16 Model { get; set; }
        public byte Rarity { get; set; }
        public byte Unk1 { get; set; }
        public UInt32 Price { get; set; }
        public UInt16 Damage { get; set; }
        public sbyte Defense { get; set; }
        public byte Recoil { get; set; }
        public byte Slots { get; set; }
        public sbyte Affinity { get; set; }
        public UInt16 SortOrder { get; set; }
        public byte AmmoConfig { get; set; }
        public byte ElementId { get; set; }
        public byte ElementValue { get; set; }
        public byte ReloadSpeed { get; set; }
        public UInt32 Unk2 { get; set; }
        public byte AmmoUsable1 { get; set; }
        public byte AmmoUsable2 { get; set; }
        public byte AmmoUsable3 { get; set; }
        public byte AmmoUsable4 { get; set; }
    }
}
