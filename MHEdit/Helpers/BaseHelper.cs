using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Helpers
{
    internal class BaseHelper
    {
        public string[] meleeNames { get; set; }
        public string[] gunnerNames { get; set; }

        public string[] headNames { get; set; }
        public string[] chestNames { get; set; }
        public string[] armNames { get; set; }
        public string[] waistNames { get; set; }
        public string[] legNames { get; set; }
        public string[] skillNames { get; set; }

        public uint meleeOffset { get; set; }
        public uint gunnerOffset { get; set; }

        public uint headOffset { get; set; }
        public uint chestOffset { get; set; }
        public uint armOffset { get; set; }
        public uint waistOffset { get; set; }
        public uint legOffset { get; set; }

        public uint skillsOffset { get; set; }

        public uint meleeCount { get; set; }
        public uint gunnerCount { get; set; }

        public uint headCount { get; set; }
        public uint chestCount { get; set; }
        public uint armCount { get; set; }
        public uint waistCount { get; set; }
        public uint legCount { get; set; }

        public uint skillsCount { get; set; }
    }
}
