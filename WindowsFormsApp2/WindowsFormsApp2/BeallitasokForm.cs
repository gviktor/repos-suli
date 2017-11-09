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
    public partial class BeallitasokForm : Form
    {
        public BeallitasokForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var veletlen = new Random();

            listBox1.Items.Add(veletlen.NextDouble());
        }

        private void visszaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = (Form)this.Tag;
            form1.Show();
        }
    }
}
