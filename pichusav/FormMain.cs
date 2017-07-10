using System;
using System.Drawing;
using System.Windows.Forms;

using RedBlue;

namespace pichusav
{
    public partial class FormMain : Form
    {
        private const string filterAll = "All types (*.*)|*.*";
        private const string filterSAV = "|Save file (*.sav)|*.sav";
        private const string filterState = "|Save state (*.gqs;*.sna)" +
            "|*.gqs;*.sna;*.sn1;*.sn2;*.sn3;*.sn4;*.sn5;*.sn6;*.sn7;*.sn8;*.sn9;*.sn0";
        private const string filterGSR = "|GSR save state (*.gqs)|*.gqs";
        private const string filterBGB = "|BGB save state (*.sna)" +
            "|*.sna;*.sn1;*.sn2;*.sn3;*.sn4;*.sn5;*.sn6;*.sn7;*.sn8;*.sn9;*.sn0";

        private static readonly Color colorGrid = Color.FromArgb(64, 0, 0, 0);
        private static readonly Color colorBox = Color.FromArgb(192, 255, 255, 0);

        private static readonly Color[] paletteBG0 = new Color[]
        {
            Color.FromArgb(255, 232, 232, 232),
            Color.FromArgb(255, 160, 160, 160),
            Color.FromArgb(255, 88, 88, 88),
            Color.FromArgb(255, 16, 16, 16)
        };

        private static readonly Color[] paletteOBJ0 = new Color[]
        {
            Color.FromArgb(0, 0, 0, 0),
            Color.FromArgb(255, 192, 160, 192),
            Color.FromArgb(255, 192, 88, 192),
            Color.FromArgb(255, 192, 16, 192)
        };

        private TownMap townMap;
        private Thunderstone thunderstone;

        private byte[] mapPixels;
        private byte grassTile;

        private Bitmap bg0;
        private Bitmap grid;
        private Bitmap boxScreen;
        private Bitmap boxSprite;
        private Bitmap[] obj0;

        private byte[] fileData;
        private string filePath = "";
        private bool initUI = false;
        private bool initSprite = false;
        private int baseWidth;
        private int baseHeight;
        private int zoomFactor;
        private bool scrolling = false;
        private Point scrollSource;
        private Point toolTipCoords;

        public FormMain(string[] args)
        {
            InitializeComponent();
            
            townMap = new TownMap();
            thunderstone = new Thunderstone(townMap);

            townMap.SetROM(Properties.Resources.ROM);

            if (args.Length > 0)
                LoadFile(args[0]);
        }

        private void InitUI()
        {
            initUI = false;

            buttonSave.Enabled = true;
            buttonCopy.Enabled = true;

            numericUpDownIGTH.Enabled = true;
            numericUpDownIGTM.Enabled = true;
            numericUpDownIGTS.Enabled = true;
            numericUpDownIGTF.Enabled = true;
            numericUpDownPPX.Enabled = true;
            numericUpDownPPY.Enabled = true;
            comboBoxDirection.Enabled = true;
            comboBoxState.Enabled = true;

            numericUpDownIGTH.Value = thunderstone.PlayTimeHours;
            numericUpDownIGTM.Value = thunderstone.PlayTimeMinutes;
            numericUpDownIGTS.Value = thunderstone.PlayTimeSeconds;
            numericUpDownIGTF.Value = thunderstone.PlayTimeFrames;
            numericUpDownPPX.Value = thunderstone.XCoord;
            numericUpDownPPY.Value = thunderstone.YCoord;

            MapHeader mapHeader = townMap.GetMapHeader(thunderstone.CurMap);

            numericUpDownPPX.Maximum = mapHeader.Width * 2 - 1;
            numericUpDownPPY.Maximum = mapHeader.Height * 2 - 1;

            switch (thunderstone.PlayerMovingDirection)
            {
                case 0: comboBoxDirection.SelectedIndex = 0; break;
                case 8: comboBoxDirection.SelectedIndex = 1; break;
                case 4: comboBoxDirection.SelectedIndex = 2; break;
                case 2: comboBoxDirection.SelectedIndex = 3; break;
                case 1: comboBoxDirection.SelectedIndex = 4; break;
            }

            comboBoxState.SelectedIndex = thunderstone.WalkBikeSurfState;

            for (int i = 1; i < 16; i++)
            {
                if (i <= thunderstone.NumSprites)
                    panel2.Controls[i].Enabled = true;
                else
                    panel2.Controls[i].Enabled = false;

                ((RadioButton)panel2.Controls[i]).Checked = false;
            }

            InitSprite();

            initUI = true;
        }

