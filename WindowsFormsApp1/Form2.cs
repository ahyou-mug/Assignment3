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
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        //Tool tip settings
        // Method to set tool tips
        public void Intro_Load(object sender, System.EventArgs e)
        {
            foreach (var tt in Controls.OfType<ToolTip>())
            {
                tt.AutoPopDelay = 5000;
                tt.InitialDelay = 1000;
                tt.ReshowDelay = 500;
                tt.ShowAlways = true;
                tt.Active = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().Show();
            // Need to get new reg form to load when clicked
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MemberSearch().Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            toolTip1.SetToolTip(button1, "Create a new membership");
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            toolTip2.SetToolTip(button2, "Search the membership database");
        }

        private void toolTip3_Popup(object sender, PopupEventArgs e)
        {
            toolTip3.SetToolTip(button3, "Search available classes and book them");
        }

        private void toolTip4_Popup(object sender, PopupEventArgs e)
        {
            toolTip4.SetToolTip(Exit, "Exit the Application completely");
        }
    }
}
