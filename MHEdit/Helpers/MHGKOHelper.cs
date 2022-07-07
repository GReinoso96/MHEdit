using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MHGKOHelper : BaseHelper
    {
        public MHGKOHelper()
        {
            MeleeOffset = 0x774D0;
            gunnerOffset = 0x79890;

            WeaponCraftOffset = 0x74150;
            ArmorCraftOffset = 0x6DEE0;
            WeaponUpgradeOffset = 0x75110;

            HeadOffset = 0x79FE0;
            ChestOffset = 0x7BD60;
            ArmOffset = 0x7D8E0;
            WaistOffset = 0x7F400;
            LegOffset = 0x80DA0;

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