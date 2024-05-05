using System;
using System.IO;
using System.Windows.Forms;

namespace SemestralneZadanie_MC
{
    public partial class Form1 : Form
    {
        TextEditor textEditor = null;
        bool isSaved = false;
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
                    toolStripStatusLabel1.Text = "Súbor neuložený, otváranie zrušené.";
                    return;
                }
            }
            DialogResult odpovedDialogovehoOkna = openFileDialog1.ShowDialog();
            if (odpovedDialogovehoOkna == DialogResult.OK)
            {
                try
                {
                    textEditor = new TextEditor(openFileDialog1.FileName);
                }
                catch
                {
                    toolStripStatusLabel1.Text = "Chyba pri otváraní súboru: " + Path.GetFullPath(openFileDialog1.FileName);
                    return;
                }
                textBox1.Text = textEditor.Data;
                textBox2.Text = textEditor.Changes;
                this.Text = Path.GetFullPath(openFileDialog1.FileName) ;
                toolStripStatusLabel1.Text = "Otvorené: " + Path.GetFullPath(openFileDialog1.FileName);
                isSaved = false;
                úpravyToolStripMenuItem.Enabled = true;
                uložiťToolStripMenuItem.Enabled = true;
                return;
            }
            toolStripStatusLabel1.Text = "Otváranie súboru zrušené.";
        }
        private void uložiťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult odpovedDialogovehoOkna = saveFileDialog1.ShowDialog();
            if (odpovedDialogovehoOkna == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, textEditor.Data);
                }
                catch (IOException)
                {
                    toolStripStatusLabel1.Text = "Chyba pri práci so súborom!";
                }
                catch (UnauthorizedAccessException)
                {
                    toolStripStatusLabel1.Text = "Prístup pre zápis do súboru je zamietnutý!";
                }
                
                isSaved = true;
                this.Text = Path.GetFullPath(saveFileDialog1.FileName) + " - Text Master MC";
                toolStripStatusLabel1.Text = "Súbor uložený: " + Path.GetFullPath(saveFileDialog1.FileName);
                return;
            }
            toolStripStatusLabel1.Text = "Ukladanie súboru zrušené.";
        }
        private void oAplikáciiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }
        private void ukončiťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ukončovanie aplikácie.";
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textEditor != null && !isSaved)
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
                    toolStripStatusLabel1.Text = "Ukončovanie aplikácie zrušené.";
                }
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //zmena veľkých písmen na malé
        {
            textEditor.toLowercase();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            isSaved = false;
            toolStripStatusLabel1.Text = "Vykonaná zmena veľkých písmen na malé.";
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        //zmena malých písmen na veľké
        {
            textEditor.toUppercase();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            isSaved = false;
            toolStripStatusLabel1.Text = "Vykonaná zmena malých písmen na veľké.";
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        //prvé písmeno vety na veľké
        {
            textEditor.sentencesStartsToUpper();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            isSaved = false;
            toolStripStatusLabel1.Text = "Vykonaná zmena prvých písmen vety na veľké.";
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        //prvé písmeno slova na veľké
        {
            textEditor.wordsStartsToUpper();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            isSaved = false;
            toolStripStatusLabel1.Text = "Vykonaná zmena prvých písmen slov na veľké.";
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        //odstrániť diakritiku
        {
            textEditor.removeDiacritic();
            textBox1.Text = textEditor.Data;
            textBox2.Text = textEditor.Changes;
            isSaved = false;
            toolStripStatusLabel1.Text = "Diakritika odstránená.";
        }
    }
}
