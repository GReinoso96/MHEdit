using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MH1NAHelper : MH1JAHelper
    {
        public new uint meleeOffset = 0x48E80;
        public new uint gunnerOffset = 0x4A6E0;

        public new uint headOffset = 0x4AB20;
        public new uint chestOffset = 0x4B100;
        public new uint armOffset = 0x4B740;
        public new uint waistOffset = 0x4BD70;
        public new uint legOffset = 0x4C2F0;

        public new uint skillsOffset = 0x4C840;

        public new uint meleeCount = 260;
        public new uint gunnerCount = 26;

        public new uint headCount = 75;
        public new uint chestCount = 80;
        public new uint armCount = 79;
        public new uint waistCount = 70;
        public new uint legCount = 68;

        public new uint skillsCount = 137;
    }
}