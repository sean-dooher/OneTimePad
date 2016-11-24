using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePad
{
    public partial class NewKey : Form
    {
        public event EventHandler<Key> KeyCreated;
        private Key created;
        public NewKey()
        {
            InitializeComponent();
            unitSelector.SelectedIndex = 2;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sFD = new SaveFileDialog();
            sFD.AddExtension = true;
            sFD.Filter = "One Time Pad Key (*.pad)|*.pad";
            sFD.ShowDialog();
            filepathBox.Text = sFD.FileName;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int mb = Int32.Parse(sizeBox.Text);
            int multiplier = 1;
            if (unitSelector.Text == "KB") multiplier = 1024;
            else if (unitSelector.Text == "MB") multiplier = 1048576;
            //Disable UI controls while creating keys
            sizeBox.Enabled = false; 
            createButton.Enabled = false;
            unitSelector.Enabled = false;
            filepathBox.Enabled = false;
            browseButton.Enabled = false;
            backgroundWorker1.RunWorkerAsync(new Tuple<int, string>(mb * multiplier, filepathBox.Text));
        }

        private void filepathBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                createButton.Enabled = Directory.Exists(Path.GetDirectoryName(filepathBox.Text));
            }
            catch
            {
            }
        }

        private void sizeBox_ValueChanged(object sender, EventArgs e)
        {
            /*int multiplier = 1;
            if (unitSelector.Text == "KB") multiplier = 1024;
            else if (unitSelector.Text == "MB") multiplier = 1048576;
            if (sizeBox.Value * multiplier > 524288000)
            {
                sizeBox.Text = (524288000 / multiplier).ToString();
            }*/
        }

        private void unitSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int multiplier = 1;
            if (unitSelector.Text == "KB") multiplier = 1024;
            else if (unitSelector.Text == "MB") multiplier = 1048576;
            if (sizeBox.Value * multiplier > 524288000)
            {
                sizeBox.Text = (524288000 / multiplier).ToString();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int byteSize = (e.Argument as Tuple<int,string>).Item1;
            string filePath =(e.Argument as Tuple<int,string>).Item2;
            created = new Key(byteSize, filePath, (send, args) => backgroundWorker1.ReportProgress(args));//creates key and has progress reported
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 0; i < 100; i++)//add artificial delay to make progress bar look better
            {
                progressBar1.Increment(+1);
                progressBar1.Update();
                Thread.Sleep(5);
            }
            KeyCreated(this, created);
            this.Close();
        }

        private void NewKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyCreated(null, null);
        }
    }
}
