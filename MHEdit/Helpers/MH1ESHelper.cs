using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MH1ESHelper : BaseHelper
    {
        public MH1ESHelper()
        {
            MeleeOffset = 0x2CD0;
            gunnerOffset = 0x4730;

            //Sub Main WeaponCraftOffset = 0x48CE0;
            //Sub Main ArmorCraftOffset = 0x46AA0;
            //ELF WeaponUpgradeOffset = 0x232F00;

            HeadOffset = 0x4E50;
            ChestOffset = 0x5990;
            ArmOffset = 0x6810;
            WaistOffset = 0x73C0;
            LegOffset = 0x8090;

            //Sub Main SkillsOffset = 0x49A70;

            MeleeCount = 260;
            GunnerCount = 26;

            WeaponCraftCount = 94;
            ArmorCraftCount = 364;

            HeadCount = 75;
            ChestCount = 80;
            ArmCount = 79;
            WaistCount = 70;
            LegCount = 68;

            //SkillsCount = 137;

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