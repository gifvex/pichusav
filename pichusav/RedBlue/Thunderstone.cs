using System.Drawing;

namespace RedBlue
{
    class Thunderstone
    {
        private TownMap townMap;

        private byte[] sav;

        private byte mapWidth;
        private byte[] mapTiles;
        private byte grassTile;
        private MapObject mapObject;

        public byte CurMap
        {
            get
            {
                return sav[Pointers.sCurMap];
            }
        }

        public ushort CurrentTileBlockMapViewPointer
        {
            set
            {
                sav[Pointers.sCurrentTileBlockMapViewPointer + 0] = (byte)(value % 256);
                sav[Pointers.sCurrentTileBlockMapViewPointer + 1] = (byte)(value / 256);
                CalculateChecksum();
            }
        }

        public byte YCoord
        {
            get
            {
                return sav[Pointers.sYCoord];
            }
            set
            {
                byte diff = (byte)(value - sav[Pointers.sYCoord]);

                for (byte i = 1; i <= NumSprites; i++)
                    SpriteYPixels(i, (byte)(SpriteYPixels(i) - diff * 0x10));

                sav[Pointers.sYCoord] = value;
                CalculatePlayerPos();
                CalculateSpriteData();
                CalculateChecksum();
            }
        }

        public byte XCoord
        {
            get
            {
                return sav[Pointers.sXCoord];
            }
            set
            {
                byte diff = (byte)(value - sav[Pointers.sXCoord]);

                for (byte i = 1; i <= NumSprites; i++)
                    SpriteXPixels(i, (byte)(SpriteXPixels(i) - diff * 0x10));

                sav[Pointers.sXCoord] = value;
                CalculatePlayerPos();
                CalculateSpriteData();
                CalculateChecksum();
            }
        }

        public byte YBlockCoord
        {
            set
            {
                sav[Pointers.sYBlockCoord] = value;
                CalculateChecksum();
            }
        }

        public byte XBlockCoord
        {
            set
            {
                sav[Pointers.sXBlockCoord] = value;
                CalculateChecksum();
            }
        }

        public byte CurMapWidth
        {
            get
            {
                return sav[Pointers.sCurMapWidth];
            }
        }

        public byte NumSprites
        {
            get
            {
                return sav[Pointers.sNumSprites];
            }
        }

        public byte PlayerMovingDirection
        {
            get
            {
                return sav[Pointers.sPlayerMovingDirection];
            }
            set
            {
                sav[Pointers.sPlayerMovingDirection] = value;
                CalculateChecksum();
            }
        }

        public byte[] MissableObjectFlags
        {
            get
            {
                return sav.Subarray(Pointers.sMissableObjectFlags, 32);
            }
        }

        public byte[] MissableObjectList
        {
            get
            {
                return sav.Subarray(Pointers.sMissableObjectList, 17 * 2);
            }
        }

        public byte WalkBikeSurfState
        {
            get
            {
                return sav[Pointers.sWalkBikeSurfState];
            }
            set
            {
                sav[Pointers.sWalkBikeSurfState] = value;
                CalculateChecksum();
            }
        }

        public byte PlayTimeHours
        {
            get
            {
                return sav[Pointers.sPlayTimeHours];
            }
            set
            {
                sav[Pointers.sPlayTimeHours] = value;
                PlayTimeMaxed = (byte)((value == 0xFF) ? 0xFF : 0x00);
                CalculateChecksum();
            }
        }

        public byte PlayTimeMaxed
        {
            set
            {
                sav[Pointers.sPlayTimeMaxed] = value;
                CalculateChecksum();
            }
        }

        public byte PlayTimeMinutes
        {
            get
            {
                return sav[Pointers.sPlayTimeMinutes];
            }
            set
            {
                sav[Pointers.sPlayTimeMinutes] = value;
                CalculateChecksum();
            }
        }

        public byte PlayTimeSeconds
        {
            get
            {
                return sav[Pointers.sPlayTimeSeconds];
            }
            set
            {
                sav[Pointers.sPlayTimeSeconds] = value;
                CalculateChecksum();
            }
        }

        public byte PlayTimeFrames
        {
            get
            {
                return sav[Pointers.sPlayTimeFrames];
            }
            set
            {
                sav[Pointers.sPlayTimeFrames] = value;
                CalculateChecksum();
            }
        }

        public ushort SpriteStateData(byte set, byte i, byte offset)
        {
            ushort pointer = 0;

            switch(set)
            {
                case 1: pointer = Pointers.sSpriteStateData1; break;
                case 2: pointer = Pointers.sSpriteStateData2; break;
            }

            return (ushort)(pointer + i * 0x10 + offset);
        }

