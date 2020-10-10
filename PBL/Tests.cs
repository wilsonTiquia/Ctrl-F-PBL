using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
namespace PBL
{
   
    public partial class Tests : Form
    {
        List<string> allHospitalList = new List<string>();
        bool didNotOpenFile = true;
        string location = "";
        string locationOfTest = "";

        List<string> openedFileHospitalList = new List<string>();


        public Tests()
        {
            InitializeComponent();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void map_Click(object sender, EventArgs e)
        {
            Mapa_ni_Tiquia mapForm = new Mapa_ni_Tiquia();
            mapForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cases casesForm = new Cases();
            casesForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Tests testsForm = new Tests();
            testsForm.Show();
        }

        private void equipments_Click(object sender, EventArgs e)
        {
            Equipments equipmentsForms = new Equipments();
            equipmentsForms.Show();
        }

    
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
            TopMost = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Width = 550;
            this.Height = 370;
            pictureBox6.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Width = 1290;
            this.Height = 770;
            pictureBox6.Visible = true;
            pictureBox4.Visible = false;
        }

        private void extend1_Click_1(object sender, EventArgs e)
        {
            panel16.Visible = true;
            map.Visible = true;
            casess.Visible = true;
            pictureBox3.Visible = true;
            pictureBox2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            extend2.Visible = true;
            extend1.Visible = false;
        }

        private void extend2_Click_1(object sender, EventArgs e)
        {
            panel16.Visible = false;
            map.Visible = false;
            casess.Visible = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            extend2.Visible = false;
            extend1.Visible = true;
        }
        private void map_Click_1(object sender, EventArgs e)
        {
            Mapa_ni_Tiquia mapForm = new Mapa_ni_Tiquia();
            mapForm.Show();
        }

        private void casess_Click(object sender, EventArgs e)
        {
            Cases casesForm = new Cases();
            casesForm.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Tests testsForm = new Tests();
            testsForm.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Equipments equipmentsForm = new Equipments();
            equipmentsForm.Show();
        }

    

        private void openAdd_Click(object sender, EventArgs e)
        {
            cumulativePanel.Visible = true;
            hospitalLabel.Visible = true;
            hospitalPanel.Visible = true;
            hospitalComboBox.Visible = true;
            uniqueLabel.Visible = true;
            uniquePanel.Visible = true;
            uniqueTextBox.Visible = true;
            positiveLabel.Visible = true;
            positivePanel.Visible = true;
            positiveTextBox.Visible = true;
            negativeLabel.Visible = true;
            negativePanel.Visible = true;
            negativeTextBox.Visible = true;
            equivocalLabel.Visible = true;
            equivocalPanel.Visible = true;
            equivocalTextBox.Visible = true;
            invalidLabel.Visible = true;
            invalidPanel.Visible = true;
            invalidTextBox.Visible = true;
            totalLabel.Visible = true;
            totalPanel.Visible = true;
            totalTextBox.Visible = true;
            remainingLabel.Visible = true;
            remainingPanel.Visible = true;
            remainingTextBox.Visible = true;
            openAdd.Visible = false;
            closeAdd.Visible = true;
            saveButton.Visible = true;
            openFile.Visible = true;
            uploadToCloud.Visible = true;
        }
        public void clearEntries()
        {
            // clear laman
            hospitalComboBox.Text = string.Empty;
            uniqueTextBox.Text = string.Empty;
            positiveTextBox.Text = string.Empty;
            negativeTextBox.Text = string.Empty;
            equivocalTextBox.Text = string.Empty;
            invalidTextBox.Text = string.Empty;
            totalTextBox.Text = string.Empty;
            remainingTextBox.Text = string.Empty;
        }
        private void closeAdd_Click(object sender, EventArgs e)
        {
            clearEntries();
            cumulativePanel.Visible = false;
            hospitalLabel.Visible = false;
            hospitalPanel.Visible = false;
            hospitalComboBox.Visible = false;
            uniqueLabel.Visible = false;
            uniquePanel.Visible = false;
            uniqueTextBox.Visible = false;
            positiveLabel.Visible = false;
            positivePanel.Visible = false;
            positiveTextBox.Visible = false;
            negativeLabel.Visible = false;
            negativePanel.Visible = false;
            negativeTextBox.Visible = false;
            equivocalLabel.Visible = false;
            equivocalPanel.Visible = false;
            equivocalTextBox.Visible = false;
            invalidLabel.Visible = false;
            invalidPanel.Visible = false;
            invalidTextBox.Visible = false;
            totalLabel.Visible = false;
            totalPanel.Visible = false;
            totalTextBox.Visible = false;
            remainingLabel.Visible = false;
            remainingPanel.Visible = false;
            remainingTextBox.Visible = false;
            openAdd.Visible = true;
            closeAdd.Visible = false;
            saveButton.Visible = false;
            openFile.Visible = false;
            uploadToCloud.Visible = false;
            uploadSelected.Visible = false;
            hospitalComboBox.SelectedIndex = -1;
            
        }

