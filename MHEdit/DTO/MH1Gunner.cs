using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.DTO
{
    internal class MH1Gunner
    {
        public MH1Gunner(byte model, byte rarity, byte unk1, byte reloadSpeed, uint price, ushort damage, byte defense, byte unk2, byte recoil, byte ammoConfig, ushort sortOrder, uint nameOffset, byte ammoUsable1, byte ammoUsable2, byte ammoUsable3, byte ammoUsable4)
        {
            Model = model;
            Rarity = rarity;
            Unk1 = unk1;
            ReloadSpeed = reloadSpeed;
            Price = price;
            Damage = damage;
            Defense = defense;
            Unk2 = unk2;
            Recoil = recoil;
            AmmoConfig = ammoConfig;
            SortOrder = sortOrder;
            NameOffset = nameOffset;
            AmmoUsable1 = ammoUsable1;
            AmmoUsable2 = ammoUsable2;
            AmmoUsable3 = ammoUsable3;
            AmmoUsable4 = ammoUsable4;
        }

        public byte Model { get; set; }
        public byte Rarity { get; set; }
        public byte Unk1 { get; set; }
        public byte ReloadSpeed { get; set; }
        public UInt32 Price { get; set; }
        public UInt16 Damage { get; set; }
        public byte Defense { get; set; }
        public byte Unk2 { get; set; }
        public byte Recoil { get; set; }
        public byte AmmoConfig { get; set; }
        public UInt16 SortOrder { get; set; }
        public UInt32 NameOffset { get; set; }
        public byte AmmoUsable1 { get; set; }
        public byte AmmoUsable2 { get; set; }
        public byte AmmoUsable3 { get; set; }
        public byte AmmoUsable4 { get; set; }
    }
}
