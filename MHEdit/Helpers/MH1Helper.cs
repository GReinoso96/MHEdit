namespace MHEdit.Helpers
{
    internal static class MH1Helper
    {

        public static string[] meleeNames;
        public static string[] gunnerNames;

        public static string[] headNames;
        public static string[] chestNames;
        public static string[] armNames;
        public static string[] waistNames;
        public static string[] legNames;

        //MH1J 0x100088
        public static uint meleeOffset = 0x235340;
        public static uint gunnerOffset = 0x236930;

        public static uint headOffset = 0x236D70;
        public static uint chestOffset = 0x237350;
        public static uint armOffset = 0x237970;
        public static uint waistOffset = 0x237F80;
        public static uint legOffset = 0x2384D0;

        public static uint meleeCountJP = 234;
        public static uint gunnerCountJP = 26;

        public static uint headCountJP = 75;
        public static uint chestCountJP = 78;
        public static uint armCountJP = 77;
        public static uint waistCountJP = 44;
        public static uint legCountJP = 44;

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