using System.Linq;

namespace LnkReader
{
    public class Lnk
    {
        const int HEADER_SIZE = 76;

        public string BasePath { get; private set; }
        public string Name { get; private set; }
        public string RelativePath { get; private set; }
        public string WorkingDir { get; private set; }
        public string Args { get; private set; }
        public string IconLocation { get; private set; }

        private Lnk()
        {
        }

        static public Lnk OpenLnk(string lnkpath)
        {
            LnkHeader header;
            LnkTarget target;
            LnkInfo info;
            LnkStrData strData;

            var lnkBytes = System.IO.File.ReadAllBytes(lnkpath);

            header = new LnkHeader(lnkBytes.Take(HEADER_SIZE).ToArray());
            lnkBytes = lnkBytes.Skip(HEADER_SIZE).ToArray();

            if (header.Flags.HasLinkTargetIDList)
            {
                target = new LnkTarget(lnkBytes);
                lnkBytes = lnkBytes.Skip(target.Size).ToArray();
            }

            info = new LnkInfo(lnkBytes);
            lnkBytes = lnkBytes.Skip(info.Size).ToArray();

            strData = new LnkStrData(header.Flags, lnkBytes);

            //TODO: ExtraData Structures

            // COM reference to Windows Script Host Object Model.
            //IWshShell shell = new WshShell();
            //var lnk = shell.CreateShortcut(lnkP) as IWshShortcut;
            //if (lnk != null)
            //{
            //    Console.WriteLine("Link name: {0}", lnk.FullName);
            //    Console.WriteLine("link target: {0}", lnk.TargetPath);
            //    Console.WriteLine("link working: {0}", lnk.WorkingDirectory);
            //    Console.WriteLine("description: {0}", lnk.Description);
            //    Console.WriteLine("args: {0}", lnk.Arguments);
            //}

            return new Lnk
            {
                BasePath = string.IsNullOrWhiteSpace(info.LocalBasePath) ? info.LocalBasePathUnicode : info.LocalBasePath,
                Name = strData.NAME_STRING,
                RelativePath = strData.RELATIVE_PATH,
                WorkingDir = strData.WORKING_DIR,
                Args = strData.COMMAND_LINE_ARGUMENTS,
                IconLocation = strData.ICON_LOCATION
            };
        }
    }
}
