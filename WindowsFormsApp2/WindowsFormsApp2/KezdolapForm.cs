using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class KezdolapForm : Form
    {
        public KezdolapForm()
        {
            InitializeComponent();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void beállításokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeallitasokForm form2 = new BeallitasokForm();
            form2.Show();
            form2.Tag = this;
            this.Hide();
        }
    }
}
