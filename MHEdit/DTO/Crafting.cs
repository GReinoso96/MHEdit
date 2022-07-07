using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.DTO
{
    internal class Crafting
    {
        public Crafting(byte type, byte unknown, ushort pieceID, ushort itemID1, ushort itemAmt1, ushort itemID2, ushort itemAmt2, ushort itemID3, ushort itemAmt3, ushort itemID4, ushort itemAmt4, byte item1Required, byte item2Required, byte item3Required, byte item4Required)
        {
            Type = type;
            Unknown = unknown;
            PieceID = pieceID;
            ItemID1 = itemID1;
            ItemAmt1 = itemAmt1;
            ItemID2 = itemID2;
            ItemAmt2 = itemAmt2;
            ItemID3 = itemID3;
            ItemAmt3 = itemAmt3;
            ItemID4 = itemID4;
            ItemAmt4 = itemAmt4;
            Item1Required = item1Required;
            Item2Required = item2Required;
            Item3Required = item3Required;
            Item4Required = item4Required;
        }

        public byte Type { get; set; }
        public byte Unknown { get; set; }
        public UInt16 PieceID { get; set; }
        public UInt16 ItemID1 { get; set; }
        public UInt16 ItemAmt1 { get; set; }
        public UInt16 ItemID2 { get; set; }
        public UInt16 ItemAmt2 { get; set; }
        public UInt16 ItemID3 { get; set; }
        public UInt16 ItemAmt3 { get; set; }
        public UInt16 ItemID4 { get; set; }
        public UInt16 ItemAmt4 { get; set; }
        public byte Item1Required { get; set; }
        public byte Item2Required { get; set; }
        public byte Item3Required { get; set; }
        public byte Item4Required { get; set; }
    }
}
