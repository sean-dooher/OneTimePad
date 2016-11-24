namespace OnePad
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeButton = new System.Windows.Forms.Button();
            this.unMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeButton = new System.Windows.Forms.Button();
            this.enMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowLabel = new System.Windows.Forms.Label();
            this.unListBox = new System.Windows.Forms.ListBox();
            this.enListBox = new System.Windows.Forms.ListBox();
            this.fileProgress = new System.Windows.Forms.ProgressBar();
            this.encodeWorker = new System.ComponentModel.BackgroundWorker();
            this.decodeWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.unMenuStrip.SuspendLayout();
            this.enMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(486, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newKeyToolStripMenuItem,
            this.openKeyToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // newKeyToolStripMenuItem
            // 
            this.newKeyToolStripMenuItem.Name = "newKeyToolStripMenuItem";
            this.newKeyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newKeyToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newKeyToolStripMenuItem.Text = "&New Key";
            this.newKeyToolStripMenuItem.Click += new System.EventHandler(this.newKeyToolStripMenuItem_Click);
            // 
            // openKeyToolStripMenuItem
            // 
            this.openKeyToolStripMenuItem.Name = "openKeyToolStripMenuItem";
            this.openKeyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openKeyToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openKeyToolStripMenuItem.Text = "&Open Key";
            this.openKeyToolStripMenuItem.Click += new System.EventHandler(this.openKeyToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // encodeButton
            // 
            this.encodeButton.Enabled = false;
            this.encodeButton.Location = new System.Drawing.Point(83, 349);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(75, 23);
            this.encodeButton.TabIndex = 2;
            this.encodeButton.Text = "Encode";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encode_Click);
            // 
            // unMenuStrip
            // 
            this.unMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.unMenuStrip.Name = "contextMenuStrip1";
            this.unMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Remove";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Enabled = false;
            this.decodeButton.Location = new System.Drawing.Point(328, 349);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(75, 23);
            this.decodeButton.TabIndex = 4;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decode_Click);
            // 
            // enMenuStrip
            // 
            this.enMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.enMenuStrip.Name = "contextMenuStrip2";
            this.enMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Enabled = false;
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem1.Text = "Remove";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // arrowLabel
            // 
            this.arrowLabel.AutoSize = true;
            this.arrowLabel.Location = new System.Drawing.Point(234, 162);
            this.arrowLabel.Name = "arrowLabel";
            this.arrowLabel.Size = new System.Drawing.Size(19, 26);
            this.arrowLabel.TabIndex = 8;
            this.arrowLabel.Text = "=>\r\n<=";
            // 
            // unListBox
            // 
            this.unListBox.ContextMenuStrip = this.unMenuStrip;
            this.unListBox.Enabled = false;
            this.unListBox.FormattingEnabled = true;
            this.unListBox.Location = new System.Drawing.Point(12, 27);
            this.unListBox.Name = "unListBox";
            this.unListBox.Size = new System.Drawing.Size(217, 316);
            this.unListBox.TabIndex = 9;
            this.unListBox.SelectedIndexChanged += new System.EventHandler(this.unListBox_SelectedIndexChanged);
            // 
            // enListBox
            // 
            this.enListBox.ContextMenuStrip = this.enMenuStrip;
            this.enListBox.Enabled = false;
            this.enListBox.FormattingEnabled = true;
            this.enListBox.Location = new System.Drawing.Point(257, 27);
            this.enListBox.Name = "enListBox";
            this.enListBox.Size = new System.Drawing.Size(217, 316);
            this.enListBox.TabIndex = 10;
            this.enListBox.SelectedIndexChanged += new System.EventHandler(this.enListBox_SelectedIndexChanged);
            // 
            // fileProgress
            // 
            this.fileProgress.Location = new System.Drawing.Point(181, 349);
            this.fileProgress.Name = "fileProgress";
            this.fileProgress.Size = new System.Drawing.Size(124, 23);
            this.fileProgress.TabIndex = 11;
            // 
            // encodeWorker
            // 
            this.encodeWorker.WorkerReportsProgress = true;
            this.encodeWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.encodeWorker_DoWork);
            this.encodeWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.encodeWorker_ProgressChanged);
            this.encodeWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.encodeWorker_RunWorkerCompleted);
            // 
            // decodeWorker
            // 
            this.decodeWorker.WorkerReportsProgress = true;
            this.decodeWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.decodeWorker_DoWork);
            this.decodeWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.decodeWorker_ProgressChanged);
            this.decodeWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.decodeWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 379);
            this.Controls.Add(this.fileProgress);
            this.Controls.Add(this.enListBox);
            this.Controls.Add(this.unListBox);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.arrowLabel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.unMenuStrip.ResumeLayout(false);
            this.enMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip unMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip enMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Label arrowLabel;
        private System.Windows.Forms.ListBox unListBox;
        private System.Windows.Forms.ListBox enListBox;
        private System.Windows.Forms.ToolStripMenuItem newKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openKeyToolStripMenuItem;
        private System.Windows.Forms.ProgressBar fileProgress;
        private System.ComponentModel.BackgroundWorker encodeWorker;
        private System.ComponentModel.BackgroundWorker decodeWorker;
    }
}

