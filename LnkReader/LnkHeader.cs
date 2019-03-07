using System;
using System.Linq;

namespace LnkReader
{
    class LnkHeader
    {
        public readonly int Size;
        public readonly Guid CLSID;
        public readonly LnkFlags Flags;
        public readonly LnkFileAttrs Attrs;
        public readonly DateTime CreationTime;
        public readonly DateTime AccessTime;
        public readonly DateTime WriteTime;
        public readonly uint FileSize;
        public readonly int IconIndex;
        public readonly LnkShowCommand ShowCommand;
        //TODO: HotKey;

        public LnkHeader(byte[] hb)
        {
            Size = BitConverter.ToInt32(hb.Take(4).ToArray(), 0);
            CLSID = new Guid(hb.Skip(4).Take(16).ToArray());
            Flags = new LnkFlags(hb.Skip(20).Take(4).ToArray());
            Attrs = new LnkFileAttrs(hb.Skip(24).Take(4).ToArray());
            CreationTime = DateTime.FromFileTime(BitConverter.ToInt64(hb.Skip(28).Take(8).ToArray(), 0));
            AccessTime = DateTime.FromFileTime(BitConverter.ToInt64(hb.Skip(36).Take(8).ToArray(), 0));
            WriteTime = DateTime.FromFileTime(BitConverter.ToInt64(hb.Skip(44).Take(8).ToArray(), 0));
            FileSize = BitConverter.ToUInt32(hb.Skip(52).Take(4).ToArray(), 0);
            IconIndex = BitConverter.ToInt32(hb.Skip(56).Take(4).ToArray(), 0);
            ShowCommand = (LnkShowCommand)BitConverter.ToUInt32(hb.Skip(60).Take(4).ToArray(), 0);
            //TODO: HotKey -> 2B
            // 2B Reserved 1
            // 4B Reserved 2
            // 4B Reserved 3
        }
    }
}
