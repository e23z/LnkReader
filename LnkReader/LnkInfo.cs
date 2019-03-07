using System;
using System.Linq;
using System.Text;

namespace LnkReader {
  class LnkInfo {
    const int OPTIONALS_NOT_SPECIFIED = 0x0000001C; // 24
    const int OPTIONALS_SPECIFIED = 0x00000024; // 36

    public readonly int Size;
    public readonly int HeaderSize;
    public readonly LnkInfoFlags Flags;
    public readonly int VolumeIDOffset;
    public readonly int LocalBasePathOffset;
    public readonly int CommonNetworkRelativeLinkOffset;
    public readonly int CommonPathSuffixOffset;
    public readonly int LocalBasePathOffsetUnicode;
    public readonly int CommonPathSuffixOffsetUnicode;
    public readonly LnkVolumeId VolumeID;
    public readonly string LocalBasePath;
    public readonly LnkCommonNetworkRelativeLink CommonNetworkRelativeLink;
    public readonly string CommonPathSuffix;
    public readonly string LocalBasePathUnicode;
    public readonly string CommonPathSuffixUnicode;

    public LnkInfo(byte[] ib) {
      Size = BitConverter.ToInt32(ib.Take(4).ToArray(), 0);
      HeaderSize = BitConverter.ToInt32(ib.Skip(4).Take(4).ToArray(), 0);
      Flags = new LnkInfoFlags(ib.Skip(8).Take(4).ToArray());
      VolumeIDOffset = BitConverter.ToInt32(ib.Skip(12).Take(4).ToArray(), 0);
      LocalBasePathOffset = BitConverter.ToInt32(ib.Skip(16).Take(4).ToArray(), 0);
      CommonNetworkRelativeLinkOffset = BitConverter.ToInt32(ib.Skip(20).Take(4).ToArray(), 0);
      CommonPathSuffixOffset = BitConverter.ToInt32(ib.Skip(24).Take(4).ToArray(), 0);

      if (HeaderSize >= OPTIONALS_SPECIFIED) {
        LocalBasePathOffsetUnicode = BitConverter.ToInt32(ib.Skip(28).Take(4).ToArray(), 0);
        CommonPathSuffixOffsetUnicode = BitConverter.ToInt32(ib.Skip(32).Take(4).ToArray(), 0);
      }

      if (Flags.VolumeIDAndLocalBasePath) {
        VolumeID = new LnkVolumeId(ib.Skip(VolumeIDOffset).ToArray());
        if (HeaderSize >= OPTIONALS_SPECIFIED) {
          LocalBasePathUnicode = Encoding.UTF8.GetString(ib.Skip(LocalBasePathOffsetUnicode).TakeWhile(_ => _ != 0).ToArray());
          CommonPathSuffixUnicode = Encoding.UTF8.GetString(ib.Skip(CommonPathSuffixOffsetUnicode).TakeWhile(_ => _ != 0).ToArray());
        }
        else {
          LocalBasePath = Encoding.UTF8.GetString(ib.Skip(LocalBasePathOffset).TakeWhile(_ => _ != 0).ToArray());
          CommonPathSuffix = Encoding.UTF8.GetString(ib.Skip(CommonPathSuffixOffset).TakeWhile(_ => _ != 0).ToArray());
        }
      }

      if (Flags.CommonNetworkRelativeLinkAndPathSuffix) {
        CommonNetworkRelativeLink = new LnkCommonNetworkRelativeLink(ib.Skip(CommonPathSuffixOffset).ToArray());
      }
    }
  }
}
