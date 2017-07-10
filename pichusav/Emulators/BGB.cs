using System;

namespace Emulators
{
    static class BGB
    {
        public const string Version = "BGB1.0";

        private const int SizeSize = 4;
        private const string InvalidFormat = "Invalid BGB save state format";

        public static void DecodeSAV(byte[] fileData, byte[] data)
        {
            if (ReadString(fileData, 0) != Version)
                throw new Exception(InvalidFormat);

            try
            {
                Array.Copy(fileData, GetSAVOffset(fileData), data, 0, 0x8000);
            }
            catch
            {
                throw new Exception(InvalidFormat);
            }
        }

        public static void EncodeSAV(byte[] data, byte[] fileData)
        {
            try
            {
                Array.Copy(data, 0, fileData, GetSAVOffset(fileData), 0x8000);
            }
            catch
            {
                throw new Exception(InvalidFormat);
            }
        }

        private static int GetSAVOffset(byte[] fileData)
        {
            return GetOffset(fileData, "SRAM");
        }

        private static string ReadString(byte[] fileData, int offset)
        {
            string str = "";

            while (fileData[offset] != 0x00)
                str += Convert.ToChar(fileData[offset++]);

            return str;
        }

        private static int ReadSize(byte[] fileData, int offset)
        {
            return (fileData[offset + 3] << 24) |
                (fileData[offset + 2] << 16) |
                (fileData[offset + 1] << 8) |
                fileData[offset + 0];
        }

        private static int GetOffset(byte[] fileData, string searchKey)
        {
            int offset = 0;
            int size;

            while (true)
            {
                string key = ReadString(fileData, offset);
                offset += key.Length + 1;
                size = ReadSize(fileData, offset);
                offset += SizeSize;

                if (key == searchKey)
                    return offset;

                offset += size;
            }
        }
    }
}
