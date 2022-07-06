using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MH1NAHelper : BaseHelper
    {
        public MH1NAHelper()
        {
            MeleeOffset = 0x48E80;
            gunnerOffset = 0x4A6E0;

            WeaponCraftOffset = 0x469D0;
            ArmorCraftOffset = 0x44790;

            HeadOffset = 0x4AB20;
            ChestOffset = 0x4B100;
            ArmOffset = 0x4B740;
            WaistOffset = 0x4BD70;
            LegOffset = 0x4C2F0;

            SkillsOffset = 0x4C840;

            MeleeCount = 260;
            GunnerCount = 26;

            WeaponCraftCount = 94;
            ArmorCraftCount = 364;

            HeadCount = 75;
            ChestCount = 80;
            ArmCount = 79;
            WaistCount = 70;
            LegCount = 68;

            SkillsCount = 137;

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