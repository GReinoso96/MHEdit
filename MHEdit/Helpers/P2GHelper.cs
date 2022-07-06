namespace MHEdit.Helpers
{
    internal class P2GHelper : BaseHelper
    {
        public P2GHelper()
        {
            MeleeOffset = 0x155A94;
            gunnerOffset = 0x15C668;

            HeadOffset = 0x15ED04;
            ChestOffset = 0x163124;
            ArmOffset = 0x1672C4;
            WaistOffset = 0x16B2FC;
            LegOffset = 0x16F2E4;

            MeleeCount = 1149;
            GunnerCount = 353;

            HeadCount = 436;
            ChestCount = 420;
            ArmCount = 411;
            WaistCount = 409;
            LegCount = 420;

            try
            {
                MeleeNames = File.ReadAllLines("Data\\P2G-Melee.txt");
                GunnerNames = File.ReadAllLines("Data\\P2G-Gunner.txt");
                HeadNames = File.ReadAllLines("Data\\P2G-Helms.txt");
                ChestNames = File.ReadAllLines("Data\\P2G-Chests.txt");
                ArmNames = File.ReadAllLines("Data\\P2G-Arms.txt");
                WaistNames = File.ReadAllLines("Data\\P2G-Waists.txt");
                LegNames = File.ReadAllLines("Data\\P2G-Legs.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}