        private void openTest_Click(object sender, EventArgs e)
        {
            clearEntries();
            testPanel.Visible = true;
            hospitalLabel.Visible = true;
            hospitalComboBox.Visible = true;
            hospitalPanel.Visible = true;
            dateLabel.Visible = true;
            dateTimePicker1.Visible = true;
            datePanel.Visible = true;
            conductedLabel.Visible = true;
            conductedPanel.Visible = true;
            conductedTextBox.Visible = true;
            openTest.Visible = false;
            closeTest.Visible = true;
            openFileTestConducted.Visible = true;
          
        }

        private void closeTest_Click(object sender, EventArgs e)
        {
            testPanel.Visible = false;
            hospitalLabel.Visible = false;
            hospitalComboBox.Visible = false;
            hospitalPanel.Visible = false;
            dateLabel.Visible = false;
            dateTimePicker1.Visible = false;
            datePanel.Visible = false;
            conductedLabel.Visible = false;
            conductedPanel.Visible = false;
            conductedTextBox.Visible = false;
            openTest.Visible = true;
            closeTest.Visible = false;
            openFileTestConducted.Visible = false;
            
        }

        public void sortUserSelectedHospital(string hospital)
        {
            if (!didNotOpenFile)
            {
                StreamReader read = new StreamReader($@"{location}");
               
                while (read.Peek() != -1)
                {
                    string reads = read.ReadLine();
                    string[] splitReads = reads.Split(',');

                    if (hospital == splitReads[0])
                    {
                        ListViewItem lvi = new ListViewItem(hospital);
                        lvi.SubItems.Add(splitReads[1]);
                        lvi.SubItems.Add(splitReads[2]);
                        lvi.SubItems.Add(splitReads[3]);
                        lvi.SubItems.Add(splitReads[4]);
                        lvi.SubItems.Add(splitReads[5]);
                        lvi.SubItems.Add(splitReads[6]);
                        lvi.SubItems.Add(splitReads[7]);
                        listView1.Items.Add(lvi);
                    }

                }
                read.Close();
            }
          


           
        }

