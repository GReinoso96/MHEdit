namespace MHEdit.Helpers
{
    internal class EUFUHelper : BaseHelper
    {
        public EUFUHelper()
        {
            meleeOffset = 0x158598;
            gunnerOffset = 0x15F16C;

            headOffset = 0x161808;
            chestOffset = 0x165C28;
            armOffset = 0x169DC8;
            waistOffset = 0x16DE00;
            legOffset = 0x171DE8;

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