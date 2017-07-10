using System;

namespace Emulators
{
    static class GSR
    {
        public const byte Version = 0x01;

        private const int HeaderSize = 3;
        private const int SizeSize = 3;
        private const string InvalidFormat = "Invalid GSR save state format";

        public static void DecodeSAV(byte[] fileData, byte[] data)
        {
            if (fileData[0] != 0xFF || fileData[1] != Version)
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
            return GetOffset(fileData, "sram");
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
            return (fileData[offset + 0] << 16) |
                (fileData[offset + 1] << 8) |
                fileData[offset + 2];
        }

        private static int GetOffset(byte[] fileData, string searchKey)
        {
            int offset = HeaderSize;
            int size = ReadSize(fileData, offset);
            offset += SizeSize + size;

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
