using System;
using System.Linq;
using System.Text;

namespace LnkReader {
  class LnkVolumeId {
    const int IGNORE_LABEL_OFFSET = 0x00000014;

    public readonly int Size;
    public readonly LnkDriveType DriveType;
    public readonly int DriveSerialNumber;
    public readonly int VolumeLabelOffset;
    public readonly int VolumeLabelOffsetUnicode;
    public readonly string Data;

    public LnkVolumeId(byte[] vib) {
      Size = BitConverter.ToInt32(vib.Take(4).ToArray(), 0);

      vib = vib.Take(Size).ToArray();

      DriveType = (LnkDriveType)BitConverter.ToInt32(vib.Skip(4).Take(4).ToArray(), 0);
      DriveSerialNumber = BitConverter.ToInt32(vib.Skip(8).Take(4).ToArray(), 0);
      VolumeLabelOffset = BitConverter.ToInt32(vib.Skip(12).Take(4).ToArray(), 0);

      if (VolumeLabelOffset == IGNORE_LABEL_OFFSET)
        VolumeLabelOffsetUnicode = BitConverter.ToInt32(vib.Skip(16).Take(4).ToArray(), 0);

      int offset = VolumeLabelOffset != IGNORE_LABEL_OFFSET ? VolumeLabelOffset : VolumeLabelOffsetUnicode;
      Data = Encoding.UTF8.GetString(vib.Skip(offset).ToArray()).Replace("\0", "");
    }
  }
}
