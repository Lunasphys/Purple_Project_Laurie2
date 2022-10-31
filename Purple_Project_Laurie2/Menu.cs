using System;
using System.Windows.Forms;

namespace Purple_Project_Laurie2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            
            Close();
            
            


        }
     // close application and return to desk
            private void button2_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
        
    }
}
 