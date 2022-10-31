using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;




namespace Purple_Project_Laurie2
{
    public partial class Form1 : Form
    {
        private bool isGameOver, goLeft, goRight, jumpin, enemyPosition;
        int gravity = 10;
        int force;
        int croquettes = 0;
    
   

    
    int verticalForce = 5;
    int verticalForce2 = 5;

    int enemySpeed1 = 5;
    int enemySpeed2 = 5;
        
    
    public Form1()
    {
            
            InitializeComponent();
    }

       

        private async void
            
            MainGameTimerEvent(object sender, ElapsedEventArgs e)
        {
            
            
            enemyPosition = true;
            txtCroquettes.Text = "Croquettes: " + croquettes;

            // Direction of nami

            if (goLeft == true)
            {
                nami.Left -= 8;
            }

            if (goRight == true)
            {
                nami.Left += 8;
            }


            if (jumpin == true)
            {
                nami.Top -= force;
                force -= 1;
            }


            if (jumpin == false)
            {
                nami.Top += gravity  -5;
            }

            

            // Collision with the left part of the pictureBox41, to not cross it and be stopped

            if (nami.Right >= pictureBox41.Left && nami.Bottom > pictureBox41.Top && nami.Left < pictureBox41.Left && nami.Top > pictureBox41.Top -3 && !jumpin )
            {
                
                nami.Left = pictureBox41.Left - nami.Width;
                jumpin = false;
                
            }
            

            // if nami touch the border of the screen, he can't go further (left and right) and die if he touch the bottom

            if (nami.Left < 0)
            {
                nami.Left = 0;
            }
            else if (nami.Right > ClientSize.Width)
            {
                nami.Left = ClientSize.Width - nami.Width;
            }
            // If nami go outside of the bottom side of the game area, it's a game over
            else if (nami.Bottom > ClientSize.Height + 100)
            {
                gameTimer.Stop();
                isGameOver = true;
                looseG();
                txtCroquettes.Text = "Perdu ! Tu as collecté " + croquettes + " croquettes!";
            }


            if (nami.Left < enemyBox.Right && nami.Right > enemyBox.Left && nami.Bottom > enemyBox.Top && nami.Top < enemyBox.Bottom || nami.Left < enemyBox2.Right && nami.Right > enemyBox2.Left && nami.Bottom > enemyBox2.Top && nami.Top < enemyBox2.Bottom)
            {
                looseG();
            }
            if (nami.Left < niche.Right && nami.Right > niche.Left && nami.Bottom > niche.Top && nami.Top < niche.Bottom && croquettes < 30)
            {
                looseG();
            }

            // Collision with platform to jump on them
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (nami.Right > x.Left && nami.Left < x.Right && nami.Bottom >= x.Top && nami.Top < x.Top)
                    {
                        nami.Top = x.Top - nami.Height;
                        force = 0;
                        jumpin = false;


                    } 
                     else if (nami.Right > x.Left && nami.Left < x.Right && nami.Top <= x.Bottom && nami.Bottom > x.Bottom)
                    {
                        nami.Top = x.Bottom;
                    }
                    else if (nami.Bottom > x.Top && nami.Top < x.Bottom && nami.Left < x.Right && nami.Right > x.Right)
                    {
                        nami.Left = x.Right;
                    }
                    else if (nami.Bottom > x.Top && nami.Top < x.Bottom && nami.Right > x.Left && nami.Left < x.Left)
                    {
                        nami.Left = x.Left - nami.Width;
                        
                    }
                    


                    }
                // if nami is on the elevator and jump, the jump had to take in count the elevator's speed


