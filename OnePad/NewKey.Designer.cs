namespace OnePad
{
    partial class NewKey
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
            this.filepathBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.unitSelector = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.sizeBox = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // filepathBox
            // 
            this.filepathBox.Location = new System.Drawing.Point(12, 11);
            this.filepathBox.Name = "filepathBox";
            this.filepathBox.Size = new System.Drawing.Size(184, 20);
            this.filepathBox.TabIndex = 0;
            this.filepathBox.TextChanged += new System.EventHandler(this.filepathBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.browseButton.Location = new System.Drawing.Point(202, 9);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(64, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // createButton
            // 
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(188, 45);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(78, 22);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Create New";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Size:";
            // 
            // unitSelector
            // 
            this.unitSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.unitSelector.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB"});
            this.unitSelector.Location = new System.Drawing.Point(134, 45);
            this.unitSelector.Name = "unitSelector";
            this.unitSelector.Size = new System.Drawing.Size(48, 21);
            this.unitSelector.TabIndex = 2;
            this.unitSelector.SelectedIndexChanged += new System.EventHandler(this.unitSelector_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(82, 72);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // sizeBox
            // 
            this.sizeBox.Location = new System.Drawing.Point(48, 46);
            this.sizeBox.Maximum = new decimal(new int[] {
            524288000,
            0,
            0,
            0});
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sizeBox.Size = new System.Drawing.Size(80, 20);
            this.sizeBox.TabIndex = 9;
            this.sizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeBox.ValueChanged += new System.EventHandler(this.sizeBox_ValueChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // NewKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 100);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.unitSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.filepathBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewKey";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Create a New Key";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewKey_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sizeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filepathBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox unitSelector;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown sizeBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}