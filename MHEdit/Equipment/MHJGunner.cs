using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Equipment
{
    internal class MHJGunner
    {
        public MHJGunner(byte model, byte rarity, byte unk1, byte reloadSpeed, uint price, ushort damage, ushort sortOrder, uint nameOffset, byte ammoUsable1, byte ammoUsable2, byte ammoUsable3, byte ammoUsable4)
        {
            Model = model;
            Rarity = rarity;
            Unk1 = unk1;
            ReloadSpeed = reloadSpeed;
            Price = price;
            Damage = damage;
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
        public UInt16 SortOrder { get; set; }
        public UInt32 NameOffset { get; set; }
        public byte AmmoUsable1 { get; set; }
        public byte AmmoUsable2 { get; set; }
        public byte AmmoUsable3 { get; set; }
        public byte AmmoUsable4 { get; set; }
    }
}
