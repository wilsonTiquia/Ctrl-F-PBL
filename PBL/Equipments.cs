using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace PBL
{
    public partial class Equipments : Form
    {

        StreamReader equipments = new StreamReader("D://Equipments.txt");
        StreamReader ppe = new StreamReader("D://PPE.txt");
        //variable process for ppe
        int coverall = 0;
        int faceshield = 0;
        int goggles = 0;
        int gown = 0;
        int N95 = 0;
        int shoecover = 0;
        int headcover = 0;
        int surgicalmask = 0;
        //variable for ppe
        int val1 = 0;
        int val2 = 0;
        int val3 = 0;
        int val4 = 0;
        int val5 = 0;
        int val6 = 0;
        int val7 = 0;
        int val8 = 0;
        //variable for equipments
        int equipval1 = 0;
        int equipval2 = 0;
        int equipval3 = 0;
        int equipval4 = 0;

        public Equipments()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void extend1_Click(object sender, EventArgs e)
        {
            menuPanel.Visible = true;
            mapButton.Visible = true;
            casesButton.Visible = true;
            testButton.Visible = true;
            equipmentsButton.Visible = true;
            mapLabel.Visible = true;
            casesLabel.Visible = true;
            testLabel.Visible = true;
            equipmentsLabel.Visible = true;
            extend2.Visible = true;
            extend1.Visible = false;
        }

        private void extend2_Click(object sender, EventArgs e)
        {
            menuPanel.Visible = false;
            mapButton.Visible = false;
            casesButton.Visible = false;
            testButton.Visible = false;
            equipmentsButton.Visible = false;
            mapLabel.Visible = false;
            casesLabel.Visible = false;
            testLabel.Visible = false;
            equipmentsLabel.Visible = false;
            extend2.Visible = false;
            extend1.Visible = true;
        }

        private void map_Click(object sender, EventArgs e)
        {
            Mapa_ni_Tiquia mapForm = new Mapa_ni_Tiquia();
            mapForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Cases casesForms = new Cases();
            casesForms.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Tests testsForms = new Tests();
            testsForms.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Width = 550;
            this.Height = 370;
            pictureBox6.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Width = 1290;
            this.Height = 770;
            pictureBox6.Visible = true;
            pictureBox4.Visible = false;
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void map_Click_1(object sender, EventArgs e)
        {
            //Form1 mapForm = new Form1();
            //mapForm.Show();
        }

        private void casess_Click(object sender, EventArgs e)
        {
            Cases casesForm = new Cases();
            casesForm.Show();
        }

        private void tests_Click(object sender, EventArgs e)
        {
            Tests testsForm = new Tests();
            testsForm.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Equipments equipmentsForm = new Equipments();
            equipmentsForm.Show();
        }

        private void Equipments_Load_1(object sender, EventArgs e)
        {

            chart1.Visible = true;
            listView2.Visible = false;
            listViewPanel.Visible = false;

            //display of first default data for equipments (Abra)

            while (equipments.Peek() != -1)
            {
                string x = equipments.ReadLine();
                string[] xe = x.Split(',');
                ListViewItem lvi = new ListViewItem(xe[0]);
                

                lvi.SubItems.Add(xe[1]);
                lvi.SubItems.Add(xe[2]);
                lvi.SubItems.Add(xe[3]);
                lvi.SubItems.Add(xe[4]);
                lvi.SubItems.Add(xe[5]);
                lvi.SubItems.Add(xe[6]);
                lvi.SubItems.Add(xe[7]);
                lvi.SubItems.Add(xe[8]);
                listView2.Items.Add(lvi);
                if (xe[0] == "ABRA") 
                {
                    chart1.Series["Total"].Points.AddXY("ICU Beds", xe[1]);
                    chart1.Series["Occupied"].Points.AddXY("ICU Beds", xe[2]);
                    chart1.Series["Total"].Points.AddXY("Isolation Beds", xe[3]);
                    chart1.Series["Occupied"].Points.AddXY("Isolation beds", xe[4]);
                    chart1.Series["Total"].Points.AddXY("Ward Beds", xe[5]);
                    chart1.Series["Occupied"].Points.AddXY("Ward Beds", xe[6]);
                    chart1.Series["Total"].Points.AddXY("Mechanical Ventilators", xe[7]);
                    chart1.Series["Occupied"].Points.AddXY("Mechanical Ventilators", xe[8]);
                }

            }
            equipments.Close();
            
            //display for ppe data

                string x1 = ppe.ReadLine();
                string[] xe1 = x1.Split(',');

                coverall = Convert.ToInt32(xe1[0]);
                faceshield = Convert.ToInt32(xe1[1]);
                goggles = Convert.ToInt32(xe1[2]);
                gown = Convert.ToInt32(xe1[3]);
                N95 = Convert.ToInt32(xe1[4]);
                shoecover = Convert.ToInt32(xe1[5]);
                headcover = Convert.ToInt32(xe1[6]);
                surgicalmask = Convert.ToInt32(xe1[7]);
 
                chart2.Series["Personal Protective Equipment"].Points.AddXY("Coverall", coverall);
                chart2.Series["Personal Protective Equipment"].Points.AddXY("Face Shield", faceshield);
                chart2.Series["Personal Protective Equipment"].Points.AddXY("Goggles", goggles);
                chart2.Series["Personal Protective Equipment"].Points.AddXY("Gown", gown);
                chart2.Series["Personal Protective Equipment"].Points.AddXY("N95", N95);
                chart2.Series["Personal Protective Equipment"].Points.AddXY("Shoe Cover", shoecover);
                chart2.Series["Personal Protective Equipment"].Points.AddXY("Head Cover", headcover);
                chart2.Series["Personal Protective Equipment"].Points.AddXY("Surgical Mask", surgicalmask);

            
            ppe.Close();



        }

        //saving new ppe data
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtcoverall.Text == "")
            {
                val1 = coverall;
            }
            else 
            { 
                val1 = Convert.ToInt32(txtcoverall.Text);
            }

            if(txtfaceshield.Text == "")
            {
                val2 = faceshield;
            }
            else
            {
                val2 = Convert.ToInt32(txtfaceshield.Text);
            }
 
            if(txtgoggles.Text == "")
            {
                val3 = goggles;
            }
            else
            {
                val3 = Convert.ToInt32(txtgoggles.Text);
            }

            if(txtgown.Text == "")
            {
                val4 = gown;
            }
            else
            {
                val4 = Convert.ToInt32(txtgown.Text);
            }
            if (txtN95.Text == "")
            {
                val5 = N95;
            }
            else
            {
                val5 = Convert.ToInt32(txtN95.Text);
            }
            if (txtShoeCover.Text == "")
            {
                val6 = shoecover;
            }
            else
            {
                val6 = Convert.ToInt32(txtShoeCover.Text);
            }
            if (txtHeadCover.Text == "")
            {
                val7 = headcover;
            }
            else
            {
                val7 = Convert.ToInt32(txtHeadCover.Text);
            }
            if (txtSurgicalMask.Text == "")
            {
               val8 = surgicalmask;
            }
            else
            {
                val8 = Convert.ToInt32(txtSurgicalMask.Text);
            }

            //Write to csv text file
            StreamWriter sw = new StreamWriter("D://PPE.txt", false);
            string strtowrite = "";
            strtowrite = val1 + "," + val2 + "," + val3 + "," + val4 + "," + val5 + "," + val6 + "," + val7 + "," + val8;
            sw.Write(strtowrite.ToString());
            sw.Write(sw.NewLine);
            sw.Close();

            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("JeonLana", "lana0316");
            client.UploadFile("ftp://66.220.9.50/My Documents/PPE.txt", "D://PPE.txt");

            //Clear text boxes
            txtcoverall.Text = "";
            txtfaceshield.Text = "";
            txtgown.Text = "";
            txtgoggles.Text = "";
            txtN95.Text = "";
            txtHeadCover.Text = "";
            txtShoeCover.Text = "";
            txtSurgicalMask.Text = "";
            //Initialize current value
            coverall = val1;
            faceshield = val2;
            goggles = val3;
            gown = val4;
            N95 = val5;
            shoecover = val6;
            headcover = val7;
            surgicalmask = val8;

            //Display value to chart
            chart2.Series["Personal Protective Equipment"].Points.Clear();
            chart2.Series["Personal Protective Equipment"].Points.AddXY("Coverall", val1);
            chart2.Series["Personal Protective Equipment"].Points.AddXY("Face Shield", val2);
            chart2.Series["Personal Protective Equipment"].Points.AddXY("Goggles", val3);
            chart2.Series["Personal Protective Equipment"].Points.AddXY("Gown", val4);
            chart2.Series["Personal Protective Equipment"].Points.AddXY("N95", val5);
            chart2.Series["Personal Protective Equipment"].Points.AddXY("Shoe Cover", val6);
            chart2.Series["Personal Protective Equipment"].Points.AddXY("Head Cover", val7);
            chart2.Series["Personal Protective Equipment"].Points.AddXY("Surgical Mask", val8);
            
            MessageBox.Show("Saved!!!");

        }

        
        //filter out specific "province" in chart
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreamReader equipments = new StreamReader("D://Equipments.txt");
            string tofind = "";
            if (comboBox1.Text != "")
            {
                tofind = comboBox1.Text;
                while (equipments.Peek() != -1)
                {
                    string x = equipments.ReadLine();
                    string[] xe = x.Split(',');
                    ListViewItem lvi = new ListViewItem(xe[0]);


                    lvi.SubItems.Add(xe[1]);
                    lvi.SubItems.Add(xe[2]);
                    lvi.SubItems.Add(xe[3]);
                    lvi.SubItems.Add(xe[4]);
                    lvi.SubItems.Add(xe[5]);
                    lvi.SubItems.Add(xe[6]);
                    lvi.SubItems.Add(xe[7]);
                    lvi.SubItems.Add(xe[8]);
                    listView2.Items.Add(lvi);
                    if (xe[0] == tofind)
                    {
                        chart1.Series["Total"].Points.Clear();
                        chart1.Series["Occupied"].Points.Clear();
                        chart1.Series["Total"].Points.AddXY("ICU Beds", xe[1]);
                        chart1.Series["Occupied"].Points.AddXY("ICU Beds", xe[2]);
                        chart1.Series["Total"].Points.AddXY("Isolation Beds", xe[3]);
                        chart1.Series["Occupied"].Points.AddXY("Isolation beds", xe[4]);
                        chart1.Series["Total"].Points.AddXY("Ward Beds", xe[5]);
                        chart1.Series["Occupied"].Points.AddXY("Ward Beds", xe[6]);
                        chart1.Series["Total"].Points.AddXY("Mechanical Ventilators", xe[7]);
                        chart1.Series["Occupied"].Points.AddXY("Mechanical Ventilators", xe[8]);
                    }

                }
                equipments.Close();

            }
        }

        //saving new equipments data
        private void btnSave2_Click(object sender, EventArgs e)
        {
           //save to listview function
            savetolvi();

            StreamWriter sw = new StreamWriter("D://Equipments.txt", false);

            foreach (ListViewItem itemRow in listView2.Items)
            {
                for (int i = 0; i < itemRow.SubItems.Count; i++)
                {
                    sw.Write(itemRow.SubItems[i].Text);

                    if (i < listView2.Columns.Count - 1)
                    {
                        sw.Write(",");

                    }

                }
                sw.Write(sw.NewLine);

            }
            sw.Close();

            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("JeonLana", "lana0316");
            client.UploadFile("ftp://66.220.9.50/My Documents/Equipments.txt", "D://Equipments.txt");

            //Clear textbox inputs
            txticubeds.Text = "";
            txtisolationbeds.Text = "";
            txtwardbeds.Text = "";
            txtmechanicalventilators.Text = "";
               
            MessageBox.Show("Saved!!!");

            //Load chart with current combo text box selection
            StreamReader equipments = new StreamReader("D://Equipments.txt", false);
            while (equipments.Peek() != -1)
            {
                string x = equipments.ReadLine();
                string[] xe = x.Split(',');
                ListViewItem lvi = new ListViewItem(xe[0]);


                lvi.SubItems.Add(xe[1]);
                lvi.SubItems.Add(xe[2]);
                lvi.SubItems.Add(xe[3]);
                lvi.SubItems.Add(xe[4]);
                lvi.SubItems.Add(xe[5]);
                lvi.SubItems.Add(xe[6]);
                lvi.SubItems.Add(xe[7]);
                lvi.SubItems.Add(xe[8]);
                listView2.Items.Add(lvi);
                if (xe[0] == comboBox1.Text)
                {
                    chart1.Series["Total"].Points.Clear();
                    chart1.Series["Occupied"].Points.Clear();

                    chart1.Series["Total"].Points.AddXY("ICU Beds", xe[1]);
                    chart1.Series["Occupied"].Points.AddXY("ICU Beds", xe[2]);
                    chart1.Series["Total"].Points.AddXY("Isolation Beds", xe[3]);
                    chart1.Series["Occupied"].Points.AddXY("Isolation beds", xe[4]);
                    chart1.Series["Total"].Points.AddXY("Ward Beds", xe[5]);
                    chart1.Series["Occupied"].Points.AddXY("Ward Beds", xe[6]);
                    chart1.Series["Total"].Points.AddXY("Mechanical Ventilators", xe[7]);
                    chart1.Series["Occupied"].Points.AddXY("Mechanical Ventilators", xe[8]);
                }

            }
            equipments.Close();

        }

        //para isang tawagan na lang
        private void savetolvi()
        {
            //Validation for text box it should accept numeric only

            StreamReader equipments = new StreamReader("D://Equipments.txt");

            listView2.Items.Clear();


            string tofind = comboBox1.Text;


            while (equipments.Peek() != -1)
            {
                string x = equipments.ReadLine();

                string[] xe = x.Split(',');
                ListViewItem lvi = new ListViewItem(xe[0]);
                lvi.SubItems.Add(xe[1]);
                if (xe[0] == tofind)
                {

                    
                    if (txticubeds.Text == "")
                    {
                        lvi.SubItems.Add(xe[2]);
                    }
                    else
                    {
                        lvi.SubItems.Add(txticubeds.Text); //data from icu beds
                    }
                    lvi.SubItems.Add(xe[3]);
                    if (txtisolationbeds.Text == "")
                    {
                        lvi.SubItems.Add(xe[4]);
                    }
                    else
                    {
                        lvi.SubItems.Add(txtisolationbeds.Text); //data from isolation beds
                    }
                    lvi.SubItems.Add(xe[5]);
                    if (txtwardbeds.Text == "")
                    {
                        lvi.SubItems.Add(xe[6]);
                    }
                    else
                    {
                        lvi.SubItems.Add(txtwardbeds.Text); //data from ward beds

                    }
                    lvi.SubItems.Add(xe[7]);
                    if (txtmechanicalventilators.Text == "")
                    {
                        lvi.SubItems.Add(xe[8]);
                    }
                    else
                    {
                        lvi.SubItems.Add(txtmechanicalventilators.Text); //data from mechanical ventilators
                    }

                }
                else
                {
                    lvi.SubItems.Add(xe[2]);
                    lvi.SubItems.Add(xe[3]);
                    lvi.SubItems.Add(xe[4]);
                    lvi.SubItems.Add(xe[5]);
                    lvi.SubItems.Add(xe[6]);
                    lvi.SubItems.Add(xe[7]);
                    lvi.SubItems.Add(xe[8]);

                }

                listView2.Items.Add(lvi);
            }
            equipments.Close();

            //Clean up Input box
            txticubeds.Text = "";
            txtisolationbeds.Text = "";
            txtwardbeds.Text = "";
            txtmechanicalventilators.Text = "";

        }

        //shows and hide data or chart
        private void btnView_Click(object sender, EventArgs e)
        {
            if (btnView.Text == "View Data")
            {
                chart1.Visible = false;
                listView2.Visible = true;
                listViewPanel.Visible = true;
                btnView.Text = "View Chart";
            }
            else if (btnView.Text == "View Chart")
            {
                chart1.Visible = true;
                listView2.Visible = false;
                listViewPanel.Visible = false;
                btnView.Text = "View Data";
            }
            

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
    }
}