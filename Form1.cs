using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void uložiťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult odpovedDialogovehoOkna = saveFileDialog1.ShowDialog();
            if (odpovedDialogovehoOkna == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, this.textEditor.Data);
                this.Text = Path.GetFileName(saveFileDialog1.FileName);
            }
        }

        private void ukončiťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void otvoriťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult odpovedDialogovehoOkna = openFileDialog1.ShowDialog();
            if (odpovedDialogovehoOkna == DialogResult.OK)
            {                
                this.textEditor = new TextEditor(openFileDialog1.FileName);
                textBox1.Text = textEditor.Data;
                this.Text = "Text Master MC - Otvorené: " + Path.GetFullPath(openFileDialog1.FileName);
                toolStripStatusLabel1.Text = "Otvorené: " + Path.GetFullPath(openFileDialog1.FileName);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
            }

        }
    }
}
