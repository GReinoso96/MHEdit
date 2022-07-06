using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.DTO
{
    internal class MH1Skills
    {
        public MH1Skills(byte unk1, sbyte legArmor, sbyte headArmor, sbyte chestArmor, sbyte armArmor, sbyte waistArmor, byte skill1, byte skill2, byte skill3, byte skill4, byte skill5, byte unk2)
        {
            Unk1 = unk1;
            LegArmor = legArmor;
            HeadArmor = headArmor;
            ChestArmor = chestArmor;
            ArmArmor = armArmor;
            WaistArmor = waistArmor;
            Skill1 = skill1;
            Skill2 = skill2;
            Skill3 = skill3;
            Skill4 = skill4;
            Skill5 = skill5;
            Unk2 = unk2;
        }

        public byte Unk1 { get; set; }
        public sbyte LegArmor { get; set; }
        public sbyte HeadArmor { get; set; }
        public sbyte ChestArmor { get; set; }
        public sbyte ArmArmor { get; set; }
        public sbyte WaistArmor { get; set; }
        public byte Skill1 { get; set; }
        public byte Skill2 { get; set; }
        public byte Skill3 { get; set; }
        public byte Skill4 { get; set; }
        public byte Skill5 { get; set; }
        public byte Unk2 { get; set; }
    }
    internal class MH1SkillsText
    {
        public MH1SkillsText(byte unk1, string legArmor, string headArmor, string chestArmor, string armArmor, string waistArmor, string skill1, string skill2, string skill3, string skill4, string skill5, byte unk2)
        {
            Unk1 = unk1;
            LegArmor = legArmor;
            HeadArmor = headArmor;
            ChestArmor = chestArmor;
            ArmArmor = armArmor;
            WaistArmor = waistArmor;
            Skill1 = skill1;
            Skill2 = skill2;
            Skill3 = skill3;
            Skill4 = skill4;
            Skill5 = skill5;
            Unk2 = unk2;
        }

        public byte Unk1 { get; set; }
        public string LegArmor { get; set; }
        public string HeadArmor { get; set; }
        public string ChestArmor { get; set; }
        public string ArmArmor { get; set; }
        public string WaistArmor { get; set; }
        public string Skill1 { get; set; }
        public string Skill2 { get; set; }
        public string Skill3 { get; set; }
        public string Skill4 { get; set; }
        public string Skill5 { get; set; }
        public byte Unk2 { get; set; }
    }
}
