using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = tabControl1.SelectedIndex.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form1 = (Form)Tag;
            form1.Show();
            this.Close();
        }
    }
}
