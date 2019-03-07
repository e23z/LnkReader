using System.Collections;

namespace LnkReader
{
    class LnkInfoFlags
    {
        /// <summary>
        /// If set, the VolumeID and LocalBasePath fields are present,
        /// and their locations are specified by the values of the
        /// VolumeIDOffset and LocalBasePathOffset fields,
        /// respectively. If the value of the LinkInfoHeaderSize field is
        /// greater than or equal to 0x00000024, the
        /// LocalBasePathUnicode field is present, and its location is
        /// specified by the value of the LocalBasePathOffsetUnicode
        /// field.
        /// 
        /// If not set, the VolumeID, LocalBasePath, and
        /// LocalBasePathUnicode fields are not present, and the
        /// values of the VolumeIDOffset and LocalBasePathOffset
        /// fields are zero.If the value of the LinkInfoHeaderSize field
        /// is greater than or equal to 0x00000024, the value of the
        /// LocalBasePathOffsetUnicode field is zero.
        /// </summary>
        public readonly bool VolumeIDAndLocalBasePath;
        /// <summary>
        /// If set, the CommonNetworkRelativeLink field is present, and its location is
        /// specified by the value of the CommonNetworkRelativeLinkOffset field.
        /// 
        /// If not set, the CommonNetworkRelativeLink field is not present, and the value of the
        /// CommonNetworkRelativeLinkOffset field is zero.
        /// </summary>
        public readonly bool CommonNetworkRelativeLinkAndPathSuffix;

        public LnkInfoFlags(byte[] ifb)
        {
            var bits = new BitArray(ifb);

            VolumeIDAndLocalBasePath = bits[0];
            CommonNetworkRelativeLinkAndPathSuffix = bits[1];
        }
    }
}