        private void InitSprite()
        {
            initSprite = false;

            byte i;

            if (!GetSelectedSprite(out i))
            {
                numericUpDownSPX.Enabled = false;
                numericUpDownSPY.Enabled = false;
                numericUpDownTimer.Enabled = false;

                numericUpDownSPX.Value = 0;
                numericUpDownSPY.Value = 0;
                numericUpDownTimer.Value = 0;

                return;
            }

            numericUpDownSPX.Enabled = true;
            numericUpDownSPY.Enabled = true;
            numericUpDownTimer.Enabled = true;

            Point coords = thunderstone.GetSpriteCoords(i);

            numericUpDownSPX.Value = coords.X;
            numericUpDownSPY.Value = coords.Y;
            numericUpDownTimer.Value = thunderstone.SpriteMovementDelay(i);

            MapHeader mapHeader = townMap.GetMapHeader(thunderstone.CurMap);

            numericUpDownSPX.Maximum = mapHeader.Width * 2 - 1;
            numericUpDownSPY.Maximum = mapHeader.Height * 2 - 1;

            PreviewScrollSquare(coords);
            pictureBoxPreview.Refresh();

            initSprite = true;
        }

        private void ScrollingBegin(MouseEventArgs e)
        {
            if (!initUI)
                return;

            if (e.Button == MouseButtons.Left)
            {
                scrolling = true;
                scrollSource = e.Location;
            }
        }

        private void ScrollingStep(MouseEventArgs e)
        {
            if (!initUI)
                return;

            if (scrolling && e.Button == MouseButtons.Left)
            {
                PreviewScroll(scrollSource.X - (pictureBoxPreview.Left + e.X),
                    scrollSource.Y - (pictureBoxPreview.Top + e.Y));
            }

            int size = 16 * zoomFactor;
            Point coords = new Point(e.X / size - 6, e.Y / size - 6);

            if (coords != toolTipCoords)
            {
                if (coords.X >= 0 && coords.X < (pictureBoxPreview.Width / size - 12) &&
                    coords.Y >= 0 && coords.Y < (pictureBoxPreview.Height / size - 12))
                {
                    string tip = string.Format("({0}, {1})", coords.X, coords.Y);

                    if (obj0 != null)
                    {
                        for (byte i = 0; i < obj0.Length; i++)
                        {
                            Point point2 = thunderstone.GetSpriteCoords(i);

                            if (coords == point2)
                            {
                                if (i == 0)
                                    tip += " (player)";
                                else
                                    tip += string.Format(" (sprite {0})", i);
                            }
                        }
                    }

                    toolTipPreview.SetToolTip(pictureBoxPreview, tip);
                }
                else
                {
                    toolTipPreview.SetToolTip(pictureBoxPreview, "");
                }

                toolTipCoords = coords;
            }
        }

        private void ScrollingEnd(MouseEventArgs e)
        {
            if (!initUI)
                return;

            scrolling = false;
        }

        private void UpdateIGT()
        {
            if (!initUI)
                return;

            thunderstone.PlayTimeHours = (byte)numericUpDownIGTH.Value;
            thunderstone.PlayTimeMinutes = (byte)numericUpDownIGTM.Value;
            thunderstone.PlayTimeSeconds = (byte)numericUpDownIGTS.Value;
            thunderstone.PlayTimeFrames = (byte)numericUpDownIGTF.Value;
        }

