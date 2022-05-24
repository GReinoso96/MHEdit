using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEdit.Helpers
{
    internal static class PathHelper
    {
        public static string sanePath(string pathIn)
        {
            string path = Path.GetDirectoryName(pathIn);
            foreach(char c in Path.GetInvalidPathChars())
            {
                path = path.Replace(c.ToString(), "");
            }

            string file = Path.GetFileName(pathIn);
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                file = file.Replace(c.ToString(), "");
            }

            return path + file;
        }
    }
}
