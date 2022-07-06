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
    internal class P2GDAO : Interfaces.IController
    {
        private static uint meleeOffset = Helpers.P2GHelper.meleeOffset;
        private static uint gunnerOffset = Helpers.P2GHelper.gunnerOffset;
        private static uint headOffset = Helpers.P2GHelper.headOffset;
        private static uint chestOffset = Helpers.P2GHelper.chestOffset;
        private static uint armOffset = Helpers.P2GHelper.armOffset;
        private static uint waistOffset = Helpers.P2GHelper.waistOffset;
        private static uint legOffset = Helpers.P2GHelper.legOffset;

        private static uint meleeCount = Helpers.P2GHelper.meleeCount;
        private static uint gunnerCount = Helpers.P2GHelper.gunnerCount;
        private static uint headCount = Helpers.P2GHelper.headCount;
        private static uint chestCount = Helpers.P2GHelper.chestCount;
        private static uint armCount = Helpers.P2GHelper.armCount;
        private static uint waistCount = Helpers.P2GHelper.waistCount;
        private static uint legCount = Helpers.P2GHelper.legCount;

        private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        public void SetGame(string code)
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

        public void DumpData(string inFile, string outFolder)
        {
            var melee = GetMelee(inFile);
            var gunner = GetGunner(inFile);
            var head = GetArmorParts(inFile, headOffset, headCount, Helpers.P2GHelper.headNames);
            var chest = GetArmorParts(inFile, chestOffset, chestCount, Helpers.P2GHelper.chestNames);
            var arm = GetArmorParts(inFile, armOffset, armCount, Helpers.P2GHelper.armNames);
            var waist = GetArmorParts(inFile, waistOffset, waistCount, Helpers.P2GHelper.waistNames);
            var leg = GetArmorParts(inFile, legOffset, legCount, Helpers.P2GHelper.legNames);

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
                Dictionary<string, DTO.P2GArmor> parts = new();
                for (int i = 0; i < count; i++)
                {
                    DTO.P2GArmor part = new(
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
                    parts.Add($"{i}-{names[i]}", part);
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
                Dictionary<string, DTO.P2GGunner> gunnerWeapons = new();
                for (int i = 0; i < gunnerCount; i++)
                {
                    DTO.P2GGunner weapon = new(
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
                    gunnerWeapons.Add($"{i}-{Helpers.P2GHelper.gunnerNames[i]}", weapon);
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
                Dictionary<string, DTO.P2GMelee> meleeWeapons = new();
                for (int i = 0; i < meleeCount; i++)
                {
                    DTO.P2GMelee weapon = new(
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
                    meleeWeapons.Add($"{i}-{Helpers.P2GHelper.meleeNames[i]}", weapon);
                }

                string jsonString = JsonSerializer.Serialize(meleeWeapons, JsonOptions);
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
                SaveMelee(outFile, meleeIn);
                SaveGunner(outFile, gunnerIn);
                SaveArmorParts(outFile, headIn, headOffset);
                SaveArmorParts(outFile, chestIn, chestOffset);
                SaveArmorParts(outFile, armsIn, armOffset);
                SaveArmorParts(outFile, waistIn, waistOffset);
                SaveArmorParts(outFile, legIn, legOffset);
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
                    Dictionary<string, DTO.P2GArmor> parts = JsonSerializer.Deserialize<Dictionary<string, DTO.P2GArmor>>(jsonIn);
                    foreach (KeyValuePair<string, P2GArmor> item in parts)
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

        public void SaveGunner(string fileIn, string jsonIn)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(gunnerOffset, SeekOrigin.Begin);
                    Dictionary<string, DTO.P2GGunner> gunnerWeapons = JsonSerializer.Deserialize<Dictionary<string, DTO.P2GGunner>>(jsonIn);
                    foreach (KeyValuePair<string, P2GGunner> item in gunnerWeapons)
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
        }

        public void SaveMelee(string fileIn, string jsonIn)
        {
            if (jsonIn != null)
            {
                using (BinaryWriter bw = new(File.OpenWrite(fileIn)))
                {
                    bw.BaseStream.Seek(meleeOffset, SeekOrigin.Begin);
                    Dictionary<string, DTO.P2GMelee> meleeWeapons = JsonSerializer.Deserialize<Dictionary<string, DTO.P2GMelee>>(jsonIn);
                    foreach (var item in meleeWeapons)
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
        }
    }
}
