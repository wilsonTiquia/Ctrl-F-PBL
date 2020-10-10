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
    public partial class realSplash : Form
    {
        public realSplash()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            try
            {
                circularProgressBar1.Value += 1;
            }
            catch (Exception)
            {
                timer1.Enabled = false;
                this.Close();
            };
        }
    }
}
