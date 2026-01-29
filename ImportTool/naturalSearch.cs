using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImportTool
{
    public class NaturalSort
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string psz1, string psz2);

        public static string[] GetFilesNaturalSort(string path, string searchPattern, SearchOption searchoptions)
        {
            string[] files = Directory.GetFiles(path, searchPattern, searchoptions);
            Array.Sort(files, (x, y) => StrCmpLogicalW(x, y));
            return files;
        }
    }
}