                if ((string)x.Tag == "Vplatform")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds) && !jumpin)
                    {
                        force = 8;
                        nami.Top = x.Top - nami.Height;
                        


                    }


                }
                // Need to collect all croquette to go to the nickel. If not, it's game over
                if ((string)x.Tag == "niche")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds) && croquettes >= 30)
                    {

                        txtCroquettes.Text = "Bravo ! Tu as collecté " + croquettes + " croquettes!";
                        
                        

                    }
                    else if (nami.Bounds.IntersectsWith(x.Bounds) && croquettes < 30)
                    {
                        txtCroquettes.Text = "Perdu ! Tu n'as collecté " + croquettes + " croquettes, réessaye !";
                        
                        isGameOver = true;
                        gameTimer.Stop();
                    }
                    

                }
                // Collision with croquettes, add 1 point if collectef, +10 if supercroc is collected
                if ((string)x.Tag == "croc")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        croquettes += 1;
                        x.Visible = false;
                        x.SendToBack();
                    }
                }
                if ((string)x.Tag == "superCrocs")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        croquettes += 10;
                        x.Visible = false;
                        x.SendToBack();
                    }
                    
                }

                // Collision with enemy cat, if collide, the party is over
                if ((string)x.Tag == "enemy")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        
                        isGameOver = true;
                        

                        txtCroquettes.Text = "Perdu ! Tu as collecté " + croquettes + " croquettes!";
                        


                    }
                    
                } 


            }

            // Pathing of the elevators
            
            elevator1.Top += verticalForce;
            if (elevator1.Top < 134 || elevator1.Top > 484)
            {
                verticalForce = -verticalForce;

            }

            elevator2.Top += verticalForce2;
            if (elevator2.Top < 134 || elevator2.Top > 484)
            {
                verticalForce2 = -verticalForce2;
            }

            // Pathing of the enemies

            enemyBox.Left -= enemySpeed1;
            if (enemyBox.Left < pictureBox11.Left || enemyBox.Left + enemyBox.Width > pictureBox11.Left + pictureBox11.Width)
            {
                enemySpeed1 = -enemySpeed1;
            }

            enemyBox2.Left -= enemySpeed2;
            if (enemyBox2.Left < pictureBox2.Left || enemyBox2.Left + enemyBox2.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemySpeed2 = -enemySpeed2;
            }


            // Enemies image go on other direction when hit the border of the platform
            if (enemyBox.Left > pictureBox11.Left + pictureBox11.Width - 60)
            {
                enemyBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else if (enemyBox.Left < pictureBox11.Left)
            {
                enemyBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

            if (enemyBox2.Left >= pictureBox2.Left + pictureBox2.Width - 60)
            {
                enemyBox2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else if (enemyBox2.Left <= pictureBox2.Left)
            {
                enemyBox2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            


        }







        // Look if the key is not pressed

        private void KeyIsDown(object sender, KeyEventArgs e)
    {
        

        if (e.KeyCode == Keys.Left)
        {
            goLeft = true;
                

        }
        if (e.KeyCode == Keys.Right)
        {
            goRight = true;
               
           
            }
            if (jumpin == false && e.KeyCode == Keys.Space)
            {
                jumpin = true;
                force = gravity;


            }

        }

        // Look if the key is pressed
        private void KeyIsUp(object sender, KeyEventArgs e)
    {
        
        
        if (e.KeyCode == Keys.Left)
        {
               
                goLeft = false;
        }
        if (e.KeyCode == Keys.Right)
        {
            
            goRight = false;
        }

        


            if (e.KeyCode == Keys.Enter && isGameOver == true)
        {
            RestartGame();  
        }
        
    }


    private PictureBox looseG() // Return and s
        {

            PictureBox loose = new PictureBox();
            loose.Location = new Point(500, 200);
            loose.BackColor = Color.Transparent;
            loose.Visible = true;
            loose.Height = 240;
            loose.Width = 600;
            loose.Tag = "looser";
            loose.Image = Properties.Resources.gameover1;
            Controls.Add(loose);
            loose.BringToFront();
            return loose;
        }
        
        private void RestartGame() // Restart the game when nami's die
    {
            // Delete memory cache
            GC.Collect();

            // Position of pictureBox when the game is restarted and reinitialisation of boolean and int
            isGameOver = false;
       
       nami.Top = 500;
       nami.Left = 50;
            

        croquettes = 0;
        txtCroquettes.Text = "Croquettes" + croquettes;

        foreach (Control x in this.Controls)
        {
            if ((string)x.Tag == "croc" || (string)x.Tag == "superCrocs")
            {
                x.Visible = true;
            }
                if ((string)x.Tag == "looser")
                {
                    x.Dispose();
                }
                if ((string)x.Name == "looser2")
                {
                    x.Dispose();
                }
            }
        
        
        enemyBox.Left = 456;
        enemyBox2.Left = 1051;

        elevator1.Top = 484;
        elevator2.Top = 134;
 
        gameTimer.Start();

    }


    
    }
    


}


