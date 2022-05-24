using System;
using System.IO;

namespace MHEdit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length >= 4)
            {
                if (args[0].Equals("P2G"))
                {
                    if (args[1].Equals("-d"))
                    {
                        var outMelee = Controllers.P2G.GetMelee(args[2]);
                        var outGunner = Controllers.P2G.GetGunner(args[2]);

                        try
                        {
                            Directory.CreateDirectory(args[3]);
                            File.WriteAllText($"{args[3]}\\melee.json", outMelee);
                            File.WriteAllText($"{args[3]}\\gunner.json", outGunner);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else if (args[1].Equals("-i"))
                    {
                        try
                        {
                            string meleeIn = File.ReadAllText($"{args[2]}\\melee.json");
                            string gunnerIn = File.ReadAllText($"{args[2]}\\gunner.json");
                            Controllers.P2G.saveMelee(args[3], meleeIn);
                            Controllers.P2G.saveGunner(args[3], gunnerIn);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
