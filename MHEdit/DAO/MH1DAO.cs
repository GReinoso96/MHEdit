using MHEdit.DTO;
using MHEdit.Helpers;
using MHEdit.Interfaces;
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
        private BaseHelper Helper = new MH1JAHelper();

        private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        public void SetGame(string code)
        {
            switch (code)
            {
                case "1NA":
                    Helper = new MH1NAHelper();
                    break;
                case "1JA":
                default:
                    Helper = new MH1JAHelper();
                    break;
            }
        }

        public void DumpData(string inFile, string outFolder)
        {
            var melee = GetMelee(inFile);
            var gunner = GetGunner(inFile);
            var head = GetArmorParts(inFile, Helper.headOffset, Helper.headCount, Helper.headNames);
            var chest = GetArmorParts(inFile, Helper.chestOffset, Helper.chestCount, Helper.chestNames);
            var arm = GetArmorParts(inFile, Helper.armOffset, Helper.armCount, Helper.armNames);
            var waist = GetArmorParts(inFile, Helper.waistOffset, Helper.waistCount, Helper.waistNames);
            var leg = GetArmorParts(inFile, Helper.legOffset, Helper.legCount ,Helper.legNames);
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
                br.BaseStream.Seek(Helper.gunnerOffset, SeekOrigin.Begin);
                Dictionary<string, DTO.MHJGunner> gunnerWeapons = new();
                for (int i = 0; i < Helper.gunnerCount; i++)
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
                    gunnerWeapons.Add(Helper.gunnerNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(gunnerWeapons, JsonOptions);
                return jsonString;
            }
        }

        public string GetMelee(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helper.meleeOffset, SeekOrigin.Begin);
                Dictionary<string, DTO.MH1Melee> meleeWeapons = new();
                for (int i = 0; i < Helper.meleeCount; i++)
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
                    meleeWeapons.Add(Helper.meleeNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(meleeWeapons, JsonOptions);
                return jsonString;
            }
        }

        public string GetSkills(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helper.skillsOffset, SeekOrigin.Begin);
                Dictionary<int, DTO.MH1Skills> armorSkills = new();
                for (int i = 0; i < Helper.skillsCount; i++)
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
                SaveArmorParts(outFile, headIn, Helper.headOffset);
                SaveArmorParts(outFile, chestIn, Helper.chestOffset);
                SaveArmorParts(outFile, armsIn, Helper.armOffset);
                SaveArmorParts(outFile, waistIn, Helper.waistOffset);
                SaveArmorParts(outFile, legIn, Helper.legOffset);
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
                    bw.BaseStream.Seek(Helper.gunnerOffset, SeekOrigin.Begin);
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
                    bw.BaseStream.Seek(Helper.meleeOffset, SeekOrigin.Begin);
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
                    bw.BaseStream.Seek(Helper.skillsOffset, SeekOrigin.Begin);
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
