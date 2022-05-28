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
            }
        }
    }
}
