using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal static class MH1Helper
    {
        static MH1Helper()
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

        public static string[] meleeNames;
        public static string[] gunnerNames;

        public static string[] headNames;
        public static string[] chestNames;
        public static string[] armNames;
        public static string[] waistNames;
        public static string[] legNames;
        public static string[] skillNames;

        //MH1J 0x100088
        public static uint meleeOffset = 0x235340;
        public static uint gunnerOffset = 0x236930;

        public static uint headOffset = 0x236D70;
        public static uint chestOffset = 0x237350;
        public static uint armOffset = 0x237970;
        public static uint waistOffset = 0x237F80;
        public static uint legOffset = 0x2384D0;

        public static uint skillsOffsetJP = 0x238A20;

        public static uint meleeCountJP = 234;
        public static uint gunnerCountJP = 26;

        public static uint headCountJP = 75;
        public static uint chestCountJP = 78;
        public static uint armCountJP = 77;
        public static uint waistCountJP = 68;
        public static uint legCountJP = 68;

        public static uint skillsCountJP = 132;

        //1USA
        public static uint meleeOffsetNA = 0x48E80;
        public static uint gunnerOffsetNA = 0x4A6E0;

        public static uint headOffsetNA = 0x4AB20;
        public static uint chestOffsetNA = 0x4B100;
        public static uint armOffsetNA = 0x4B740;
        public static uint waistOffsetNA = 0x4BD70;
        public static uint legOffsetNA = 0x4C2F0;

        public static uint skillsOffsetNA = 0x4C840;

        public static uint meleeCountNA = 260;
        public static uint gunnerCountNA = 26;

        public static uint headCountNA = 75;
        public static uint chestCountNA = 80;
        public static uint armCountNA = 79;
        public static uint waistCountNA = 70;
        public static uint legCountNA = 68;

        public static uint skillsCountNA = 137;

        //EUFU
        public static uint meleeOffsetEU = 0x158598;
        public static uint gunnerOffsetEU = 0x15F16C;

        public static uint headOffsetEU = 0x161808;
        public static uint chestOffsetEU = 0x165C28;
        public static uint armOffsetEU = 0x169DC8;
        public static uint waistOffsetEU = 0x16DE00;
        public static uint legOffsetEU = 0x171DE8;
    }
}