        private void hospitalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = hospitalComboBox.GetItemText(hospitalComboBox.SelectedItem);
            string hosp = hospitalComboBox.Text;
            listView1.Items.Clear();
            if (hosp != string.Empty && hospitalComboBox.SelectedIndex != -1) 
            {
                sortUserSelectedHospital(selected);
            }
            else
            {
                showAllHospitals(hosp);
            }

        }
        // add and show hospitals
        public void showAllHospitals(string hospitalAdd)
        {
            if (!didNotOpenFile)
            {
                listView1.Items.Clear();
                StreamReader read = new StreamReader($@"{location}");
                read.ReadLine();
                while (read.Peek() != -1)
                {
                    string reads = read.ReadLine();
                    string[] splitRead = reads.Split(',');

                    ListViewItem lvi = new ListViewItem(splitRead[0]);
                    lvi.SubItems.Add(splitRead[1]);
                    lvi.SubItems.Add(splitRead[2]);
                    lvi.SubItems.Add(splitRead[3]);
                    lvi.SubItems.Add(splitRead[4]);
                    lvi.SubItems.Add(splitRead[5]);
                    lvi.SubItems.Add(splitRead[6]);
                    lvi.SubItems.Add(splitRead[7]);
                    listView1.Items.Add(lvi);
                }
            }
        }
        public void openedFileCheckIfHospitalRepeated(string hospitalSelected)
        {
            StreamReader readFiles = new StreamReader($@"{location}");
            string empty = "0";
            // condition if empty laman
            if (uniqueTextBox.Text == string.Empty) uniqueTextBox.Text = empty;
            if (positiveTextBox.Text == string.Empty) positiveTextBox.Text = empty;
            if (negativeTextBox.Text == string.Empty) negativeTextBox.Text = empty;
            if (equivocalTextBox.Text == string.Empty) equivocalTextBox.Text = empty;
            if (invalidTextBox.Text == string.Empty) invalidTextBox.Text = empty;
            if (totalTextBox.Text == string.Empty) totalTextBox.Text = empty;
            if (remainingTextBox.Text == string.Empty) remainingTextBox.Text = empty;
            string uniqueStr = "";
            string positiveStr = "";
            string negativeStr = "";
            string equivocalStr = "";
            string invalidStr = "";
            string totalStr = "";
            string remainingStr = "";            
            while (readFiles.Peek()!=-1)
            {
                string datas = readFiles.ReadLine();
                string[] token = datas.Split(',');
                string nameOfHospital = token[0];
                if (nameOfHospital == hospitalSelected)
                {
                    // basahin mo luma store mo dito
                    int uniqueInt = int.Parse(token[1]);
                    int positiveInt = int.Parse(token[2]);
                    int negativeInt = int.Parse(token[3]);
                    int equivocalInt = int.Parse(token[4]);
                    int invalidInt = int.Parse(token[5]);
                    int totalInt = int.Parse(token[6]);
                    int remainingInt = int.Parse(token[7]);
                    // add mo sya sa bago nilagay
                    uniqueInt += int.Parse(uniqueTextBox.Text);
                    positiveInt += int.Parse(positiveTextBox.Text);
                    negativeInt += int.Parse(negativeTextBox.Text);
                    equivocalInt += int.Parse(equivocalTextBox.Text);
                    invalidInt += int.Parse(invalidTextBox.Text);
                    totalInt += int.Parse(totalTextBox.Text);
                    remainingInt += int.Parse(remainingTextBox.Text);
                    listView1.Items.Clear();
                    // convert sa string
                    uniqueStr = uniqueInt.ToString();
                    positiveStr = positiveInt.ToString();
                    negativeStr = negativeInt.ToString();
                    equivocalStr = equivocalInt.ToString();
                    invalidStr = invalidInt.ToString();
                    totalStr = totalInt.ToString();
                    remainingStr = remainingInt.ToString();
                    //
                   
                    //
                    ListViewItem lvi = new ListViewItem(nameOfHospital);
                    lvi.SubItems.Add(uniqueStr);
                    lvi.SubItems.Add(positiveStr);
                    lvi.SubItems.Add(negativeStr);
                    lvi.SubItems.Add(equivocalStr);
                    lvi.SubItems.Add(invalidStr);
                    lvi.SubItems.Add(totalStr);
                    lvi.SubItems.Add(remainingStr);
                    listView1.Items.Add(lvi);
                }
            }
            readFiles.Close();
            // sulat mo sya
            StreamWriter write = new StreamWriter($@"{location}", true);
            write.WriteLine();
            write.Write($"{hospitalSelected},{uniqueStr},{positiveStr},{negativeStr},{equivocalStr},{invalidStr},{totalStr},{remainingStr}");
            write.Close();



        }
       
