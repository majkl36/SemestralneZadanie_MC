using System;
using System.IO;
using System.Windows.Forms;

namespace SemestralneZadanie_MC
{
    public partial class Form1 : Form
    {
        TextEditor textEditor = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void otvoriťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textEditor != null)
            {
                DialogResult odp = MessageBox.Show("Chcete uložiť súbor?", "Otázka",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button3);
                if (odp == DialogResult.Yes)
                {
                    uložiťToolStripMenuItem_Click(sender, e);
                }
                else if (odp == DialogResult.Cancel)
                {
                    return;
                    //toolstrip label "Zrušené"
                }
            }
            DialogResult odpovedDialogovehoOkna = openFileDialog1.ShowDialog();
            if (odpovedDialogovehoOkna == DialogResult.OK)
            {
                this.textEditor = new TextEditor(openFileDialog1.FileName);
                textBox1.Text = textEditor.Data;
                this.Text = Path.GetFullPath(openFileDialog1.FileName) + " - Text Master MC";
                toolStripStatusLabel1.Text = "Otvorené: " + Path.GetFullPath(openFileDialog1.FileName);
                úpravyToolStripMenuItem.Enabled = true;
                uložiťToolStripMenuItem.Enabled = true;
            }
            //toolstrip otváranie súboru zrušené
        }

        private void uložiťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult odpovedDialogovehoOkna = saveFileDialog1.ShowDialog();
            if (odpovedDialogovehoOkna == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, this.textEditor.Data);
                this.Text = Path.GetFileName(saveFileDialog1.FileName);
                //toolstrip súbor uložený do - path
                return;
            }
            //toolstrip ukladanie súboru zrušené
        }
        private void oAplikáciiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
        private void ukončiťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolstrip Ukončovanie aplikácie
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textEditor != null)
            {
                DialogResult odp = MessageBox.Show("Chcete uložiť súbor?", "Otázka",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button3);
                if (odp == DialogResult.Yes)
                {
                    uložiťToolStripMenuItem_Click(sender, e);
                }
                else if (odp == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    //toolstrip label "Zrušené"
                }
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //zmena veľkých písmen na malé
        {
            textEditor.toLowercase();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            //toolstrip
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        //zmena malých písmen na veľké
        {
            textEditor.toUppercase();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            //toolstrip
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        //prvé písmeno vety na veľké
        {
            textEditor.sentencesStartsToUpper();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            //toolstrip
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        //prvé písmeno slova na veľké
        {
            textEditor.wordsStartsToUpper();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            //toolstrip
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        //odstrániť diakritiku
        {
            textEditor.removeDiacritic();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            //toolstrip
        }
    }
}
