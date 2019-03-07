using System.Collections;

namespace LnkReader
{
    class LnkFlags
    {
        /// <summary>
        ///  The shell link is saved with an item ID list (IDList).
        ///  If this bit is set, a LinkTargetIDList structure MUST follow the ShellLinkHeader.
        ///  If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public readonly bool HasLinkTargetIDList;
        /// <summary>
        /// The shell link is saved with link information.
        /// If this bit is set, a LinkInfo structure MUST be present.
        /// If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public readonly bool HasLinkInfo;
        /// <summary>
        /// The shell link is saved with a name string.
        /// If this bit is set, a NAME_STRING StringData structure MUST be present.
        /// If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public readonly bool HasName;
        /// <summary>
        /// The shell link is saved with a relative path string.
        /// If this bit is set, a RELATIVE_PATH StringData structure MUST be present.
        /// If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public readonly bool HasRelativePath;
        /// <summary>
        /// The shell link is saved with a working directory string.
        /// If this bit is set, a WORKING_DIR StringData structure MUST be present.
        /// If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public readonly bool HasWorkingDir;
        /// <summary>
        /// The shell link is saved with command line arguments.
        /// If this bit is set, a COMMAND_LINE_ARGUMENTS StringData structure MUST be present.
        /// If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public readonly bool HasArguments;
        /// <summary>
        /// The shell link is saved with an icon location string.
        /// If this bit is set, an ICON_LOCATION StringData structure MUST be present.
        /// If this bit is not set, this structure MUST NOT be present.
        /// </summary>
        public readonly bool HasIconLocation;
        /// <summary>
        /// The shell link contains Unicode encoded strings. This bit SHOULD be set.
        /// If this bit is set, the StringData section contains Unicode-encoded strings;
        /// otherwise, it contains strings that are encoded using the system default code page.
        /// </summary>
        public readonly bool IsUnicode;
        /// <summary>
        /// The LinkInfo structure is ignored.
        /// </summary>
        public readonly bool ForceNoLinkInfo;
        /// <summary>
        /// The shell link is saved with an EnvironmentVariableDataBlock.
        /// </summary>
        public readonly bool HasExpString;
        /// <summary>
        /// The target is run in a separate virtual machine when launching a link target that
        /// is a 16-bit application.
        /// </summary>
        public readonly bool RunInSeparateProcess;
        /// <summary>
        /// The shell link is saved with a DarwinDataBlock.
        /// </summary>
        public readonly bool HasDarwinID;
        /// <summary>
        /// The application is run as a different user when the target of the shell link is activated.
        /// </summary>
        public readonly bool RunAsUser;
        /// <summary>
        /// The shell link is saved with an IconEnvironmentDataBlock.
        /// </summary>
        public readonly bool HasExpIcon;
        /// <summary>
        /// The file system location is represented in the shell namespace when the
        /// path to an item is parsed into an IDList.
        /// </summary>
        public readonly bool NoPidlAlias;
        /// <summary>
        /// The shell link is saved with a ShimDataBlock.
        /// </summary>
        public readonly bool RunWithShimLayer;
        /// <summary>
        /// The TrackerDataBlock is ignored.
        /// </summary>
        public readonly bool ForceNoLinkTrack;
        /// <summary>
        /// The shell link attempts to collect target properties and store them in the
        /// PropertyStoreDataBlock when the link target is set.
        /// </summary>
        public readonly bool EnableTargetMetadata;
        /// <summary>
        /// The EnvironmentVariableDataBlock is ignored.
        /// </summary>
        public readonly bool DisableLinkPathTracking;
        /// <summary>
        /// The SpecialFolderDataBlock (section 2.5.9) and the
        /// KnownFolderDataBlock are ignored when loading the shell
        /// link.If this bit is set, these extra data blocks SHOULD NOT be saved when
        /// saving the shell link.
        /// </summary>
        public readonly bool DisableKnownFolderTracking;
        /// <summary>
        /// If the link has a KnownFolderDataBlock, the unaliased form
        /// of the known folder IDList SHOULD be used when translating the target
        /// IDList at the time that the link is loaded.
        /// </summary>
        public readonly bool DisableKnownFolderAlias;
        /// <summary>
        /// Creating a link that references another link is enabled. Otherwise,
        /// specifying a link as the target IDList SHOULD NOT be allowed.
        /// </summary>
        public readonly bool AllowLinkToLink;
        /// <summary>
        /// When saving a link for which the target IDList is under a known folder,
        /// either the unaliased form of that known folder or the target IDList SHOULD be used.
        /// </summary>
        public readonly bool UnaliasOnSave;
        /// <summary>
        /// The target IDList SHOULD NOT be stored; instead, the path specified in the
        /// EnvironmentVariableDataBlock SHOULD be used to refer to the target.
        /// </summary>
        public readonly bool PreferEnvironmentPath;
        /// <summary>
        /// When the target is a UNC name that refers to a location on a local
        /// machine, the local path IDList in the PropertyStoreDataBlock SHOULD be stored,
        /// so it can be used when the link is loaded on the local machine.
        /// </summary>
        public readonly bool KeepLocalIDListForUNCTarget;

        public LnkFlags(byte[] fb)
        {
            var bits = new BitArray(fb);

            HasLinkTargetIDList = bits[0];
            HasLinkInfo = bits[1];
            HasName = bits[2];
            HasRelativePath = bits[3];
            HasWorkingDir = bits[4];
            HasArguments = bits[5];
            HasIconLocation = bits[6];
            IsUnicode = bits[7];
            ForceNoLinkInfo = bits[8];
            HasExpString = bits[9];
            RunInSeparateProcess = bits[10];
            // bits[11] MUST be ignored
            HasDarwinID = bits[12];
            RunAsUser = bits[13];
            HasExpIcon = bits[14];
            NoPidlAlias = bits[15];
            // bits[16] MUST be ignored
            RunWithShimLayer = bits[17];
            ForceNoLinkTrack = bits[18];
            EnableTargetMetadata = bits[19];
            DisableLinkPathTracking = bits[20];
            DisableKnownFolderTracking = bits[21];
            DisableKnownFolderAlias = bits[22];
            AllowLinkToLink = bits[23];
            UnaliasOnSave = bits[24];
            PreferEnvironmentPath = bits[25];
            KeepLocalIDListForUNCTarget = bits[26];
            // bits[27] to bits[31] MUST be zero.
        }
    }
}
