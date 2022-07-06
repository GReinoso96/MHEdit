namespace MHEdit.Helpers
{
    internal static class P2GHelper
    {
        static P2GHelper()
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

        public static string[] meleeNames;
        public static string[] gunnerNames;

        public static string[] headNames;
        public static string[] chestNames;
        public static string[] armNames;
        public static string[] waistNames;
        public static string[] legNames;

        //P2G
        public static uint meleeOffset = 0x155A94;
        public static uint gunnerOffset = 0x15C668;

        public static uint headOffset = 0x15ED04;
        public static uint chestOffset = 0x163124;
        public static uint armOffset = 0x1672C4;
        public static uint waistOffset = 0x16B2FC;
        public static uint legOffset = 0x16F2E4;

        public static uint meleeCount = 1149;
        public static uint gunnerCount = 353;

        public static uint headCount = 436;
        public static uint chestCount = 420;
        public static uint armCount = 411;
        public static uint waistCount = 409;
        public static uint legCount = 420;

        //NAFU
        public static uint meleeOffsetNA = 0x1586B8;
        public static uint gunnerOffsetNA = 0x15F28C;

        public static uint headOffsetNA = 0x161928;
        public static uint chestOffsetNA = 0x165D48;
        public static uint armOffsetNA = 0x169EE8;
        public static uint waistOffsetNA = 0x16DF20;
        public static uint legOffsetNA = 0x171F08;

        //EUFU
        public static uint meleeOffsetEU = 0x158598;
        public static uint gunnerOffsetEU = 0x15F16C;

        public static uint headOffsetEU = 0x161808;
        public static uint chestOffsetEU = 0x165C28;
        public static uint armOffsetEU = 0x169DC8;
        public static uint waistOffsetEU = 0x16DE00;
        public static uint legOffsetEU = 0x171DE8;
    }
}