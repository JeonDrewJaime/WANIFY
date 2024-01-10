using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Guna.Charts;
using Guna.Charts.WinForms;

namespace E_CommerceSystem
{
    public partial class CustomMessageBox : KryptonForm
    {

        private String title;
        public CustomMessageBox()
        {
            InitializeComponent();
        }


    public string Title
        {
            get { return title; }
            set { title = value; Header.Text = value; }
        }

        private void messageBox_animation_Tick(object sender, EventArgs e)
        {
            if (Opacity > 1)
            {
                messageBox_animation.Stop();

            }
            else
            {
                Opacity += .05;
            }
        }
        int i;


        private void try_again_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
     
        }
    }
}
