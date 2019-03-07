using System;
using System.IO;
using System.Reflection;
using LnkReader;

namespace Demo
{
    // https://msdn.microsoft.com/en-us/library/dd871305.aspx
    class Program
    {
        static void Main(string[] args)
        {
            var lnkBasePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var lnkNames = new[] { "firefox.lnk", "sample.lnk", "chrome.lnk" };

            foreach (string name in lnkNames)
            {
                var lnk = Lnk.OpenLnk(Path.Combine(lnkBasePath, name));
                Console.WriteLine("Name: {0}", lnk.Name);
                Console.WriteLine("BasePath: {0}", lnk.BasePath);
                Console.WriteLine("RelativePath: {0}", lnk.RelativePath);
                Console.WriteLine("WorkingDir: {0}", lnk.WorkingDir);
                Console.WriteLine("Args: {0}", lnk.Args);
                Console.WriteLine("IconLocation: {0}", lnk.IconLocation);
                Console.WriteLine("-----------------------");
            }

            Console.ReadLine();
        }
    }
}