        public byte SpritePictureID(byte i)
        {
            return sav[SpriteStateData(1, i, Pointers.SpritePictureID)];
        }

        public byte SpriteMovementStatus(byte i)
        {
            return sav[SpriteStateData(1, i, Pointers.SpriteMovementStatus)];
        }

        public byte SpriteImageIdx(byte i)
        {
            return sav[SpriteStateData(1, i, Pointers.SpriteImageIdx)];
        }

        public void SpriteImageIdx(byte i, byte value)
        {
            sav[SpriteStateData(1, i, Pointers.SpriteImageIdx)] = value;
            CalculateChecksum();
        }

        public byte SpriteYPixels(byte i)
        {
            return sav[SpriteStateData(1, i, Pointers.SpriteYPixels)];
        }

        public void SpriteYPixels(byte i, byte value)
        {
            sav[SpriteStateData(1, i, Pointers.SpriteYPixels)] = value;
            CalculateChecksum();
        }

        public byte SpriteXPixels(byte i)
        {
            return sav[SpriteStateData(1, i, Pointers.SpriteXPixels)];
        }

        public void SpriteXPixels(byte i, byte value)
        {
            sav[SpriteStateData(1, i, Pointers.SpriteXPixels)] = value;
            CalculateChecksum();
        }

        public byte SpriteAnimFrameCounter(byte i)
        {
            return sav[SpriteStateData(1, i, Pointers.SpriteAnimFrameCounter)];
        }

        public byte SpriteFacingDirection(byte i)
        {
            return sav[SpriteStateData(1, i, Pointers.SpriteFacingDirection)];
        }

        public byte SpriteYDisplacement(byte i)
        {
            return sav[SpriteStateData(2, i, Pointers.SpriteYDisplacement)];
        }

        public void SpriteYDisplacement(byte i, byte value)
        {
            sav[SpriteStateData(2, i, Pointers.SpriteYDisplacement)] = value;
            CalculateChecksum();
        }

        public byte SpriteXDisplacement(byte i)
        {
            return sav[SpriteStateData(2, i, Pointers.SpriteXDisplacement)];
        }

        public void SpriteXDisplacement(byte i, byte value)
        {
            sav[SpriteStateData(2, i, Pointers.SpriteXDisplacement)] = value;
            CalculateChecksum();
        }

        public byte SpriteMapY(byte i)
        {
            return sav[SpriteStateData(2, i, Pointers.SpriteMapY)];
        }

        public void SpriteMapY(byte i, byte value)
        {
            byte diff = (byte)(value - sav[SpriteStateData(2, i, Pointers.SpriteMapY)]);

            SpriteYPixels(i, (byte)(SpriteYPixels(i) + diff * 0x10));

            if (IsSpriteLoaded(i))
                SpriteYDisplacement(i, (byte)(SpriteYDisplacement(i) + diff));

            sav[SpriteStateData(2, i, Pointers.SpriteMapY)] = value;
            CalculateSpriteData();
            CalculateChecksum();
        }

        public byte SpriteMapX(byte i)
        {
            return sav[SpriteStateData(2, i, Pointers.SpriteMapX)];
        }

        public void SpriteMapX(byte i, byte value)
        {
            byte diff = (byte)(value - sav[SpriteStateData(2, i, Pointers.SpriteMapX)]);

            SpriteXPixels(i, (byte)(SpriteXPixels(i) + diff * 0x10));

            if (IsSpriteLoaded(i))
                SpriteXDisplacement(i, (byte)(SpriteXDisplacement(i) + diff));

            sav[SpriteStateData(2, i, Pointers.SpriteMapX)] = value;
            CalculateSpriteData();
            CalculateChecksum();
        }

        public byte SpriteGrassPriority(byte i)
        {
            return sav[SpriteStateData(2, i, Pointers.SpriteGrassPriority)];
        }

        public void SpriteGrassPriority(byte i, byte value)
        {
            sav[SpriteStateData(2, i, Pointers.SpriteGrassPriority)] = value;
            CalculateChecksum();
        }

        public byte SpriteMovementDelay(byte i)
        {
            return sav[SpriteStateData(2, i, Pointers.SpriteMovementDelay)];
        }

        public void SpriteMovementDelay(byte i, byte value)
        {
            sav[SpriteStateData(2, i, Pointers.SpriteMovementDelay)] = value;
            CalculateChecksum();
        }

        public byte SpriteImageBaseOffset(byte i)
        {
            return sav[SpriteStateData(2, i, Pointers.SpriteImageBaseOffset)];
        }

        public byte Checksum
        {
            set
            {
                sav[Pointers.sChecksum] = value;
            }
        }

