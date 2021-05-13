using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.IO.Compression;

namespace StudJournal
{
    [Serializable]
    public partial class Form1 : Form
    {
        //tab1 vars
        public List<Discipline> disciplines = new List<Discipline>();
        public string[] bells = { "9:00", "10:45", "13:00", "14:45" };
        //tab2 vars
        public List<Discipline> disciplinesT2 = new List<Discipline>();
        public string[] bellsT2 = { "9:00", "10:45", "13:00", "14:45" };

        //init
        public Form1()
        {
            InitializeComponent();
            readSer();
            drawDataGrid();
            drawDataGridTab2();
        }
        //tab1 buttons
        private void button1_Click(object sender, EventArgs e)
        {
            addNewDiscipline f = new addNewDiscipline(disciplines, this);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editDiscipline edisc = new editDiscipline(disciplines, this);
            edisc.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            editBells ebells = new editBells(bells, this);
            ebells.Show();
        }

        //tab1 setters

        private void setDisc(List<Discipline> disc)
        {
            disciplines = disc;
            drawDataGrid();
        }
        private void setBells(string[] bells)
        {
            this.bells = bells;
            drawDataGrid();
        }
        private void delB_Click(object sender, EventArgs e)
        {
            delElement dle = new delElement(disciplines, this);
            dle.Show();
        }

        //tab2 buttons
        private void button4_Click(object sender, EventArgs e)
        {
            addNewDiscipline f = new addNewDiscipline(disciplinesT2, this);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            editDiscipline edisc = new editDiscipline(disciplinesT2, this);
            edisc.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            editBells ebells = new editBells(bellsT2, this);
            ebells.Show();
        }
        private void delBT2_Click(object sender, EventArgs e)
        {
            delElement dle = new delElement(disciplines, this);
            dle.Show();
        }
        //tab2 setters
        private void setDiscTab2(List<Discipline> disc)
        {
            disciplinesT2 = disc;
            drawDataGridTab2();
        }
        private void setBellsTab2(string[] bells)
        {
            this.bellsT2 = bells;
            drawDataGridTab2();
        }

