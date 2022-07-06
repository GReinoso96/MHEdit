namespace MHEdit.Helpers
{
    internal class NAFUHelper : BaseHelper
    {
        public NAFUHelper()
        {
            meleeOffset = 0x1586B8;
            gunnerOffset = 0x15F28C;

            headOffset = 0x161928;
            chestOffset = 0x165D48;
            armOffset = 0x169EE8;
            waistOffset = 0x16DF20;
            legOffset = 0x171F08;

            meleeCount = 1149;
            gunnerCount = 353;

            headCount = 436;
            chestCount = 420;
            armCount = 411;
            waistCount = 409;
            legCount = 420;

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
    }
}