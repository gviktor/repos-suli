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

namespace xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text.Trim();
            webBrowser1.Navigate(url);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //MessageBox.Show("A fajl letöltődött");
            string tipus = webBrowser1.DocumentType;
            Stream adatfolyam = webBrowser1.DocumentStream;
            StreamReader adat = new StreamReader(adatfolyam);
            string szoveg = "";
            while (!adat.EndOfStream)
            {
                szoveg+=adat.ReadLine();
            }
            MessageBox.Show(szoveg);

        }
    }
}