        private void UpdatePP()
        {
            if (!initUI)
                return;

            thunderstone.XCoord = (byte)numericUpDownPPX.Value;
            thunderstone.YCoord = (byte)numericUpDownPPY.Value;

            pictureBoxPreview.Refresh();
        }

        private void UpdateDirection()
        {
            if (!initUI)
                return;

            switch (comboBoxDirection.SelectedIndex)
            {
                case 0: thunderstone.PlayerMovingDirection = 0; break;
                case 1: thunderstone.PlayerMovingDirection = 8; break;
                case 2: thunderstone.PlayerMovingDirection = 4; break;
                case 3: thunderstone.PlayerMovingDirection = 2; break;
                case 4: thunderstone.PlayerMovingDirection = 1; break;
            }

            PreviewLoadSprite(0);
            pictureBoxPreview.Refresh();
        }

        private void UpdateState()
        {
            if (!initUI)
                return;

            thunderstone.WalkBikeSurfState = (byte)comboBoxState.SelectedIndex;

            PreviewLoadSprite(0);
            pictureBoxPreview.Refresh();
        }

        private void UpdateSP()
        {
            if (!initSprite)
                return;

            byte i;

            if (!GetSelectedSprite(out i))
                return;

            thunderstone.SpriteMapX(i, (byte)(numericUpDownSPX.Value + 4));
            thunderstone.SpriteMapY(i, (byte)(numericUpDownSPY.Value + 4));

            pictureBoxPreview.Refresh();
        }

        private void UpdateTimer()
        {
            if (!initSprite)
                return;

            byte i;

            if (!GetSelectedSprite(out i))
                return;

            thunderstone.SpriteMovementDelay(i, (byte)numericUpDownTimer.Value);
        }

        private bool GetSelectedSprite(out byte i)
        {
            for (i = 1; i < 16; i++)
            {
                if (((RadioButton)panel2.Controls[i]).Checked)
                    return true;
            }

            return false;
        }

        #region Windows Form Designer events

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadFilePrompt();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            SaveFilePrompt();
        }

        private void comboBoxDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDirection();
        }

        private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateState();
        }

        private void labelPlayer_Click(object sender, EventArgs e)
        {
            PreviewScrollPlayer();
        }

        private void labelSprites_Click(object sender, EventArgs e)
        {
            PreviewScrollSprite();
        }

        private void numericUpDownIGTH_ValueChanged(object sender, EventArgs e)
        {
            UpdateIGT();
        }

        private void numericUpDownIGTM_ValueChanged(object sender, EventArgs e)
        {
            UpdateIGT();
        }

        private void numericUpDownIGTS_ValueChanged(object sender, EventArgs e)
        {
            UpdateIGT();
        }

        private void numericUpDownIGTF_ValueChanged(object sender, EventArgs e)
        {
            UpdateIGT();
        }

        private void numericUpDownPPX_ValueChanged(object sender, EventArgs e)
        {
            UpdatePP();
        }

        private void numericUpDownPPY_ValueChanged(object sender, EventArgs e)
        {
            UpdatePP();
        }

        private void numericUpDownSPX_ValueChanged(object sender, EventArgs e)
        {
            UpdateSP();
        }

        private void numericUpDownSPY_ValueChanged(object sender, EventArgs e)
        {
            UpdateSP();
        }

        private void numericUpDownTimer_ValueChanged(object sender, EventArgs e)
        {
            UpdateTimer();
        }

        private void pictureBoxPreview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PreviewZoomToggle(e);
        }

        private void pictureBoxPreview_MouseDown(object sender, MouseEventArgs e)
        {
            ScrollingBegin(e);
        }

        private void pictureBoxPreview_MouseMove(object sender, MouseEventArgs e)
        {
            ScrollingStep(e);
        }

        private void pictureBoxPreview_MouseUp(object sender, MouseEventArgs e)
        {
            ScrollingEnd(e);
        }

        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            PreviewPaint(e);
        }

        private void radioButtonSN_CheckedChanged(object sender, EventArgs e)
        {
            InitSprite();
        }

        #endregion
    }
}
