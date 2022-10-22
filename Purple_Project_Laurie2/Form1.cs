using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Purple_Project_Laurie2
{
    public partial class Form1 : Form
{
    bool isGameOver, goLeft, goUp, goRight, jumpin;
    int jumpSpeed;
    int force;
    int croquettes = 0;
    int namiSpeed = 8;

    int horizontalForce = 3;
    int verticalForce = 5;

    int enemySpeed = 5;

    public Form1()
    {
        InitializeComponent();
    }

    private void MainGameTimerEvent(object sender, ElapsedEventArgs e)
    {
        txtCroquettes.Text = "Croquettes: " + croquettes;

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
            jumpSpeed = 12;
        }
        
        // if nami touch the border of the screen, he can't go further (left and right) and die if he touch the bottom
        
        if (nami.Left < 0)
        {
            nami.Left = 0;
        } else if (nami.Right > ClientSize.Width)
        {
            nami.Left = ClientSize.Width - nami.Width;
        } else if (nami.Bottom > ClientSize.Height + 100)
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
                        if (nami.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            nami.Top = x.Top - nami.Height;
                        }

                        x.BringToFront();
                    }
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
        elevator1.Top += verticalForce;
        if (elevator1.Top < 120 || elevator1.Top > 500)
        {
            verticalForce =-verticalForce;
        }
        elevator2.Top += verticalForce;
        if (elevator2.Top < 120 || elevator2.Top > 500)
        {
            verticalForce =-verticalForce;
        }
    }



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
        if (e.KeyCode == Keys.Space && jumpin == false)
        {
            jumpin = true;
            
        }
    }

    private void KeyIsUp(object sender, KeyEventArgs e)
    {
        // if nami touch the border of the screen, he can't go further
        
        if (e.KeyCode == Keys.Left)
        {
            goLeft = false;
        }
        if (e.KeyCode == Keys.Right)
        {
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

    private void RestartGame()
    {
        jumpin = false;
        goLeft = false;
        goRight = false;
        goUp = false;
        isGameOver = false;
        croquettes = 0;
        txtCroquettes.Text = "Croquettes" + croquettes;

        foreach (Control x in this.Controls)
        {
            if (x is PictureBox && x.Visible == false)
            {
                x.Visible = true;
            }
        }
        nami.Left = 80;
        nami.Top = 776;

        enemyBox.Left = 456;
        enemyBox2.Left = 1051;

        elevator1.Top = 361;
        elevator2.Top = 361;
        
        gameTimer.Start();
        


    
    }


   
}
    
}