        //tab1 draw
        public void drawDataGrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows.Add();
            }
            for (int i = 0; i < disciplines.Count; i++)
            {
                int k = disciplines[i].Lesson;
                int j = -1;
                switch (disciplines[i].DayWeek)
                {
                    case DayOfWeek.Monday:
                        j = 0;
                        break;
                    case DayOfWeek.Tuesday:
                        j = 1;
                        break;
                    case DayOfWeek.Wednesday:
                        j = 2;
                        break;
                    case DayOfWeek.Thursday:
                        j = 3;
                        break;
                    case DayOfWeek.Friday:
                        j = 4;
                        break;
                }
                dataGridView1[j + 1, k - 1].Value = disciplines[i].ToString();
            }
            for (int i = 0; i < 4; i++)
            {
                dataGridView1[0, i].Value = bells[i];
            }
        }
        //tab2 draw
        public void drawDataGridTab2()
        {
            dataGridView2.Rows.Clear();
            for (int i = 0; i < 4; i++)
            {
                dataGridView2.Rows.Add();
            }
            for (int i = 0; i < disciplinesT2.Count; i++)
            {
                int k = disciplinesT2[i].Lesson;
                int j = -1;
                switch (disciplinesT2[i].DayWeek)
                {
                    case DayOfWeek.Monday:
                        j = 0;
                        break;
                    case DayOfWeek.Tuesday:
                        j = 1;
                        break;
                    case DayOfWeek.Wednesday:
                        j = 2;
                        break;
                    case DayOfWeek.Thursday:
                        j = 3;
                        break;
                    case DayOfWeek.Friday:
                        j = 4;
                        break;
                }
                dataGridView2[j + 1, k - 1].Value = disciplinesT2[i].ToString();
            }
            for (int i = 0; i < 4; i++)
            {
                dataGridView2[0, i].Value = bellsT2[i];
            }
        }

        public void setDiscip(List<Discipline> disc)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                setDisc(disc);
            }
            else
            {
                setDiscTab2(disc);
            }
        }

        public void setBell(string[] bells)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                setBells(bells);
            }
            else
            {
                setBellsTab2(bells);
            }
        }

        //changeTab
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                button1.Click -= button4_Click;
                button1.Click += button1_Click;
                button2.Click -= button5_Click;
                button2.Click += button2_Click;
                button3.Click -= button6_Click;
                button3.Click += button3_Click;
                delB.Click -= delBT2_Click;
                delB.Click += delB_Click;
            }
            else
            {
                button1.Click -= button1_Click;
                button1.Click += button4_Click;
                button2.Click -= button2_Click;
                button2.Click += button5_Click;
                button3.Click -= button3_Click;
                button3.Click += button6_Click;
                delB.Click -= delB_Click;
                delB.Click += delBT2_Click;
            }
        }

        //serialize
        private void save_Click(object sender, EventArgs e)
        {
            //tab1 discipl
            string output = JsonSerializer.Serialize<List<Discipline>>(disciplines);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path += "\\MyStudJournal";
            StreamWriter f;
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
                f = new StreamWriter(path + "\\tab1Disciplines.json");
                f.Write(output);
                f.Close();
            }
            else
            {
                f = new StreamWriter(path + "\\tab1Disciplines.json");
                f.Write(output);
                f.Close();
            }
            output = JsonSerializer.Serialize<List<Discipline>>(disciplinesT2);
            f = new StreamWriter(path + "\\tab2Disciplines.json");
            f.Write(output);
            f.Close();

            output = JsonSerializer.Serialize<string[]>(bells);
            f = new StreamWriter(path + "\\tab1Bells.json");
            f.Write(output);
            f.Close();

            output = JsonSerializer.Serialize<string[]>(bellsT2);
            f = new StreamWriter(path + "\\tab2Bells.json");
            f.Write(output);
            f.Close();
        }

        //deserialize
        private void readSer()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path += "\\MyStudJournal";
            if (File.Exists(path + "\\tab1Disciplines.json"))
            {
                try
                {
                    StreamReader f = new StreamReader(path+ "\\tab1Disciplines.json");
                    string input = f.ReadToEnd();
                    disciplines = JsonSerializer.Deserialize<List<Discipline>>(input);
                    f.Close();
                }
                catch (UnauthorizedAccessException){}
                catch (IOException){}
                catch (ArgumentException){}
                catch (InvalidOperationException){}
            }
            if (File.Exists(path + "\\tab2Disciplines.json"))
            {
                try
                {
                    StreamReader f = new StreamReader(path + "\\tab2Disciplines.json");
                    string input = f.ReadToEnd();
                    disciplinesT2 = JsonSerializer.Deserialize<List<Discipline>>(input);
                    f.Close();
                }
                catch (UnauthorizedAccessException) { }
                catch (IOException) { }
                catch (ArgumentException) { }
                catch (InvalidOperationException) { }
            }
            if (File.Exists(path + "\\tab1Bells.json"))
            {
                try
                {
                    StreamReader f = new StreamReader(path + "\\tab1Bells.json");
                    string input = f.ReadToEnd();
                    bells = JsonSerializer.Deserialize<string[]>(input);
                    f.Close();
                }
                catch (UnauthorizedAccessException) { }
                catch (IOException) { }
                catch (ArgumentException) { }
                catch (InvalidOperationException) { }
            }
            if (File.Exists(path + "\\tab2Bells.json"))
            {
                try
                {
                    StreamReader f = new StreamReader(path + "\\tab2Bells.json");
                    string input = f.ReadToEnd();
                    bellsT2 = JsonSerializer.Deserialize<string[]>(input);
                    f.Close();
                }
                catch (UnauthorizedAccessException) { }
                catch (IOException) { }
                catch (ArgumentException) { }
                catch (InvalidOperationException) { }
            }
            drawDataGrid();
            drawDataGridTab2();
        }

        private void export_Click(object sender, EventArgs e)
        {
            save_Click(sender, e);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\MyStudJournal";
            string zipPath;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Zip files(*.zip)|*.zip|All files(*.*)|*.*";
            saveFileDialog.Title = "Экспорт";
            DialogResult dr = saveFileDialog.ShowDialog();
            zipPath = saveFileDialog.FileName;
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.CreatePrompt = false;
            if (dr == DialogResult.OK&&!File.Exists(zipPath))
            {
                
                ZipFile.CreateFromDirectory(path, zipPath, CompressionLevel.Optimal, true);
            }
            else if (dr == DialogResult.OK)
            {
                File.Delete(zipPath);
                ZipFile.CreateFromDirectory(path, zipPath, CompressionLevel.Optimal, true);
            }
        }

        private void import_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string zipPath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zip files(*.zip)|*.zip|All files(*.*)|*.*";
            ofd.Title = "Импорт";
            DialogResult dr = ofd.ShowDialog();
            zipPath = ofd.FileName;
            if (dr == DialogResult.OK)
            {
                try
                {
                    ZipFile.ExtractToDirectory(zipPath, path);
                }
                catch(IOException)
                {
                    Directory.Delete(path + "\\MyStudJournal", true);
                    ZipFile.ExtractToDirectory(zipPath, path);
                }
            }
            readSer();
            drawDataGrid();
            drawDataGridTab2();
        }

        
    }
}
