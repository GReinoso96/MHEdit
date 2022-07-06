using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MH1JAHelper : BaseHelper
    {
        public MH1JAHelper()
        {
            MeleeOffset = 0x235340;
            gunnerOffset = 0x236930;

            WeaponCraftOffset = 0x2331B0;
            ArmorCraftOffset = 0x231000;

            HeadOffset = 0x236D70;
            ChestOffset = 0x237350;
            ArmOffset = 0x237970;
            WaistOffset = 0x237F80;
            LegOffset = 0x2384D0;

            SkillsOffset = 0x238A20;

            MeleeCount = 234;
            GunnerCount = 26;

            WeaponCraftCount = 91;
            ArmorCraftCount = 358;

            HeadCount = 75;
            ChestCount = 78;
            ArmCount = 77;
            WaistCount = 68;
            LegCount = 68;

            SkillsCount = 132;

            try
            {
                MeleeNames = File.ReadAllLines("Data\\MHG-Melee.txt");
                GunnerNames = File.ReadAllLines("Data\\MHG-Gunner.txt");
                HeadNames = File.ReadAllLines("Data\\MH1-Helms.txt");
                ChestNames = File.ReadAllLines("Data\\MH1-Chests.txt");
                ArmNames = File.ReadAllLines("Data\\MH1-Arms.txt");
                WaistNames = File.ReadAllLines("Data\\MH1-Waists.txt");
                LegNames = File.ReadAllLines("Data\\MH1-Legs.txt");
                SkillNames = File.ReadAllLines("Data\\MH1-Skills.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}