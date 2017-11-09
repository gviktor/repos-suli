using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "RTF|*.rtf|Text Files|*.txt|Word Documents|*.doc";
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);

        }
    }
}
