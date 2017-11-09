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
            loszertRakLe();
            zombiLetrehozas();
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
            if (gameOver) return;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    balramegy = false;
                    break;
                case Keys.Right:
                    jobbramegy = false;
                    break;
                case Keys.Up:
                    felmegy = false;
                    break;
                case Keys.Down:
                    lemegy = false;
                    break;
            }
            if (e.KeyCode == Keys.Space && loszer > 0) // in this if statement we are checking if the space bar is up and ammo is more than 0             
            {
                loszer--; // reduce ammo by 1 from the total number 
                loves(irany); // invoke the shoot function with the facing string inside it //facing will transfer up, down, left or right to the function and that will shoot the bullet that way.  
                if (loszer < 1) // if ammo is less than 1 
                {
                    loszertRakLe(); // invoke the drop ammo function 
                }
            }
        }

        private void jatekMotor(object sender, EventArgs e)
        {
            if (balramegy && jatekos.Left > 0)
            {
                jatekos.Left -= sebesseg;                 // if moving left is true AND pacman is             
            }
            if (jobbramegy && jatekos.Left + jatekos.Width < 930)
            {
                jatekos.Left += sebesseg;                 // if moving RIGHT is true AND player             
            }
            if (felmegy && jatekos.Top > 60)
            {
                jatekos.Top -= sebesseg;                 // if moving TOP is true AND player is 60        
            }
            if (lemegy && jatekos.Top + jatekos.Height < 700)
            {
                jatekos.Top += sebesseg;                 // if moving DOWN is true AND player top         
            }
        }

        private void loszertRakLe()
        {
            // this function will make a ammo image for this game             
            PictureBox ammo = new PictureBox(); // create a new instance of the picture box             
            ammo.Image = Properties.Resources.ammo_Image; // assignment the ammo image to the picture box             
            ammo.SizeMode = PictureBoxSizeMode.AutoSize; // set the size to auto size             
            ammo.Left = rnd.Next(10, 890); // set the location to a random left             
            ammo.Top = rnd.Next(50, 600); // set the location to a random top             
            ammo.Tag = "loszer"; // set the tag to ammo             
            this.Controls.Add(ammo); // add the ammo picture box to the screen             
            ammo.BringToFront(); // bring it to front             
            jatekos.BringToFront(); // bring the player to front 
        }
        private void loves(string irany)
        {
            Lovedek lovedek = new Lovedek(); // create a new instance of the bullet class 
            lovedek.irany = irany; // assignment the direction to the bulletMore tutorials 
            lovedek.lovedekX = jatekos.Left + (jatekos.Width / 2); // place the bullet to left half of the player            
            lovedek.lovedekY = jatekos.Top + (jatekos.Height / 2); // place the bullet on top half of the player             
            lovedek.letrehoz(this); // run the function mkBullet from the bullet class.
        }
        private void zombiLetrehozas()
        {
            PictureBox zombie = new PictureBox(); // create a new picture box called zombie             
            zombie.Tag = "zombi"; // add a tag to it called zombie             
            zombie.Image = Properties.Resources.zdown; // the default picture for the zombie is zdown             
            zombie.Left = rnd.Next(0, 900); // generate a number between 0 and 900 and assignment that to the new zombies left              
            zombie.Top = rnd.Next(0, 800); // generate a number between 0 and 800 and assignment that to the new zombies top             
            zombie.SizeMode = PictureBoxSizeMode.AutoSize; // set auto size for the new picture box             
            this.Controls.Add(zombie); // add the picture box to the screen             
            jatekos.BringToFront(); // bring the player to the front         
        }

    }
}

