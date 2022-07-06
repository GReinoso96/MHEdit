namespace MHEdit.Helpers
{
    internal class EUFUHelper : BaseHelper
    {
        public EUFUHelper()
        {
            MeleeOffset = 0x158598;
            gunnerOffset = 0x15F16C;

            HeadOffset = 0x161808;
            ChestOffset = 0x165C28;
            ArmOffset = 0x169DC8;
            WaistOffset = 0x16DE00;
            LegOffset = 0x171DE8;

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