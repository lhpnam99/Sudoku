namespace Sudoku
{
    partial class GameBoard
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
            this.pnlGameBoard = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.rBtnEasy = new System.Windows.Forms.RadioButton();
            this.rBtnNormal = new System.Windows.Forms.RadioButton();
            this.rBtnHard = new System.Windows.Forms.RadioButton();
            this.grpBoxLevel = new System.Windows.Forms.GroupBox();
            this.lbTimePlay = new System.Windows.Forms.Label();
            this.lbSeconds = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMinutes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbHours = new System.Windows.Forms.Label();
            this.lbSuggestions = new System.Windows.Forms.Label();
            this.timerPlaying = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlControl.SuspendLayout();
            this.grpBoxLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGameBoard
            // 
            this.pnlGameBoard.BackgroundImage = global::Sudoku.Properties.Resources.BoardGame;
            this.pnlGameBoard.Location = new System.Drawing.Point(12, 12);
            this.pnlGameBoard.Name = "pnlGameBoard";
            this.pnlGameBoard.Size = new System.Drawing.Size(436, 436);
            this.pnlGameBoard.TabIndex = 0;
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.Controls.Add(this.btnLoadGame);
            this.pnlControl.Controls.Add(this.btnSave);
            this.pnlControl.Controls.Add(this.btnHelp);
            this.pnlControl.Controls.Add(this.btnSolve);
            this.pnlControl.Controls.Add(this.btnStart);
            this.pnlControl.Location = new System.Drawing.Point(483, 254);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(180, 217);
            this.pnlControl.TabIndex = 2;
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Location = new System.Drawing.Point(39, 44);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(109, 28);
            this.btnLoadGame.TabIndex = 4;
            this.btnLoadGame.Text = "Load";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(39, 78);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(39, 112);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(109, 28);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(39, 146);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(109, 28);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(39, 180);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rBtnEasy
            // 
            this.rBtnEasy.AutoSize = true;
            this.rBtnEasy.Location = new System.Drawing.Point(6, 32);
            this.rBtnEasy.Name = "rBtnEasy";
            this.rBtnEasy.Size = new System.Drawing.Size(48, 17);
            this.rBtnEasy.TabIndex = 0;
            this.rBtnEasy.TabStop = true;
            this.rBtnEasy.Tag = "60";
            this.rBtnEasy.Text = "Easy";
            this.rBtnEasy.UseVisualStyleBackColor = true;
            // 
            // rBtnNormal
            // 
            this.rBtnNormal.AutoSize = true;
            this.rBtnNormal.Location = new System.Drawing.Point(6, 76);
            this.rBtnNormal.Name = "rBtnNormal";
            this.rBtnNormal.Size = new System.Drawing.Size(58, 17);
            this.rBtnNormal.TabIndex = 1;
            this.rBtnNormal.TabStop = true;
            this.rBtnNormal.Tag = "50";
            this.rBtnNormal.Text = "Normal";
            this.rBtnNormal.UseVisualStyleBackColor = true;
            // 
            // rBtnHard
            // 
            this.rBtnHard.AutoSize = true;
            this.rBtnHard.Location = new System.Drawing.Point(6, 118);
            this.rBtnHard.Name = "rBtnHard";
            this.rBtnHard.Size = new System.Drawing.Size(48, 17);
            this.rBtnHard.TabIndex = 2;
            this.rBtnHard.TabStop = true;
            this.rBtnHard.Tag = "40";
            this.rBtnHard.Text = "Hard";
            this.rBtnHard.UseVisualStyleBackColor = true;
            // 
            // grpBoxLevel
            // 
            this.grpBoxLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxLevel.Controls.Add(this.lbTimePlay);
            this.grpBoxLevel.Controls.Add(this.lbSeconds);
            this.grpBoxLevel.Controls.Add(this.label3);
            this.grpBoxLevel.Controls.Add(this.lbMinutes);
            this.grpBoxLevel.Controls.Add(this.label2);
            this.grpBoxLevel.Controls.Add(this.lbHours);
            this.grpBoxLevel.Controls.Add(this.rBtnEasy);
            this.grpBoxLevel.Controls.Add(this.rBtnHard);
            this.grpBoxLevel.Controls.Add(this.rBtnNormal);
            this.grpBoxLevel.Location = new System.Drawing.Point(483, 12);
            this.grpBoxLevel.Name = "grpBoxLevel";
            this.grpBoxLevel.Size = new System.Drawing.Size(180, 206);
            this.grpBoxLevel.TabIndex = 3;
            this.grpBoxLevel.TabStop = false;
            this.grpBoxLevel.Text = "Level";
            // 
            // lbTimePlay
            // 
            this.lbTimePlay.AutoSize = true;
            this.lbTimePlay.Location = new System.Drawing.Point(7, 167);
            this.lbTimePlay.Name = "lbTimePlay";
            this.lbTimePlay.Size = new System.Drawing.Size(33, 13);
            this.lbTimePlay.TabIndex = 8;
            this.lbTimePlay.Text = "Time:";
            // 
            // lbSeconds
            // 
            this.lbSeconds.AutoSize = true;
            this.lbSeconds.Location = new System.Drawing.Point(121, 167);
            this.lbSeconds.Name = "lbSeconds";
            this.lbSeconds.Size = new System.Drawing.Size(13, 13);
            this.lbSeconds.TabIndex = 7;
            this.lbSeconds.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = ":";
            // 
            // lbMinutes
            // 
            this.lbMinutes.AutoSize = true;
            this.lbMinutes.Location = new System.Drawing.Point(86, 167);
            this.lbMinutes.Name = "lbMinutes";
            this.lbMinutes.Size = new System.Drawing.Size(13, 13);
            this.lbMinutes.TabIndex = 5;
            this.lbMinutes.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = ":";
            // 
            // lbHours
            // 
            this.lbHours.AutoSize = true;
            this.lbHours.Location = new System.Drawing.Point(51, 167);
            this.lbHours.Name = "lbHours";
            this.lbHours.Size = new System.Drawing.Size(13, 13);
            this.lbHours.TabIndex = 3;
            this.lbHours.Text = "0";
            // 
            // lbSuggestions
            // 
            this.lbSuggestions.AutoSize = true;
            this.lbSuggestions.Location = new System.Drawing.Point(483, 225);
            this.lbSuggestions.Name = "lbSuggestions";
            this.lbSuggestions.Size = new System.Drawing.Size(71, 13);
            this.lbSuggestions.TabIndex = 4;
            this.lbSuggestions.Text = "Suggestions: ";
            // 
            // timerPlaying
            // 
            this.timerPlaying.Interval = 1000;
            this.timerPlaying.Tick += new System.EventHandler(this.timerPlaying_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 474);
            this.Controls.Add(this.lbSuggestions);
            this.Controls.Add(this.grpBoxLevel);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlGameBoard);
            this.Name = "GameBoard";
            this.Text = "Sudoku";
            this.pnlControl.ResumeLayout(false);
            this.grpBoxLevel.ResumeLayout(false);
            this.grpBoxLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlGameBoard;
        private System.Windows.Forms.GroupBox grpBoxLevel;
        private System.Windows.Forms.RadioButton rBtnEasy;
        private System.Windows.Forms.RadioButton rBtnHard;
        private System.Windows.Forms.RadioButton rBtnNormal;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Label lbSuggestions;
        private System.Windows.Forms.Label lbTimePlay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Timer timerPlaying;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnLoadGame;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Label lbMinutes;
        public System.Windows.Forms.Label lbHours;
        public System.Windows.Forms.Label lbSeconds;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

