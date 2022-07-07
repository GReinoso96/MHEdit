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
            var head = GetArmorParts(inFile, Helper.HeadOffset, Helper.HeadCount, Helper.HeadNames);
            var chest = GetArmorParts(inFile, Helper.ChestOffset, Helper.ChestCount, Helper.ChestNames);
            var arm = GetArmorParts(inFile, Helper.ArmOffset, Helper.ArmCount, Helper.ArmNames);
            var waist = GetArmorParts(inFile, Helper.WaistOffset, Helper.WaistCount, Helper.WaistNames);
            var leg = GetArmorParts(inFile, Helper.LegOffset, Helper.LegCount ,Helper.LegNames);
            var skills = GetSkills(inFile);
            var weaponCrafts = GetCrafting(inFile, Helper.WeaponCraftOffset, Helper.WeaponCraftCount);
            var armorCrafts = GetCrafting(inFile, Helper.ArmorCraftOffset, Helper.ArmorCraftCount);
            var upgrades = GetUpgrades(inFile);

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
                File.WriteAllText($"{outFolder}\\WeaponCraft.json", weaponCrafts);
                File.WriteAllText($"{outFolder}\\ArmorCraft.json", armorCrafts);
                File.WriteAllText($"{outFolder}\\WeaponUpgrades.json", upgrades);
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
                Dictionary<string, MH1Armor> parts = new();
                for (int i = 0; i < count; i++)
                {
                    MH1Armor part = new(
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
                Dictionary<string, MHJGunner> gunnerWeapons = new();
                for (int i = 0; i < Helper.GunnerCount; i++)
                {
                    MHJGunner weapon = new(
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
                    gunnerWeapons.Add(Helper.GunnerNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(gunnerWeapons, JsonOptions);
                return jsonString;
            }
        }

        public string GetMelee(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helper.MeleeOffset, SeekOrigin.Begin);
                Dictionary<string, MH1Melee> meleeWeapons = new();
                for (int i = 0; i < Helper.MeleeCount; i++)
                {
                    MH1Melee weapon = new(
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
                    meleeWeapons.Add(Helper.MeleeNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(meleeWeapons, JsonOptions);
                return jsonString;
            }
        }

        public string GetSkills(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helper.SkillsOffset, SeekOrigin.Begin);
                Dictionary<int, MH1Skills> armorSkills = new();
                for (int i = 0; i < Helper.SkillsCount; i++)
                {
                    MH1Skills skill = new(
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

        public string GetUpgrades(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helper.WeaponUpgradeOffset, SeekOrigin.Begin);
                Dictionary<int, MH1Upgrade> upgrades = new();
                for (int i = 0; i < Helper.MeleeCount; i++)
                {
                    MH1Upgrade upgrade = new(
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16());
                    upgrades.Add(i, upgrade);
                }

                string jsonString = JsonSerializer.Serialize(upgrades, JsonOptions);
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
                string weapCraftIn = File.ReadAllText($"{inFolder}\\WeaponCraft.json");
                string armorCraftIn = File.ReadAllText($"{inFolder}\\ArmorCraft.json");
                string weaponUpgradeIn = File.ReadAllText($"{inFolder}\\WeaponUpgrades.json");
                SaveMelee(outFile, meleeIn);
                SaveGunner(outFile, gunnerIn);
                SaveArmorParts(outFile, headIn, Helper.HeadOffset);
                SaveArmorParts(outFile, chestIn, Helper.ChestOffset);
                SaveArmorParts(outFile, armsIn, Helper.ArmOffset);
                SaveArmorParts(outFile, waistIn, Helper.WaistOffset);
                SaveArmorParts(outFile, legIn, Helper.LegOffset);
                SaveSkills(outFile, skillsIn);
                SaveCrafting(outFile, weapCraftIn, Helper.WeaponCraftOffset);
                SaveCrafting(outFile, armorCraftIn, Helper.ArmorCraftOffset);
                SaveSkills(outFile, weaponUpgradeIn);
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
                    Dictionary<string, MH1Armor> parts = JsonSerializer.Deserialize<Dictionary<string, MH1Armor>>(jsonIn);
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
                    Dictionary<string, MHJGunner> gunnerWeapons = JsonSerializer.Deserialize<Dictionary<string, MHJGunner>>(jsonIn);
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
                    bw.BaseStream.Seek(Helper.MeleeOffset, SeekOrigin.Begin);
                    Dictionary<string, MH1Melee> meleeWeapons = JsonSerializer.Deserialize<Dictionary<string, MH1Melee>>(jsonIn);
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
                    bw.BaseStream.Seek(Helper.SkillsOffset, SeekOrigin.Begin);
                    Dictionary<string, MH1Skills> armorSkills = JsonSerializer.Deserialize<Dictionary<string, MH1Skills>>(jsonIn);
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

        public string GetCrafting(string fileIn, uint offset, uint count)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                Dictionary<int, Crafting> crafts = new();
                for (int i = 0; i < count; i++)
                {
                    Crafting craft = new(
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte());
                    crafts.Add(i, craft);
                }

                string jsonString = JsonSerializer.Serialize(crafts, JsonOptions);
                return jsonString;
            }
        }

        public void SaveCrafting(string fileIn, string jsonIn, uint offset)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(offset, SeekOrigin.Begin);
                    Dictionary<string, Crafting> crafts = JsonSerializer.Deserialize<Dictionary<string, Crafting>>(jsonIn);
                    foreach (var item in crafts)
                    {
                        bw.Write((byte)item.Value.Type);
                        bw.Write((byte)item.Value.Unknown);
                        bw.Write((UInt16)item.Value.PieceID);
                        bw.Write((UInt16)item.Value.ItemID1);
                        bw.Write((UInt16)item.Value.ItemAmt1);
                        bw.Write((UInt16)item.Value.ItemID2);
                        bw.Write((UInt16)item.Value.ItemAmt2);
                        bw.Write((UInt16)item.Value.ItemID3);
                        bw.Write((UInt16)item.Value.ItemAmt3);
                        bw.Write((UInt16)item.Value.ItemID4);
                        bw.Write((UInt16)item.Value.ItemAmt4);
                        bw.Write((byte)item.Value.Item1Required);
                        bw.Write((byte)item.Value.Item2Required);
                        bw.Write((byte)item.Value.Item3Required);
                        bw.Write((byte)item.Value.Item4Required);
                    }
                }
            }
        }

        public void SaveUpgrades(string fileIn, string jsonIn)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(Helper.WeaponUpgradeOffset, SeekOrigin.Begin);
                    Dictionary<string, MH1Upgrade> upgrades = JsonSerializer.Deserialize<Dictionary<string, MH1Upgrade>>(jsonIn);
                    foreach (var item in upgrades)
                    {
                        bw.Write((UInt16)item.Value.ItemID1);
                        bw.Write((UInt16)item.Value.ItemAmt1);
                        bw.Write((UInt16)item.Value.ItemID2);
                        bw.Write((UInt16)item.Value.ItemAmt2);
                        bw.Write((UInt16)item.Value.ItemID3);
                        bw.Write((UInt16)item.Value.ItemAmt3);
                        bw.Write((UInt16)item.Value.WeaponID1);
                        bw.Write((UInt16)item.Value.WeaponID2);
                        bw.Write((UInt16)item.Value.WeaponID3);
                        bw.Write((UInt16)item.Value.WeaponID4);
                        bw.Write((UInt16)item.Value.WeaponID5);
                        bw.Write((UInt16)item.Value.WeaponID6);
                    }
                }
            }
        }
    }
}
