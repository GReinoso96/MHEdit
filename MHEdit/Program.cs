using System;
using System.IO;

namespace MHEdit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length >= 3)
            {
                if (args[0].Equals("-d"))
                {
                    var outString = Controllers.P2G.GetMelee(args[1]);

                    try
                    {
                        File.WriteAllText(args[2], outString);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else if (args[0].Equals("-i"))
                {
                    try
                    {
                        string jsonIn = File.ReadAllText(args[1]);
                        Controllers.P2G.saveMelee(args[2], jsonIn);
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
