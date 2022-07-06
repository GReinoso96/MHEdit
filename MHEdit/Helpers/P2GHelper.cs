namespace MHEdit.Helpers
{
    internal class P2GHelper : BaseHelper
    {
        public P2GHelper()
        {
            meleeOffset = 0x155A94;
            gunnerOffset = 0x15C668;

            headOffset = 0x15ED04;
            chestOffset = 0x163124;
            armOffset = 0x1672C4;
            waistOffset = 0x16B2FC;
            legOffset = 0x16F2E4;

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