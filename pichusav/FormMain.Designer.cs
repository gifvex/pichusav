namespace pichusav
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSprites = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownIGTH = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIGTM = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIGTS = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIGTF = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPPX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPPY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSPX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSPY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTimer = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonS0 = new System.Windows.Forms.RadioButton();
            this.radioButtonS1 = new System.Windows.Forms.RadioButton();
            this.radioButtonS2 = new System.Windows.Forms.RadioButton();
            this.radioButtonS3 = new System.Windows.Forms.RadioButton();
            this.radioButtonS4 = new System.Windows.Forms.RadioButton();
            this.radioButtonS5 = new System.Windows.Forms.RadioButton();
            this.radioButtonS6 = new System.Windows.Forms.RadioButton();
            this.radioButtonS7 = new System.Windows.Forms.RadioButton();
            this.radioButtonS8 = new System.Windows.Forms.RadioButton();
            this.radioButtonS9 = new System.Windows.Forms.RadioButton();
            this.radioButtonS10 = new System.Windows.Forms.RadioButton();
            this.radioButtonS11 = new System.Windows.Forms.RadioButton();
            this.radioButtonS12 = new System.Windows.Forms.RadioButton();
            this.radioButtonS13 = new System.Windows.Forms.RadioButton();
            this.radioButtonS14 = new System.Windows.Forms.RadioButton();
            this.radioButtonS15 = new System.Windows.Forms.RadioButton();
            this.toolTipPreview = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimer)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(7, 305);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(88, 305);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Enabled = false;
            this.buttonCopy.Location = new System.Drawing.Point(169, 305);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 3;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.Enabled = false;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "Unbuffered",
            "Up",
            "Down",
            "Left",
            "Right"});
            this.comboBoxDirection.Location = new System.Drawing.Point(397, 112);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(79, 21);
            this.comboBoxDirection.TabIndex = 10;
            this.comboBoxDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirection_SelectedIndexChanged);
            // 
            // comboBoxState
            // 
            this.comboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxState.Enabled = false;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] {
            "Walking",
            "Cycling",
            "Surfing"});
            this.comboBoxState.Location = new System.Drawing.Point(397, 141);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(79, 21);
            this.comboBoxState.TabIndex = 11;
            this.comboBoxState.SelectedIndexChanged += new System.EventHandler(this.comboBoxState_SelectedIndexChanged);
            // 
            // labelPlayer
            // 
            this.labelPlayer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelPlayer.Location = new System.Drawing.Point(338, 8);
            this.labelPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(151, 21);
            this.labelPlayer.TabIndex = 0;
            this.labelPlayer.Text = "Player";
            this.labelPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPlayer.Click += new System.EventHandler(this.labelPlayer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "IGT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Position:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Direction:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "State:";
            // 
            // labelSprites
            // 
            this.labelSprites.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSprites.Location = new System.Drawing.Point(338, 170);
            this.labelSprites.Margin = new System.Windows.Forms.Padding(0);
            this.labelSprites.Name = "labelSprites";
            this.labelSprites.Size = new System.Drawing.Size(151, 21);
            this.labelSprites.TabIndex = 0;
            this.labelSprites.Text = "Sprites";
            this.labelSprites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSprites.Click += new System.EventHandler(this.labelSprites_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 273);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Position:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 301);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Timer:";
            // 
            // numericUpDownIGTH
            // 
            this.numericUpDownIGTH.Enabled = false;
            this.numericUpDownIGTH.Location = new System.Drawing.Point(397, 37);
            this.numericUpDownIGTH.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownIGTH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownIGTH.Name = "numericUpDownIGTH";
            this.numericUpDownIGTH.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownIGTH.TabIndex = 4;
            this.numericUpDownIGTH.ValueChanged += new System.EventHandler(this.numericUpDownIGTH_ValueChanged);
            // 
            // numericUpDownIGTM
            // 
            this.numericUpDownIGTM.Enabled = false;
            this.numericUpDownIGTM.Location = new System.Drawing.Point(436, 37);
            this.numericUpDownIGTM.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownIGTM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownIGTM.Name = "numericUpDownIGTM";
            this.numericUpDownIGTM.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownIGTM.TabIndex = 5;
            this.numericUpDownIGTM.ValueChanged += new System.EventHandler(this.numericUpDownIGTM_ValueChanged);
            // 
            // numericUpDownIGTS
            // 
            this.numericUpDownIGTS.Enabled = false;
            this.numericUpDownIGTS.Location = new System.Drawing.Point(397, 56);
            this.numericUpDownIGTS.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownIGTS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownIGTS.Name = "numericUpDownIGTS";
            this.numericUpDownIGTS.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownIGTS.TabIndex = 6;
            this.numericUpDownIGTS.ValueChanged += new System.EventHandler(this.numericUpDownIGTS_ValueChanged);
            // 
            // numericUpDownIGTF
            // 
            this.numericUpDownIGTF.Enabled = false;
            this.numericUpDownIGTF.Location = new System.Drawing.Point(436, 56);
            this.numericUpDownIGTF.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownIGTF.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownIGTF.Name = "numericUpDownIGTF";
            this.numericUpDownIGTF.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownIGTF.TabIndex = 7;
            this.numericUpDownIGTF.ValueChanged += new System.EventHandler(this.numericUpDownIGTF_ValueChanged);
            // 
            // numericUpDownPPX
            // 
            this.numericUpDownPPX.Enabled = false;
            this.numericUpDownPPX.Location = new System.Drawing.Point(397, 84);
            this.numericUpDownPPX.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownPPX.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownPPX.Name = "numericUpDownPPX";
            this.numericUpDownPPX.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownPPX.TabIndex = 8;
            this.numericUpDownPPX.ValueChanged += new System.EventHandler(this.numericUpDownPPX_ValueChanged);
            // 
            // numericUpDownPPY
            // 
            this.numericUpDownPPY.Enabled = false;
            this.numericUpDownPPY.Location = new System.Drawing.Point(436, 84);
            this.numericUpDownPPY.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownPPY.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownPPY.Name = "numericUpDownPPY";
            this.numericUpDownPPY.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownPPY.TabIndex = 9;
            this.numericUpDownPPY.ValueChanged += new System.EventHandler(this.numericUpDownPPY_ValueChanged);
            // 
            // numericUpDownSPX
            // 
            this.numericUpDownSPX.Enabled = false;
            this.numericUpDownSPX.Location = new System.Drawing.Point(397, 271);
            this.numericUpDownSPX.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownSPX.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSPX.Name = "numericUpDownSPX";
            this.numericUpDownSPX.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownSPX.TabIndex = 13;
            this.numericUpDownSPX.ValueChanged += new System.EventHandler(this.numericUpDownSPX_ValueChanged);
            // 
            // numericUpDownSPY
            // 
            this.numericUpDownSPY.Enabled = false;
            this.numericUpDownSPY.Location = new System.Drawing.Point(436, 271);
            this.numericUpDownSPY.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownSPY.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSPY.Name = "numericUpDownSPY";
            this.numericUpDownSPY.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownSPY.TabIndex = 14;
            this.numericUpDownSPY.ValueChanged += new System.EventHandler(this.numericUpDownSPY_ValueChanged);
            // 
            // numericUpDownTimer
            // 
            this.numericUpDownTimer.Enabled = false;
            this.numericUpDownTimer.Location = new System.Drawing.Point(397, 299);
            this.numericUpDownTimer.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownTimer.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownTimer.Name = "numericUpDownTimer";
            this.numericUpDownTimer.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownTimer.TabIndex = 15;
            this.numericUpDownTimer.ValueChanged += new System.EventHandler(this.numericUpDownTimer_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxPreview);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 290);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(320, 288);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPreview_Paint);
            this.pictureBoxPreview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPreview_MouseDoubleClick);
            this.pictureBoxPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPreview_MouseDown);
            this.pictureBoxPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPreview_MouseMove);
            this.pictureBoxPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPreview_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.radioButtonS0);
            this.panel2.Controls.Add(this.radioButtonS1);
            this.panel2.Controls.Add(this.radioButtonS2);
            this.panel2.Controls.Add(this.radioButtonS3);
            this.panel2.Controls.Add(this.radioButtonS4);
            this.panel2.Controls.Add(this.radioButtonS5);
            this.panel2.Controls.Add(this.radioButtonS6);
            this.panel2.Controls.Add(this.radioButtonS7);
            this.panel2.Controls.Add(this.radioButtonS8);
            this.panel2.Controls.Add(this.radioButtonS9);
            this.panel2.Controls.Add(this.radioButtonS10);
            this.panel2.Controls.Add(this.radioButtonS11);
            this.panel2.Controls.Add(this.radioButtonS12);
            this.panel2.Controls.Add(this.radioButtonS13);
            this.panel2.Controls.Add(this.radioButtonS14);
            this.panel2.Controls.Add(this.radioButtonS15);
            this.panel2.Location = new System.Drawing.Point(337, 193);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 76);
            this.panel2.TabIndex = 12;
            // 
            // radioButtonS0
            // 
            this.radioButtonS0.Enabled = false;
            this.radioButtonS0.Location = new System.Drawing.Point(4, 4);
            this.radioButtonS0.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS0.Name = "radioButtonS0";
            this.radioButtonS0.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS0.TabIndex = 0;
            this.radioButtonS0.TabStop = true;
            this.radioButtonS0.Text = "0";
            this.radioButtonS0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS0.UseVisualStyleBackColor = true;
            // 
            // radioButtonS1
            // 
            this.radioButtonS1.Enabled = false;
            this.radioButtonS1.Location = new System.Drawing.Point(41, 4);
            this.radioButtonS1.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS1.Name = "radioButtonS1";
            this.radioButtonS1.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS1.TabIndex = 1;
            this.radioButtonS1.TabStop = true;
            this.radioButtonS1.Text = "1";
            this.radioButtonS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS1.UseVisualStyleBackColor = true;
            this.radioButtonS1.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS2
            // 
            this.radioButtonS2.Enabled = false;
            this.radioButtonS2.Location = new System.Drawing.Point(78, 4);
            this.radioButtonS2.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS2.Name = "radioButtonS2";
            this.radioButtonS2.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS2.TabIndex = 2;
            this.radioButtonS2.TabStop = true;
            this.radioButtonS2.Text = "2";
            this.radioButtonS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS2.UseVisualStyleBackColor = true;
            this.radioButtonS2.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS3
            // 
            this.radioButtonS3.Enabled = false;
            this.radioButtonS3.Location = new System.Drawing.Point(115, 4);
            this.radioButtonS3.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS3.Name = "radioButtonS3";
            this.radioButtonS3.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS3.TabIndex = 3;
            this.radioButtonS3.TabStop = true;
            this.radioButtonS3.Text = "3";
            this.radioButtonS3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS3.UseVisualStyleBackColor = true;
            this.radioButtonS3.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS4
            // 
            this.radioButtonS4.Enabled = false;
            this.radioButtonS4.Location = new System.Drawing.Point(4, 21);
            this.radioButtonS4.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS4.Name = "radioButtonS4";
            this.radioButtonS4.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS4.TabIndex = 4;
            this.radioButtonS4.TabStop = true;
            this.radioButtonS4.Text = "4";
            this.radioButtonS4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS4.UseVisualStyleBackColor = true;
            this.radioButtonS4.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS5
            // 
            this.radioButtonS5.Enabled = false;
            this.radioButtonS5.Location = new System.Drawing.Point(41, 21);
            this.radioButtonS5.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS5.Name = "radioButtonS5";
            this.radioButtonS5.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS5.TabIndex = 5;
            this.radioButtonS5.TabStop = true;
            this.radioButtonS5.Text = "5";
            this.radioButtonS5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS5.UseVisualStyleBackColor = true;
            this.radioButtonS5.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS6
            // 
            this.radioButtonS6.Enabled = false;
            this.radioButtonS6.Location = new System.Drawing.Point(78, 21);
            this.radioButtonS6.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS6.Name = "radioButtonS6";
            this.radioButtonS6.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS6.TabIndex = 6;
            this.radioButtonS6.TabStop = true;
            this.radioButtonS6.Text = "6";
            this.radioButtonS6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS6.UseVisualStyleBackColor = true;
            this.radioButtonS6.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS7
            // 
            this.radioButtonS7.Enabled = false;
            this.radioButtonS7.Location = new System.Drawing.Point(115, 21);
            this.radioButtonS7.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS7.Name = "radioButtonS7";
            this.radioButtonS7.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS7.TabIndex = 7;
            this.radioButtonS7.TabStop = true;
            this.radioButtonS7.Text = "7";
            this.radioButtonS7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS7.UseVisualStyleBackColor = true;
            this.radioButtonS7.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS8
            // 
            this.radioButtonS8.Enabled = false;
            this.radioButtonS8.Location = new System.Drawing.Point(4, 38);
            this.radioButtonS8.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS8.Name = "radioButtonS8";
            this.radioButtonS8.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS8.TabIndex = 8;
            this.radioButtonS8.TabStop = true;
            this.radioButtonS8.Text = "8";
            this.radioButtonS8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS8.UseVisualStyleBackColor = true;
            this.radioButtonS8.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS9
            // 
            this.radioButtonS9.Enabled = false;
            this.radioButtonS9.Location = new System.Drawing.Point(41, 38);
            this.radioButtonS9.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS9.Name = "radioButtonS9";
            this.radioButtonS9.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS9.TabIndex = 9;
            this.radioButtonS9.TabStop = true;
            this.radioButtonS9.Text = "9";
            this.radioButtonS9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS9.UseVisualStyleBackColor = true;
            this.radioButtonS9.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS10
            // 
            this.radioButtonS10.Enabled = false;
            this.radioButtonS10.Location = new System.Drawing.Point(78, 38);
            this.radioButtonS10.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS10.Name = "radioButtonS10";
            this.radioButtonS10.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS10.TabIndex = 10;
            this.radioButtonS10.TabStop = true;
            this.radioButtonS10.Text = "10";
            this.radioButtonS10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS10.UseVisualStyleBackColor = true;
            this.radioButtonS10.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS11
            // 
            this.radioButtonS11.Enabled = false;
            this.radioButtonS11.Location = new System.Drawing.Point(115, 38);
            this.radioButtonS11.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS11.Name = "radioButtonS11";
            this.radioButtonS11.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS11.TabIndex = 11;
            this.radioButtonS11.TabStop = true;
            this.radioButtonS11.Text = "11";
            this.radioButtonS11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS11.UseVisualStyleBackColor = true;
            this.radioButtonS11.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS12
            // 
            this.radioButtonS12.Enabled = false;
            this.radioButtonS12.Location = new System.Drawing.Point(4, 55);
            this.radioButtonS12.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS12.Name = "radioButtonS12";
            this.radioButtonS12.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS12.TabIndex = 12;
            this.radioButtonS12.TabStop = true;
            this.radioButtonS12.Text = "12";
            this.radioButtonS12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS12.UseVisualStyleBackColor = true;
            this.radioButtonS12.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS13
            // 
            this.radioButtonS13.Enabled = false;
            this.radioButtonS13.Location = new System.Drawing.Point(41, 55);
            this.radioButtonS13.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS13.Name = "radioButtonS13";
            this.radioButtonS13.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS13.TabIndex = 13;
            this.radioButtonS13.TabStop = true;
            this.radioButtonS13.Text = "13";
            this.radioButtonS13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS13.UseVisualStyleBackColor = true;
            this.radioButtonS13.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS14
            // 
            this.radioButtonS14.Enabled = false;
            this.radioButtonS14.Location = new System.Drawing.Point(78, 55);
            this.radioButtonS14.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS14.Name = "radioButtonS14";
            this.radioButtonS14.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS14.TabIndex = 14;
            this.radioButtonS14.TabStop = true;
            this.radioButtonS14.Text = "14";
            this.radioButtonS14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS14.UseVisualStyleBackColor = true;
            this.radioButtonS14.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // radioButtonS15
            // 
            this.radioButtonS15.Enabled = false;
            this.radioButtonS15.Location = new System.Drawing.Point(115, 55);
            this.radioButtonS15.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonS15.Name = "radioButtonS15";
            this.radioButtonS15.Size = new System.Drawing.Size(37, 17);
            this.radioButtonS15.TabIndex = 15;
            this.radioButtonS15.TabStop = true;
            this.radioButtonS15.Text = "15";
            this.radioButtonS15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonS15.UseVisualStyleBackColor = true;
            this.radioButtonS15.CheckedChanged += new System.EventHandler(this.radioButtonSN_CheckedChanged);
            // 
            // toolTipPreview
            // 
            this.toolTipPreview.AutoPopDelay = 5000;
            this.toolTipPreview.InitialDelay = 0;
            this.toolTipPreview.ReshowDelay = 100;
            this.toolTipPreview.ShowAlways = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 335);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.comboBoxDirection);
            this.Controls.Add(this.comboBoxState);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelSprites);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownIGTH);
            this.Controls.Add(this.numericUpDownIGTM);
            this.Controls.Add(this.numericUpDownIGTS);
            this.Controls.Add(this.numericUpDownIGTF);
            this.Controls.Add(this.numericUpDownPPX);
            this.Controls.Add(this.numericUpDownPPY);
            this.Controls.Add(this.numericUpDownSPX);
            this.Controls.Add(this.numericUpDownSPY);
            this.Controls.Add(this.numericUpDownTimer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "pichusav r1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIGTF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimer)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSprites;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownIGTH;
        private System.Windows.Forms.NumericUpDown numericUpDownIGTM;
        private System.Windows.Forms.NumericUpDown numericUpDownIGTS;
        private System.Windows.Forms.NumericUpDown numericUpDownIGTF;
        private System.Windows.Forms.NumericUpDown numericUpDownPPX;
        private System.Windows.Forms.NumericUpDown numericUpDownPPY;
        private System.Windows.Forms.NumericUpDown numericUpDownSPX;
        private System.Windows.Forms.NumericUpDown numericUpDownSPY;
        private System.Windows.Forms.NumericUpDown numericUpDownTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.RadioButton radioButtonS0;
        private System.Windows.Forms.RadioButton radioButtonS1;
        private System.Windows.Forms.RadioButton radioButtonS2;
        private System.Windows.Forms.RadioButton radioButtonS3;
        private System.Windows.Forms.RadioButton radioButtonS4;
        private System.Windows.Forms.RadioButton radioButtonS5;
        private System.Windows.Forms.RadioButton radioButtonS6;
        private System.Windows.Forms.RadioButton radioButtonS7;
        private System.Windows.Forms.RadioButton radioButtonS8;
        private System.Windows.Forms.RadioButton radioButtonS9;
        private System.Windows.Forms.RadioButton radioButtonS10;
        private System.Windows.Forms.RadioButton radioButtonS11;
        private System.Windows.Forms.RadioButton radioButtonS12;
        private System.Windows.Forms.RadioButton radioButtonS13;
        private System.Windows.Forms.RadioButton radioButtonS14;
        private System.Windows.Forms.RadioButton radioButtonS15;
        private System.Windows.Forms.ToolTip toolTipPreview;
    }
}

