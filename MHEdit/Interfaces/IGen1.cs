using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Interfaces
{
    internal interface IGen1 : IController
    {
        string GetSkills(string fileIn);
        void SaveSkills(string fileIn, string jsonIn);
    }
}