        private void Tests_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            string empty = "RESEARCH INSTITUTE FOR TROPICAL MEDICINE (RITM)";
            showAllHospitals(empty);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd yyyy";




        }
        private void aboutUs_Click(object sender, EventArgs e)
        {
            SplashScreen aboutForm = new SplashScreen();
            aboutForm.Show();
        }

        
        private void hospitalComboBox_DropDown(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string empty = "RESEARCH INSTITUTE FOR TROPICAL MEDICINE (RITM)";
            showAllHospitals(empty);
           
           
        }

        private void mapShadow_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (didNotOpenFile)
            {
                // write mo 
                StreamWriter write = new StreamWriter(@"C:/NewCumulativeTest.txt",true);
                string empty = "0";
                string selectedHospital = hospitalComboBox.Text;
                // condition if empty laman
                if (uniqueTextBox.Text == string.Empty) uniqueTextBox.Text = empty;
                if (positiveTextBox.Text == string.Empty) positiveTextBox.Text = empty;
                if (negativeTextBox.Text == string.Empty) negativeTextBox.Text = empty;
                if (equivocalTextBox.Text == string.Empty) equivocalTextBox.Text = empty;
                if (invalidTextBox.Text == string.Empty) invalidTextBox.Text = empty;
                if (totalTextBox.Text == string.Empty) totalTextBox.Text = empty;
                if (remainingTextBox.Text == string.Empty) remainingTextBox.Text = empty;
                
                string[] all =
                {
                    selectedHospital,",",uniqueTextBox.Text,",",positiveTextBox.Text,",",negativeTextBox.Text,",",
                    equivocalTextBox.Text,",",invalidTextBox.Text,",",totalTextBox.Text,",",remainingTextBox.Text
                };
                for (int i =0;i<all.Length;i++)
                {
                    write.Write(all[i]);
                }
                write.WriteLine();
                write.Close();
                // add mo sa listview
                ListViewItem lvi = new ListViewItem(selectedHospital);
                lvi.SubItems.Add(uniqueTextBox.Text);
                lvi.SubItems.Add(positiveTextBox.Text);
                lvi.SubItems.Add(negativeTextBox.Text);
                lvi.SubItems.Add(equivocalTextBox.Text);
                lvi.SubItems.Add(invalidTextBox.Text);
                lvi.SubItems.Add(totalTextBox.Text);
                lvi.SubItems.Add(remainingTextBox.Text);
                listView1.Items.Add(lvi);
                clearEntries();

                


            }
            if (!didNotOpenFile)
            {
                DateTime today =  DateTime.Now;
                string selectedHospital = hospitalComboBox.Text;
                openedFileCheckIfHospitalRepeated(selectedHospital);
                clearEntries();
                listView1.Items.Clear();
                showAllHospitals(selectedHospital);
       
                MessageBox.Show("SAVED!!!");


               
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            uploadToCloud.Visible = false;
            uploadSelected.Visible = true;
            DialogResult responseDialogResult;
            responseDialogResult = openFileDialog1.ShowDialog();
            if (responseDialogResult != DialogResult.Cancel)
            {
                StreamReader hospitalDetails = new StreamReader(openFileDialog1.FileName);
                location= openFileDialog1.FileName;
                hospitalDetails.ReadLine();
                bool pwedeIRead = true;
                while (pwedeIRead)
                {
                    if (hospitalDetails.Peek()!=-1)
                    {
                        // read the csv
                        string details = hospitalDetails.ReadLine();
                        string[] splittedDetails = details.Split(',');
                        string nameOfHospital = splittedDetails[0];
                        string unique = splittedDetails[1];
                        string positive = splittedDetails[2];
                        string negative = splittedDetails[3];
                        string equivocal = splittedDetails[4];
                        string invalid = splittedDetails[5];
                        string total = splittedDetails[6];
                        string remaining = splittedDetails[7];

                        // populate listbox
                        ListViewItem hospital = new ListViewItem(nameOfHospital);
                        hospital.SubItems.Add(unique);
                        hospital.SubItems.Add(positive);
                        hospital.SubItems.Add(negative);
                        hospital.SubItems.Add(equivocal);
                        hospital.SubItems.Add(invalid);
                        hospital.SubItems.Add(total);
                        hospital.SubItems.Add(remaining);
                        listView1.Items.Add(hospital);
                        didNotOpenFile = false;
                        // populate the combobox
                        hospitalComboBox.Items.Add(nameOfHospital);
                        openedFileHospitalList.Add(nameOfHospital);
                       
                    }
                    if (hospitalDetails.Peek() == -1)
                    {
                        pwedeIRead = false;
                    }
                    
                }
                hospitalDetails.Close();
            }
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            dailyTestChart.Series.Add("Date");
            if (radioButton1.Checked)
            {
                dailyTestChart.ChartAreas[0].AxisX.Interval = 1;
            }
            if (radioButton2.Checked)
            {
                dailyTestChart.ChartAreas[0].AxisX.Interval = 1;
                dailyTestChart.Series["Date"].IsValueShownAsLabel = true;
            }
            if (radioButton3.Checked)
            {
                dailyTestChart.ChartAreas[0].AxisX.Interval = 0;
                dailyTestChart.Series["Date"].IsValueShownAsLabel = true;


            }


            string selectedDate = dateTimePicker1.Value.ToString("MMMM dd yyyy").ToUpper();
            string selectedHospital = comboBox2.Text.ToUpper();
            StreamReader read = new StreamReader($@"{locationOfTest}");
            while (read.Peek() != -1)
            {
                string x = read.ReadLine();
                string[] xe = x.Split(',');
                if (xe[0] == selectedHospital)
                {
                    string date = xe[1];
                    
                    string cases2 = xe[2];
                    Console.WriteLine(cases2);
                    dailyTestChart.Series["Date"].Points.AddXY(date, cases2);
                    dailyTestLabel.Text = "DAILY TESTS: " + selectedHospital;
                }
            }
            read.Close();
           
        }

        private void conductedTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void conductedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("MMMM dd yyyy").ToUpper(); 
            string selectedHospital = comboBox2.Text.ToUpper();
            string caseAdd = conductedTextBox.Text;
            if (e.KeyCode == Keys.Enter && conductedTextBox.Text != string.Empty)
            {
                dailyTestChart.Series.Clear();
                dailyTestChart.Series.Add("Date");
                StreamWriter write = new StreamWriter($@"{locationOfTest}",true);
                write.WriteLine(selectedHospital + "," + selectedDate + "," + caseAdd);
                write.Close();
                StreamReader read = new StreamReader($@"{locationOfTest}");
                while (read.Peek() != -1)
                {
                    //dailyTestChart.Series.Add("Date");
                    string x = read.ReadLine();
                    string[] xe = x.Split(',');
                    if (xe[0] == selectedHospital)
                    {
                       
                        string date = xe[1];
                        string cases2 = xe[2];
                        dailyTestChart.Series["Date"].Points.AddXY(date, cases2);
                        dailyTestLabel.Text = "DAILY TESTS: " + selectedHospital;
                        if (radioButton1.Checked)
                        {
                            dailyTestChart.ChartAreas[0].AxisX.Interval = 1;
                        }
                        if (radioButton2.Checked)
                        {
                            dailyTestChart.ChartAreas[0].AxisX.Interval = 1;
                            dailyTestChart.Series["Date"].IsValueShownAsLabel = true;
                        }
                        if (radioButton3.Checked)
                        {
                            dailyTestChart.ChartAreas[0].AxisX.Interval = 0;
                            dailyTestChart.Series["Date"].IsValueShownAsLabel = false;


                        }
                    }
                }
                conductedTextBox.Text = string.Empty;
            }
        }
        
        private void openFileTestConducted_Click(object sender, EventArgs e)
        {
            hospitalComboBox.Items.Clear();
            DialogResult response;
            response = openFileDialog2.ShowDialog();
            if (response != DialogResult.Cancel)
            {

                StreamReader read = new StreamReader(openFileDialog2.FileName);
                locationOfTest = openFileDialog2.FileName;
                bool pwedeIRead = true;
                List<string> test = new List<string>();
                read.ReadLine();
                while (pwedeIRead)
                {
                    if (read.Peek()!=-1)
                    {
                        string testConducted = read.ReadLine();
                        string[] splitTest = testConducted.Split(',');
                        test.Add(splitTest[0]);
                    }
                    if (read.Peek() == -1)
                    {
                        pwedeIRead = false;
                    }
                }
                List<string> noDupiclate = test.Distinct().ToList();
                foreach(string a in noDupiclate)
                {
                    comboBox2.Items.Add(a);
                }
                read.Close();

            }

        }

        private void uploadToCloud_Click(object sender, EventArgs e)
        {
            clearEntries();
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("JeonLana", "lana0316");
            client.UploadFile("ftp://66.220.9.50/My Documents/NewTestCase.txt", "C://NewCumulativeTest.txt");
            MessageBox.Show("Uploaded to Cloud Server");
        }

        private void uploadSelected_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("JeonLana", "lana0316");
            client.UploadFile("ftp://66.220.9.50/My Documents/Selected Case.txt", $"{location}");
            MessageBox.Show("Uploaded to Cloud Server");
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            dailyTestChart.Series.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Text = string.Empty;
            dailyTestChart.Series.Clear();


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Text = string.Empty;
            dailyTestChart.Series.Clear();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Text = string.Empty;
            dailyTestChart.Series.Clear();

        }
    }
}

   
       