using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        bool balraMegy;
        bool jobbraMegy;
        int sebesseg = 5;
        int pontszam = 0;
        bool leVanNyomva;
        int ellensegekSzama = 12;
        int jatekosSebesseg = 6;
        public Form1()
        {
            InitializeComponent();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                balraMegy = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                jobbraMegy = true;
            }
            if (e.KeyCode == Keys.Space && !leVanNyomva)
            {
                leVanNyomva = true;
                lovedeketCsinal();
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                balraMegy = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                jobbraMegy = false;
            }
            if (leVanNyomva) leVanNyomva = false; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (balraMegy) jatekos.Left -= jatekosSebesseg;
            if (jobbraMegy) jatekos.Left += jatekosSebesseg;
            foreach (Control x in this.Controls)
            {
                
                if (x is PictureBox && x.Tag == "invader")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(jatekos.Bounds))
                    {
                        jatekVege();
                    }
                    x.Left += sebesseg;
                    if (x.Left>720)
                    {
                        x.Top += 60;
                        x.Left = -50;
                    }
                }
            }
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "lovedek")
                {
                    y.Top -= 20;
                    if (((PictureBox)y).Top < this.Height -490)
                {
                    this.Controls.Remove(y);
                }
                }
                
            }
            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "invader")
                    {
                        if (j is PictureBox && j.Tag == "lovedek")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                pontszam++;
                                this.Controls.Remove(i);
                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }
            label1.Text = pontszam.ToString();

        }
        public void lovedeketCsinal()
        {
            PictureBox lovedek = new PictureBox();
            lovedek.Image = Properties.Resources.bullet;
            lovedek.Size = new Size(5, 20);
            lovedek.Tag = "lovedek";
            lovedek.Left = jatekos.Left+jatekos.Width/2;
            lovedek.Top = jatekos.Top - 20;
            this.Controls.Add(lovedek);
            lovedek.BringToFront();
        }
        public void jatekVege()
        {
            timer1.Stop();
            label1.Text = "Vége";
        }
    }
}
