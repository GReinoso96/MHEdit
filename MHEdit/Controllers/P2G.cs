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
    }
}
