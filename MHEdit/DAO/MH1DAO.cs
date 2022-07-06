using MHEdit.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace MHEdit.DAO
{
    internal class MH1DAO : Interfaces.IGen1
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

        public void SetGame(string code)
        {
            switch (code)
            {
                case "1U":
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
                case "1J":
                default:
                    break;
            }
        }

        public void DumpData(string inFile, string outFolder)
        {
            var melee = GetMelee(inFile);
            var gunner = GetGunner(inFile);
            var head = GetArmorParts(inFile, headOffset, headCount, Helpers.MH1Helper.headNames);
            var chest = GetArmorParts(inFile, chestOffset, chestCount, Helpers.MH1Helper.chestNames);
            var arm = GetArmorParts(inFile, armOffset, armCount, Helpers.MH1Helper.armNames);
            var waist = GetArmorParts(inFile, waistOffset, waistCount, Helpers.MH1Helper.waistNames);
            var leg = GetArmorParts(inFile, legOffset, legCount, Helpers.MH1Helper.legNames);
            var skills = GetSkills(inFile);

            try
            {
                Directory.CreateDirectory(outFolder);
                File.WriteAllText($"{outFolder}\\Melee.json", melee);
                File.WriteAllText($"{outFolder}\\Gunner.json", gunner);
                File.WriteAllText($"{outFolder}\\Helmets.json", head);
                File.WriteAllText($"{outFolder}\\Chestplates.json", chest);
                File.WriteAllText($"{outFolder}\\Armguards.json", arm);
                File.WriteAllText($"{outFolder}\\Waistpieces.json", waist);
                File.WriteAllText($"{outFolder}\\Leggings.json", leg);
                File.WriteAllText($"{outFolder}\\ArmorSkills.json", skills);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string GetArmorParts(string inFile, uint offset, uint count, string[] names)
        {
            using(BinaryReader br = new(File.OpenRead(inFile)))
            {
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                Dictionary<string, DTO.MH1Armor> parts = new();
                for (int i = 0; i < count; i++)
                {
                    DTO.MH1Armor part = new(
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
                    parts.Add(names[i], part);
                }

                string jsonString = JsonSerializer.Serialize(parts, JsonOptions);
                return jsonString;
            }
        }

        public string GetGunner(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(gunnerOffset, SeekOrigin.Begin);
                Dictionary<string, DTO.MHJGunner> gunnerWeapons = new();
                for (int i = 0; i < gunnerCount; i++)
                {
                    DTO.MHJGunner weapon = new(
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

        public string GetMelee(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(meleeOffset, SeekOrigin.Begin);
                Dictionary<string, DTO.MH1Melee> meleeWeapons = new();
                for (int i = 0; i < meleeCount; i++)
                {
                    DTO.MH1Melee weapon = new(
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
                    meleeWeapons.Add(Helpers.MH1Helper.meleeNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(meleeWeapons, JsonOptions);
                return jsonString;
            }
        }

        public string GetSkills(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(skillsOffset, SeekOrigin.Begin);
                Dictionary<int, DTO.MH1Skills> armorSkills = new();
                for (int i = 0; i < skillsCount; i++)
                {
                    DTO.MH1Skills skill = new(
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

        public void LoadData(string inFolder, string outFile)
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
                string skillsIn = File.ReadAllText($"{inFolder}\\ArmorSkills.json");
                SaveMelee(outFile, meleeIn);
                SaveGunner(outFile, gunnerIn);
                SaveArmorParts(outFile, headIn, headOffset);
                SaveArmorParts(outFile, chestIn, chestOffset);
                SaveArmorParts(outFile, armsIn, armOffset);
                SaveArmorParts(outFile, waistIn, waistOffset);
                SaveArmorParts(outFile, legIn, legOffset);
                SaveSkills(outFile, skillsIn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SaveArmorParts(string fileIn, string jsonIn, uint offset)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(offset, SeekOrigin.Begin);
                    Dictionary<string, DTO.MH1Armor> parts = JsonSerializer.Deserialize<Dictionary<string, DTO.MH1Armor>>(jsonIn);
                    foreach (KeyValuePair<string, MH1Armor> item in parts)
                    {
                        bw.Write((byte)item.Value.ModelMale);
                        bw.Write((byte)item.Value.ModelFemale);
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

        public void SaveGunner(string fileIn, string jsonIn)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(gunnerOffset, SeekOrigin.Begin);
                    Dictionary<string, DTO.MHJGunner> gunnerWeapons = JsonSerializer.Deserialize<Dictionary<string, DTO.MHJGunner>>(jsonIn);
                    foreach (KeyValuePair<string, MHJGunner> item in gunnerWeapons)
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
        }

        public void SaveMelee(string fileIn, string jsonIn)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(meleeOffset, SeekOrigin.Begin);
                    Dictionary<string, DTO.MH1Melee> meleeWeapons = JsonSerializer.Deserialize<Dictionary<string, DTO.MH1Melee>>(jsonIn);
                    foreach (var item in meleeWeapons)
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
        }

        public void SaveSkills(string fileIn, string jsonIn)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(skillsOffset, SeekOrigin.Begin);
                    Dictionary<string, DTO.MH1Skills> armorSkills = JsonSerializer.Deserialize<Dictionary<string, DTO.MH1Skills>>(jsonIn);
                    foreach (var item in armorSkills)
                    {
                        bw.Write((byte)item.Value.Unk1);
                        bw.Write((sbyte)item.Value.LegArmor);
                        bw.Write((sbyte)item.Value.HeadArmor);
                        bw.Write((sbyte)item.Value.ChestArmor);
                        bw.Write((sbyte)item.Value.ArmArmor);
                        bw.Write((sbyte)item.Value.WaistArmor);
                        bw.Write((byte)item.Value.Skill1);
                        bw.Write((byte)item.Value.Skill2);
                        bw.Write((byte)item.Value.Skill3);
                        bw.Write((byte)item.Value.Skill4);
                        bw.Write((byte)item.Value.Skill5);
                        bw.Write((byte)item.Value.Unk2);
                    }
                }
            }
        }
    }
}
