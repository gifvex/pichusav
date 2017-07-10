using System;

namespace RedBlue
{
    static class Pointers
    {
        public const int MapHeaderBanks = 0xC23D;
        public const int MapHeaderPointers = 0x01AE;
        public const int Tilesets = 0xC7BE;

        public const int RedCyclingSprite = 0x14000;
        public const int SeelSprite = 0x176C0;
        public const int SpriteSheetPointerTable = 0x17B27;

        public const ushort wOverworldMap = 0xC6E8;

        public const ushort sPlayerName = 0x2598;

        public const ushort MainDataOffset = 0xAD54;
        public const ushort sCurMap = 0xD35E - MainDataOffset;
        public const ushort sCurrentTileBlockMapViewPointer = 0xD35F - MainDataOffset;
        public const ushort sYCoord = 0xD361 - MainDataOffset;
        public const ushort sXCoord = 0xD362 - MainDataOffset;
        public const ushort sYBlockCoord = 0xD363 - MainDataOffset;
        public const ushort sXBlockCoord = 0xD364 - MainDataOffset;
        public const ushort sCurMapWidth = 0xD369 - MainDataOffset;
        public const ushort sNumSprites = 0xD4E1 - MainDataOffset;
        public const ushort sPlayerMovingDirection = 0xD528 - MainDataOffset;
        public const ushort sMissableObjectFlags = 0xD5A6 - MainDataOffset;
        public const ushort sMissableObjectList = 0xD5CE - MainDataOffset;
        public const ushort sWalkBikeSurfState = 0xD700 - MainDataOffset;
        public const ushort sPlayTimeHours = 0xDA41 - MainDataOffset;
        public const ushort sPlayTimeMaxed = 0xDA42 - MainDataOffset;
        public const ushort sPlayTimeMinutes = 0xDA43 - MainDataOffset;
        public const ushort sPlayTimeSeconds = 0xDA44 - MainDataOffset;
        public const ushort sPlayTimeFrames = 0xDA45 - MainDataOffset;

        public const ushort SpriteDataOffset = 0x93D4;
        public const ushort sSpriteStateData1 = 0xC100 - SpriteDataOffset;
        public const ushort sSpriteStateData2 = 0xC200 - SpriteDataOffset;

        public const byte SpritePictureID = 0x0;
        public const byte SpriteMovementStatus = 0x1;
        public const byte SpriteImageIdx = 0x2;
        public const byte SpriteYPixels = 0x4;
        public const byte SpriteXPixels = 0x6;
        public const byte SpriteAnimFrameCounter = 0x8;
        public const byte SpriteFacingDirection = 0x9;

        public const byte SpriteYDisplacement = 0x2;
        public const byte SpriteXDisplacement = 0x3;
        public const byte SpriteMapY = 0x4;
        public const byte SpriteMapX = 0x5;
        public const byte SpriteGrassPriority = 0x7;
        public const byte SpriteMovementDelay = 0x8;
        public const byte SpriteImageBaseOffset = 0xE;

        public const ushort sChecksum = 0x3523;
    }

    static class Extensions
    {
        public static byte[] Subarray(this byte[] source, int index, int length)
        {
            byte[] subarray = new byte[length];
            Array.Copy(source, index, subarray, 0, length);
            return subarray;
        }

        public static ushort ToUInt16(this byte[] value, int index)
        {
            return (ushort)((value[index + 1] << 8) | value[index + 0]);
        }
    }
}
