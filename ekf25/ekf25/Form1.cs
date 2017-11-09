using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ekf25
{
    public partial class Form1 : Form
    {
        XmlDocument dok;
        XmlNode csomopont;
        public Form1()
        {
            InitializeComponent();
            dok = new XmlDocument();
            //dok.LoadXml("<hirek><hir><cim>elso</cim></hir><hir><cim>masodik</cim></hir></hirek>");
            dok.Load("http://v2lab.hu/hirek2.xml");
            csomopont = dok.DocumentElement.SelectSingleNode("/hirek/hir/cim");
            //listBox1.Items.Add(csomopont.InnerText);
            tobbNodeotKezel();
        }
        public void tobbNodeotKezel()
        {
            XmlNodeList csomopontok = dok.DocumentElement.SelectNodes("/hirek/hir/iskola");
            foreach (XmlNode csomopont in csomopontok)
            {
                listBox1.Items.Add(csomopont.InnerText);
            }
        }
        private void alaphelyzetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Random vel = new Random();
            for (int i = 0; i < 10; i++)
            {
                int szam = vel.Next(10, 20);
                listBox1.Items.Add(szam);
            }
            allapotsor();
        }
        /// <summary>
        /// ez a fv frissíti az állapotsort
        /// </summary>
        private void allapotsor()
        {
            toolStripStatusLabel1.Text = listBox1.Items.Count.ToString();
        }

        private void osszegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var osszeg = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                osszeg += Convert.ToInt32(listBox1.Items[i]);
            }
            label1.Text = osszeg.ToString();
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void újToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                try
                {
                    Convert.ToInt32(textBox1.Text);
                    listBox1.Items.Add(textBox1.Text);
                }
                catch (FormatException ex)
                {
                    label1.Text = "Számot adj meg!";
                }
            }
            allapotsor();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            progressBar1.Value = trackBar1.Value;
        }
    }
}
