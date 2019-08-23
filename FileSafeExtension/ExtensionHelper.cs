using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSafeExtension
{
    public static class MimeTypes
    {
        public static List<FileType> types;

        static MimeTypes()
        {
            types = new List<FileType> { PDF, WORD, EXCEL, JPEG, ZIP, RAR, RTF, PNG, PPT, GIF, DLL_EXE, MSDOC, BMP, ZIP_7z, ZIP_7z_2, GZ_TGZ, TAR_ZH, TAR_ZV, OGG, ICO, XML, MIDI, FLV, WAVE, DWG, LIB_COFF, PST, PSD, AES, SKR, SKR_2, PKR, EML_FROM, ELF, TXT_UTF8, TXT_UTF16_BE, TXT_UTF16_LE, TXT_UTF32_BE, TXT_UTF32_LE };
        }

        public readonly static FileType WORD = new FileType(new byte?[] { 0xEC, 0xA5, 0xC1, 0x00 }, 512, "doc", "application/msword");
        public readonly static FileType EXCEL = new FileType(new byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 }, 512, "xls", "application/excel");
        public readonly static FileType PPT = new FileType(new byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, 0x00, 0x00, 0x00 }, 512, "ppt", "application/mspowerpoint");
        public readonly static FileType RTF = new FileType(new byte?[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }, "rtf", "application/rtf");
        public readonly static FileType PDF = new FileType(new byte?[] { 0x25, 0x50, 0x44, 0x46 }, "pdf", "application/pdf");
        public readonly static FileType MSDOC = new FileType(new byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }, "", "application/octet-stream");
        public readonly static FileType XML = new FileType(new byte?[] { 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x3F, 0x3E }, "xml,xul", "text/xml");
        public readonly static FileType TXT = new FileType(new byte?[0], "txt", "text/plain");
        public readonly static FileType TXT_UTF8 = new FileType(new byte?[] { 0xEF, 0xBB, 0xBF }, "txt", "text/plain");
        public readonly static FileType TXT_UTF16_BE = new FileType(new byte?[] { 0xFE, 0xFF }, "txt", "text/plain");
        public readonly static FileType TXT_UTF16_LE = new FileType(new byte?[] { 0xFF, 0xFE }, "txt", "text/plain");
        public readonly static FileType TXT_UTF32_BE = new FileType(new byte?[] { 0x00, 0x00, 0xFE, 0xFF }, "txt", "text/plain");
        public readonly static FileType TXT_UTF32_LE = new FileType(new byte?[] { 0xFF, 0xFE, 0x00, 0x00 }, "txt", "text/plain");
        public readonly static FileType JPEG = new FileType(new byte?[] { 0xFF, 0xD8, 0xFF }, "jpg", "image/jpeg");
        public readonly static FileType PNG = new FileType(new byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png", "image/png");
        public readonly static FileType GIF = new FileType(new byte?[] { 0x47, 0x49, 0x46, 0x38, null, 0x61 }, "gif", "image/gif");
        public readonly static FileType BMP = new FileType(new byte?[] { 66, 77 }, "bmp", "image/gif");
        public readonly static FileType ICO = new FileType(new byte?[] { 0, 0, 1, 0 }, "ico", "image/x-icon");
        public readonly static FileType GZ_TGZ = new FileType(new byte?[] { 0x1F, 0x8B, 0x08 }, "gz, tgz", "application/x-gz");
        public readonly static FileType ZIP_7z = new FileType(new byte?[] { 66, 77 }, "7z", "application/x-compressed");
        public readonly static FileType ZIP_7z_2 = new FileType(new byte?[] { 0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C }, "7z", "application/x-compressed");
        public readonly static FileType ZIP = new FileType(new byte?[] { 0x50, 0x4B, 0x03, 0x04 }, "zip", "application/x-compressed");
        public readonly static FileType RAR = new FileType(new byte?[] { 0x52, 0x61, 0x72, 0x21 }, "rar", "application/x-compressed");
        public readonly static FileType DLL_EXE = new FileType(new byte?[] { 0x4D, 0x5A }, "dll, exe", "application/octet-stream");
        public readonly static FileType TAR_ZV = new FileType(new byte?[] { 0x1F, 0x9D }, "tar.z", "application/x-tar");
        public readonly static FileType TAR_ZH = new FileType(new byte?[] { 0x1F, 0xA0 }, "tar.z", "application/x-tar");
        public readonly static FileType OGG = new FileType(new byte?[] { 103, 103, 83, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 }, "oga,ogg,ogv,ogx", "application/ogg");
        public readonly static FileType MIDI = new FileType(new byte?[] { 0x4D, 0x54, 0x68, 0x64 }, "midi,mid", "audio/midi");
        public readonly static FileType FLV = new FileType(new byte?[] { 0x46, 0x4C, 0x56, 0x01 }, "flv", "application/unknown");
        public readonly static FileType WAVE = new FileType(new byte?[] { 0x52, 0x49, 0x46, 0x46, null, null, null, null, 0x57, 0x41, 0x56, 0x45, 0x66, 0x6D, 0x74, 0x20 }, "wav", "audio/wav");
        public readonly static FileType PST = new FileType(new byte?[] { 0x21, 0x42, 0x44, 0x4E }, "pst", "application/octet-stream");
        public readonly static FileType DWG = new FileType(new byte?[] { 0x41, 0x43, 0x31, 0x30 }, "dwg", "application/acad");
        public readonly static FileType PSD = new FileType(new byte?[] { 0x38, 0x42, 0x50, 0x53 }, "psd", "application/octet-stream");
        public readonly static FileType LIB_COFF = new FileType(new byte?[] { 0x21, 0x3C, 0x61, 0x72, 0x63, 0x68, 0x3E, 0x0A }, "lib", "application/octet-stream");
        public readonly static FileType AES = new FileType(new byte?[] { 0x41, 0x45, 0x53 }, "aes", "application/octet-stream");
        public readonly static FileType SKR = new FileType(new byte?[] { 0x95, 0x00 }, "skr", "application/octet-stream");
        public readonly static FileType SKR_2 = new FileType(new byte?[] { 0x95, 0x01 }, "skr", "application/octet-stream");
        public readonly static FileType PKR = new FileType(new byte?[] { 0x99, 0x01 }, "pkr", "application/octet-stream");
        public readonly static FileType EML_FROM = new FileType(new byte?[] { 0x46, 0x72, 0x6F, 0x6D }, "eml", "message/rfc822");
        public readonly static FileType ELF = new FileType(new byte?[] { 0x45, 0x6C, 0x66, 0x46, 0x69, 0x6C, 0x65, 0x00 }, "elf", "text/plain");
        public const int MaxHeaderSize = 560;

        public static FileType GetFileType(this byte[] bytes)
        {
            FileType fileType = null;
            var fileName = Path.GetTempFileName();
            var stream = new MemoryStream(bytes);

            try
            {
                using (var fileStream = File.Create(fileName))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }

                byte[] fileHeader = ReadFileHeader(new FileInfo(fileName), MaxHeaderSize);

                if (!fileHeader.Any(b => b == 0))
                {
                    fileType = TXT;
                }
                else
                {
                    foreach (FileType type in types)
                    {
                        int matchingCount = GetFileMatchingCount(fileHeader, type);

                        if (matchingCount == type.Header.Length)
                        {
                            fileType = type;

                            break;
                        }
                    }
                }
            }
            finally
            {
                File.Delete(fileName);
            }

            return fileType;
        }

        private static int GetFileMatchingCount(byte[] fileHeader, FileType type)
        {
            int matchingCount = 0;

            for (int i = 0; i < type.Header.Length; i++)
            {
                if (type.Header[i] != null && type.Header[i] != fileHeader[i + type.HeaderOffset])
                {
                    matchingCount = 0;

                    break;
                }
                else
                {
                    matchingCount++;
                }
            }

            return matchingCount;
        }

        private static Byte[] ReadFileHeader(FileInfo file, int MaxHeaderSize)
        {
            Byte[] header = new byte[MaxHeaderSize];

            try
            {
                using (FileStream fsSource = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    fsSource.Read(header, 0, MaxHeaderSize);
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException("Could not read file : " + e.Message);
            }

            return header;
        }
    }

    public class FileType
    {
        public byte?[] Header { get; set; }
        public int HeaderOffset { get; set; }
        public string Extension { get; set; }
        public string Mime { get; set; }

        public FileType()
        {

        }

        public FileType(byte?[] header, string extension, string mime)
        {
            Header = header;
            Extension = extension;
            Mime = mime;
            HeaderOffset = 0;
        }

        public FileType(byte?[] header, int offset, string extension, string mime)
        {
            this.Header = null;
            this.Header = header;
            this.HeaderOffset = offset;
            this.Extension = extension;
            this.Mime = mime;
        }

        public override bool Equals(object other)
        {
            if (!(other is FileType)) return false;

            FileType otherType = (FileType)other;

            if (this.Extension == otherType.Extension && this.Mime == otherType.Mime) return true;

            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Extension;
        }
    }
}
