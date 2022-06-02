using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace MHEdit.Controllers
{
    internal static class MH1
    {
        private static uint skillsOffset = Helpers.MH1Helper.skillsOffsetJP;
        private static uint meleeOffset = Helpers.MH1Helper.meleeOffset;
        private static uint gunnerOffset = Helpers.MH1Helper.gunnerOffset;
        private static uint headOffset = Helpers.MH1Helper.headOffset;
        private static uint chestOffset = Helpers.MH1Helper.chestOffset;
        private static uint armOffset = Helpers.MH1Helper.armOffset;
        private static uint waistOffset = Helpers.MH1Helper.waistOffset;
        private static uint legOffset = Helpers.MH1Helper.legOffset;

        private static uint skillsCount = Helpers.MH1Helper.skillsCountJP;
        private static uint meleeCount = Helpers.MH1Helper.meleeCountJP;
        private static uint gunnerCount = Helpers.MH1Helper.gunnerCountJP;
        private static uint headCount = Helpers.MH1Helper.headCountJP;
        private static uint chestCount = Helpers.MH1Helper.chestCountJP;
        private static uint armCount = Helpers.MH1Helper.armCountJP;
        private static uint waistCount = Helpers.MH1Helper.waistCountJP;
        private static uint legCount = Helpers.MH1Helper.legCountJP;

        private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

    public static void SetGame(string code)
        {
            switch (code)
            {
                case "1USA":
                    meleeOffset = Helpers.MH1Helper.meleeOffsetNA;
                    gunnerOffset = Helpers.MH1Helper.gunnerOffsetNA;
                    headOffset = Helpers.MH1Helper.headOffsetNA;
                    chestOffset = Helpers.MH1Helper.chestOffsetNA;
                    armOffset = Helpers.MH1Helper.armOffsetNA;
                    waistOffset = Helpers.MH1Helper.waistOffsetNA;
                    legOffset = Helpers.MH1Helper.legOffsetNA;
                    skillsOffset = Helpers.MH1Helper.skillsOffsetNA;
                    skillsCount = Helpers.MH1Helper.skillsCountNA;
                    meleeCount = Helpers.MH1Helper.meleeCountNA;
                    gunnerCount = Helpers.MH1Helper.gunnerCountNA;
                    headCount = Helpers.MH1Helper.headCountNA;
                    chestCount = Helpers.MH1Helper.chestCountNA;
                    armCount = Helpers.MH1Helper.armCountNA;
                    waistCount = Helpers.MH1Helper.waistCountNA;
                    legCount = Helpers.MH1Helper.legCountNA;
                    break;
                case "1EUR":
                    meleeOffset = Helpers.MH1Helper.meleeOffsetEU;
                    gunnerOffset = Helpers.MH1Helper.gunnerOffsetEU;
                    headOffset = Helpers.MH1Helper.headOffsetEU;
                    chestOffset = Helpers.MH1Helper.chestOffsetEU;
                    armOffset = Helpers.MH1Helper.armOffsetEU;
                    waistOffset = Helpers.MH1Helper.waistOffsetEU;
                    legOffset = Helpers.MH1Helper.legOffsetEU;
                    break;
                case "MH1J":
                default:
                    break;
            }
        }

        public static void DumpData(string inFile, string outFolder)
        {
            var melee = GetMelee(inFile);
            var gunner = GetGunner(inFile);
            var helm = GetHelms(inFile);
            var chest = GetChests(inFile);
            var arm = GetArms(inFile);
            var waist = GetWaists(inFile);
            var leg = GetLegs(inFile);
            var skills = GetSkills(inFile);
            var skillsText = GetSkillsText(inFile);

            try
            {
                Directory.CreateDirectory(outFolder);
                File.WriteAllText($"{outFolder}\\Melee.json", melee);
                File.WriteAllText($"{outFolder}\\Gunner.json", gunner);
                File.WriteAllText($"{outFolder}\\Helmets.json", helm);
                File.WriteAllText($"{outFolder}\\Chestplates.json", chest);
                File.WriteAllText($"{outFolder}\\Armguards.json", arm);
                File.WriteAllText($"{outFolder}\\Waistpieces.json", waist);
                File.WriteAllText($"{outFolder}\\Leggings.json", leg);
                File.WriteAllText($"{outFolder}\\ArmorSkills.json", skills);
                File.WriteAllText($"{outFolder}\\ArmorSkillsText.json", skillsText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void LoadData(string inFolder, string outFile)
        {
            try
            {
                string meleeIn = File.ReadAllText($"{inFolder}\\Melee.json");
                string gunnerIn = File.ReadAllText($"{inFolder}\\Gunner.json");
                string headIn = File.ReadAllText($"{inFolder}\\Helmets.json");
                string chestIn = File.ReadAllText($"{inFolder}\\Chestplates.json");
                string armsIn = File.ReadAllText($"{inFolder}\\Armguards.json");
                string waistIn = File.ReadAllText($"{inFolder}\\Waistpieces.json");
                string legIn = File.ReadAllText($"{inFolder}\\Leggings.json");
                SaveMelee(outFile, meleeIn);
                SaveGunner(outFile, gunnerIn);
                SaveHeads(outFile, headIn);
                SaveChests(outFile, chestIn);
                SaveArms(outFile, armsIn);
                SaveWaists(outFile, waistIn);
                SaveLegs(outFile, legIn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string GetSkills(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(skillsOffset, SeekOrigin.Begin);
                Dictionary<int, Equipment.MH1Skills> armorSkills = new();
                for (int i = 0; i < skillsCount; i++)
                {
                    Equipment.MH1Skills skill = new(
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte());
                    armorSkills.Add(i, skill);
                }

                string jsonString = JsonSerializer.Serialize(armorSkills, JsonOptions);
                return jsonString;
            }
        }

        public static string GetSkillsText(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(skillsOffset, SeekOrigin.Begin);
                Dictionary<int, Equipment.MH1SkillsText> armorSkills = new();
                for (int i = 0; i < skillsCount; i++)
                {
                    Equipment.MH1Skills skill = new(
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte());
                    string legName = "Any";
                    string headName = "Any";
                    string chestName = "Any";
                    string armName = "Any";
                    string waistName = "Any";
                    if (skill.LegArmor != -1) { legName = Helpers.MH1Helper.legNames[skill.LegArmor]; }
                    if (skill.HeadArmor != -1) { headName = Helpers.MH1Helper.headNames[skill.HeadArmor]; }
                    if (skill.ChestArmor != -1) { chestName = Helpers.MH1Helper.chestNames[skill.ChestArmor]; }
                    if (skill.ArmArmor != -1) { armName = Helpers.MH1Helper.armNames[skill.ArmArmor]; }
                    if (skill.WaistArmor != -1) { waistName = Helpers.MH1Helper.waistNames[skill.WaistArmor]; }
                    Equipment.MH1SkillsText skillText = new(
                        skill.Unk1,
                        legName,
                        headName,
                        chestName,
                        armName,
                        waistName,
                        Helpers.MH1Helper.skillNames[skill.Skill1],
                        Helpers.MH1Helper.skillNames[skill.Skill2],
                        Helpers.MH1Helper.skillNames[skill.Skill3],
                        Helpers.MH1Helper.skillNames[skill.Skill4],
                        Helpers.MH1Helper.skillNames[skill.Skill5],
                        skill.Unk2);
                    armorSkills.Add(i, skillText);
                }

                string jsonString = JsonSerializer.Serialize(armorSkills, JsonOptions);
                return jsonString;
            }
        }

        public static string GetMelee(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(meleeOffset, SeekOrigin.Begin);
                Dictionary<string,Equipment.MH1Melee> meleeWeapons = new();
                for (int i = 0; i < meleeCount; i++)
                {
                    Equipment.MH1Melee weapon = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32());
                    meleeWeapons.Add(Helpers.MH1Helper.meleeNames[i],weapon);
                }

                string jsonString = JsonSerializer.Serialize(meleeWeapons, JsonOptions);
                return jsonString;
            }
        }

        public static string GetGunner(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(gunnerOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MHJGunner> gunnerWeapons = new();
                for (int i = 0; i < gunnerCount; i++)
                {
                    Equipment.MHJGunner weapon = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte());
                    gunnerWeapons.Add(Helpers.MH1Helper.gunnerNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(gunnerWeapons, JsonOptions);
                return jsonString;
            }
        }

        public static string GetHelms(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(headOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> headParts = new();
                for (int i = 0; i < headCount; i++)
                {
                    Equipment.MH1Armor armor = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32());
                    headParts.Add(Helpers.MH1Helper.headNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(headParts, JsonOptions);
                return jsonString;
            }
        }

        public static string GetChests(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(chestOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> chestParts = new();
                for (int i = 0; i < chestCount; i++)
                {
                    Equipment.MH1Armor armor = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32());
                    chestParts.Add(Helpers.MH1Helper.chestNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(chestParts, JsonOptions);
                return jsonString;
            }
        }

        public static string GetArms(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(armOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> armParts = new();
                for (int i = 0; i < armCount; i++)
                {
                    Equipment.MH1Armor armor = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32());
                    armParts.Add(Helpers.MH1Helper.armNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(armParts, JsonOptions);
                return jsonString;
            }
        }

        public static string GetWaists(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(waistOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> waistParts = new();
                for (int i = 0; i < waistCount; i++)
                {
                    Equipment.MH1Armor armor = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32());
                    waistParts.Add(Helpers.MH1Helper.waistNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(waistParts, JsonOptions);
                return jsonString;
            }
        }

        public static string GetLegs(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(legOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> legParts = new();
                for (int i = 0; i < legCount; i++)
                {
                    Equipment.MH1Armor armor = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32());
                    legParts.Add(Helpers.MH1Helper.legNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(legParts, JsonOptions);
                return jsonString;
            }
        }

        public static void SaveMelee(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(meleeOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Melee> meleeWeapons = JsonSerializer.Deserialize<Dictionary<string, Equipment.MH1Melee>>(jsonIn);
                foreach(var item in meleeWeapons)
                {
                    bw.Write((byte)item.Value.Model);
                    bw.Write((byte)item.Value.Rarity);
                    bw.Write((UInt16)item.Value.Sharpness);
                    bw.Write((UInt32)item.Value.Price);
                    bw.Write((UInt16)item.Value.Attack);
                    bw.Write((byte)item.Value.Defense);
                    bw.Write((byte)item.Value.Fire);
                    bw.Write((byte)item.Value.Water);
                    bw.Write((byte)item.Value.Thunder);
                    bw.Write((byte)item.Value.Dragon);
                    bw.Write((byte)item.Value.Poison);
                    bw.Write((byte)item.Value.Paralysis);
                    bw.Write((byte)item.Value.Sleep);
                    bw.Write((UInt16)item.Value.SortOrder);
                    bw.Write((UInt32)item.Value.NameOffset);
                }
            }
        }

        public static void SaveGunner(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(gunnerOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MHJGunner> gunnerWeapons = JsonSerializer.Deserialize<Dictionary<string, Equipment.MHJGunner>>(jsonIn);
                foreach (var item in gunnerWeapons)
                {
                    bw.Write((byte)item.Value.Model);
                    bw.Write((byte)item.Value.Rarity);
                    bw.Write((byte)item.Value.Unk1);
                    bw.Write((byte)item.Value.ReloadSpeed);
                    bw.Write((UInt32)item.Value.Price);
                    bw.Write((UInt16)item.Value.Damage);
                    bw.Write((UInt16)item.Value.SortOrder);
                    bw.Write((UInt32)item.Value.NameOffset);
                    bw.Write((byte)item.Value.AmmoUsable1);
                    bw.Write((byte)item.Value.AmmoUsable2);
                    bw.Write((byte)item.Value.AmmoUsable3);
                    bw.Write((byte)item.Value.AmmoUsable4);
                }
            }
        }

        public static void SaveHeads(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(headOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> headParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.MH1Armor>>(jsonIn);
                WriteArmor(bw, headParts);
            }
        }

        public static void SaveChests(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(chestOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> chestParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.MH1Armor>>(jsonIn);
                WriteArmor(bw, chestParts);
            }
        }

        public static void SaveArms(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(armOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> armParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.MH1Armor>>(jsonIn);
                WriteArmor(bw, armParts);
            }
        }

        public static void SaveWaists(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(waistOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> waistParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.MH1Armor>>(jsonIn);
                WriteArmor(bw, waistParts);
            }
        }

        public static void SaveLegs(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(legOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.MH1Armor> legParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.MH1Armor>>(jsonIn);
                WriteArmor(bw, legParts);
            }
        }

        private static void WriteArmor(BinaryWriter bw, Dictionary<string, Equipment.MH1Armor> parts)
        {
            foreach (var item in parts)
            {
                bw.Write((UInt16)item.Value.ModelMale);
                bw.Write((UInt16)item.Value.ModelFemale);
                bw.Write((byte)item.Value.Type);
                bw.Write((byte)item.Value.Rarity);
                bw.Write((UInt32)item.Value.Price);
                bw.Write((byte)item.Value.Defense);
                bw.Write((sbyte)item.Value.ResFire);
                bw.Write((sbyte)item.Value.ResWater);
                bw.Write((sbyte)item.Value.ResThunder);
                bw.Write((sbyte)item.Value.ResDragon);
                bw.Write((byte)item.Value.Unk1);
                bw.Write((UInt16)item.Value.Unk2);
                bw.Write((UInt32)item.Value.NameOffset);
            }
        }
    }
}
