using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MH1NAHelper : BaseHelper
    {
        public MH1NAHelper()
        {
            meleeOffset = 0x48E80;
            gunnerOffset = 0x4A6E0;

            headOffset = 0x4AB20;
            chestOffset = 0x4B100;
            armOffset = 0x4B740;
            waistOffset = 0x4BD70;
            legOffset = 0x4C2F0;

            skillsOffset = 0x4C840;

            meleeCount = 260;
            gunnerCount = 26;

            headCount = 75;
            chestCount = 80;
            armCount = 79;
            waistCount = 70;
            legCount = 68;

            skillsCount = 137;

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
    }
}