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
        public Form1()
        {
            InitializeComponent();
        }

        private void uložiťToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                TextEditor editor = new TextEditor(openFileDialog1.FileName);
                textBox1.Text = editor.Data;
                this.Text = "Text Master MC - Otvorené: " + Path.GetFullPath(openFileDialog1.FileName);
                toolStripStatusLabel1.Text = "Otvorené: " + Path.GetFullPath(openFileDialog1.FileName);
            }
        }
    }
}
