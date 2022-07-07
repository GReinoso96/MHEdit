using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Helpers
{
    internal class BaseHelper
    {
        public string[] MeleeNames { get; set; }
        public string[] GunnerNames { get; set; }

        public string[] HeadNames { get; set; }
        public string[] ChestNames { get; set; }
        public string[] ArmNames { get; set; }
        public string[] WaistNames { get; set; }
        public string[] LegNames { get; set; }
        public string[] SkillNames { get; set; }

        public uint MeleeOffset { get; set; }
        public uint gunnerOffset { get; set; }
        public uint WeaponCraftOffset { get; set; }
        public uint HeadCraftOffset { get; set; }
        public uint ChestCraftOffset { get; set; }
        public uint ArmCraftOffset { get; set; }
        public uint WaistCraftOffset { get; set; }
        public uint LegCraftOffset { get; set; }
        public uint ArmorCraftOffset { get; set; }
        public uint WeaponUpgradeOffset { get; set; }

        public uint HeadOffset { get; set; }
        public uint ChestOffset { get; set; }
        public uint ArmOffset { get; set; }
        public uint WaistOffset { get; set; }
        public uint LegOffset { get; set; }

        public uint SkillsOffset { get; set; }

        public uint MeleeCount { get; set; }
        public uint GunnerCount { get; set; }
        public uint WeaponCraftCount { get; set; }
        public uint HeadCraftCount { get; set; }
        public uint ChestCraftCount { get; set; }
        public uint ArmCraftCount { get; set; }
        public uint WaistCraftCount { get; set; }
        public uint LegCraftCount { get; set; }
        public uint ArmorCraftCount { get; set; }
        public uint WeaponUpgradeCount { get; set; }

        public uint HeadCount { get; set; }
        public uint ChestCount { get; set; }
        public uint ArmCount { get; set; }
        public uint WaistCount { get; set; }
        public uint LegCount { get; set; }

        public uint SkillsCount { get; set; }
    }
}
