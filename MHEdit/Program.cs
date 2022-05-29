using System;
using System.IO;

namespace MHEdit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 4)
            {
                try
                {
                    Helpers.MH1Helper.meleeNames = File.ReadAllLines("Data\\MHG-Melee.txt");
                    Helpers.MH1Helper.gunnerNames = File.ReadAllLines("Data\\MHG-Gunner.txt");
                    Helpers.MH1Helper.headNames = File.ReadAllLines("Data\\MH1-Helms.txt");
                    Helpers.MH1Helper.chestNames = File.ReadAllLines("Data\\MH1-Chests.txt");
                    Helpers.MH1Helper.armNames = File.ReadAllLines("Data\\MH1-Arms.txt");
                    Helpers.MH1Helper.waistNames = File.ReadAllLines("Data\\MH1-Waists.txt");
                    Helpers.MH1Helper.legNames = File.ReadAllLines("Data\\MH1-Legs.txt");
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                if (args[0].Equals("P2G") || args[0].Equals("NAFU") || args[0].Equals("EUFU"))
                {
                    Controllers.P2G.SetGame(args[0]);
                    if (args[1].Equals("-d", StringComparison.OrdinalIgnoreCase))
                    {
                        Controllers.P2G.DumpData(args[2], args[3]);
                    }
                    else if (args[1].Equals("-i", StringComparison.OrdinalIgnoreCase))
                    {
                        Controllers.P2G.LoadData(args[2], args[3]);
                    }
                }
                if (args[0].Equals("MH1J") || args[0].Equals("1USA") || args[0].Equals("1EUR"))
                {
                    Controllers.MH1.SetGame(args[0]);
                    if (args[1].Equals("-d", StringComparison.OrdinalIgnoreCase))
                    {
                        Controllers.MH1.DumpData(args[2], args[3]);
                    }
                    else if (args[1].Equals("-i", StringComparison.OrdinalIgnoreCase))
                    {
                        Controllers.MH1.LoadData(args[2], args[3]);
                    }
                }
            }
        }
    }
}
