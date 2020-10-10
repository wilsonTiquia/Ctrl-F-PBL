using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mapa_ni_Tiquia aForm = new Mapa_ni_Tiquia();
            aForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cases casesForm = new Cases();
            casesForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Equipments equipmentsForm = new Equipments();
            equipmentsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tests testsForm = new Tests();
            testsForm.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void minimize(object sender, EventArgs e)
        {
            this.Width = 550;
            this.Height = 370;
            minimizeButton.Visible = false;
            maximizeButton.Visible = true;
        }

        private void maximize(object sender, EventArgs e)
        {
            this.Width = 1290;
            this.Height = 770;
            maximizeButton.Visible = false;
            minimizeButton.Visible = true;
        }
        private void hide(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
            TopMost = false;
        }

        private void aboutUs_Click(object sender, EventArgs e)
        {
            SplashScreen aboutForm = new SplashScreen();
            aboutForm.Show();
            aboutUs.Visible = false;
            endUs.Visible = true;
        }
        private void endUs_Click(object sender, EventArgs e)
        {
            SplashScreen aboutForm = new SplashScreen();
            aboutForm.Visible = false;
            aboutUs.Visible = true;
            endUs.Visible = false;
        }

        private void headerPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
