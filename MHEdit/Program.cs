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
                        var outString = Controllers.P2G.GetMelee(args[2]);

                        try
                        {
                            File.WriteAllText(args[3], outString);
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
                            string jsonIn = File.ReadAllText(args[2]);
                            Controllers.P2G.saveMelee(args[3], jsonIn);
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
