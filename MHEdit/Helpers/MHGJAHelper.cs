using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MHGJAHelper : BaseHelper
    {
        public MHGJAHelper()
        {
            MeleeOffset = 0x746E0;
            gunnerOffset = 0x76AA0;

            WeaponCraftOffset = 0x70D20;
            ArmorCraftOffset = 0x6AAB0;
            WeaponUpgradeOffset = 0x71D30;

            HeadOffset = 0x77420;
            ChestOffset = 0x791A0;
            ArmOffset = 0x7AD20;
            WaistOffset = 0x7C840;
            LegOffset = 0x7E1E0;

            MeleeCount = 381;
            GunnerCount = 78;

            WeaponCraftCount = 170;
            ArmorCraftCount = 1049;

            HeadCount = 236;
            ChestCount = 220;
            ArmCount = 217;
            WaistCount = 205;
            LegCount = 202;

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