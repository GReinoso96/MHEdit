namespace MHEdit.Helpers
{
    internal class P2GHelper
    {
        public P2GHelper()
        {
            try
            {
                meleeNames = File.ReadAllLines("Data\\P2G-Melee.txt");
                gunnerNames = File.ReadAllLines("Data\\P2G-Gunner.txt");
                headNames = File.ReadAllLines("Data\\P2G-Helms.txt");
                chestNames = File.ReadAllLines("Data\\P2G-Chests.txt");
                armNames = File.ReadAllLines("Data\\P2G-Arms.txt");
                waistNames = File.ReadAllLines("Data\\P2G-Waists.txt");
                legNames = File.ReadAllLines("Data\\P2G-Legs.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string[] meleeNames;
        public string[] gunnerNames;

        public string[] headNames;
        public string[] chestNames;
        public string[] armNames;
        public string[] waistNames;
        public string[] legNames;

        //P2G
        public uint meleeOffset = 0x155A94;
        public uint gunnerOffset = 0x15C668;

        public uint headOffset = 0x15ED04;
        public uint chestOffset = 0x163124;
        public uint armOffset = 0x1672C4;
        public uint waistOffset = 0x16B2FC;
        public uint legOffset = 0x16F2E4;

        public uint meleeCount = 1149;
        public uint gunnerCount = 353;

        public uint headCount = 436;
        public uint chestCount = 420;
        public uint armCount = 411;
        public uint waistCount = 409;
        public uint legCount = 420;
    }
}