using System;

namespace RedBlue
{
    class Connection
    {
        public byte MapIndex;
        public ushort Source;
        public ushort Destination;
        public byte Length;
        public byte MapWidth;
        public byte YAlignment;
        public byte XAlignment;
        public ushort Window;

        public Connection(byte[] data, int offset = 0)
        {
            MapIndex = data[offset + 0];
            Source = data.ToUInt16(offset + 1);
            Destination = data.ToUInt16(offset + 3);
            Length = data[offset + 5];
            MapWidth = data[offset + 6];
            YAlignment = data[offset + 7];
            XAlignment = data[offset + 8];
            Window = data.ToUInt16(offset + 9);
        }
    }

    class MapHeader
    {
        public byte TilesetIndex;
        public byte Height, Width;
        public ushort DataPointer;
        public ushort TextPointer;
        public ushort ScriptPointer;
        public byte ConnectionFlags;
        public Connection[] Connections;
        public ushort ObjectPointer;

        public MapHeader(byte[] data, int offset = 0)
        {
            TilesetIndex = data[offset + 0];
            Height = data[offset + 1];
            Width = data[offset + 2];
            DataPointer = data.ToUInt16(offset + 3);
            TextPointer = data.ToUInt16(offset + 5);
            ScriptPointer = data.ToUInt16(offset + 7);
            ConnectionFlags = data[offset + 9];
            Connections = new Connection[4];
            offset += 10;

            for (int i = 3; i >= 0; i--)
            {
                if (((ConnectionFlags >> i) & 1) == 1)
                {
                    Connections[i] = new Connection(data, offset);
                    offset += 11;
                }
            }

            ObjectPointer = data.ToUInt16(offset);
        }
    }

    public class Object
    {
        public const byte Trainer = 0x40;
        public const byte Item = 0x80;

        public byte SpriteID;
        public byte YPosition;
        public byte XPosition;
        public byte Movement;
        public byte Direction;
        public byte TextID;
        public byte TrainerClass;
        public byte TrainerSet;

        public byte Length
        {
            get
            {
                if ((TextID & Trainer) != 0)
                    return 8;

                if ((TextID & Item) != 0)
                    return 7;

                return 6;
            }
        }

        public Object(byte[] data, int offset = 0)
        {
            SpriteID = data[offset + 0];
            YPosition = data[offset + 1];
            XPosition = data[offset + 2];
            Movement = data[offset + 3];
            Direction = data[offset + 4];
            TextID = data[offset + 5];

            if ((TextID & (Trainer | Item)) != 0)
            {
                TrainerClass = data[offset + 6];

                if ((TextID & Trainer) != 0)
                    TrainerSet = data[offset + 7];
            }
        }
    }

    public class MapObject
    {
        public byte BorderBlock;
        public byte WarpCount;
        public byte[][] Warps;
        public byte SignCount;
        public byte[][] Signs;
        public byte ObjectCount;
        public Object[] Objects;

        public MapObject(byte[] data, int offset = 0)
        {
            BorderBlock = data[offset + 0];
            WarpCount = data[offset + 1];
            Warps = new byte[WarpCount][];
            offset += 2;

            for (int i = 0; i < WarpCount; i++)
            {
                Warps[i] = data.Subarray(offset, 4);
                offset += 4;
            }

            SignCount = data[offset + 0];
            Signs = new byte[SignCount][];
            offset += 1;

            for (int i = 0; i < SignCount; i++)
            {
                Signs[i] = data.Subarray(offset, 3);
                offset += 3;
            }

            ObjectCount = data[offset + 0];
            Objects = new Object[ObjectCount];
            offset += 1;

            for (int i = 0; i < ObjectCount; i++)
            {
                Objects[i] = new Object(data, offset);
                offset += Objects[i].Length;
            }
        }
    }

    public class Tileset
    {
        public byte Bank;
        public ushort BlockPointer;
        public ushort GFXPointer;
        public ushort CollPointer;
        public byte[] CounterTiles;
        public byte GrassTile;
        public byte Permission;

        public Tileset(byte[] data, int offset = 0)
        {
            Bank = data[offset + 0];
            BlockPointer = data.ToUInt16(offset + 1);
            GFXPointer = data.ToUInt16(offset + 3);
            CollPointer = data.ToUInt16(offset + 5);
            CounterTiles = data.Subarray(offset + 7, 3);
            GrassTile = data[offset + 10];
            Permission = data[offset + 11];
        }
    }

    class TownMap
    {
        private const int bankSize = 0x4000;

        private byte[] rom;
        private byte[][] ram;

        public TownMap()
        {
        }

        public void SetROM(byte[] data)
        {
            rom = data;
            int count = rom.Length / bankSize;
            ram = new byte[count][];
            byte[] home = rom.Subarray(0, bankSize);

            for (int bank = 0; bank < count; bank++)
            {
                ram[bank] = new byte[bankSize * 3];
                home.CopyTo(ram[bank], 0);
                rom.Subarray(bank * bankSize, bankSize).CopyTo(ram[bank], bankSize);
            }
        }

        public byte GetMapHeaderBank(byte mapIndex)
        {
            return rom[Pointers.MapHeaderBanks + mapIndex];
        }

        public ushort GetMapHeaderPointer(byte mapIndex)
        {
            return rom.ToUInt16(Pointers.MapHeaderPointers + mapIndex * 2);
        }

