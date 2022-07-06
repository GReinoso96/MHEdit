using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Interfaces
{
    internal interface IController
    {
        void SetGame(string code);
        void DumpData(string inFile, string outFolder);
        void LoadData(string inFolder, string outFile);
        string GetArmorParts(string inFile, uint offset, uint count, string[] names);
        string GetGunner(string fileIn);
        string GetMelee(string fileIn);
        void SaveArmorParts(string fileIn, string jsonIn, uint offset);
        void SaveMelee(string fileIn, string jsonIn);
        void SaveGunner(string fileIn, string jsonIn);
    }
}
