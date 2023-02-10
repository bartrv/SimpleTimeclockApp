namespace WindowsFormsApp1
{
    partial class TestClock
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
            this.UiTxt_currentTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.UiTxt_cTimeDiff = new System.Windows.Forms.Label();
            this.UiBtn_Stop = new System.Windows.Forms.Button();
            this.UiBtn_Pause = new System.Windows.Forms.Button();
            this.UiBtn_Start = new System.Windows.Forms.Button();
            this.UiTxtBox_Timelog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UiTxt_cTimeSession = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UiTxt_cTimeTotal = new System.Windows.Forms.Label();
            this.btnParseFolders = new System.Windows.Forms.Button();
            this.textOpenFileSelect = new System.Windows.Forms.TextBox();
            this.pListComboBox = new System.Windows.Forms.ComboBox();
            this.tLogFileDisplay = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnWriteDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UiTxt_currentTime
            // 
            this.UiTxt_currentTime.AutoSize = true;
            this.UiTxt_currentTime.Font = new System.Drawing.Font("Code Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiTxt_currentTime.Location = new System.Drawing.Point(429, 9);
            this.UiTxt_currentTime.Name = "UiTxt_currentTime";
            this.UiTxt_currentTime.Size = new System.Drawing.Size(136, 25);
            this.UiTxt_currentTime.TabIndex = 0;
            this.UiTxt_currentTime.Text = "00:00:00 PM";
            this.UiTxt_currentTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UiTxt_cTimeDiff
            // 
            this.UiTxt_cTimeDiff.AutoSize = true;
            this.UiTxt_cTimeDiff.Font = new System.Drawing.Font("Code Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiTxt_cTimeDiff.Location = new System.Drawing.Point(447, 48);
            this.UiTxt_cTimeDiff.Name = "UiTxt_cTimeDiff";
            this.UiTxt_cTimeDiff.Size = new System.Drawing.Size(121, 32);
            this.UiTxt_cTimeDiff.TabIndex = 1;
            this.UiTxt_cTimeDiff.Text = "00:00:00";
            this.UiTxt_cTimeDiff.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UiBtn_Stop
            // 
            this.UiBtn_Stop.Location = new System.Drawing.Point(12, 9);
            this.UiBtn_Stop.Name = "UiBtn_Stop";
            this.UiBtn_Stop.Size = new System.Drawing.Size(48, 23);
            this.UiBtn_Stop.TabIndex = 2;
            this.UiBtn_Stop.Text = "Stop";
            this.UiBtn_Stop.UseVisualStyleBackColor = true;
            // 
            // UiBtn_Pause
            // 
            this.UiBtn_Pause.Location = new System.Drawing.Point(66, 9);
            this.UiBtn_Pause.Name = "UiBtn_Pause";
            this.UiBtn_Pause.Size = new System.Drawing.Size(48, 23);
            this.UiBtn_Pause.TabIndex = 3;
            this.UiBtn_Pause.Text = "Pause";
            this.UiBtn_Pause.UseVisualStyleBackColor = true;
            this.UiBtn_Pause.Click += new System.EventHandler(this.BtnPause);
            // 
            // UiBtn_Start
            // 
            this.UiBtn_Start.Location = new System.Drawing.Point(120, 9);
            this.UiBtn_Start.Name = "UiBtn_Start";
            this.UiBtn_Start.Size = new System.Drawing.Size(48, 23);
            this.UiBtn_Start.TabIndex = 4;
            this.UiBtn_Start.Text = "Start";
            this.UiBtn_Start.UseVisualStyleBackColor = true;
            this.UiBtn_Start.Click += new System.EventHandler(this.BtnStart);
            // 
            // UiTxtBox_Timelog
            // 
            this.UiTxtBox_Timelog.Location = new System.Drawing.Point(12, 42);
            this.UiTxtBox_Timelog.Multiline = true;
            this.UiTxtBox_Timelog.Name = "UiTxtBox_Timelog";
            this.UiTxtBox_Timelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UiTxtBox_Timelog.Size = new System.Drawing.Size(429, 122);
            this.UiTxtBox_Timelog.TabIndex = 6;
            this.UiTxtBox_Timelog.Text = "UiTxtBox_Timelog";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Code Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(77)));
            this.label2.Location = new System.Drawing.Point(454, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 11);
            this.label2.TabIndex = 8;
            this.label2.Text = "Current Increment:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Code Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(77)));
            this.label1.Location = new System.Drawing.Point(466, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 11);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current Session:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UiTxt_cTimeSession
            // 
            this.UiTxt_cTimeSession.AutoSize = true;
            this.UiTxt_cTimeSession.Font = new System.Drawing.Font("Code Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiTxt_cTimeSession.Location = new System.Drawing.Point(447, 94);
            this.UiTxt_cTimeSession.Name = "UiTxt_cTimeSession";
            this.UiTxt_cTimeSession.Size = new System.Drawing.Size(121, 32);
            this.UiTxt_cTimeSession.TabIndex = 10;
            this.UiTxt_cTimeSession.Text = "00:00:00";
            this.UiTxt_cTimeSession.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Code Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(77)));
            this.label3.Location = new System.Drawing.Point(476, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 11);
            this.label3.TabIndex = 11;
            this.label3.Text = "Project Total:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UiTxt_cTimeTotal
            // 
            this.UiTxt_cTimeTotal.AutoSize = true;
            this.UiTxt_cTimeTotal.Font = new System.Drawing.Font("Code Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiTxt_cTimeTotal.Location = new System.Drawing.Point(447, 135);
            this.UiTxt_cTimeTotal.Name = "UiTxt_cTimeTotal";
            this.UiTxt_cTimeTotal.Size = new System.Drawing.Size(121, 32);
            this.UiTxt_cTimeTotal.TabIndex = 12;
            this.UiTxt_cTimeTotal.Text = "00:00:00";
            this.UiTxt_cTimeTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnParseFolders
            // 
            this.btnParseFolders.Location = new System.Drawing.Point(12, 170);
            this.btnParseFolders.Name = "btnParseFolders";
            this.btnParseFolders.Size = new System.Drawing.Size(79, 23);
            this.btnParseFolders.TabIndex = 13;
            this.btnParseFolders.Text = "Parse Folders";
            this.btnParseFolders.UseVisualStyleBackColor = true;
            this.btnParseFolders.Click += new System.EventHandler(this.BtnParseDirs);
            // 
            // textOpenFileSelect
            // 
            this.textOpenFileSelect.Location = new System.Drawing.Point(12, 199);
            this.textOpenFileSelect.Name = "textOpenFileSelect";
            this.textOpenFileSelect.Size = new System.Drawing.Size(293, 20);
            this.textOpenFileSelect.TabIndex = 14;
            // 
            // pListComboBox
            // 
            this.pListComboBox.FormattingEnabled = true;
            this.pListComboBox.Location = new System.Drawing.Point(97, 171);
            this.pListComboBox.Name = "pListComboBox";
            this.pListComboBox.Size = new System.Drawing.Size(208, 21);
            this.pListComboBox.TabIndex = 15;
            this.pListComboBox.Text = "Waiting...";
            this.pListComboBox.SelectedIndexChanged += new System.EventHandler(this.pListComboSelected);
            // 
            // tLogFileDisplay
            // 
            this.tLogFileDisplay.Location = new System.Drawing.Point(311, 171);
            this.tLogFileDisplay.Multiline = true;
            this.tLogFileDisplay.Name = "tLogFileDisplay";
            this.tLogFileDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tLogFileDisplay.Size = new System.Drawing.Size(249, 106);
            this.tLogFileDisplay.TabIndex = 16;
            this.tLogFileDisplay.Text = "...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "d:\\";
            this.openFileDialog1.Title = "Folder Browser";
            this.openFileDialog1.ValidateNames = false;
            // 
            // btnWriteDate
            // 
            this.btnWriteDate.Location = new System.Drawing.Point(12, 254);
            this.btnWriteDate.Name = "btnWriteDate";
            this.btnWriteDate.Size = new System.Drawing.Size(102, 23);
            this.btnWriteDate.TabIndex = 17;
            this.btnWriteDate.Text = "Write Date To File";
            this.btnWriteDate.UseVisualStyleBackColor = true;
            // 
            // TestClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 289);
            this.Controls.Add(this.btnWriteDate);
            this.Controls.Add(this.tLogFileDisplay);
            this.Controls.Add(this.pListComboBox);
            this.Controls.Add(this.textOpenFileSelect);
            this.Controls.Add(this.btnParseFolders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UiTxt_cTimeTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UiTxtBox_Timelog);
            this.Controls.Add(this.UiBtn_Start);
            this.Controls.Add(this.UiBtn_Pause);
            this.Controls.Add(this.UiBtn_Stop);
            this.Controls.Add(this.UiTxt_cTimeDiff);
            this.Controls.Add(this.UiTxt_currentTime);
            this.Controls.Add(this.UiTxt_cTimeSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "TestClock";
            this.Text = "Test Clock";
            this.Load += new System.EventHandler(this.TestClock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UiTxt_currentTime;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label UiTxt_cTimeDiff;
        private System.Windows.Forms.Button UiBtn_Stop;
        private System.Windows.Forms.Button UiBtn_Pause;
        private System.Windows.Forms.Button UiBtn_Start;
        private System.Windows.Forms.TextBox UiTxtBox_Timelog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UiTxt_cTimeSession;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label UiTxt_cTimeTotal;
        private System.Windows.Forms.Button btnParseFolders;
        private System.Windows.Forms.TextBox textOpenFileSelect;
        private System.Windows.Forms.ComboBox pListComboBox;
        private System.Windows.Forms.TextBox tLogFileDisplay;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnWriteDate;
    }
}

