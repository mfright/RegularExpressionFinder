namespace RegularExpressionFinder
{
    partial class RegularExpressionFinder
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTargetFolder = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTargetFiles = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadExpression = new System.Windows.Forms.Button();
            this.txtRegularExpressions = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 354);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(481, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(499, 348);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(137, 43);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "３．検索を開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 389);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 12);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "status";
            // 
            // lblTargetFolder
            // 
            this.lblTargetFolder.AutoSize = true;
            this.lblTargetFolder.BackColor = System.Drawing.Color.White;
            this.lblTargetFolder.Location = new System.Drawing.Point(6, 53);
            this.lblTargetFolder.Name = "lblTargetFolder";
            this.lblTargetFolder.Size = new System.Drawing.Size(19, 12);
            this.lblTargetFolder.TabIndex = 3;
            this.lblTargetFolder.Text = "c:\\";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(6, 18);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(135, 23);
            this.btnSelectFolder.TabIndex = 4;
            this.btnSelectFolder.Text = "フォルダ選択";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTargetFiles);
            this.groupBox1.Controls.Add(this.lblTargetFolder);
            this.groupBox1.Controls.Add(this.btnSelectFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 330);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "１．検索対象のテキストファイルのあるフォルダを選択";
            // 
            // lstTargetFiles
            // 
            this.lstTargetFiles.FormattingEnabled = true;
            this.lstTargetFiles.ItemHeight = 12;
            this.lstTargetFiles.Location = new System.Drawing.Point(8, 85);
            this.lstTargetFiles.Name = "lstTargetFiles";
            this.lstTargetFiles.Size = new System.Drawing.Size(254, 232);
            this.lstTargetFiles.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadExpression);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtRegularExpressions);
            this.groupBox2.Location = new System.Drawing.Point(298, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 330);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "２．検索条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "複数行でOR検索。AND条件は&&で繋ぐ。\r\nファイル名の条件も付けるときは行末に【】で指定。";
            // 
            // btnLoadExpression
            // 
            this.btnLoadExpression.Location = new System.Drawing.Point(227, 12);
            this.btnLoadExpression.Name = "btnLoadExpression";
            this.btnLoadExpression.Size = new System.Drawing.Size(103, 23);
            this.btnLoadExpression.TabIndex = 1;
            this.btnLoadExpression.Text = "ファイルを読み込み";
            this.btnLoadExpression.UseVisualStyleBackColor = true;
            this.btnLoadExpression.Click += new System.EventHandler(this.btnLoadExpression_Click);
            // 
            // txtRegularExpressions
            // 
            this.txtRegularExpressions.Location = new System.Drawing.Point(13, 70);
            this.txtRegularExpressions.Multiline = true;
            this.txtRegularExpressions.Name = "txtRegularExpressions";
            this.txtRegularExpressions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRegularExpressions.Size = new System.Drawing.Size(319, 254);
            this.txtRegularExpressions.TabIndex = 0;
            // 
            // RegularExpressionFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegularExpressionFinder";
            this.Text = "正規表現で行検索ツール";
            this.Load += new System.EventHandler(this.RegularExpressionFinder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTargetFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstTargetFiles;
        private System.Windows.Forms.Button btnLoadExpression;
        private System.Windows.Forms.TextBox txtRegularExpressions;
        private System.Windows.Forms.Label label1;
    }
}

