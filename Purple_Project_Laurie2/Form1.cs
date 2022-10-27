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
        private bool isGameOver, goLeft, goRight, jumpin, namiPosition;
    int jumpSpeed;
    int force;
    int croquettes = 0;
    int namiSpeed = 8;
        int gravity = 5;

    
    int verticalForce = 5;
    int verticalForce2 = 5;

    int enemySpeed1 = 5;
    int enemySpeed2 = 5;

    public Form1()
    {
        InitializeComponent();
    }

        private async void MainGameTimerEvent(object sender, ElapsedEventArgs e)
        {

            
            txtCroquettes.Text = "Croquettes: " + croquettes;
            enemyBox.BringToFront();
            enemyBox2.BringToFront();

            nami.Top += jumpSpeed;
            if (goLeft == true)
            {
                nami.Left -= namiSpeed;
            }

            if (goRight == true)
            {
                nami.Left += namiSpeed;
            }

            if (jumpin == true && force < 0)
            {
                jumpin = false;
            }

            if (jumpin == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 9;
            }

            if (namiPosition == true)
            {
                nami.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
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
            else if (nami.Bottom > ClientSize.Height + 100)
            {
                gameTimer.Stop();
                isGameOver = true;
                //gameOver.BringToFront();
                //gameOver.Visible = true;

                txtCroquettes.Text = "Perdu ! Tu as collecté " + croquettes + " croquettes!";
            }

            


            foreach (Control x in this.Controls)
            {



                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (x is PictureBox)
                    {

                        if ((string)x.Tag == "platform")
                        {
                            if (nami.Bounds.IntersectsWith(x.Bounds) && !jumpin)
                            {
                                force = 8;
                                nami.Top = x.Top +2- nami.Height;
                                jumpin = false;
                                

                            }

                            x.BringToFront();


                        }

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

                if ((string)x.Tag == "niche")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds) && croquettes >= 31)
                    {

                        txtCroquettes.Text = "Bravo ! Tu as collecté " + croquettes + " croquettes!";
                       
                    }
                    else if (nami.Bounds.IntersectsWith(x.Bounds) && croquettes < 31)
                    {
                        txtCroquettes.Text = "Perdu ! Tu n'as collecté " + croquettes + " croquettes, réessaye !";
                    }


                }

                if ((string)x.Tag == "croc")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        croquettes += 1;
                        x.Visible = false;
                    }
                }
                if ((string)x.Tag == "superCrocs")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        croquettes += 10;
                        x.Visible = false;
                    }
                }


                if ((string)x.Tag == "enemy")
                {
                    if (nami.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        isGameOver = true;
                        //gameOver.BringToFront();
                        //gameOver.Visible = true;

                        txtCroquettes.Text = "Perdu ! Tu as collecté " + croquettes + " croquettes!";
                     

                    }

                } 


            }

            // Pathing of the elevators
            
            elevator1.Top += verticalForce;
            if (elevator1.Top < 120 || elevator1.Top > 500)
            {
                verticalForce = -verticalForce;

            }

            elevator2.Top += verticalForce2;
            if (elevator2.Top < 120 || elevator2.Top > 500)
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
            
            if (enemyBox.Left >= pictureBox11.Left + pictureBox11.Width - 60)
            {
                
                enemyBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                
            }
            else if (enemyBox.Left <= pictureBox11.Left )
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

        

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Timer1(object sender, EventArgs e)
        {
            if (!jumpin && pb_Player.Location.Y +
        pb_Player.Height < WorldFrame.Height - 2 && !Collision_Top(pb_Player))
            {
                pb_Player.Top += Speed_Fall;
            }

            if (!Player_Jump && pb_Player.Location.Y + pb_Player.Height > WorldFrame.Height - 1)
            {
                pb_Player.Top--;
            }
        }

        private void imgGameOver()
        {
            // Create a picture box called "gameover" and add it to the form on front 
            PictureBox gameOver = new PictureBox();
            gameOver.Image = Properties.Resources.gameover;
            gameOver.Location = new Point(500, 200);
            gameOver.Height = 240;
            gameOver.Width = 600;
            this.Controls.Add(gameOver);
            gameOver.BringToFront();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
    {
        

        if (e.KeyCode == Keys.Left)
        {
            goLeft = true;
                goRight = false;
            
        }
        if (e.KeyCode == Keys.Right)
        {
            goRight = true;
            goLeft = false;
            }
        if (e.KeyCode == Keys.Space && jumpin == false)
        {
            jumpin = true;
            
        }
        
    }

    private void KeyIsUp(object sender, KeyEventArgs e)
    {
        
        
        if (e.KeyCode == Keys.Left)
        {
               
                goLeft = false;
        }
        if (e.KeyCode == Keys.Right)
        {
                namiPosition = false;
            goRight = false;
        }
        if (jumpin == true)
        {
            jumpin = false;
        }
        
        
        
        
        
        if (e.KeyCode == Keys.Enter && isGameOver == true)
        {
            RestartGame();
            
        }
        
    }

    private void RestartGame() // Restart the game when nami's die
    {
       isGameOver = false;
       //gameOver.Visible = false;
       nami.Top = 500;
       nami.Left = 50;
            

        croquettes = 0;
        txtCroquettes.Text = "Croquettes" + croquettes;

        foreach (Control x in this.Controls)
        {
            if (x is PictureBox && x.Visible == false)
            {
                x.Visible = true;
            }
        }
        
        enemyBox.Left = 456;
        enemyBox2.Left = 1051;

        elevator1.Top = 361;
        elevator2.Top = 361;
        
        
        gameTimer.Start();

    }


    
    }
    class OvalPictureBox : PictureBox
    {
        public OvalPictureBox()
        {
            this.BackColor = Color.DarkGray;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
    }


}


