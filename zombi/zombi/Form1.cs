using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zombi
{
    public partial class Form1 : Form
    {
        bool felmegy;
        bool lemegy; // this boolean will be used for the player to go down the screen 
        bool balramegy; // this boolean will be used for the player to go left to the screen 
        bool jobbramegy; // this boolean will be used for the player to right to the screen 
        string irany = "fel"; // this string is called facing and it will be used to guide the bullets 
        double hp = 100; // this double variable is called player health 
        int sebesseg = 10; // this integer is for the speed of the player 
        int loszer = 10; // this integer will hold the number of ammo the player has start of the game 
        int zombiSebesseg = 3; // this integer will hold the speed which the zombies move in the game
        int pontszam = 0; // this integer will hold the score the player achieved through the game 
        bool gameOver = false; // this boolean is false in the beginning and it will be used when the game is finished 
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    balramegy = true;
                    irany = "bal";
                    jatekos.Image = Properties.Resources.left;
                    break;
                case Keys.Right:
                    jobbramegy = true;
                    irany = "jobb";
                    jatekos.Image = Properties.Resources.right;
                    break;
                case Keys.Up:
                    felmegy = true;
                    irany = "fel";
                    jatekos.Image = Properties.Resources.up;
                    break;
                case Keys.Down:
                    lemegy = true;
                    irany = "le";
                    jatekos.Image = Properties.Resources.down;
                    break;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {

        }

        private void jatekMotor(object sender, EventArgs e)
        {

        }
        private void loszertRakLe()
        {

        }
        private void loves(string irany)
        {

        }
        private void zombiLetrehozas()
        {
        }
    }
}
