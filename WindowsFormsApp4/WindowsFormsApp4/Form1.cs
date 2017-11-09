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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG képek|*.jpg";
            openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                //label1.Text = openFileDialog1.FileName;
                
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void dokumentumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ablak2 = new Form2();
            ablak2.Show();
        }

        private void mentésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 ablak3 = new Form3();
            ablak3.Show();
        }
    }
}
