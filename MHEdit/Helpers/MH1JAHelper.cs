using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MH1JAHelper
    {
        public MH1JAHelper()
        {
            try
            {
                meleeNames = File.ReadAllLines("Data\\MHG-Melee.txt");
                gunnerNames = File.ReadAllLines("Data\\MHG-Gunner.txt");
                headNames = File.ReadAllLines("Data\\MH1-Helms.txt");
                chestNames = File.ReadAllLines("Data\\MH1-Chests.txt");
                armNames = File.ReadAllLines("Data\\MH1-Arms.txt");
                waistNames = File.ReadAllLines("Data\\MH1-Waists.txt");
                legNames = File.ReadAllLines("Data\\MH1-Legs.txt");
                skillNames = File.ReadAllLines("Data\\MH1-Skills.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string[] meleeNames;
        public string[] gunnerNames;

        public string[] headNames;
        public string[] chestNames;
        public string[] armNames;
        public string[] waistNames;
        public string[] legNames;
        public string[] skillNames;

        public uint meleeOffset = 0x235340;
        public uint gunnerOffset = 0x236930;

        public uint headOffset = 0x236D70;
        public uint chestOffset = 0x237350;
        public uint armOffset = 0x237970;
        public uint waistOffset = 0x237F80;
        public uint legOffset = 0x2384D0;

        public uint skillsOffset = 0x238A20;

        public uint meleeCount = 234;
        public uint gunnerCount = 26;

        public uint headCount = 75;
        public uint chestCount = 78;
        public uint armCount = 77;
        public uint waistCount = 68;
        public uint legCount = 68;

        public uint skillsCount = 132;
    }
}