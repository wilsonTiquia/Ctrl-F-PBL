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
    public partial class Mapa_ni_Tiquia : Form
    {
        string[] islandList = { "Luzon", "Visayas", "Mindanao" };
        string[] ncrCity =
        {
            "Caloocan City", "Las Pinas City", "Makati City", "Malabon City", "Mandaluyong City", "Manila City", "Marikina City",
            "Muntinlupa City", "Navotas City", "Paranaque City", "Pasay City", "Pasig City", "Quezon City", "San Juan City", "Taguig City", "Valenzuela City"
        };

        //16 //38
        string[,] luzonRegionOneToEight =
        {
            // nag multi dimensional array ako
            {"Region I", "Region II", "Region III", "Region IV-A", "Region IV-B", "Region V", "Cordillera Administrative Region" , "NCR"},
            {"Ilocos Norte", "Ilocos Sur", "La Union", "Pangasinan", "","","",""},                     // ilocos region or region 1
            {"Batanes", "Cagayan", "Isabela", "Nueva Vizcaya", "Quirino","","",""},           //  region 2 or Cagayan Valley
            {"Aurora", "Bataan", "Bulacan", "Nueva Ecija", "Pampanga", "Tarlac", "Zambales",""},       //region3 or Central Luzon
            {"Cavite", "Laguna","Batangas","Rizal", "Quezon","","",""},                                // region 4 a calabarzon 
            {"Occidental Mindoro", "Oriental Mindoro", "Marinduque", "Romblon", "Palawan", "","",""},  //region 4b mimaropa
            {"Albay", "Camarines Norte", "Camarines Sur", "Sorsogon","Catanduanes", "Masbate", "",""},    //region 5
            {"Abra", "Benguet", "Ifugao", "Kalinga", "Apayao", "Mountain Province", "",""},    //cordilierra administrative region
        };
        //54
        string[,] visayasRegionSixToEight =
        {
            {"Region VI", "Region VII", "Region VIII", "", "", ""},
            {"Aklan", "Antique", "Capiz", "Guimaras", "Iloilo", "Negros Occidental" },  // western visayas Regionn 6
            {"Cebu", "Bohol", "Negros Oriental", "Siquijor", "", "" }, // central visayas region 7
            {"Leyte", "Biliran", "Southern Leyte", "Samar", "Eastern Samar", "Northern Samar"  }, // eastern visayas
        };
        // 80
        string[,] mindanaoRegions =
        {
            {"Region IX", "Region X", "Region XI", "Region XII","Region XIII", "BARMM","" },
            {"Zamboanga del Norte", "Zamboanga del Sur", "Zamboanga Sibugay", "", "", "" ,""}, //Zamboanga Peninsula Region 9
            {"Misamis Oriental", "Misamis Occidental", "Bukidnon", "Camiguin", "Lanao del Norte", "","" },         // region 10 northern mindanao
            {"Davao de Oro", "Davao del Norte", "Davao del Sur", "Davao Oriental", "Davao Occidental","",""},      // region 11 southern mindanao dabao region
            {"South Cotabato", "Cotabato", "Sultan Kudarat", "Sarangani", "", "","" },         //central mindanao sooccsargen 12
            {"Agusan del Norte", "Agusan del Sur", "Surigao del Norte", "Surigao del Sur", "Dinagat Islands", "","" }, // region 13 caraga
            {"Lanao del Sur", "Maguindanao", "Sulu", "Tawi-tawi", "", "",""},                  // BARMM
        };

        List<string> provinceAndCase = new List<string>();
        
        string temporary = "";
        int totalCASE = 0;
        public int totalAddedCase()
        {
            int total = 0;
            StreamReader readTotal = new StreamReader(@"C:\Total-Cases.txt");
            while (readTotal.Peek()!=-1)
            {

                string input = readTotal.ReadLine();
                string[] splitted = input.Split(',');
                string a = splitted[2].Replace("TOTAL_CASES", "0");
                total += int.Parse(a);
              

            }
            return total;
           

        }
      
        public void getTotalCase(string province, int sum)
         {
            StreamReader read = new StreamReader(@"C:\Total-Cases.txt");
            while (read.Peek ()!=-1)
            {
                
                string input = read.ReadLine();
                string[] splitInput = input.Split(',');
                string newSplit = splitInput[1].Replace("CITY OF ", "").Replace(" CITY", "").ToLower();
                temporary = provinceMapComboBox.Text.ToLower().Replace(" city","");
                string caseSplitNew = splitInput[2].Replace(",", "");
                if (temporary != newSplit)
                {
                    Console.WriteLine(temporary + "         " + newSplit);
                    tCase.Text = "Total Case: " + sum.ToString();
                }
                if (temporary == newSplit)
                {
                    sum += int.Parse(caseSplitNew);
                    tCase.Text = "Total Case: " + sum.ToString();
                }
                provinceAndCase.Add(newSplit + "*"+caseSplitNew);
                // conditions
                string selectedPlace = provinceMapComboBox.Text.ToLower();
                string caseSaLugar = "0";
                provincePicture.SizeMode = PictureBoxSizeMode.StretchImage;
                //
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = Path.Combine(projectPath, "Resources");
              

                if (sum >= 0 && sum <= 500)
                {
                    caseSaLugar = "0";
                    provincePicture.Image = Image.FromFile($@"{filePath}\{selectedPlace}{caseSaLugar}.png");
                }
                if (sum > 500 && sum <= 1000)
                {
                    caseSaLugar = "501";
                    provincePicture.Image = Image.FromFile($@"{filePath}\{selectedPlace}{caseSaLugar}.png");
                }
                if (sum >1000 && sum <= 2000)
                {
                    caseSaLugar = "1k";
                    provincePicture.Image = Image.FromFile($@"{filePath}\{selectedPlace}{caseSaLugar}.png");
                }
                if (sum > 2000 )
                {
                    caseSaLugar = "2k";
                    provincePicture.Image = Image.FromFile($@"{filePath}\{selectedPlace}{caseSaLugar}.png");
                }
            }
            read.Close();
   
        }
        public Mapa_ni_Tiquia()
        {
            InitializeComponent();
        }
        public void emptyRegionProvince()
        {
            provinceMapComboBox.SelectedIndex = -1;
            regionMapComboBox.SelectedIndex = -1;
        }
        public void showMap()
        {
            // hide
            islandLabel.Visible = false;
            islandComboBox.Visible = false;
            islandPanel.Visible = false;
            regionLabel.Visible = false;
            regionComboBox.Visible = false;
            region1Panel.Visible = false;
            provinceLabel.Visible = false;
            provinceComboBox.Visible = false;
            province1Panel.Visible = false;
            cases.Visible = false;
            caseInputTextBox.Visible = false;
            casesPanel.Visible = false;
            // clear laman
            islandComboBox.Text = regionComboBox.Text = provinceComboBox.Text = caseInputTextBox.Text = string.Empty;
            // visible na ngyon yung second
            regionMap.Visible = true;
            regionMapComboBox.Visible = true;
            regionPanel.Visible = true;
            provinceMap.Visible = true;
            provinceMapComboBox.Visible = true;
            provincePanel.Visible = true;
            currentIsland.Visible = true;
            panelOfImage.Visible = true;
            mapShadow.Visible = true;
            backMap.Visible = true;
            
        }
        public void hideMap ()
        {
            regionMap.Visible = false;
            regionMapComboBox.Visible = false;
            regionPanel.Visible = false;
            provinceMapComboBox.Visible = false;
            provinceMap.Visible = false;
            provincePanel.Visible = false;
            currentIsland.Visible = false;
            panelOfImage.Visible = false;
            mapShadow.Visible = false;
            backMap.Visible = false;
            // vvisible mo ung orig
            islandLabel.Visible = true;
            islandComboBox.Visible = true;
            islandPanel.Visible = true;
            regionLabel.Visible = true;
            regionComboBox.Visible = true;
            region1Panel.Visible = true;
            provinceLabel.Visible = true;
            provinceComboBox.Visible = true;
            province1Panel.Visible = true;
            cases.Visible = true;
            casesPanel.Visible = true;
            caseInputTextBox.Visible = true;
        }
        public void populateIsland()
        {
            for (int i = 0; i < islandList.Length;i++)
            {
                islandComboBox.Items.Add(islandList[i]);
            }
        }
        // lagyan mo laman regions
        public void populateRegions(string island)
        {
            int dimension = 0;
            if (island == "Luzon")
            {
                regionComboBox.Items.Clear();
                regionMapComboBox.Items.Clear();
                dimension = luzonRegionOneToEight.GetLength(0);
                for (int i = 0; i <dimension;i++)
                {
                    if (luzonRegionOneToEight[0,i] != string.Empty)
                    {
                        regionComboBox.Items.Add(luzonRegionOneToEight[0, i]);
                        regionMapComboBox.Items.Add(luzonRegionOneToEight[0, i]);
                    }
                }

            }
            if (island == "Visayas")
            {
                regionComboBox.Items.Clear();
                regionMapComboBox.Items.Clear();
                dimension = visayasRegionSixToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (visayasRegionSixToEight[0, i] != string.Empty)
                    {
                        regionComboBox.Items.Add(visayasRegionSixToEight[0, i]);
                        regionMapComboBox.Items.Add(visayasRegionSixToEight[0, i]);
                    }
                }

            }
            if (island == "Mindanao")
            {
                regionComboBox.Items.Clear();
                regionMapComboBox.Items.Clear();
                dimension = mindanaoRegions.GetLength(1);
                for (int i = 0; i < dimension; i++)
                {
                    if (mindanaoRegions[0, i] != string.Empty)
                    {
                        regionComboBox.Items.Add(mindanaoRegions[0, i]);
                        regionMapComboBox.Items.Add(mindanaoRegions[0, i]);
                    }
                }
            }
        }
        // lagyan mo laman province
        public void populateProvince(string region)
        {
            int dimension = 0;
            // buonng luzon
            if (region == "Region I")
            {
                dimension = luzonRegionOneToEight.GetLength(0); 
                for (int i = 0; i <dimension;i++ )
                {
                    if (luzonRegionOneToEight[1,i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(luzonRegionOneToEight[1, i]);
                        provinceMapComboBox.Items.Add(luzonRegionOneToEight[1, i]);
                        
                    }
                }
            }
            if (region == "Region II")
            {
                dimension = luzonRegionOneToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (luzonRegionOneToEight[2, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(luzonRegionOneToEight[2, i]);
                        provinceMapComboBox.Items.Add(luzonRegionOneToEight[2, i]);
                        
                    }
                }
            }
            if (region == "Region III")
            {
                dimension = luzonRegionOneToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (luzonRegionOneToEight[3, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(luzonRegionOneToEight[3, i]);
                        provinceMapComboBox.Items.Add(luzonRegionOneToEight[3, i]);
                        
                    }
                }
            }

            if (region == "Region IV-A")
            {
                dimension = luzonRegionOneToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (luzonRegionOneToEight[4, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(luzonRegionOneToEight[4, i]);
                        provinceMapComboBox.Items.Add(luzonRegionOneToEight[4, i]);
                       
                    }
                }
            }
            if (region == "Region IV-B")
            {
                dimension = luzonRegionOneToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (luzonRegionOneToEight[5, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(luzonRegionOneToEight[5, i]);
                        provinceMapComboBox.Items.Add(luzonRegionOneToEight[5, i]);
                        

                    }
                }
            }
            if (region == "Region V")
            {
                dimension = luzonRegionOneToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (luzonRegionOneToEight[6, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(luzonRegionOneToEight[6, i]);
                        provinceMapComboBox.Items.Add(luzonRegionOneToEight[6, i]);
                        
                    }
                }
            }
            if (region == "Cordillera Administrative Region")
            {
                dimension = luzonRegionOneToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (luzonRegionOneToEight[7, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(luzonRegionOneToEight[7, i]);
                        provinceMapComboBox.Items.Add(luzonRegionOneToEight[7, i]);
                        

                    }
                }
            }
            if (region == "NCR")
            {
                for (int i = 0; i <ncrCity.Length;i++)
                {
                    provinceComboBox.Items.Add(ncrCity[i]);
                    provinceMapComboBox.Items.Add(ncrCity[i]);
                }
            }


            // end ng luzon
            // start ng visayas
            if (region == "Region VI")
            {
                dimension = visayasRegionSixToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (visayasRegionSixToEight[1, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(visayasRegionSixToEight[1, i]);
                        provinceMapComboBox.Items.Add(visayasRegionSixToEight[1, i]);
                        
                    }
                }
            }
            if (region == "Region VII")
            {
                dimension = visayasRegionSixToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (visayasRegionSixToEight[2, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(visayasRegionSixToEight[2, i]);
                        provinceMapComboBox.Items.Add(visayasRegionSixToEight[2, i]);
                        
                    }
                }
            }
            if (region == "Region VIII")
            {
                dimension = visayasRegionSixToEight.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (visayasRegionSixToEight[3, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(visayasRegionSixToEight[3, i]);
                        provinceMapComboBox.Items.Add(visayasRegionSixToEight[3, i]);
                        
                    }
                }
            }
            // end ng visayas
            // start ng sa mindanao
            // length of column kinukuha kasi 6 column 7 rows e column long kailangan
            if (region == "Region IX")
            {
                dimension = mindanaoRegions.GetLength(1);
                for (int i = 0; i < dimension; i++)
                {
                    if (mindanaoRegions[1, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(mindanaoRegions[1, i]);
                        provinceMapComboBox.Items.Add(mindanaoRegions[1, i]);
                        

                    }
                }
            }
            if (region == "Region X")
            {
                dimension = mindanaoRegions.GetLength(1);
                for (int i = 0; i < dimension; i++)
                {
                    if (mindanaoRegions[2, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(mindanaoRegions[2, i]);
                        provinceMapComboBox.Items.Add(mindanaoRegions[2, i]);
                        
                    }
                }
            }
            if (region == "Region XI")
            {
                dimension = mindanaoRegions.GetLength(1);
                for (int i = 0; i < dimension; i++)
                {
                    if (mindanaoRegions[3, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(mindanaoRegions[3, i]);
                        provinceMapComboBox.Items.Add(mindanaoRegions[3, i]);
                        

                    }
                }
            }
            if (region == "Region XII")
            {
                dimension = mindanaoRegions.GetLength(1);
                for (int i = 0; i < dimension; i++)
                {
                    if (mindanaoRegions[4, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(mindanaoRegions[4, i]);
                        provinceMapComboBox.Items.Add(mindanaoRegions[4, i]);
                       

                    }
                }
            }
            if (region == "Region XIII")
            {
                dimension = visayasRegionSixToEight.GetLength(1);
                for (int i = 0; i < dimension; i++)
                {
                    if (mindanaoRegions[5, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(mindanaoRegions[5, i]);
                        provinceMapComboBox.Items.Add(mindanaoRegions[5, i]);
                       

                    }
                }
            }
            if (region == "BARMM")
            {
                dimension = mindanaoRegions.GetLength(0);
                for (int i = 0; i < dimension; i++)
                {
                    if (mindanaoRegions[6, i] != string.Empty)
                    {
                        provinceComboBox.Items.Add(mindanaoRegions[6, i]);
                        provinceMapComboBox.Items.Add(mindanaoRegions[6, i]);
                      
                    }
                }
            }


        }
        private void Mapa_ni_Tiquia_Load(object sender, EventArgs e)
        {
            hideMap();
            populateIsland();
            FormBorderStyle = FormBorderStyle.None;
          //  WindowState = FormWindowState.Maximized;
            totalCASE += totalAddedCase();
            totalCases.Text = totalCASE.ToString();
            
           
        }

        private void islandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedIsland = islandComboBox.GetItemText(islandComboBox.SelectedItem);
           
            populateRegions(selectedIsland);
            provinceComboBox.Text = string.Empty;

        }

     

        private void regionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            string selectedRegion = regionComboBox.GetItemText(regionComboBox.SelectedItem);
            provinceComboBox.Items.Clear();
            populateProvince(selectedRegion);
        }

        private void islandComboBox_DropDown(object sender, EventArgs e)
        {
            provinceComboBox.SelectedIndex = -1;
            regionComboBox.SelectedIndex = -1;
            caseInputTextBox.Text = string.Empty;
            
        }

        private void caseInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool mayLamanIslandRegionAtProvince = islandComboBox.Text != string.Empty && regionComboBox.Text != string.Empty && provinceComboBox.Text != string.Empty;
            if (e.KeyCode == Keys.Enter && mayLamanIslandRegionAtProvince)
            {
                int a = int.Parse(caseInputTextBox.Text);
                totalCASE += a;
                totalCases.Text = totalCASE.ToString();
                MessageBox.Show("Added Case");
                string[] addedCase = { regionComboBox.Text, ",", provinceComboBox.Text.Replace(" City",""), ",", caseInputTextBox.Text };
                StreamWriter addUser = new StreamWriter(@"C:\Total-Cases.txt", true);
                addUser.WriteLine();
                for (int i = 0; i < addedCase.Length; i++)
                {
                    addUser.Write(addedCase[i]);
                }
                addUser.Close();
                islandComboBox.Text = regionComboBox.Text = provinceComboBox.Text = caseInputTextBox.Text = string.Empty;
                islandComboBox.Focus();
                islandComboBox.SelectedIndex = -1;
                regionComboBox.SelectedIndex = -1;
                provinceComboBox.SelectedIndex = -1;
             
            }
         
        }

        private void luzonButton_Click(object sender, EventArgs e)
        {
            
            showMap();
            string island = currentIsland.Text = "Luzon";
            emptyRegionProvince();
            populateRegions(island);
            panelOfImage.Visible = false;
            mapShadow.Visible = false;

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            hideMap();
            islandComboBox.SelectedIndex = -1;
            regionComboBox.SelectedIndex = -1;
            provinceComboBox.SelectedIndex = -1;
            caseInputTextBox.Text = string.Empty;
            islandComboBox.Focus();
        }

        private void backMap_Click(object sender, EventArgs e)
        {
            hideMap();
            islandComboBox.SelectedIndex = -1;
            regionComboBox.SelectedIndex = -1;
            provinceComboBox.SelectedIndex = -1;
            caseInputTextBox.Text = string.Empty;
            islandComboBox.Focus();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            showMap();
            string island = currentIsland.Text = "Visayas";
            emptyRegionProvince();
            populateRegions(island);
            panelOfImage.Visible = false;
            mapShadow.Visible = false;
        }

        private void regionMapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRegion = regionMapComboBox.GetItemText(regionMapComboBox.SelectedItem);
            provinceMapComboBox.Items.Clear();
            populateProvince(selectedRegion);
        }

     

        private void regionMapComboBox_DropDown(object sender, EventArgs e)
        {
            panelOfImage.Visible = false;
            mapShadow.Visible = false;
            provinceMapComboBox.SelectedIndex = -1;
            
           
        }

        private void provinceMapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (regionMapComboBox.Text != string.Empty && provinceMapComboBox.Text != string.Empty)
            {
                panelOfImage.Visible = true;
                mapShadow.Visible = true;
                string province= provinceMapComboBox.GetItemText(provinceMapComboBox.SelectedItem);
                provinceName.Text = province;
                int sum = 0;
                getTotalCase(province, sum);
                
            }
        }

        private void mindanao_Click(object sender, EventArgs e)
        {
            
            showMap();
            string selectedIsland = currentIsland.Text = "Mindanao";
            emptyRegionProvince();
            populateRegions(selectedIsland);
            panelOfImage.Visible = false;
            mapShadow.Visible = false;
        }

       

        private void provinceMapComboBox_DropDown(object sender, EventArgs e)
        {
            provinceMapComboBox.Text = string.Empty;
            provinceMapComboBox.SelectedIndex = -1;
            panelOfImage.Visible = false;
            mapShadow.Visible = false;
        }

      

        private void minimize_Click(object sender, EventArgs e)
        {
            this.Width = 550;
            this.Height = 370;
            minimize.Visible = false;
            maximize.Visible = true;
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            this.Width = 1290;
            this.Height = 770;
            minimize.Visible = true;
            maximize.Visible = false;
        }

        private void hide_Click(object sender, EventArgs e)
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

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void map_Click(object sender, EventArgs e)
        {
            Mapa_ni_Tiquia mapsForm = new Mapa_ni_Tiquia();
            mapsForm.Show();
        }

        private void casess_Click(object sender, EventArgs e)
        {
            Cases casesForm = new Cases();
            casesForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tests testForm = new Tests();
            testForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Equipments equipmentsForm = new Equipments();
            equipmentsForm.Show();
        }

      
        private void extend1_Click(object sender, EventArgs e)
        {
            panel16.Visible = true;
            map.Visible = true;
            casess.Visible = true;
            pictureBox3.Visible = true;
            pictureBox2.Visible = true;
           // label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            extend2.Visible = true;
            extend1.Visible = false;
        }

        private void extend2_Click(object sender, EventArgs e)
        {
            panel16.Visible = false;
            map.Visible = false;
            casess.Visible = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = false;
           // label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            extend2.Visible = false;
            extend1.Visible = true;
        }

      
    }
}
