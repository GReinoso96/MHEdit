namespace MHEdit.Helpers
{
    internal class NAFUHelper : BaseHelper
    {
        public NAFUHelper()
        {
            MeleeOffset = 0x1586B8;
            gunnerOffset = 0x15F28C;

            HeadOffset = 0x161928;
            ChestOffset = 0x165D48;
            ArmOffset = 0x169EE8;
            WaistOffset = 0x16DF20;
            LegOffset = 0x171F08;

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