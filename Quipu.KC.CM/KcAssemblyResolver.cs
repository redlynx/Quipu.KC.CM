using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quipu.KC.CM
{
    public class KcAssemblyResolver
    {
        private static string exePath;
        public static Assembly Resolve(ResolveEventArgs args)
        {
            if (String.IsNullOrEmpty(exePath))
            {
                string softwareRoot = Environment.Is64BitOperatingSystem ? @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node" : @"HKEY_LOCAL_MACHINE\SOFTWARE";
                exePath = Registry.GetValue(Path.Combine(softwareRoot, @"Kofax Image Products\Ascent Capture\3.0"), "ExePath",
                    @"C:\Program Files (x86)\Kofax\CaptureSS\ServLib\Bin").ToString();
            }

            string assemblyPath = Path.Combine(exePath, new AssemblyName(args.Name).Name + ".dll");
            if (File.Exists(assemblyPath))
                return Assembly.LoadFrom(assemblyPath);
            else
                return null;
        }
    }
}
