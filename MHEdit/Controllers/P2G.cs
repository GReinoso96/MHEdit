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
        public static string GetMelee(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helpers.P2GHelpers.meleeOffset, SeekOrigin.Begin);
                Dictionary<string,Equipment.P2GMelee> meleeWeapons = new();
                for (int i = 0; i < Helpers.P2GHelpers.meleeCount; i++)
                {
                    Equipment.P2GMelee weapon = new Equipment.P2GMelee(
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
                    meleeWeapons.Add(Helpers.P2GHelpers.meleeNames[i],weapon);
                }

                string jsonString = JsonSerializer.Serialize(meleeWeapons, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetGunner(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helpers.P2GHelpers.gunnerOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GGunner> gunnerWeapons = new();
                for (int i = 0; i < Helpers.P2GHelpers.gunnerCount; i++)
                {
                    Equipment.P2GGunner weapon = new Equipment.P2GGunner(
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
                    gunnerWeapons.Add(Helpers.P2GHelpers.gunnerNames[i], weapon);
                }

                string jsonString = JsonSerializer.Serialize(gunnerWeapons, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetHelms(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helpers.P2GHelpers.headOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> headParts = new();
                for (int i = 0; i < Helpers.P2GHelpers.headCount; i++)
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
                    headParts.Add(Helpers.P2GHelpers.headNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(headParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetChests(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helpers.P2GHelpers.chestOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> chestParts = new();
                for (int i = 0; i < Helpers.P2GHelpers.chestCount; i++)
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
                    chestParts.Add(Helpers.P2GHelpers.chestNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(chestParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetArms(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helpers.P2GHelpers.armOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> armParts = new();
                for (int i = 0; i < Helpers.P2GHelpers.armCount; i++)
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
                    armParts.Add(Helpers.P2GHelpers.armNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(armParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetWaists(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helpers.P2GHelpers.waistOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> waistParts = new();
                for (int i = 0; i < Helpers.P2GHelpers.waistCount; i++)
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
                    waistParts.Add(Helpers.P2GHelpers.waistNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(waistParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static string GetLegs(string fileIn)
        {
            using (BinaryReader br = new(File.OpenRead(fileIn)))
            {
                br.BaseStream.Seek(Helpers.P2GHelpers.legOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> legParts = new();
                for (int i = 0; i < Helpers.P2GHelpers.legCount; i++)
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
                    legParts.Add(Helpers.P2GHelpers.legNames[i], armor);
                }

                string jsonString = JsonSerializer.Serialize(legParts, new JsonSerializerOptions { WriteIndented = true });
                return jsonString;
            }
        }

        public static void saveMelee(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(Helpers.P2GHelpers.meleeOffset, SeekOrigin.Begin);
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

        public static void saveGunner(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(Helpers.P2GHelpers.gunnerOffset, SeekOrigin.Begin);
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

        public static void saveHeads(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(Helpers.P2GHelpers.headOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> headParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                writeArmor(bw, headParts);
            }
        }

        public static void saveChests(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(Helpers.P2GHelpers.chestOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> chestParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                writeArmor(bw, chestParts);
            }
        }

        public static void saveArms(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(Helpers.P2GHelpers.armOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> armParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                writeArmor(bw, armParts);
            }
        }

        public static void saveWaists(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(Helpers.P2GHelpers.waistOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> waistParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                writeArmor(bw, waistParts);
            }
        }

        public static void saveLegs(string fileIn, string jsonIn)
        {
            using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
            {
                bw.BaseStream.Seek(Helpers.P2GHelpers.legOffset, SeekOrigin.Begin);
                Dictionary<string, Equipment.P2GArmor> legParts = JsonSerializer.Deserialize<Dictionary<string, Equipment.P2GArmor>>(jsonIn);
                writeArmor(bw, legParts);
            }
        }

        private static void writeArmor(BinaryWriter bw, Dictionary<string, Equipment.P2GArmor> parts)
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
