using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MHEdit.Controllers
{
    internal static class P2G
    {
        public static uint meleeOffset = Helpers.P2GHelper.meleeOffset;
        public static uint gunnerOffset = Helpers.P2GHelper.gunnerOffset;
        public static uint headOffset = Helpers.P2GHelper.headOffset;
        public static uint chestOffset = Helpers.P2GHelper.chestOffset;
        public static uint armOffset = Helpers.P2GHelper.armOffset;
        public static uint waistOffset = Helpers.P2GHelper.waistOffset;
        public static uint legOffset = Helpers.P2GHelper.legOffset;

        public static void SetGame(string code)
        {
            switch (code)
            {
                case "NAFU":
                    meleeOffset = Helpers.P2GHelper.meleeOffsetNA;
                    gunnerOffset = Helpers.P2GHelper.gunnerOffsetNA;
                    headOffset = Helpers.P2GHelper.headOffsetNA;
                    chestOffset = Helpers.P2GHelper.chestOffsetNA;
                    armOffset = Helpers.P2GHelper.armOffsetNA;
                    waistOffset = Helpers.P2GHelper.waistOffsetNA;
                    legOffset = Helpers.P2GHelper.legOffsetNA;
                    break;
                case "EUFU":
                    meleeOffset = Helpers.P2GHelper.meleeOffsetEU;
                    gunnerOffset = Helpers.P2GHelper.gunnerOffsetEU;
                    headOffset = Helpers.P2GHelper.headOffsetEU;
                    chestOffset = Helpers.P2GHelper.chestOffsetEU;
                    armOffset = Helpers.P2GHelper.armOffsetEU;
                    waistOffset = Helpers.P2GHelper.waistOffsetEU;
                    legOffset = Helpers.P2GHelper.legOffsetEU;
                    break;
                case "P2G":
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

        public static string GetMelee(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(meleeOffset, SeekOrigin.Begin);
                Dictionary<string,Equipment.P2GMelee> meleeWeapons = new();
                for (int i = 0; i < Helpers.P2GHelper.meleeCount; i++)
                {
                    Equipment.P2GMelee weapon = new(
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadSByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadByte());
                    meleeWeapons.Add(Helpers.P2GHelper.meleeNames[i],weapon);
                }

                string jsonString = JsonSerializer.Serialize(meleeWeapons, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetGunner(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(gunnerOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GGunner> gunnerWeapons = new();
                for (int i = 0; i < Helpers.P2GHelper.gunnerCount; i++)
                {
                    Equipment.P2GGunner weapon = new(
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadUInt16(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt32(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte());
                    gunnerWeapons.Add(Helpers.P2GHelper.gunnerNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(gunnerWeapons, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetHelms(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(headOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> headParts = new();
                for (int i = 0; i < Helpers.P2GHelper.headCount; i++)
                {
                    Equipment.P2GArmor armor = new(
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32(),
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
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte());
                    headParts.Add(Helpers.P2GHelper.headNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(headParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetChests(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(chestOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> chestParts = new();
                for (int i = 0; i < Helpers.P2GHelper.chestCount; i++)
                {
                    Equipment.P2GArmor armor = new(
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32(),
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
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte());
                    chestParts.Add(Helpers.P2GHelper.chestNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(chestParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetArms(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(armOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> armParts = new();
                for (int i = 0; i < Helpers.P2GHelper.armCount; i++)
                {
                    Equipment.P2GArmor armor = new(
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32(),
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
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte());
                    armParts.Add(Helpers.P2GHelper.armNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(armParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetWaists(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(waistOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> waistParts = new();
                for (int i = 0; i < Helpers.P2GHelper.waistCount; i++)
                {
                    Equipment.P2GArmor armor = new(
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32(),
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
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte());
                    waistParts.Add(Helpers.P2GHelper.waistNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(waistParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetLegs(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(legOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> legParts = new();
                for (int i = 0; i < Helpers.P2GHelper.legCount; i++)
                {
                    Equipment.P2GArmor armor = new(
                        br.ReadUInt16(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadUInt32(),
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
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadByte(),
                        br.ReadUInt16(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte(),
                        br.ReadByte(),
                        br.ReadSByte());
                    legParts.Add(Helpers.P2GHelper.legNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(legParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static void SaveMelee(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(meleeOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GMelee> meleeWeapons = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GMelee>>(jsonIn);
                foreach(var item in meleeWeapons)
                {
                    bw.Write((UInt16)item.Value.Model);
                    bw.Write((byte)item.Value.Rarity);
                    bw.Write((byte)item.Value.Unk1);
                    bw.Write((UInt32)item.Value.Price);
                    bw.Write((UInt16)item.Value.Sharpness);
                    bw.Write((UInt16)item.Value.Attack);
                    bw.Write((sbyte)item.Value.Defense);
                    bw.Write((sbyte)item.Value.Affinity);
                    bw.Write((byte)item.Value.ElementId);
                    bw.Write((byte)item.Value.ElementValue);
                    bw.Write((byte)item.Value.StatusId);
                    bw.Write((byte)item.Value.StatusValue);
                    bw.Write((byte)item.Value.Slots);
                    bw.Write((byte)item.Value.Unk2);
                    bw.Write((byte)item.Value.ExtraBit);
                    bw.Write((UInt16)item.Value.SortOrder);
                    bw.Write((byte)item.Value.Unk3);
                }
            }
        }

        public static void SaveGunner(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(gunnerOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GGunner> gunnerWeapons = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GGunner>>(jsonIn);
                foreach (var item in gunnerWeapons)
                {
                    bw.Write((UInt16)item.Value.Model);
                    bw.Write((byte)item.Value.Rarity);
                    bw.Write((byte)item.Value.Unk1);
                    bw.Write((UInt32)item.Value.Price);
                    bw.Write((UInt16)item.Value.Damage);
                    bw.Write((sbyte)item.Value.Defense);
                    bw.Write((byte)item.Value.Recoil);
                    bw.Write((byte)item.Value.Slots);
                    bw.Write((sbyte)item.Value.Affinity);
                    bw.Write((UInt16)item.Value.SortOrder);
                    bw.Write((byte)item.Value.AmmoConfig);
                    bw.Write((byte)item.Value.ElementId);
                    bw.Write((byte)item.Value.ElementValue);
                    bw.Write((byte)item.Value.ReloadSpeed);
                    bw.Write((UInt32)item.Value.Unk2);
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
                Dictionary<string, Equipment.P2GArmor> headParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                WriteArmor(bw, headParts);
            }
        }

        public static void SaveChests(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(chestOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> chestParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                WriteArmor(bw, chestParts);
            }
        }

        public static void SaveArms(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(armOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> armParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                WriteArmor(bw, armParts);
            }
        }

        public static void SaveWaists(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(waistOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> waistParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                WriteArmor(bw, waistParts);
            }
        }

        public static void SaveLegs(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(legOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> legParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                WriteArmor(bw, legParts);
            }
        }

        private static void WriteArmor(BinaryWriter bw, Dictionary<string, Equipment.P2GArmor> parts)
        {
            foreach (var item in parts)
            {
                bw.Write((UInt16)item.Value.ModelMale);
                bw.Write((UInt16)item.Value.ModelFemale);
                bw.Write((byte)item.Value.Type);
                bw.Write((byte)item.Value.Rarity);
                bw.Write((UInt16)item.Value.Unk1);
                bw.Write((UInt32)item.Value.Price);
                bw.Write((byte)item.Value.Defense);
                bw.Write((sbyte)item.Value.ResFire);
                bw.Write((sbyte)item.Value.ResWater);
                bw.Write((sbyte)item.Value.ResThunder);
                bw.Write((sbyte)item.Value.ResDragon);
                bw.Write((sbyte)item.Value.ResIce);
                bw.Write((byte)item.Value.Slots);
                bw.Write((byte)item.Value.Series);
                bw.Write((byte)item.Value.ArmorSphere);
                bw.Write((byte)item.Value.ArmorSpherePlus);
                bw.Write((byte)item.Value.ArmorSphereHard);
                bw.Write((byte)item.Value.ArmorSphereHeavy);
                bw.Write((byte)item.Value.ArmorSphereRoyal);
                bw.Write((byte)item.Value.ArmorSphereTrue);
                bw.Write((byte)item.Value.MaxLevel);
                bw.Write((byte)item.Value.Unk2);
                bw.Write((UInt16)item.Value.SortOrder);
                bw.Write((byte)item.Value.SkillId1);
                bw.Write((sbyte)item.Value.SkillAmount1);
                bw.Write((byte)item.Value.SkillId2);
                bw.Write((sbyte)item.Value.SkillAmount2);
                bw.Write((byte)item.Value.SkillId3);
                bw.Write((sbyte)item.Value.SkillAmount3);
                bw.Write((byte)item.Value.SkillId4);
                bw.Write((sbyte)item.Value.SkillAmount4);
                bw.Write((byte)item.Value.SkillId5);
                bw.Write((sbyte)item.Value.SkillAmount5);
            }
        }
    }
}
