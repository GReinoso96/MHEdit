using MHEdit.DTO;
using MHEdit.Helpers;
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
    internal class MHGDAO : Interfaces.IController
    {
        private BaseHelper Helper = new MHGJAHelper();

        private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        public void SetGame(string code)
        {
            switch (code)
            {
                case "GWII":
                    //Helper = new MH1NAHelper();
                    break;
                case "GJA":
                    Helper = new MHGJAHelper();
                    break;
                case "GKO":
                default:
                    Helper = new MHGKOHelper();
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
            var leg = GetArmorParts(inFile, Helper.LegOffset, Helper.LegCount, Helper.LegNames);
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
            using (BinaryReader br = new(File.OpenRead(inFile)))
            {
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                Dictionary<string, MHGArmor> parts = new();
                for (int i = 0; i < count; i++)
                {
                    MHGArmor part = new(
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
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadUInt16());
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
                SaveCrafting(outFile, weapCraftIn, Helper.WeaponCraftOffset);
                SaveCrafting(outFile, armorCraftIn, Helper.ArmorCraftOffset);
                SaveUpgrades(outFile, weaponUpgradeIn);
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
                    Dictionary<string, MHGArmor> parts = JsonSerializer.Deserialize<Dictionary<string, MHGArmor>>(jsonIn);
                    foreach (KeyValuePair<string, MHGArmor> item in parts)
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
                        bw.Write((UInt16)item.Value.Unk1);
                        bw.Write((byte)item.Value.Unk2);
                        bw.Write((UInt32)item.Value.NameOffset);
                        bw.Write((byte)item.Value.SkillID1);
                        bw.Write((sbyte)item.Value.SkillValue1);
                        bw.Write((byte)item.Value.SkillID2);
                        bw.Write((sbyte)item.Value.SkillValue2);
                        bw.Write((byte)item.Value.SkillID3);
                        bw.Write((sbyte)item.Value.SkillValue3);
                        bw.Write((byte)item.Value.SkillID4);
                        bw.Write((sbyte)item.Value.SkillValue4);
                        bw.Write((byte)item.Value.SkillID5);
                        bw.Write((sbyte)item.Value.SkillValue5);
                        bw.Write((UInt16)item.Value.Unk3);
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
