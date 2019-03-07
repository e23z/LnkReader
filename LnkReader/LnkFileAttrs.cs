using System.Collections;

namespace LnkReader
{
    class LnkFileAttrs
    {
        /// <summary>
        /// The file or directory is read-only. For a file, if this bit is set,
        /// applications can read the file but cannot write to it or delete
        /// it.For a directory, if this bit is set, applications cannot delete
        /// the directory.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_READONLY;
        /// <summary>
        /// The file or directory is hidden. If this bit is set, the file or
        /// folder is not included in an ordinary directory listing.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_HIDDEN;
        /// <summary>
        /// The file or directory is part of the operating system or is used
        /// exclusively by the operating system.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_SYSTEM;
        /// <summary>
        /// The link target is a directory instead of a file.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_DIRECTORY;
        /// <summary>
        /// The file or directory is an archive file. Applications use this
        /// flag to mark files for backup or removal.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_ARCHIVE;
        /// <summary>
        /// The file or directory has no other flags set. If this bit is 1, all
        /// other bits in this structure MUST be clear.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_NORMAL;
        /// <summary>
        /// The file is being used for temporary storage.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_TEMPORARY;
        /// <summary>
        /// The file is a sparse file.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_SPARSE_FILE;
        /// <summary>
        /// The file or directory has an associated reparse point.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_REPARSE_POINT;
        /// <summary>
        /// The file or directory is compressed. For a file, this means that
        /// all data in the file is compressed.For a directory, this means
        /// that compression is the default for newly created files and subdirectories.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_COMPRESSED;
        /// <summary>
        /// The data of the file is not immediately available.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_OFFLINE;
        /// <summary>
        /// The contents of the file need to be indexed.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_NOT_CONTENT_INDEXED;
        /// <summary>
        /// The file or directory is encrypted. For a file, this means that
        /// all data in the file is encrypted.For a directory, this means
        /// that encryption is the default for newly created files and subdirectories.
        /// </summary>
        public readonly bool FILE_ATTRIBUTE_ENCRYPTED;

        public LnkFileAttrs(byte[] fab)
        {
            var bits = new BitArray(fab);

            FILE_ATTRIBUTE_READONLY = bits[0];
            FILE_ATTRIBUTE_HIDDEN = bits[1];
            FILE_ATTRIBUTE_SYSTEM = bits[2];
            // bits[3] MUST be zero
            FILE_ATTRIBUTE_DIRECTORY = bits[4];
            FILE_ATTRIBUTE_ARCHIVE = bits[5];
            // bits[6] MUST be zero
            FILE_ATTRIBUTE_NORMAL = bits[7];
            FILE_ATTRIBUTE_TEMPORARY = bits[8];
            FILE_ATTRIBUTE_SPARSE_FILE = bits[9];
            FILE_ATTRIBUTE_REPARSE_POINT = bits[10];
            FILE_ATTRIBUTE_COMPRESSED = bits[11];
            FILE_ATTRIBUTE_OFFLINE = bits[12];
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = bits[13];
            FILE_ATTRIBUTE_ENCRYPTED = bits[14];
            // bits[15] to bits[31] MUST be zero
        }
    }
}
