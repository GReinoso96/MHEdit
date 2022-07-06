using MHEdit.Interfaces;
using System;
using System.IO;

namespace MHEdit.Helpers
{
    internal class MH1JAHelper : BaseHelper
    {
        public MH1JAHelper()
        {
            meleeOffset = 0x235340;
            gunnerOffset = 0x236930;

            headOffset = 0x236D70;
            chestOffset = 0x237350;
            armOffset = 0x237970;
            waistOffset = 0x237F80;
            legOffset = 0x2384D0;

            skillsOffset = 0x238A20;

            meleeCount = 234;
            gunnerCount = 26;

            headCount = 75;
            chestCount = 78;
            armCount = 77;
            waistCount = 68;
            legCount = 68;

            skillsCount = 132;

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