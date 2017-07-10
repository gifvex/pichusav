using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using RedBlue;

namespace pichusav
{
    partial class FormMain
    {
        private void PreviewLoad()
        {
            byte mapIndex = thunderstone.CurMap;

            MapHeader mapHeader = townMap.GetMapHeader(mapIndex);
            byte tilesetIndex = mapHeader.TilesetIndex;
            int height = mapHeader.Height + 6;
            int width = mapHeader.Width + 6;

            Tileset mapTileset = townMap.GetTileset(tilesetIndex);

            byte[] mapBlocks = townMap.GetOverworldMap(mapIndex);
            byte[] mapTiles = townMap.BlocksToTiles(mapBlocks, width, tilesetIndex);
            mapPixels = townMap.TilesToPixels(mapTiles, width * 4, tilesetIndex);

            grassTile = mapTileset.GrassTile;

            height *= 32;
            width *= 32;

            grid = new Bitmap(width, height);
            bg0 = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y % 16 == 0 || x % 16 == 0)
                        grid.SetPixel(x, y, colorGrid);

                    bg0.SetPixel(x, y, paletteBG0[mapPixels[y * width + x]]);
                }
            }

            int count = thunderstone.NumSprites + 1;
            obj0 = new Bitmap[count];

            for (byte i = 0; i < count; i++)
                PreviewLoadSprite(i);

            boxScreen = new Bitmap(160, 144);
            boxSprite = new Bitmap(16, 16);

            Outline(boxScreen, 2);
            Outline(boxSprite, 2);

            pictureBoxPreview.Size = new Size(width, height);
            baseWidth = width;
            baseHeight = height;

            zoomFactor = 1;

            PreviewScrollSquare(thunderstone.GetSpriteCoords(0));
            pictureBoxPreview.Refresh();
        }

        private void PreviewLoadSprite(byte i)
        {
            obj0[i] = new Bitmap(16, 16);

            byte pictureID = thunderstone.SpritePictureID(i);
            int spritePointer = 0;
            byte index = thunderstone.GetSpriteIndex(i);
            bool flip = false;

            if (i == 0)
            {
                switch (thunderstone.WalkBikeSurfState)
                {
                    case 0: spritePointer = townMap.GetSpriteSheetPointer(pictureID); break;
                    case 1: spritePointer = Pointers.RedCyclingSprite; break;
                    case 2: spritePointer = Pointers.SeelSprite; break;
                }
            }
            else
            {
                spritePointer = townMap.GetSpriteSheetPointer(pictureID);
            }

            if (index == 3)
            {
                index = 2;
                flip = true;
            }

            byte[] pixels = townMap.GetSpritePixels(spritePointer, index);

            if (flip)
            {
                for (int j = 0; j < 16; j++)
                    Array.Reverse(pixels, j * 16, 16);
            }

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                    obj0[i].SetPixel(x, y, paletteOBJ0[pixels[y * 16 + x]]);
            }
        }

        private void PreviewPaint(PaintEventArgs e)
        {
            if (!initUI)
                return;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.ScaleTransform(zoomFactor, zoomFactor);

            e.Graphics.DrawImage(bg0, 0, 0);
            e.Graphics.DrawImage(grid, 0, 0);

            int y = (thunderstone.YCoord + 6 - 4) * 16;
            int x = (thunderstone.XCoord + 6 - 4) * 16;

            e.Graphics.DrawImage(boxScreen, x, y);

            byte index;
            bool selected = GetSelectedSprite(out index);

            for (byte i = 0; i < obj0.Length; i++)
            {
                Point coords = thunderstone.GetSpriteCoords(i);

                int drawY = (coords.Y + 6) * 16;
                int drawX = (coords.X + 6) * 16;

                if (selected && i == index)
                    e.Graphics.DrawImage(boxSprite, drawX, drawY);

                if (i != 0 && thunderstone.IsSpriteHidden(i))
                    continue;

                Bitmap temp = new Bitmap(obj0[i]);
                drawY -= 4;

                if (i != 0 && thunderstone.IsSpriteLoaded(i))
                {
                    byte diffY = (byte)(thunderstone.SpriteMapY(i) - thunderstone.YCoord);
                    diffY *= 0x10;
                    diffY -= 4;
                    drawY += thunderstone.SpriteYPixels(i) - diffY;

                    byte diffX = (byte)(thunderstone.SpriteMapX(i) - thunderstone.XCoord);
                    diffX *= 0x10;
                    drawX += thunderstone.SpriteXPixels(i) - diffX;
                }

                if (thunderstone.GetTile(coords) == grassTile)
                {
                    for (int yy = 8; yy < 16; yy++)
                    {
                        for (int xx = 0; xx < 16; xx++)
                        {
                            if (bg0.GetPixel(drawX + xx, drawY + yy) != paletteBG0[0])
                                temp.SetPixel(xx, yy, paletteOBJ0[0]);
                        }
                    }
                }

                e.Graphics.DrawImage(temp, drawX, drawY);
            }
        }

        private void PreviewScroll(int x, int y)
        {
            int width = pictureBoxPreview.Width;
            int height = pictureBoxPreview.Height;

            if (width < 320)
                pictureBoxPreview.Left = 160 - width / 2;
            else
                pictureBoxPreview.Left = Math.Max(-width + 320, Math.Min(0, -x));

            if (height < 288)
                pictureBoxPreview.Top = 144 - height / 2;
            else
                pictureBoxPreview.Top = Math.Max(-height + 288, Math.Min(0, -y));
        }

        private void PreviewScrollSquare(Point coords)
        {
            int posY = ((coords.Y + 6) * 16 + 8) * zoomFactor - 144;
            int posX = ((coords.X + 6) * 16 + 16) * zoomFactor - 160;

            PreviewScroll(posX, posY);
        }

        private void PreviewScrollPlayer()
        {
            if (!initUI)
                return;

            PreviewScrollSquare(thunderstone.GetSpriteCoords(0));
        }

        private void PreviewScrollSprite()
        {
            if (!initSprite)
                return;

            byte i;

            if (!GetSelectedSprite(out i))
                return;

            PreviewScrollSquare(thunderstone.GetSpriteCoords(i));
        }

        private void PreviewZoomToggle(MouseEventArgs e)
        {
            if (!initUI)
                return;

            int x = e.X / zoomFactor;
            int y = e.Y / zoomFactor;

            switch (zoomFactor)
            {
                case 1: zoomFactor = 2; break;
                default: zoomFactor = 1; break;
            }

            pictureBoxPreview.Size = new Size(baseWidth * zoomFactor,
                baseHeight * zoomFactor);

            PreviewScroll(x * zoomFactor - 160, y * zoomFactor - 144);
            pictureBoxPreview.Refresh();
        }

        private void Outline(Bitmap bmp, int stroke)
        {
            int h = bmp.Height;
            int w = bmp.Width;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (y < stroke || y >= (h - stroke) ||
                        x < stroke || x >= (w - stroke))
                        bmp.SetPixel(x, y, colorBox);
                }
            }
        }
    }
}
