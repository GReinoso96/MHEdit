using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.DTO
{
    internal class MH1Upgrade
    {
        public MH1Upgrade(ushort itemID1, ushort itemAmt1, ushort itemID2, ushort itemAmt2, ushort itemID3, ushort itemAmt3, ushort weaponID1, ushort weaponID2, ushort weaponID3, ushort weaponID4, ushort weaponID5, ushort weaponID6)
        {
            ItemID1 = itemID1;
            ItemAmt1 = itemAmt1;
            ItemID2 = itemID2;
            ItemAmt2 = itemAmt2;
            ItemID3 = itemID3;
            ItemAmt3 = itemAmt3;
            WeaponID1 = weaponID1;
            WeaponID2 = weaponID2;
            WeaponID3 = weaponID3;
            WeaponID4 = weaponID4;
            WeaponID5 = weaponID5;
            WeaponID6 = weaponID6;
        }

        public UInt16 ItemID1 { get; set; }
        public UInt16 ItemAmt1 { get; set; }
        public UInt16 ItemID2 { get; set; }
        public UInt16 ItemAmt2 { get; set; }
        public UInt16 ItemID3 { get; set; }
        public UInt16 ItemAmt3 { get; set; }
        public UInt16 WeaponID1 { get; set; }
        public UInt16 WeaponID2 { get; set; }
        public UInt16 WeaponID3 { get; set; }
        public UInt16 WeaponID4 { get; set; }
        public UInt16 WeaponID5 { get; set; }
        public UInt16 WeaponID6 { get; set; }
    }
}
