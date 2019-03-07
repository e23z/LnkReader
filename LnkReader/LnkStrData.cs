using System;
using System.Linq;
using System.Text;
using System.IO;

namespace LnkReader {
  class LnkStrData {
    public readonly string NAME_STRING;
    public readonly string RELATIVE_PATH;
    public readonly string WORKING_DIR;
    public readonly string COMMAND_LINE_ARGUMENTS;
    public readonly string ICON_LOCATION;

    public LnkStrData(LnkFlags flags, byte[] sdb) {
      int charCount;
      int i;
      StringBuilder sb = new StringBuilder();

      if (flags.HasName)
      {
        charCount = BitConverter.ToInt16(sdb.Take(2).ToArray(), 0);
        i = 2;
        while(sb.Length < charCount)
        {
          char c = Convert.ToChar(sdb[i++]);
          if (c == '\0')
            continue;
          sb.Append(c);
        }
        NAME_STRING = sb.ToString();
        sdb = sdb.Skip(i + 1).ToArray();
        sb.Clear();
      }

      if (flags.HasRelativePath) {
        charCount = BitConverter.ToInt16(sdb.Take(2).ToArray(), 0);
        i = 2;
        while (sb.Length < charCount) {
          char c = Convert.ToChar(sdb[i++]);
          if (c == '\0')
            continue;
          sb.Append(c);
        }
        RELATIVE_PATH = sb.ToString();
        sdb = sdb.Skip(i + 1).ToArray();
        sb.Clear();
      }

      if (flags.HasWorkingDir) {
        charCount = BitConverter.ToInt16(sdb.Take(2).ToArray(), 0);
        i = 2;
        while (sb.Length < charCount) {
          char c = Convert.ToChar(sdb[i++]);
          if (c == '\0')
            continue;
          sb.Append(c);
        }
        WORKING_DIR = sb.ToString();
        sdb = sdb.Skip(i + 1).ToArray();
        sb.Clear();
      }

      if (flags.HasArguments) {
        charCount = BitConverter.ToInt16(sdb.Take(2).ToArray(), 0);
        i = 2;
        while (sb.Length < charCount) {
          char c = Convert.ToChar(sdb[i++]);
          if (c == '\0')
            continue;
          sb.Append(c);
        }
        COMMAND_LINE_ARGUMENTS = sb.ToString();
        sdb = sdb.Skip(i + 1).ToArray();
        sb.Clear();
      }

      if (flags.HasIconLocation) {
        charCount = BitConverter.ToInt16(sdb.Take(2).ToArray(), 0);
        i = 2;
        while (sb.Length < charCount) {
          char c = Convert.ToChar(sdb[i++]);
          if (c == '\0')
            continue;
          sb.Append(c);
        }
        ICON_LOCATION = sb.ToString();
        sdb = sdb.Skip(i + 1).ToArray();
        sb.Clear();
      }
    }
  }
}
