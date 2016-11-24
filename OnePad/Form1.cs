using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePad
{
    public partial class MainForm : Form
    {
        private Key key = null;
        private bool loaded = false;
        private Dictionary<object, string> origList = new Dictionary<object, string>();
        private Dictionary<object, string> encryptedList = new Dictionary<object, string>();

        public MainForm()
        {
            InitializeComponent();
        }

        #region Strip Menu
        private void newKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewKey newKey = new NewKey();
            this.Enabled = false;
            newKey.KeyCreated += loadKey;
            newKey.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "One Time Pad Key (*.pad)|*.pad";
            if(oFD.ShowDialog() == System.Windows.Forms.DialogResult.OK) loadKey(sender, new Key(oFD.FileName));
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Context Menus
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "All files (*.*) | *.*";
            if (oFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                unListBox.Items.Add(Path.GetFileName(oFD.FileName));
                origList.Add(unListBox.Items[unListBox.Items.Count - 1], oFD.FileName);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            origList.Remove(unListBox.Items[unListBox.SelectedIndex]);
            unListBox.Items.Remove(unListBox.Items[unListBox.SelectedIndex]);
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "One Time Pad File(*.padf)|*.padf";
            if (oFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                enListBox.Items.Add(Path.GetFileName(oFD.FileName));
                encryptedList.Add(enListBox.Items[enListBox.Items.Count - 1], oFD.FileName);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            encryptedList.Remove(enListBox.Items[enListBox.SelectedIndex]);
            enListBox.Items.Remove(enListBox.Items[enListBox.SelectedIndex]);
        }
        #endregion

        private void encode_Click(object sender, EventArgs e)
        {
            string filepath = origList[unListBox.SelectedItem];
            SaveFileDialog sFD = new SaveFileDialog();
            sFD.Filter = "Encoded file (*.padf)|*.padf";
            if (sFD.ShowDialog() == System.Windows.Forms.DialogResult.OK && Directory.Exists(Path.GetDirectoryName(sFD.FileName)))
            {
                enListBox.Enabled = false;
                unListBox.Enabled = false;
                decodeButton.Enabled = false;
                encodeButton.Enabled = false;
                newKeyToolStripMenuItem.Enabled = false;
                openKeyToolStripMenuItem.Enabled = false;
                encodeWorker.RunWorkerAsync(new Tuple<string, string>(filepath, sFD.FileName));
            }
        }

        private void decode_Click(object sender, EventArgs e)
        {
            string filepath = encryptedList[enListBox.SelectedItem];
            string ext = key.GetEncodedExtension(filepath);
            SaveFileDialog sFD = new SaveFileDialog();
            sFD.Filter = "Decoded file (*" + ext + ")|*" + ext;
            if (sFD.ShowDialog() == System.Windows.Forms.DialogResult.OK && Directory.Exists(Path.GetDirectoryName(sFD.FileName)))
            {
                enListBox.Enabled = false;
                unListBox.Enabled = false;
                decodeButton.Enabled = false;
                encodeButton.Enabled = false;
                newKeyToolStripMenuItem.Enabled = false;
                openKeyToolStripMenuItem.Enabled = false;
                decodeWorker.RunWorkerAsync(new Tuple<string, string>(filepath, sFD.FileName));
            }
        }

        public void loadKey(object sender, Key key)
        {
            if (key != null)
            {
                this.key = key;
                this.Enabled = true;
                this.Text = "Index = " + key.Index;
                loaded = true;
                unListBox.Enabled = true;
                enListBox.Enabled = true;
                key.EncodeFileProgress += (send, e) => encodeWorker.ReportProgress(e);
                key.IndexChanged += (send, e) => encodeWorker.ReportProgress(e + 150);
                key.DecodeFileProgress += (send, e) => decodeWorker.ReportProgress(e);
            }
            else
            {
                this.Enabled = true;
            }
        }

        private void unListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            unMenuStrip.Items["deleteToolStripMenuItem"].Enabled = unListBox.SelectedIndex >= 0;
            encodeButton.Enabled = loaded && unListBox.SelectedIndex >= 0;
        }

        private void enListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enMenuStrip.Items["deleteToolStripMenuItem1"].Enabled = enListBox.SelectedIndex >= 0;
            decodeButton.Enabled = loaded && enListBox.SelectedIndex >= 0;
        }

        private void encodeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string filename = (e.Argument as Tuple<string, string>).Item1;
            string savepath = (e.Argument as Tuple<string, string>).Item2;
            key.EncodeFile(filename, savepath);
        }

        private void encodeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = fileProgress.Value; i < 100; i++)
            {
                fileProgress.Value++;
                fileProgress.Update();
                Thread.Sleep(3);
            }
            enListBox.Enabled = true;
            unListBox.Enabled = true;
            decodeButton.Enabled = loaded && enListBox.SelectedIndex >= 0;
            encodeButton.Enabled = loaded && unListBox.SelectedIndex >= 0;
            newKeyToolStripMenuItem.Enabled = true;
            openKeyToolStripMenuItem.Enabled = true;
        }

        private void encodeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 150)
            {
                this.Text = "Index: " + (e.ProgressPercentage - 150).ToString();
            }
            else if (e.ProgressPercentage <= 100)
            {
                fileProgress.Value = e.ProgressPercentage;
                fileProgress.Update();
            }
        }

        private void decodeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string filename = (e.Argument as Tuple<string, string>).Item1;
            string savepath = (e.Argument as Tuple<string, string>).Item2;
            key.DecodeFile(filename, savepath);
        }

        private void decodeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            fileProgress.Value = e.ProgressPercentage;
            fileProgress.Update();
        }

        private void decodeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = fileProgress.Value; i < 100; i++)
            {
                fileProgress.Value++;
                fileProgress.Update();
                Thread.Sleep(3);
            }
            enListBox.Enabled = true;
            unListBox.Enabled = true;
            decodeButton.Enabled = loaded && enListBox.SelectedIndex >= 0;
            encodeButton.Enabled = loaded && unListBox.SelectedIndex >= 0;
            newKeyToolStripMenuItem.Enabled = true;
            openKeyToolStripMenuItem.Enabled = true;
        }
    }
}