        public Thunderstone(TownMap map)
        {
            townMap = map;
        }

        public void SetSAV(byte[] data)
        {
            sav = data;

            MapHeader mapHeader = townMap.GetMapHeader(CurMap);
            byte tilesetIndex = mapHeader.TilesetIndex;
            mapWidth = mapHeader.Width;

            byte[] mapBlocks = townMap.GetMapBlocks(CurMap);
            mapTiles = townMap.BlocksToTiles(mapBlocks, mapWidth, tilesetIndex);

            grassTile = townMap.GetTileset(tilesetIndex).GrassTile;
            mapObject = townMap.GetMapObject(CurMap);
        }

        public byte[] GetSAV()
        {
            return sav;
        }

        public bool IsSpriteHidden(byte i)
        {
            byte[] list = MissableObjectList;
            byte index = 0;
            int j;

            for (j = 0; j < 17 * 2; j += 2)
            {
                if (list[j] == 0xFF)
                    return false;

                if (list[j] == i)
                {
                    index = list[j + 1];
                    break;
                }
            }

            if (j == 17 * 2)
                return false;

            if (((MissableObjectFlags[index / 8] >> (index % 8)) & 1) == 0)
                return false;

            return true;
        }

        public bool IsSpriteLoaded(byte i)
        {
            if (SpriteMovementStatus(i) == 1)
                return false;

            return true;
        }

        public bool IsSpriteOnScreen(byte i)
        {
            if (YCoord > SpriteMapY(i) || (YCoord + 8) < SpriteMapY(i) ||
                XCoord > SpriteMapX(i) || (XCoord + 9) < SpriteMapX(i))
                return false;

            return true;
        }

        public Point GetSpriteCoords(byte i)
        {
            if (i == 0)
                return new Point(XCoord, YCoord);
            else
                return new Point(SpriteMapX(i) - 4, SpriteMapY(i) - 4);
        }

        public byte GetSpriteIndex(byte i)
        {
            byte index = 0;

            if (i == 0)
            {
                switch (PlayerMovingDirection)
                {
                    case 0:
                    case 4: index = 0; break;
                    case 8: index = 1; break;
                    case 2: index = 2; break;
                    case 1: index = 3; break;
                }
            }
            else
            {
                if (IsSpriteLoaded(i))
                {
                    byte facingDirection = SpriteFacingDirection(i);

                    if ((SpriteImageBaseOffset(i) - 1) >= 0xA)
                        facingDirection = 0;

                    switch (facingDirection)
                    {
                        case 0x0: index = 0; break;
                        case 0x4: index = 1; break;
                        case 0x8: index = 2; break;
                        case 0xC: index = 3; break;
                    }
                }
                else
                {
                    switch (mapObject.Objects[i - 1].Direction)
                    {
                        case 0xD0: index = 0; break;
                        case 0xD1: index = 1; break;
                        case 0xD2: index = 2; break;
                        case 0xD3: index = 3; break;
                    }
                }
            }

            return index;
        }

        public byte GetTile(Point coords)
        {
            return mapTiles[(coords.Y * 2 + 1) * (mapWidth * 4) + (coords.X * 2)];
        }

        public void CalculatePlayerPos()
        {
            CurrentTileBlockMapViewPointer = (ushort)(Pointers.wOverworldMap +
                (YCoord / 2 + 1) * (CurMapWidth + 6) + (XCoord / 2 + 1));
            YBlockCoord = (byte)(YCoord % 2);
            XBlockCoord = (byte)(XCoord % 2);
        }

        public void CalculateSpriteData()
        {
            for (byte i = 1; i <= NumSprites; i++)
            {
                if (IsSpriteHidden(i))
                    continue;

                if (!IsSpriteOnScreen(i))
                {
                    SpriteImageIdx(i, 0xFF);
                }
                else
                {
                    SpriteImageIdx(i, (byte)(SpriteAnimFrameCounter(i) +
                        SpriteFacingDirection(i) + (SpriteImageBaseOffset(i) - 1) * 0x10));
                }

                if (GetTile(GetSpriteCoords(i)) == grassTile)
                    SpriteGrassPriority(i, 0x80);
            }
        }

        public void CalculateChecksum()
        {
            Checksum = GetChecksum(sav);
        }

        public static byte GetChecksum(byte[] data)
        {
            byte sum = 255;

            for (ushort i = Pointers.sPlayerName; i < Pointers.sChecksum; i++)
                sum -= data[i];

            return sum;
        }

        public static bool CheckChecksum(byte[] data)
        {
            return (GetChecksum(data) == data[Pointers.sChecksum]);
        }
    }
}
