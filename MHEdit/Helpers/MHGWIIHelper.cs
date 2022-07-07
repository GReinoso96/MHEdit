using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MHGWIIHelper : BaseHelper
    {
        public MHGWIIHelper()
        {
            MeleeOffset = 0x609148;
            gunnerOffset = 0x60BAC0;

            WeaponCraftOffset = 0x603ED0;
            ArmorCraftOffset = 0x5FDC60;
            WeaponUpgradeOffset = 0x604ED9;

            HeadOffset = 0x60D568;
            ChestOffset = 0x610368;
            ArmOffset = 0x612E88;
            WaistOffset = 0x615960;
            LegOffset = 0x618288;

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