        public MapHeader GetMapHeader(byte mapIndex)
        {
            byte mapHeaderBank = GetMapHeaderBank(mapIndex);
            ushort mapHeaderPointer = GetMapHeaderPointer(mapIndex);

            return new MapHeader(ram[mapHeaderBank], mapHeaderPointer);
        }

        public MapObject GetMapObject(byte mapIndex)
        {
            byte mapHeaderBank = GetMapHeaderBank(mapIndex);
            MapHeader mapHeader = GetMapHeader(mapIndex);

            return new MapObject(ram[mapHeaderBank], mapHeader.ObjectPointer);
        }

        public Tileset GetTileset(byte tilesetIndex)
        {
            return new Tileset(rom, Pointers.Tilesets + tilesetIndex * 12);
        }

        public byte[] GetMapBlocks(byte mapIndex)
        {
            byte mapHeaderBank = GetMapHeaderBank(mapIndex);
            MapHeader mapHeader = GetMapHeader(mapIndex);

            return ram[mapHeaderBank].Subarray(mapHeader.DataPointer,
                mapHeader.Height * mapHeader.Width);
        }

        public byte[] GetOverworldMap(byte mapIndex)
        {
            byte[] owm = new byte[1300];
            byte[] blocks = GetMapBlocks(mapIndex);
            byte border = GetMapObject(mapIndex).BorderBlock;
            MapHeader mapHeader = GetMapHeader(mapIndex);
            int height = mapHeader.Height;
            int width = mapHeader.Width;

            for (int i = 0; i < 1300; i++)
                owm[i] = border;

            for (int i = 0; i < height; i++)
                Array.Copy(blocks, i * width, owm, (i + 3) * (width + 6) + 3, width);

            for (int i = 3; i >= 0; i--)
            {
                if (mapHeader.Connections[i] == null)
                    continue;

                Connection conn = mapHeader.Connections[i];
                byte bank = GetMapHeaderBank(conn.MapIndex);
                byte h = (byte)((i / 2 == 1) ? 3 : conn.Length);
                byte w = (byte)((i / 2 == 1) ? conn.Length : 3);

                for (int j = 0; j < h; j++)
                {
                    Array.Copy(ram[bank], conn.Source + j * conn.MapWidth, owm,
                        conn.Destination - Pointers.wOverworldMap + j * (width + 6), w);
                }
            }

            return owm;
        }

        public byte[] BlockToTiles(byte blockIndex, byte tilesetIndex)
        {
            Tileset tileset = GetTileset(tilesetIndex);

            return ram[tileset.Bank].Subarray(tileset.BlockPointer + blockIndex * 16, 16);
        }

        public byte[] BlocksToTiles(byte[] blocks, int width, byte tilesetIndex)
        {
            int length = blocks.Length - blocks.Length % width;
            byte[] tiles = new byte[length * 4 * 4];

            for (int i = 0; i < length; i++)
            {
                byte[] tiles2 = BlockToTiles(blocks[i], tilesetIndex);

                for (int j = 0; j < 4; j++)
                {
                    Array.Copy(tiles2, j * 4, tiles, (i / width) * (width * 4) * 4 +
                        j * (width * 4) + (i % width) * 4, 4);
                }
            }

            return tiles;
        }

        public byte[] TileToPixels(byte tileIndex, byte tilesetIndex)
        {
            Tileset tileset = GetTileset(tilesetIndex);

            return ram[tileset.Bank].Subarray(tileset.GFXPointer + tileIndex * 16, 16);
        }

        public byte[] TilesToPixels(byte[] tiles, int width, byte tilesetIndex)
        {
            int length = tiles.Length;
            byte[] pixels = new byte[length * 8 * 8];

            for (int i = 0; i < length; i++)
            {
                byte[] pixels2 = TileToPixels(tiles[i], tilesetIndex);

                for (int j = 0; j < 8; j++)
                {
                    byte top = pixels2[j * 2 + 0];
                    byte bot = pixels2[j * 2 + 1];

                    for (int k = 0; k < 8; k++)
                    {
                        pixels[(i / width) * (width * 8) * 8 + j * (width * 8) +
                            (i % width) * 8 + k] =
                            (byte)(((top >> (7 - k)) & 1) + ((bot >> (7 - k)) & 1) * 2);
                    }
                }
            }

            return pixels;
        }

        public int GetSpriteSheetPointer(byte pictureID)
        {
            int headerPointer = Pointers.SpriteSheetPointerTable + (pictureID - 1) * 4;
            int spritePointer = rom[headerPointer + 3] * bankSize +
                (rom.ToUInt16(headerPointer) - bankSize);

            return spritePointer;
        }

        public byte[] GetSpritePixels(int spritePointer, byte index)
        {
            byte[] pixels = new byte[16 * 16];

            for (int i = 0; i < 4; i++)
            {
                byte[] pixels2 = rom.Subarray(spritePointer + (i + index * 4) * 16, 16);

                for (int j = 0; j < 8; j++)
                {
                    byte top = pixels2[j * 2 + 0];
                    byte bot = pixels2[j * 2 + 1];

                    for (int k = 0; k < 8; k++)
                    {
                        pixels[(i / 2) * (2 * 8) * 8 + j * (2 * 8) + (i % 2) * 8 + k] =
                            (byte)(((top >> (7 - k)) & 1) + ((bot >> (7 - k)) & 1) * 2);
                    }
                }
            }

            return pixels;
        }
    }
}
